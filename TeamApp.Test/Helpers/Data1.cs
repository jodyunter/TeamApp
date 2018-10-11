using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain;
using TeamApp.Domain.Competition.Seasons.Config;

namespace TeamApp.Test.Helpers
{
    public class Data1
    {
        public static string BASIC_TEAM_MAP = "BASIC_TEAM_MAP";        
        public static string BASIC_SEASON_TEAM_RULE_LIST = "BASIC_SEASON_TEAM_RULE_LIST";
        public static string BASIC_SEASON_COMPETITION_LSIT = "BASIC_SEASON_COMPETITION_LIST";
        public static string BASIC_SEASON_DIV_RULE_LIST = "BAISC_SEASON_DIV_RULE_LIST";
        public static string BASIC_SEASON_GAME_RULES = "BASIC_SEASON_GAME_RULES";
        public static string BASIC_SEASON_SCHEDULE_RULES = "BASIC_SEASON_SCHEDULE_RULES";
        
        public static Dictionary<string, object> CreateBasicSeasonConfiguration()
        {
            var TOP = "TOP";
            var NHL = "NHL";
            var WEST = "West";
            var EAST = "East";
            var CENTRAL = "Central";
            var NORTHEAST = "NorthEast";
            var ATLANTIC = "Atlantic";                           

            var divMap = new Dictionary<string, List<string>>()
            {
                { TOP, new List<string>() { NHL } },
                { NHL, new List<string>() {EAST, WEST, CENTRAL } },
                { EAST, new List<string>() {NORTHEAST, ATLANTIC} }

            };

            var orderMap = new Dictionary<string, int[]>
            {
                { NHL, new int[] {1, 1 } },                
                {EAST, new int[] {2, 1 } },
                {WEST, new int[] {3, 1 } },
                {CENTRAL, new int[] {3, 2 } },
                {NORTHEAST, new int[] {3, 3 } },
                {ATLANTIC, new int[] {3, 4 } }
            };

            var teamNameMap = new Dictionary<string, List<string>>()
            {
                {NORTHEAST, new List<string>() { "Toronto", "Montreal", "Ottawa", "Pittsburgh" } },
                {ATLANTIC, new List<string>() {"Boston", "New York", "Philadelphia", "Buffalo"} },
                {WEST, new List<string>(){ "Calgary", "Vancouver", "Edmonton", "Los Angelas", "San Jose", "Seattle" } },
                {CENTRAL, new List<string>(){ "Chicago", "Dallas", "Winnipeg", "Minnesota", "Colorado", "Detroit" } }

            };

            var league = new League(NHL);

            var objects = new Dictionary<string, object>();
           
            var teamMap = new Dictionary<string, Team>();

            var gameRules = new SeasonGamesRules(null, 1, null, null, true, 3, 1, 7, 6);

            SeasonCompetition competition = new SeasonCompetition("My Season", league, 1, null, 1, 1, new List<SeasonTeamRule>(), new List<SeasonDivisionRule>(), gameRules, new List<SeasonScheduleRule>(), new Dictionary<string, TeamApp.Domain.Competition.CompetitionConfig>());

            

            competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.DIVISION_TYPE, NHL, SeasonScheduleRule.NONE, null, 1, true, 1, null));
            competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.DIVISION_TYPE, WEST, SeasonScheduleRule.DIVISION_TYPE, CENTRAL, 1, true, 1, null));
            competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.DIVISION_TYPE, EAST, SeasonScheduleRule.NONE, null, 3, true, 1, null));
            competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.DIVISION_TYPE, WEST, SeasonScheduleRule.NONE, null, 3, true, 1, null));
            competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.DIVISION_TYPE, CENTRAL, SeasonScheduleRule.NONE, null, 3, true, 1, null));            

            var seasonCompetitionList = new List<SeasonCompetition>()
            {
                competition   
            };


            foreach(KeyValuePair<string, List<string>> data in divMap)
            {
                data.Value.ForEach(divisionName =>
                {
                    competition.DivisionRules.Add(
                        new SeasonDivisionRule(competition, divisionName, data.Key == TOP ? null : data.Key, orderMap[divisionName][0], orderMap[divisionName][1], 1, null)
                        );

                    if (teamNameMap.ContainsKey(divisionName))
                    {
                        CreateTeamsForDivision(competition, teamMap, teamNameMap[divisionName], divisionName);
                    }
                });
 
            }

            objects.Add(BASIC_SEASON_DIV_RULE_LIST, competition.DivisionRules);
            objects.Add(BASIC_TEAM_MAP, teamMap);
            objects.Add(BASIC_SEASON_TEAM_RULE_LIST, competition.TeamRules);
            objects.Add(BASIC_SEASON_COMPETITION_LSIT, seasonCompetitionList);
            objects.Add(BASIC_SEASON_GAME_RULES, competition.GameRules);

            return objects;

        }


        public static void CreateTeamsForDivision(SeasonCompetition competition, Dictionary<string, Team> teamMap, List<string> teamNames, string divisionName)
        {            
            teamNames.ForEach(s =>
            {
                var team = new Team(s, 5, null, 1, null, true);
                var rule = new SeasonTeamRule(competition, team, divisionName, 1, null);

                competition.TeamRules.Add(rule);
                teamMap.Add(team.Name, team);
            });

        }
    }
}
