using System;
using System.Collections.Generic;
using TeamApp.Domain;
using TeamApp.Domain.Competition;
using TeamApp.Domain.Competition.Playoffs;
using TeamApp.Domain.Competition.Playoffs.Config;
using TeamApp.Domain.Competition.Seasons.Config;
using static TeamApp.Domain.Competition.Playoffs.Config.PlayoffSeriesRule;
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
                {NORTHEAST, new List<string>() { "Toronto", "Montreal", "Ottawa", "Pittsburgh","Nashville" } },
                {ATLANTIC, new List<string>() {"Boston", "New York", "Philadelphia", "Buffalo"} },
                {WEST, new List<string>(){ "Calgary", "Vancouver", "Edmonton", "Los Angelas", "San Jose", "Seattle" } },
                {CENTRAL, new List<string>(){ "Chicago", "Dallas", "Winnipeg", "Minnesota", "Colorado", "Detroit" } }

            };

            var league = new League(NHL);

            var objects = new Dictionary<string, object>();
           
            var teamMap = new Dictionary<string, Team>();

            var gameRules = new GameRules("Season Rules", true, 3, 1, 7, 6);

            SeasonCompetitionConfig competition = new SeasonCompetitionConfig("My Season", league, 1, null, 1, 1, new List<SeasonTeamRule>(), new List<SeasonDivisionRule>(), gameRules, new List<SeasonScheduleRule>(), new List<ICompetitionConfig>());

            

            competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.DIVISION_TYPE, NHL, SeasonScheduleRule.NONE, null, 1, true, 1, null)); //40
            competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.DIVISION_TYPE, WEST, SeasonScheduleRule.DIVISION_TYPE, CENTRAL, 1, true, 1, null));            
            competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.DIVISION_TYPE, WEST, SeasonScheduleRule.NONE, null, 3, true, 1, null));
            competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.DIVISION_TYPE, CENTRAL, SeasonScheduleRule.NONE, null, 3, true, 1, null));
            competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.DIVISION_TYPE, EAST, SeasonScheduleRule.NONE, null, 2, true, 1, null)); //32
            competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.DIVISION_TYPE, NORTHEAST, SeasonScheduleRule.NONE, null, 1, true, 1, null)); 
            competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.DIVISION_TYPE, ATLANTIC, SeasonScheduleRule.NONE, null, 1, true, 1, null));
            
            competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.TEAM_TYPE, "Toronto", SeasonScheduleRule.TEAM_TYPE, "Montreal", 1, false, 1, null)); //32
            competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.TEAM_TYPE, "Montreal", SeasonScheduleRule.TEAM_TYPE, "Ottawa", 1, false, 1, null)); //32
            competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.TEAM_TYPE, "Ottawa", SeasonScheduleRule.TEAM_TYPE, "Pittsburgh", 1, false, 1, null)); //32
            competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.TEAM_TYPE, "Pittsburgh", SeasonScheduleRule.TEAM_TYPE, "Nashville", 1, false, 1, null)); //32
            competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.TEAM_TYPE, "Nashville", SeasonScheduleRule.TEAM_TYPE, "Toronto", 1, false, 1, null)); //32
            competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.TEAM_TYPE, "Boston", SeasonScheduleRule.TEAM_TYPE, "New York", 1, false, 1, null)); //32
            competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.TEAM_TYPE, "Boston", SeasonScheduleRule.TEAM_TYPE, "Philadelphia", 1, false, 1, null)); //32
            competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.TEAM_TYPE, "New York", SeasonScheduleRule.TEAM_TYPE, "Philadelphia", 1, false, 1, null)); //32
            competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.TEAM_TYPE, "New York", SeasonScheduleRule.TEAM_TYPE, "Buffalo", 1, false, 1, null)); //32
            competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.TEAM_TYPE, "Philadelphia", SeasonScheduleRule.TEAM_TYPE, "Buffalo", 1, false, 1, null)); //32
            competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.TEAM_TYPE, "Philadelphia", SeasonScheduleRule.TEAM_TYPE, "Boston", 1, false, 1, null)); //32
            competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.TEAM_TYPE, "Buffalo", SeasonScheduleRule.TEAM_TYPE, "Boston", 1, false, 1, null)); //32
            //competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.TEAM_TYPE, "Buffalo", SeasonScheduleRule.TEAM_TYPE, "New York", 1, false, 1, null)); //32            


            var seasonCompetitionList = new List<SeasonCompetitionConfig>()
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

        public static PlayoffCompetitionConfig CreateBasicPlayoffConfiguration(SeasonCompetitionConfig seasonConfig)
        {
            var gameRules = new GameRules("Playoff Rules", false, 3, 1, 7, 6);

            var rankingRules = new List<PlayoffRankingRule>()
            {
                new PlayoffRankingRule("NHL", 1,seasonConfig, "NHL", 1, 20),
                new PlayoffRankingRule("West",1,seasonConfig, "West",1, 6),
                new PlayoffRankingRule("East",1,seasonConfig, "East",1, 8),
                new PlayoffRankingRule("East",9,seasonConfig, "Central",5,5), //how do we rank two teams from two divisions into one?
                new PlayoffRankingRule("East",10,seasonConfig, "West",5,5),
                new PlayoffRankingRule("Central",1,seasonConfig,"Central",1,6),
                new PlayoffRankingRule("NorthEast",1,seasonConfig,"NorthEast",1,4),
                new PlayoffRankingRule("Atlantic",1,seasonConfig,"Atlantic",1,4)
            };

            var seriesRules = new List<PlayoffSeriesRule>()
            {
                new PlayoffSeriesRule("Series A", 1, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "West", 1, FROM_RANKING, "West", 4, 1, null, new int[] {0,0,1,1,0,1,0 }, "SF_WEST", "West", null, null),
                new PlayoffSeriesRule("Series B", 1, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "West", 2, FROM_RANKING, "West", 3, 1, null, new int[] {0,0,1,1,0,1,0 }, "SF_WEST", "West", null, null),
                new PlayoffSeriesRule("Series C", 1, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "Central", 1, FROM_RANKING, "Central", 2, 1, null, new int[] {0,0,1,1,0,1,0 }, "SF_CENTRAL", "Central", null, null),
                new PlayoffSeriesRule("Series D", 1, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "Central", 2, FROM_RANKING, "Central", 3, 1, null, new int[] {0,0,1,1,0,1,0 }, "SF_CENTRAL", "Central", null, null),
                new PlayoffSeriesRule("Series E", 1, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "NorthEast", 1, FROM_RANKING, "West", 5, 1, null, new int[] {0,0,1,1,0,1,0 }, "SF_EAST", "East", null, null),
                new PlayoffSeriesRule("Series F", 1, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "NorthEast", 2, FROM_RANKING, "NorthEast", 3, 1, null, new int[] {0,0,1,1,0,1,0 }, "SF_EAST", "East", null, null),
                new PlayoffSeriesRule("Series G", 1, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "Atlantic", 1, FROM_RANKING, "Central", 5, 1, null, new int[] {0,0,1,1,0,1,0 }, "SF_EAST", "East", null, null),
                new PlayoffSeriesRule("Series H", 1, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "Atlantic", 2, FROM_RANKING, "Atlantic", 3, 1, null, new int[] {0,0,1,1,0,1,0 }, "SF_EAST", "East", null, null),
                new PlayoffSeriesRule("Series I", 2, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "SF_WEST", 1, FROM_RANKING, "SF_CENTRAL", 2, 1, null, new int[] {0,0,1,1,0,1,0 }, "F_WEST_CENTRAL", "NHL", null, null),
                new PlayoffSeriesRule("Series J", 2, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "SF_CENTRAL", 1, FROM_RANKING, "SF_WEST", 2, 1, null, new int[] {0,0,1,1,0,1,0 }, "F_WEST_CENTRAL", "NHL", null, null),
                new PlayoffSeriesRule("Series K", 2, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "SF_EAST", 1, FROM_RANKING, "SF_EAST", 4, 1, null, new int[] {0,0,1,1,0,1,0 }, "F_EAST", "East", null, null),
                new PlayoffSeriesRule("Series L", 2, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "SF_EAST", 2, FROM_RANKING, "SF_EAST", 3, 1, null, new int[] {0,0,1,1,0,1,0 }, "F_EAST", "East", null, null),
                new PlayoffSeriesRule("Series M", 3, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "F_WEST_CENTRAL", 1, FROM_RANKING, "F_WEST_CENTRAL", 2, 1, null, new int[] {0,0,1,1,0,1,0 }, "FINAL_GROUP", "NHL", null, null),
                new PlayoffSeriesRule("Series N", 3, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "F_EAST", 1, FROM_RANKING, "F_EAST", 2, 1, null, new int[] {0,0,1,1,0,1,0 }, "FINAL_GROUP", "NHL", null, null),
                new PlayoffSeriesRule("Final", 4, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "FINAL_GROUP", 1, FROM_RANKING, "FINAL_GROUP", 2, 1, null, new int[] {0,0,1,1,0,1,0 }, null, null, null, null)
            };

            var playoffConfig = new PlayoffCompetitionConfig("My Playoff", null, 1, gameRules, 1, null, rankingRules, seriesRules, new List<ICompetitionConfig> { seasonConfig });

            return playoffConfig;


        }

        public static void CreateTeamsForDivision(SeasonCompetitionConfig competition, Dictionary<string, Team> teamMap, List<string> teamNames, string divisionName)
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
