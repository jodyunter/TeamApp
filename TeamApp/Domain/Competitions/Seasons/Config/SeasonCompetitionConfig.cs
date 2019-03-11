using System;
using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain.Schedules;

namespace TeamApp.Domain.Competitions.Seasons.Config
{
    //this is the configuration setup for seasons
    public class SeasonCompetitionConfig:CompetitionConfig
    {        
        public virtual IList<SeasonTeamRule> TeamRules { get; set; }
        public virtual IList<SeasonDivisionRule> DivisionRules { get; set; } //at some point in the future our division rules may need to reference parent competitions

        public virtual IList<SeasonScheduleRule> ScheduleRules { get; set; }

        public SeasonCompetitionConfig() { }
        public SeasonCompetitionConfig(string name, League league, int? startingDay, int? firstYear, int? lastYear, int order, List<SeasonTeamRule> teamRules, List<SeasonDivisionRule> divisionRules, GameRules gameRules, List<SeasonScheduleRule> scheduleRules, List<CompetitionConfig> parents)
            : base(name, league, order, startingDay, gameRules, parents, firstYear, lastYear)
        {            
            TeamRules = teamRules;
            DivisionRules = divisionRules;
            ScheduleRules = scheduleRules;
        }


        public virtual List<string> GetTeamsInDivision(string divisionName)
        {
            var list = new List<string>();

            list.AddRange(GetTeamsAssignedToDivision(divisionName));

            var children = GetChildDivisionNames(divisionName);

            children.ToList().ForEach(childDivisionName =>
            {
                list.AddRange(GetTeamsInDivision(childDivisionName));
            });

            return list;
        }
        
        private IEnumerable<string> GetChildDivisionNames(string parentDivision)
        {
            return DivisionRules.Where(r => r.ParentName != null && r.ParentName.Equals(parentDivision)).Select(r => r.DivisionName);
        }

        private List<string> GetTeamsAssignedToDivision(string divisionName)
        {

            var teams = new List<string>();

            TeamRules.ToList().Where(tr => tr.Division.Equals(divisionName)).ToList().ForEach(rule =>
            {
                if (rule.Division.Equals(divisionName))
                {
                    teams.Add(rule.Team.Name + " " + rule.Team.NickName);
                }
            });

            return teams;
        }

        public virtual bool IsTeamInDivision(string teamName, string divisionName)
        {
            return GetTeamsInDivision(divisionName).Where(s => s.Equals(teamName)).FirstOrDefault() != null;
        }

        public override Competition CreateCompetitionDetails(int day, int year, IList<Competition> parents)
        {
            var season = new Season(this, Name, year, null, null, null, null, false, false, day, null);

            //setup divisions
            var divisions = new Dictionary<string, SeasonDivision>();
            var teams = new List<SingleYearTeam>();

            ProcessDivisionRules(season, divisions);
            ProcessTeamRules(season, divisions, teams);

            season.Divisions = divisions.Values.ToList();
            season.Teams = teams;

            CreateSeasonSchedule(season);

            season.StartDay = day;
            season.Started = true;

            return season;
        }

        //todo properly test these with years
        public virtual void ProcessDivisionRules(Season season, Dictionary<string, SeasonDivision> seasonDivisions)
        {
            //first create all the divisions
            DivisionRules.Where(dr => dr.IsActive(season.Year)).ToList().ForEach(rule =>
            {
                seasonDivisions.Add(rule.DivisionName, new SeasonDivision(season, null, season.Year, rule.DivisionName, rule.Level, rule.Ordering, null));
            });

            //now setup parent divisions relationships
            DivisionRules.Where(dr => dr.IsActive(season.Year)).ToList().ForEach(rule =>
            {
                if (rule.ParentName != null)
                {
                    seasonDivisions[rule.DivisionName].ParentDivision = seasonDivisions[rule.ParentName];
                }
            });

        }

        //todo properly test these with years
        public virtual void ProcessTeamRules(Season season, Dictionary<string, SeasonDivision> seasonDivisions, List<SingleYearTeam> teams)
        {
            TeamRules.Where(tr => tr.IsActive(season.Year)).ToList().ForEach(rule =>
            {                
                var team = rule.Team;
                var seasonDivision = seasonDivisions[rule.Division];
                var newTeam = new SeasonTeam(season, team, team.Name, team.NickName, team.ShortName, team.Skill, team.Owner, season.Year, null, seasonDivision);                

                seasonDivision.AddTeam(newTeam);
                teams.Add(newTeam);

            });
        }

        //todo properly test these with years
        public virtual void CreateSeasonSchedule(Season season)
        {
            int day = 1;

            season.Schedule = new Schedule();

            ScheduleRules.Where(sr => sr.IsActive(season.Year)).ToList().ForEach(rule =>
            {                
                //rule about duplicating teams and divisions?
                var homeTeams = GetTeams(season, rule.HomeTeam, rule.HomeDivisionRule);
                var awayTeams = GetTeams(season, rule.AwayTeam, rule.AwayDivisionRule);

                var nextSchedule = Scheduler.CreateGames(
                    season,
                    season.Year,
                    1,
                    day,
                    homeTeams.Select(st => st.Parent).ToList(),
                    (awayTeams == null || awayTeams.Count == 0) ? null : awayTeams.Select(st => st.Parent).ToList(),
                    rule.Iterations,
                    rule.HomeAndAway,
                    season.CompetitionConfig.GameRules);

                day = Scheduler.MergeSchedulesTryToCompress(season.Schedule, nextSchedule) + 1;
            });

        }

        public virtual List<SingleYearTeam> GetTeams(Season season, Team team, SeasonDivisionRule divisionRule)
        {
            var teams = new List<SingleYearTeam>();

            if (team != null)
            {
                teams.Add(season.Teams.Where(t => t.Parent.Id == team.Id).First());
            }
            else if (divisionRule != null)
            {
                teams.AddRange(season.GetAllTeamsInDivision(season.GetDivisionByName(divisionRule.DivisionName)));
            }
            else
            {
                return null;
            }

            return teams;
        }

    }
}
