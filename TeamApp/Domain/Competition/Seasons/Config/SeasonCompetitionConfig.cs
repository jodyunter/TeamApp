using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TeamApp.Domain.Schedules;

namespace TeamApp.Domain.Competition.Seasons.Config
{
    //this is the configuration setup for seasons
    public class SeasonCompetitionConfig:CompetitionConfig
    {        
        public virtual IList<SeasonTeamRule> TeamRules { get; set; }
        public virtual IList<SeasonDivisionRule> DivisionRules { get; set; } //at some point in the future our division rules may need to reference parent competitions

        public virtual IList<SeasonScheduleRule> ScheduleRules { get; set; }

        public SeasonCompetitionConfig() { }
        public SeasonCompetitionConfig(string name, League league, int? firstYear, int? lastYear, int order, int startDay, List<SeasonTeamRule> teamRules, List<SeasonDivisionRule> divisionRules, GameRules gameRules, List<SeasonScheduleRule> scheduleRules, List<CompetitionConfig> parents)
            : base(name, league, order, gameRules, parents, firstYear, lastYear)
        {            
            TeamRules = teamRules;
            DivisionRules = divisionRules;
            ScheduleRules = scheduleRules;
        }


        public virtual List<string> GetTeamsInDivision(string divisionName)
        {
            var list = new List<string>();

            return GetTeamsInDivision(divisionName, list);
        }

        private List<string> GetTeamsInDivision(string divisionName, List<string> teams)
        {
            TeamRules.ToList().ForEach(rule =>
            {
                if (rule.Division.Equals(divisionName))
                {
                    teams.Add(rule.Team.Name);
                }
            });

            DivisionRules.Where(r => r.ParentName != null && r.ParentName.Equals(divisionName)).ToList().ForEach(rule =>
            {
                teams.AddRange(GetTeamsInDivision(rule.DivisionName, teams));
            });

            return teams;
        }

        public virtual bool IsTeamInDivision(string teamName, string divisionName)
        {
            return GetTeamsInDivision(divisionName).Where(s => s.Equals(teamName)).FirstOrDefault() != null;
        }

        public override ICompetition CreateCompetition(int year, List<ICompetition> Parents)
        {
            var season = new Season(this, year);

            //setup divisions
            var divisions = new Dictionary<string, SeasonDivision>();
            var teams = new Dictionary<string, ISingleYearTeam>();

            ProcessDivisionRules(season, divisions);
            ProcessTeamRules(season, divisions, teams);

            season.Divisions = divisions.Values.ToList();
            season.Teams = teams.Values.ToList();

            CreateSeasonSchedule(season);

            return season;
        }

        public virtual void ProcessDivisionRules(Season season, Dictionary<string, SeasonDivision> seasonDivisions)
        {
            //first create all the divisions
            DivisionRules.ToList().ForEach(rule =>
            {
                seasonDivisions.Add(rule.DivisionName, new SeasonDivision(season, null, season.Year, rule.DivisionName, rule.Level, rule.Ordering, null));
            });

            //now setup parent divisions relationships
            DivisionRules.ToList().ForEach(rule =>
            {
                if (rule.ParentName != null)
                {
                    seasonDivisions[rule.DivisionName].ParentDivision = seasonDivisions[rule.ParentName];
                }
            });

        }

        public virtual void ProcessTeamRules(Season season, Dictionary<string, SeasonDivision> seasonDivisions, Dictionary<string, ISingleYearTeam> teams)
        {
            TeamRules.ToList().ForEach(rule =>
            {                
                var team = rule.Team;
                var seasonDivision = seasonDivisions[rule.Division];
                var newTeam = new SeasonTeam(team.Name, team.NickName, team.ShortName, team.Skill, team, seasonDivision.Season, seasonDivision, null, team.Owner, seasonDivision.Season.Year);
                newTeam.Stats = new SeasonTeamStats(newTeam);

                seasonDivision.AddTeam(newTeam);
                teams.Add(newTeam.Name, newTeam);

            });
        }

        public virtual void CreateSeasonSchedule(Season season)
        {
            int day = 1;

            season.Schedule = new Schedule();

            ScheduleRules.ToList().ForEach(rule =>
            {
                if (rule.HomeTeamType == rule.AwayTeamType && rule.HomeTeamValue == rule.AwayTeamValue)
                {
                    throw new ApplicationException("Can't have the same home and away types and values");
                }
                var homeTeams = GetTeams(season, rule.HomeTeamType, rule.HomeTeamValue);
                var awayTeams = GetTeams(season, rule.AwayTeamType, rule.AwayTeamValue);

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

        public virtual List<ISingleYearTeam> GetTeams(Season season, int teamType, string teamValue)
        {
            var teams = new List<ISingleYearTeam>();

            switch (teamType)
            {
                case SeasonScheduleRule.DIVISION_TYPE:
                    teams.AddRange(season.GetAllTeamsInDivision(season.GetDivisionByName(teamValue)));
                    break;
                case SeasonScheduleRule.TEAM_TYPE:
                    teams.Add(season.Teams.Where(t => t.Name.Equals(teamValue)).First());
                    break;
                case SeasonScheduleRule.NONE:
                    return null;
            }

            return teams;
        }
    }
}
