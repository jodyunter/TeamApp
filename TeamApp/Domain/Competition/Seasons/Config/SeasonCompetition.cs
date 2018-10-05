using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TeamApp.Domain.Competition.Seasons.Config
{
    //this is the configuration setup for seasons
    public class SeasonCompetition:ICompetition
    {
        public string Name { get; set; }
        public League League { get; set; }
        public int? FirstYear { get; set; }
        public int? LastYear { get; set; }
        public int Order { get; set; }
        public int StartDay { get; set; }
        public List<SeasonTeamRule> TeamRules { get; set; }
        public List<SeasonDivisionRule> DivisionRules { get; set; }
        public SeasonGameRules GameRules { get; set; }
        public List<SeasonScheduleRule> ScheduleRules { get; set; }
        public Dictionary<string, ICompetition> Parents { get; set; }
        public SeasonCompetition(string name, League league, int? firstYear, int? lastYear, int order, int startDay, List<SeasonTeamRule> teamRules, List<SeasonDivisionRule> divisionRules, SeasonGameRules gameRules, List<SeasonScheduleRule> scheduleRules, Dictionary<string, ICompetition> parents)
        {
            Name = name;
            League = league;
            FirstYear = firstYear;
            LastYear = lastYear;
            Order = order;
            StartDay = startDay;
            TeamRules = teamRules;
            DivisionRules = divisionRules;
            GameRules = gameRules;
            GameRules.Competition = this;
            ScheduleRules = scheduleRules;
            Parents = parents;
        }


        public List<string> GetTeamsInDivision(string divisionName)
        {
            var list = new List<string>();

            return GetTeamsInDivision(divisionName, list);
        }

        private List<string> GetTeamsInDivision(string divisionName, List<string> teams)
        {
            TeamRules.ForEach(rule =>
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

        public bool IsTeamInDivision(string teamName, string divisionName)
        {
            return GetTeamsInDivision(divisionName).Where(s => s.Equals(teamName)).FirstOrDefault() != null;
        }
    }
}
