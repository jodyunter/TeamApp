﻿using System;
using System.Collections.Generic;
using TeamApp.Domain;
using TeamApp.Domain.Competition;
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
                {NORTHEAST, new List<string>() { "Toronto", "Montreal", "Ottawa", "Pittsburgh" } },
                {ATLANTIC, new List<string>() {"Boston", "New York", "Philadelphia", "Buffalo"} },
                {WEST, new List<string>(){ "Calgary", "Vancouver", "Edmonton", "Los Angelas", "San Jose", "Seattle" } },
                {CENTRAL, new List<string>(){ "Chicago", "Dallas", "Winnipeg", "Minnesota", "Colorado", "Detroit" } }

            };

            var league = new League(NHL);

            var objects = new Dictionary<string, object>();
           
            var teamMap = new Dictionary<string, Team>();

            var gameRules = new GameRules("Season Rules", true, 3, 1, 7, 6);

            SeasonCompetitionConfig competition = new SeasonCompetitionConfig("My Season", league, 1, null, 1, 1, new List<SeasonTeamRule>(), new List<SeasonDivisionRule>(), gameRules, new List<SeasonScheduleRule>(), new List<ICompetitionConfig>());

            

            competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.DIVISION_TYPE, NHL, SeasonScheduleRule.NONE, null, 1, true, 1, null));
            competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.DIVISION_TYPE, WEST, SeasonScheduleRule.DIVISION_TYPE, CENTRAL, 1, true, 1, null));
            competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.DIVISION_TYPE, EAST, SeasonScheduleRule.NONE, null, 3, true, 1, null));
            competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.DIVISION_TYPE, WEST, SeasonScheduleRule.NONE, null, 3, true, 1, null));
            competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.DIVISION_TYPE, CENTRAL, SeasonScheduleRule.NONE, null, 3, true, 1, null));            

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

        public static void CreateBasicPlayoffConfiguration(SeasonCompetitionConfig seasonConfig)
        {
            var gameRules = new GameRules("Playoff Rules", false, 3, 1, 7, 6);

            var rankingRules = new List<PlayoffRankingRule>()
            {
                new PlayoffRankingRule("NHL", 1,seasonConfig, "NHL", 1, 16)
            };

            var seriesRules = new List<PlayoffSeriesRule>()
            {
                new PlayoffSeriesRule("Series A", 1, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "NHL", 1, FROM_RANKING, "NHL", 16, 1, null, new int[] {0,0,1,1,0,1,0 }),
                new PlayoffSeriesRule("Series B", 1, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "NHL", 2, FROM_RANKING, "NHL", 15, 1, null, new int[] {0,0,1,1,0,1,0 }),
                new PlayoffSeriesRule("Series C", 1, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "NHL", 3, FROM_RANKING, "NHL", 14, 1, null, new int[] {0,0,1,1,0,1,0 }),
                new PlayoffSeriesRule("Series D", 1, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "NHL", 4, FROM_RANKING, "NHL", 13, 1, null, new int[] {0,0,1,1,0,1,0 }),
                new PlayoffSeriesRule("Series E", 1, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "NHL", 5, FROM_RANKING, "NHL", 12, 1, null, new int[] {0,0,1,1,0,1,0 }),
                new PlayoffSeriesRule("Series F", 1, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "NHL", 6, FROM_RANKING, "NHL", 11, 1, null, new int[] {0,0,1,1,0,1,0 }),
                new PlayoffSeriesRule("Series G", 1, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "NHL", 7, FROM_RANKING, "NHL", 10, 1, null, new int[] {0,0,1,1,0,1,0 }),
                new PlayoffSeriesRule("Series H", 1, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "NHL", 8, FROM_RANKING, "NHL", 9, 1, null, new int[] {0,0,1,1,0,1,0 }),
                new PlayoffSeriesRule("Series I", 2, BEST_OF_SERIES, 4, gameRules, FROM_SERIES, "Series A", GET_WINNER, FROM_SERIES, "Series H", GET_WINNER, 1, null, new int[] {0,0,1,1,0,1,0 }),
                new PlayoffSeriesRule("Series J", 2, BEST_OF_SERIES, 4, gameRules, FROM_SERIES, "Series B", GET_WINNER, FROM_SERIES, "Series G", GET_WINNER, 1, null, new int[] {0,0,1,1,0,1,0 }),
                new PlayoffSeriesRule("Series K", 2, BEST_OF_SERIES, 4, gameRules, FROM_SERIES, "Series C", GET_WINNER, FROM_SERIES, "Series F", GET_WINNER, 1, null, new int[] {0,0,1,1,0,1,0 }),
                new PlayoffSeriesRule("Series L", 2, BEST_OF_SERIES, 4, gameRules, FROM_SERIES, "Series D", GET_WINNER, FROM_SERIES, "Series E", GET_WINNER, 1, null, new int[] {0,0,1,1,0,1,0 }),
                new PlayoffSeriesRule("Series M", 3, BEST_OF_SERIES, 4, gameRules, FROM_SERIES, "Series I", GET_WINNER, FROM_SERIES, "Series L", GET_WINNER, 1, null, new int[] {0,0,1,1,0,1,0 }),
                new PlayoffSeriesRule("Series N", 3, BEST_OF_SERIES, 4, gameRules, FROM_SERIES, "Series J", GET_WINNER, FROM_SERIES, "Series K", GET_WINNER, 1, null, new int[] {0,0,1,1,0,1,0 }),
                new PlayoffSeriesRule("Final", 4, BEST_OF_SERIES, 4, gameRules, FROM_SERIES, "Series M", GET_WINNER, FROM_SERIES, "Series N", GET_WINNER, 1, null, new int[] {0,0,1,1,0,1,0 })
            };


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
