using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain.Competitions.Seasons;
using TeamApp.Domain.Schedules;

namespace TeamApp.Domain.Competitions.Config.Seasons
{
    //this is the configuration setup for seasons
    public class SeasonCompetitionConfig:CompetitionConfig
    {        
        public virtual IList<SeasonTeamRule> TeamRules { get; set; }
        public virtual IList<SeasonDivisionRule> DivisionRules { get; set; } //at some point in the future our division rules may need to reference parent competitions

        public virtual IList<SeasonScheduleRule> ScheduleRules { get; set; }

        public SeasonCompetitionConfig() { }
        public SeasonCompetitionConfig(string name, League league, int? startingDay, int? firstYear, int? lastYear, int order, List<SeasonTeamRule> teamRules, List<SeasonDivisionRule> divisionRules, GameRules gameRules, List<SeasonScheduleRule> scheduleRules, List<CompetitionConfig> parents, List<CompetitionConfigFinalRankingRule> finalRankingRules)
            : base(name, league, order, startingDay, gameRules, parents, finalRankingRules, "Final Standings", firstYear, lastYear)
        {            
            TeamRules = teamRules;
            DivisionRules = divisionRules;
            ScheduleRules = scheduleRules;
        }


        public virtual List<SeasonTeamRule> GetTeamsInDivision(string divisionName)
        {
            var list = new List<SeasonTeamRule>();

            var divisionRule = DivisionRules.Where(dr => dr.DivisionName.Equals(divisionName)).FirstOrDefault();
            var parent = divisionRule;
            
            if (divisionRule.Teams != null)
                list.AddRange(divisionRule.Teams);

            GetChildDivisions(divisionRule).ForEach(dr =>
            {
                if (dr.Teams != null)
                    list.AddRange(dr.Teams);
            });

            return list;
        }         
        
        public virtual List<SeasonDivisionRule> GetChildDivisions(SeasonDivisionRule parentRule)
        {
            var result = new List<SeasonDivisionRule>();

            DivisionRules.Where(dr => dr.Parent != null && dr.Parent.DivisionName == parentRule.DivisionName).ToList().ForEach(division =>
            {
                result.Add(division);
                result.AddRange(GetChildDivisions(division));
            });

            return result;
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
                if (rule.Parent != null)
                {
                    seasonDivisions[rule.DivisionName].ParentDivision = seasonDivisions[rule.Parent.DivisionName];
                }
            });

        }

        //todo properly test these with years
        public virtual void ProcessTeamRules(Season season, Dictionary<string, SeasonDivision> seasonDivisions, List<SingleYearTeam> teams)
        {
            TeamRules.Where(tr => tr.IsActive(season.Year)).ToList().ForEach(rule =>
            {                
                var team = rule.Team;
                var seasonDivision = seasonDivisions[rule.Division.DivisionName];
                var newTeam = (SeasonTeam)CreateCompetitionTeam(season, team);

                newTeam.Division = seasonDivision;
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

        public override SingleYearTeam CreateCompetitionTeam(Competition season, Team parent)
        {
            return new SeasonTeam(season, parent, season.Year, new SeasonTeamStats(), null);
        }
        
    }
}
