using System;
using System.Collections.Generic;
using TeamApp.Domain;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Competitions.Playoffs;
using TeamApp.Domain.Competitions.Playoffs.Config;
using TeamApp.Domain.Competitions.Seasons.Config;
using static TeamApp.Domain.Competitions.Playoffs.Config.PlayoffSeriesRule;
namespace TeamApp.Test.Helpers
{
    public class RepositoryTestData
    {
        public static string BASIC_TEAM_MAP = "BASIC_TEAM_MAP";        
        public static string BASIC_SEASON_TEAM_RULE_LIST = "BASIC_SEASON_TEAM_RULE_LIST";
        public static string BASIC_SEASON_COMPETITION_LSIT = "BASIC_SEASON_COMPETITION_LIST";
        public static string BASIC_SEASON_DIV_RULE_LIST = "BAISC_SEASON_DIV_RULE_LIST";
        public static string BASIC_SEASON_GAME_RULES = "BASIC_SEASON_GAME_RULES";
        public static string BASIC_SEASON_SCHEDULE_RULES = "BASIC_SEASON_SCHEDULE_RULES";
        
        public static League CreateBasicLeague(string name)
        {
            return new League(name);
        }
        public static SeasonCompetitionConfig CreateBasicSeasonConfiguration(League league)
        {
            var TOP = "TOP";
            var NHL = "NHL";                         

            var divMap = new Dictionary<string, List<string>>()
            {
                { TOP, new List<string>() { NHL } }     

            };

            var orderMap = new Dictionary<string, int[]>
            {
                { NHL, new int[] {1, 1 } }

            };

            var teamNameMap = new Dictionary<string, List<string>>()
            {
                {NHL, new List<string>() { "Toronto", "Montreal", "Ottawa", "Quebec City", "New York", "Boston", "Detroit" } }
            };

            var objects = new Dictionary<string, object>();
           
            var teamMap = new Dictionary<string, Team>();

            var gameRules = new GameRules("Season Rules", true, 3, 1, 7, 6);

            SeasonCompetitionConfig competition = new SeasonCompetitionConfig("My Season", league, 1, null, 1, 1, new List<SeasonTeamRule>(), new List<SeasonDivisionRule>(), gameRules, new List<SeasonScheduleRule>(), new List<CompetitionConfig>());
           
            competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.DIVISION_TYPE, NHL, SeasonScheduleRule.NONE, null, 5, true, 1, null)); //42
            /*
            for (int i = 0; i < teamNameMap[NHL].Count; i++)
            {
                for (int j = i + 1; j <= i + 2; j++)
                {
                    var homeTeam = teamNameMap[NHL][i];
                    var awayTeam = teamNameMap[NHL][j % 5];
                    competition.ScheduleRules.Add(new SeasonScheduleRule(competition, SeasonScheduleRule.TEAM_TYPE, homeTeam, SeasonScheduleRule.TEAM_TYPE, awayTeam, 1, false, 1, null)); //32            
                }
            }
            */

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

            league.Competitions.Add(competition);
            return competition;

        }

        public static PlayoffCompetitionConfig CreateBasicPlayoffConfiguration(SeasonCompetitionConfig seasonConfig)
        {
            var gameRules = new GameRules("Playoff Rules", false, 3, 1, 7, 6);

            var rankingRules = new List<PlayoffRankingRule>()
            {
                new PlayoffRankingRule(null, "NHL", 1,seasonConfig, "NHL", 1, 6)
            };

            var seriesRules = new List<PlayoffSeriesRule>()
            {
                //new PlayoffSeriesRule("Final", 1, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "NHL", 1, FROM_RANKING, "NHL", 2, 1, null, new int[] {0,0,1,1,0,1,0 }, null, null, null, null)
                new PlayoffSeriesRule(null, "Semi Final A", 1, BEST_OF_SERIES, 2, gameRules, FROM_RANKING, "NHL", 1, FROM_RANKING, "NHL", 4, 1, null, new int[] {1,0,0 }, "FINALISTS", "NHL", null, null),
                new PlayoffSeriesRule(null, "Semi Final B", 1, BEST_OF_SERIES, 2, gameRules, FROM_RANKING, "NHL", 2, FROM_RANKING, "NHL", 3, 1, null, new int[] {1,0,0 }, "FINALISTS", "NHL", null, null),
                new PlayoffSeriesRule(null, "Final", 2, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "FINALISTS", 1, FROM_RANKING, "FINALISTS", 2, 1, null, new int[] {1,0,0 }, null, null, null, null)
            };

            var playoffConfig = new PlayoffCompetitionConfig("My Playoff", seasonConfig.League, 2, gameRules, 1, null, rankingRules, seriesRules, new List<CompetitionConfig> { seasonConfig });

            seasonConfig.League.Competitions.Add(playoffConfig);
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
