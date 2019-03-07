using System.Collections.Generic;
using TeamApp.Domain;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Competitions.Playoffs;
using TeamApp.Domain.Competitions.Playoffs.Config;
using TeamApp.Domain.Competitions.Seasons.Config;
using static TeamApp.Domain.Competitions.Playoffs.Config.PlayoffSeriesRule;
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
            var WEST_A = "West_A";
            var WEST_B = "West_B";
            var EAST = "East";
            var CENTRAL = "Central";
            var CEN_A = "Central_A";
            var CEN_B = "Central_B";
            var NORTHEAST = "NorthEast";
            var ATLANTIC = "Atlantic";                           

            var divMap = new Dictionary<string, List<string>>()
            {
                { TOP, new List<string>() { NHL } },
                { NHL, new List<string>() {EAST, WEST, CENTRAL } },
                { EAST, new List<string>() {NORTHEAST, ATLANTIC} },
                { WEST, new List<string>() {WEST_A, WEST_B } },
                { CENTRAL, new List<string>() {CEN_A, CEN_B } }

            };

            var orderMap = new Dictionary<string, int[]>
            {
                { NHL, new int[] {1, 1 } },                
                {EAST, new int[] {2, 1 } },
                {WEST, new int[] {3, 1 } },
                {CENTRAL, new int[] {3, 2 } },
                {NORTHEAST, new int[] {3, 3 } },
                {ATLANTIC, new int[] {3, 4 } },
                {WEST_A, new int[] {4, 5 } },
                {WEST_B, new int[] {4, 6 } },
                {CEN_A, new int[] {4, 7 } },
                {CEN_B, new int[] {4, 8 } }

            };

            var teamNameMap = new Dictionary<string, List<string>>()
            {
                {NORTHEAST, new List<string>() { "Toronto", "Montreal", "Ottawa", "Pittsburgh","Nashville" } },
                {ATLANTIC, new List<string>() {"Boston", "New York", "Philadelphia", "Buffalo"} },
                //{WEST, new List<string>(){ "Calgary", "Vancouver", "Edmonton", "Los Angelas", "San Jose", "Seattle" } },
                {WEST_A, new List<string>(){ "Calgary", "Vancouver", "Edmonton" } },
                {WEST_B, new List<string>(){"Los Angelas", "San Jose", "Anaheim" } },
                //{CENTRAL, new List<string>(){ "Chicago", "Dallas", "Winnipeg", "Minnesota", "Colorado", "Detroit" } },
                {CEN_A, new List<string>(){ "Chicago", "Minnesota", "Colorado"} },
                {CEN_B, new List<string>(){ "Dallas", "Winnipeg", "Detroit" } }

            };

            var league = new League(NHL, 1, null);

            var objects = new Dictionary<string, object>();
           
            var teamMap = new Dictionary<string, Team>();

            var gameRules = new GameRules("Season Rules", true, 3, 1, 7, 6);

            SeasonCompetitionConfig competition = new SeasonCompetitionConfig("My Season", league, 1, 1, null, 1, new List<SeasonTeamRule>(), new List<SeasonDivisionRule>(), gameRules, new List<SeasonScheduleRule>(), new List<CompetitionConfig>());
           
            competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.DIVISION_TYPE, NHL, SeasonScheduleRule.NONE, null, 1, true, 1, null)); //42
            competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.DIVISION_TYPE, WEST, SeasonScheduleRule.DIVISION_TYPE, CENTRAL, 2, true, 1, null));            
            competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.DIVISION_TYPE, WEST_A, SeasonScheduleRule.NONE, null, 1, true, 1, null));
            competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.DIVISION_TYPE, WEST_B, SeasonScheduleRule.NONE, null, 1, true, 1, null));
            competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.DIVISION_TYPE, WEST, SeasonScheduleRule.NONE, null, 1, true, 1, null));
            competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.DIVISION_TYPE, CENTRAL, SeasonScheduleRule.NONE, null, 1, true, 1, null));
            competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.DIVISION_TYPE, CEN_A, SeasonScheduleRule.NONE, null, 1, true, 1, null));
            competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.DIVISION_TYPE, CEN_B, SeasonScheduleRule.NONE, null, 1, true, 1, null));
            competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.DIVISION_TYPE, EAST, SeasonScheduleRule.NONE, null, 1, true, 1, null)); //36
            competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.DIVISION_TYPE, NORTHEAST, SeasonScheduleRule.NONE, null, 2, true, 1, null)); 
            competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.DIVISION_TYPE, ATLANTIC, SeasonScheduleRule.NONE, null, 2, true, 1, null));

            for (int i = 0; i < teamNameMap[ATLANTIC].Count; i++)
            {
                for (int j = i + 1; j < i + 3; j++)
                {
                    var homeTeam = teamNameMap[ATLANTIC][i];
                    var awayTeam = teamNameMap[ATLANTIC][j % 4];
                    competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.TEAM_TYPE, homeTeam, SeasonScheduleRule.TEAM_TYPE, awayTeam, 1, false, 1, null)); //32            
                }
            }

            for (int i = 0; i < teamNameMap[NORTHEAST].Count; i++)
            {
                for (int j = i + 1; j < i + 3; j++)
                {
                    var homeTeam = teamNameMap[NORTHEAST][i];
                    var awayTeam = teamNameMap[NORTHEAST][j % 5];
                    competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.TEAM_TYPE, homeTeam, SeasonScheduleRule.TEAM_TYPE, awayTeam, 1, false, 1, null)); //32            
                }
            }

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

            };

            var seriesRules = new List<PlayoffSeriesRule>()
            {
                new PlayoffSeriesRule(null, "Series A", 1, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "West", 1, FROM_RANKING, "West", 4, 1, null, new int[] {0,0,1,1,0,1,0 }, "SF_WEST", "West", null, null),
                new PlayoffSeriesRule(null, "Series B", 1, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "West", 2, FROM_RANKING, "West", 3, 1, null, new int[] {0,0,1,1,0,1,0 }, "SF_WEST", "West", null, null),
                new PlayoffSeriesRule(null, "Series C", 1, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "Central", 1, FROM_RANKING, "Central", 2, 1, null, new int[] {0,0,1,1,0,1,0 }, "SF_CENTRAL", "Central", null, null),
                new PlayoffSeriesRule(null, "Series D", 1, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "Central", 2, FROM_RANKING, "Central", 3, 1, null, new int[] {0,0,1,1,0,1,0 }, "SF_CENTRAL", "Central", null, null),
                new PlayoffSeriesRule(null, "Series E", 1, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "NorthEast", 1, FROM_RANKING, "West", 5, 1, null, new int[] {0,0,1,1,0,1,0 }, "SF_EAST", "East", null, null),
                new PlayoffSeriesRule(null, "Series F", 1, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "NorthEast", 2, FROM_RANKING, "NorthEast", 3, 1, null, new int[] {0,0,1,1,0,1,0 }, "SF_EAST", "East", null, null),
                new PlayoffSeriesRule(null, "Series G", 1, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "Atlantic", 1, FROM_RANKING, "Central", 5, 1, null, new int[] {0,0,1,1,0,1,0 }, "SF_EAST", "East", null, null),
                new PlayoffSeriesRule(null, "Series H", 1, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "Atlantic", 2, FROM_RANKING, "Atlantic", 3, 1, null, new int[] {0,0,1,1,0,1,0 }, "SF_EAST", "East", null, null),
                new PlayoffSeriesRule(null, "Series I", 2, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "SF_WEST", 1, FROM_RANKING, "SF_CENTRAL", 2, 1, null, new int[] {0,0,1,1,0,1,0 }, "F_WEST_CENTRAL", "NHL", null, null),
                new PlayoffSeriesRule(null, "Series J", 2, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "SF_CENTRAL", 1, FROM_RANKING, "SF_WEST", 2, 1, null, new int[] {0,0,1,1,0,1,0 }, "F_WEST_CENTRAL", "NHL", null, null),
                new PlayoffSeriesRule(null, "Series K", 2, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "SF_EAST", 1, FROM_RANKING, "SF_EAST", 4, 1, null, new int[] {0,0,1,1,0,1,0 }, "F_EAST", "East", null, null),
                new PlayoffSeriesRule(null, "Series L", 2, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "SF_EAST", 2, FROM_RANKING, "SF_EAST", 3, 1, null, new int[] {0,0,1,1,0,1,0 }, "F_EAST", "East", null, null),
                new PlayoffSeriesRule(null, "Series M", 3, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "F_WEST_CENTRAL", 1, FROM_RANKING, "F_WEST_CENTRAL", 2, 1, null, new int[] {0,0,1,1,0,1,0 }, "FINAL_GROUP", "NHL", null, null),
                new PlayoffSeriesRule(null, "Series N", 3, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "F_EAST", 1, FROM_RANKING, "F_EAST", 2, 1, null, new int[] {0,0,1,1,0,1,0 }, "FINAL_GROUP", "NHL", null, null),
                new PlayoffSeriesRule(null, "Final", 4, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "FINAL_GROUP", 1, FROM_RANKING, "FINAL_GROUP", 2, 1, null, new int[] {0,0,1,1,0,1,0 }, null, null, null, null)
            };

            var playoffConfig = new PlayoffCompetitionConfig("My Playoff", null, 65, 1, gameRules, 1, null, rankingRules, seriesRules, new List<CompetitionConfig> { seasonConfig });

            return playoffConfig;


        }

        public static void CreateTeamsForDivision(SeasonCompetitionConfig competition, Dictionary<string, Team> teamMap, List<string> teamNames, string divisionName)
        {            
            teamNames.ForEach(s =>
            {
                var team = new Team(s, null, null, 5, null, 1, null, true);
                var rule = new SeasonTeamRule(competition, team, divisionName, 1, null);

                competition.TeamRules.Add(rule);
                teamMap.Add(team.Name, team);
            });

        }
    }
}
