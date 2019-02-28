using System;
using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Competitions.Playoffs.Config;
using TeamApp.Domain.Competitions.Seasons.Config;
using static TeamApp.Domain.Competitions.Playoffs.Config.PlayoffSeriesRule;

namespace TeamApp.Test.Helpers
{
    public class DataCreator
    {
        public static League CreateLeague(string name)
        {
            return new League(name, 1, null);
        }

        public static List<Team> CreateTeams()
        {
            return new List<Team>()
            {
                new Team("Toronto", "Maple Leafs", "TML", 1, null, 1, null, true),
                new Team("Montreal", "Canadiens", "MTL", 1, null, 1, null, true),
                new Team("Quebec", "Nordiques", "QCN", 1, null, 1, null, true),
                new Team("Ottawa", "Senators", "OTS", 1, null, 3, null, true),
                new Team("Calgary", "Flames", "CGF", 1, null, 2, null, true),
                new Team("Winnipeg", "Jets", "WPJ", 1, null, 2, null, true),
                new Team("Edmonton", "Oilers", "EDO", 1, null, 2, null, true),
                new Team("Vancouver", "Canucks", "VCC", 1, null, 3, null, true),
                new Team("Detroit", "Red Wings", "DRW", 1, null, 3, null, true)
            };
        }
        public static SeasonCompetitionConfig CreateSeasonConfiguration(League league, List<Team> teamList, List<CompetitionConfig> parents, int? startingDay, int order)
        {
            var seasonConfig = new SeasonCompetitionConfig("Regular Season", league, startingDay, order, null, 1, null, null, null, null, null);

            var gameRules = new GameRules("Season Rules", true, 3, 1, 7, 6);

            seasonConfig.GameRules = gameRules;

            seasonConfig.Parents = parents;

            var divisionRules = new List<SeasonDivisionRule>()
            {
                new SeasonDivisionRule(seasonConfig, "NHL", null, 1, 1, 1, null),
                new SeasonDivisionRule(seasonConfig, "West", "NHL", 2, 1, 2, null),
                new SeasonDivisionRule(seasonConfig, "East", "NHL", 2, 2, 2, null),
                new SeasonDivisionRule(seasonConfig, "Central", "NHL", 2, 3, 3, null)
            };

            seasonConfig.DivisionRules = divisionRules;

            var scheduleRules = new List<SeasonScheduleRule>() {
                new SeasonScheduleRule(seasonConfig, SeasonScheduleRule.DIVISION_TYPE, "NHL", SeasonScheduleRule.NONE, null, 2, true, 1, 1),
                new SeasonScheduleRule(seasonConfig, SeasonScheduleRule.DIVISION_TYPE, "NHL", SeasonScheduleRule.NONE, null, 1, true, 2, null),
                new SeasonScheduleRule(seasonConfig, SeasonScheduleRule.DIVISION_TYPE, "West", SeasonScheduleRule.NONE, null, 1, true, 2, null),
                new SeasonScheduleRule(seasonConfig, SeasonScheduleRule.DIVISION_TYPE, "East", SeasonScheduleRule.NONE, null, 1, true, 2, null),
                new SeasonScheduleRule(seasonConfig, SeasonScheduleRule.DIVISION_TYPE, "Central", SeasonScheduleRule.NONE, null, 1, true, 3, null),
            };

            seasonConfig.ScheduleRules = scheduleRules;

            var seasonTeamRules = new List<SeasonTeamRule>()
            {
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Toronto").First(), "NHL", 1, 1),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Montreal").First(), "NHL", 1, 1),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Quebec").First(), "NHL", 1, 1),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Toronto").First(), "East", 2, 2),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Montreal").First(), "East", 2, null),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Quebec").First(), "East", 2, null),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Calgary").First(), "West", 2, null),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Winnipeg").First(), "West", 2, 2),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Edmonton").First(), "West", 2, null),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Detroit").First(), "Central", 3, null),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Vancouver").First(), "West", 3, null),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Ottawa").First(), "East", 3, null),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Winnipeg").First(), "Central", 3, null),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Toronto").First(), "Central", 3, null)
            };

            seasonConfig.TeamRules = seasonTeamRules;

            league.CompetitionConfigs.Add(seasonConfig);

            return seasonConfig;
        }

        public static PlayoffCompetitionConfig CreatePlayoffConfiguration(League league, List<CompetitionConfig> parents, int order, int? startingDay, int? firstYear, int? lastYear)
        {
            var playoffConfig = new PlayoffCompetitionConfig("My Playoff", league, order, startingDay, null, firstYear, lastYear, null, null, parents);

            var gameRules = new GameRules("Playoff Rules", false, 3, 1, 7, 6);

            playoffConfig.GameRules = gameRules;

            playoffConfig.Parents = parents;

            var regularSeasonConfig = parents.Where(c => c.Name == "Regular Season").First();

            var playoffRankingRules = new List<PlayoffRankingRule>()
            {
                new PlayoffRankingRule(playoffConfig, "NHL", 1, regularSeasonConfig, "NHL", 1, null,1, 1), //common ranking
                new PlayoffRankingRule(playoffConfig, "Top Seeds", 1, regularSeasonConfig, "East", 1, 1, 2, null),
                new PlayoffRankingRule(playoffConfig, "Top Seeds", 1, regularSeasonConfig, "West", 1, 1, 2, null),
                new PlayoffRankingRule(playoffConfig, "Rest of Teams", 1, regularSeasonConfig, "East", 2, null, 2, null),
                new PlayoffRankingRule(playoffConfig, "Rest of Teams", 1, regularSeasonConfig, "West", 2, null, 2, null),
                new PlayoffRankingRule(playoffConfig, "Top Seeds", 1, regularSeasonConfig, "Central", 1, 1, 3, null),
                new PlayoffRankingRule(playoffConfig, "Rest of Teams", 1, regularSeasonConfig, "Central", 2, null, 3, null)
            };

            playoffConfig.RankingRules = playoffRankingRules;

            var playoffSeriesRules = new List<PlayoffSeriesRule>()
            {
                new PlayoffSeriesRule(playoffConfig, "Final", 2, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "NHL", 1, FROM_RANKING, "NHL", 2, 1, 1, new int[] { 0,0,1,1,0,1,0 }, null, null, null, null),

                new PlayoffSeriesRule(playoffConfig, "Semi Final A", 1, BEST_OF_SERIES, 2, gameRules, FROM_RANKING, "Top Seeds", 1, FROM_RANKING, "Rest of Teams", 2, 2, 2, new int[] {1,0,0 }, "FINALISTS", "NHL", null, null),
                new PlayoffSeriesRule(playoffConfig, "Semi Final B", 1, BEST_OF_SERIES, 2, gameRules, FROM_RANKING, "Top Seeds", 2, FROM_RANKING, "Rest of Teams", 1, 2, 2, new int[] {1,0,0 }, "FINALISTS", "NHL", null, null),

                new PlayoffSeriesRule(playoffConfig, "Final", 2, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "FINALISTS", 1, FROM_RANKING, "FINALISTS", 2, 2, 2, new int[] { 0,0,1,1,0,1,0 }, null, null, null, null),

                new PlayoffSeriesRule(playoffConfig, "Q Final A", 1, BEST_OF_SERIES, 2, gameRules, FROM_RANKING, "Top Seeds", 3, FROM_RANKING, "Rest of Teams", 6, 3, null, new int[] {1,0,0 }, "SEMIFINALISTS", "NHL", null, null),
                new PlayoffSeriesRule(playoffConfig, "Q Final B", 1, BEST_OF_SERIES, 2, gameRules, FROM_RANKING, "Rest of Teams", 4, FROM_RANKING, "Rest of Teams", 5, 3, null, new int[] {1,0,0 }, "SEMIFINALISTS", "NHL", null, null),

                new PlayoffSeriesRule(playoffConfig, "Semi Final A", 2, BEST_OF_SERIES, 2, gameRules, FROM_RANKING, "Top Seeds", 1, FROM_RANKING, "SEMIFINALISTS", 2, 3, null, new int[] {1,0,0 }, "FINALISTS", "NHL", null, null),
                new PlayoffSeriesRule(playoffConfig, "Semi Final B", 2, BEST_OF_SERIES, 2, gameRules, FROM_RANKING, "Top Seeds", 2, FROM_RANKING, "SEMIFINALISTS", 1, 3, null, new int[] {1,0,0 }, "FINALISTS", "NHL", null, null),

                new PlayoffSeriesRule(playoffConfig, "Final", 3, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "FINALISTS", 1, FROM_RANKING, "FINALISTS", 2, 3, null, new int[] { 0,0,1,1,0,1,0 }, null, null, null, null)
            };

            playoffConfig.SeriesRules = playoffSeriesRules;

            league.CompetitionConfigs.Add(playoffConfig);

            return playoffConfig;
        }
    }
}
