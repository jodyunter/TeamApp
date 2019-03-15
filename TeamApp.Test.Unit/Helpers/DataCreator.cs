using System;
using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain;
using TeamApp.Domain.Competitions.Config;
using TeamApp.Domain.Competitions.Config.Playoffs;
using TeamApp.Domain.Competitions.Config.Seasons;
using static TeamApp.Domain.Competitions.Config.Playoffs.PlayoffSeriesRule;

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
                new Team("Ottawa", "Senators", "OTS", 1, null, 1, null, true),
                new Team("Calgary", "Flames", "CGF", 1, null, 1, null, true),
                new Team("Winnipeg", "Jets", "WPJ", 1, null, 1, null, true),
                new Team("Edmonton", "Oilers", "EDO", 1, null, 1, null, true),
                new Team("Vancouver", "Canucks", "VCC", 1, null, 1, null, true),
                new Team("Detroit", "Red Wings", "DRW", 1, null, 1, null, true),
                new Team("Minnesota", "Wild", "MNW", 1, null, 1, null, true),
                new Team("Chicago", "Blackhawks", "CBH", 1, null, 1, null, true),
                new Team("Victoria", "Cougars", "VCC", 1, null, 1, null, true),
                new Team("Seattle", "Metros", "STM", 1, null, 1, null, true),
                new Team("San Jose", "Sharks", "SJS", 1, null, 1, null, true),
                new Team("Colorado", "Avalance", "COL", 1, null, 1, null, true),
                new Team("Nashville", "Predators", "NSH", 1, null, 1, null, true),
                new Team("Pittsburgh", "Penguins", "PBP", 1, null, 1, null, true),
                new Team("Philadelphia", "Flyers", "PHF", 1, null, 1, null, true),
                new Team("New York", "Rangers", "NYR", 1, null, 1, null, true),
                new Team("New York", "Islanders", "NYI", 1, null, 1, null, true),
                new Team("Buffalo", "Sabres", "BUF", 1, null, 1, null, true),
                new Team("Los Angelas", "Kings", "LAK", 1, null, 1, null, true),
                new Team("Las Vegas", "Knights", "LVK", 1, null, 1, null, true),
                new Team("Saskatoon", "Blades", "SKB", 1, null, 1, null, true),
                new Team("New Jersey", "Devils", "NJD", 1, null, 1, null, true)                
            };
        }
        public static SeasonCompetitionConfig CreateSeasonConfiguration(League league, List<Team> teamList, List<CompetitionConfig> parents, int? startingDay, int order)
        {
            var seasonConfig = new SeasonCompetitionConfig("Regular Season", league, startingDay, order, null, 1, null, null, null, null, null);

            var gameRules = new GameRules("Season Rules", true, 3, 1, 7, 6);

            seasonConfig.GameRules = gameRules;

            seasonConfig.Parents = parents;

            var drNhl = new SeasonDivisionRule(seasonConfig, "NHL", null, 1, 1, null, 1, null);
            var drWest = new SeasonDivisionRule(seasonConfig, "West", drNhl, 2, 1, null, 1, null);
            var drEast = new SeasonDivisionRule(seasonConfig, "East", drNhl, 2, 2, null, 1, null);
            var drCentral = new SeasonDivisionRule(seasonConfig, "Central", drNhl, 2, 3, null, 1, null);
            var drAtlantic = new SeasonDivisionRule(seasonConfig, "Atlantic", drNhl, 2, 3, null, 1, null);
            var drPacific = new SeasonDivisionRule(seasonConfig, "Pacific", drNhl, 2, 3, null, 1, null);


            seasonConfig.DivisionRules = new List<SeasonDivisionRule>() { drNhl, drWest, drEast, drCentral, drAtlantic, drPacific };
            

            var scheduleRules = new List<SeasonScheduleRule>() {                
                new SeasonScheduleRule(seasonConfig, null, drNhl, null, null, 1, false, 1, null),                
            };

            seasonConfig.ScheduleRules = scheduleRules;

            var seasonTeamRules = new List<SeasonTeamRule>()
            {

                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Ottawa").First(), drEast, 1, null),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Toronto").First(), drEast, 1, null),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Buffalo").First(), drEast, 1, null),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.NickName == "Penguins").First(), drEast, 1, null),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.NickName == "Flyers").First(), drEast, 1, null),

                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Montreal").First(), drAtlantic, 1, null),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Quebec").First(), drAtlantic, 1, null),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "New Jersey").First(), drAtlantic, 1, null),                
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.NickName == "Rangers").First(), drAtlantic, 1, null),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.NickName == "Islanders").First(), drAtlantic, 1, null),

                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Detroit").First(), drCentral, 1, null),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Nashville").First(), drCentral, 1, null),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Winnipeg").First(), drCentral, 1, null),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Minnesota").First(), drCentral, 1, null),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Chicago").First(), drCentral, 1, null),

                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Colorado").First(), drWest, 1, null),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Calgary").First(), drWest, 1, null),                
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Edmonton").First(), drWest, 1, null),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Las Vegas").First(), drWest, 1, null),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Saskatoon").First(), drWest, 1, null),

                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Vancouver").First(), drPacific, 1, null),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Victoria").First(), drPacific, 1, null),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Seattle").First(), drPacific, 1, null),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "San Jose").First(), drPacific, 1, null),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Los Angelas").First(), drPacific, 1, null)

            };

            drEast.Teams = seasonConfig.GetTeamsInDivision("East").ToList();
            drAtlantic.Teams = seasonConfig.GetTeamsInDivision("Atlantic").ToList();
            drCentral.Teams = seasonConfig.GetTeamsInDivision("Central").ToList();
            drWest.Teams = seasonConfig.GetTeamsInDivision("West").ToList();
            drPacific.Teams = seasonConfig.GetTeamsInDivision("Pacific").ToList();

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
                //we do not need division rankings because they will come automatically
                new PlayoffRankingRule(playoffConfig, "Top Seeds", "East", "NHL", 1, 1, null, 5, 1, null),
                new PlayoffRankingRule(playoffConfig, "Top Seeds", "West", "NHL", 1, 1, null, 5, 1, null),
                new PlayoffRankingRule(playoffConfig, "Top Seeds", "Central", "NHL", 1, 1, 1, 5, 1, null),
                new PlayoffRankingRule(playoffConfig, "Top Seeds", "Atlantic", "NHL", 1, 1, null, 5, 1, null),
                new PlayoffRankingRule(playoffConfig, "Top Seeds", "Pacific", "NHL", 1, 1, null, 5, 1, null),
                new PlayoffRankingRule(playoffConfig, "Rest of Teams", "East", "NHL", 2, null, null, 5, 1, null),
                new PlayoffRankingRule(playoffConfig, "Rest of Teams", "West", "NHL", 2, null, null, 5, 1, null),
                new PlayoffRankingRule(playoffConfig, "Rest of Teams", "Central", "NHL", 2, null, null, 5, 1, null),
                new PlayoffRankingRule(playoffConfig, "Rest of Teams", "Atlantic", "NHL", 2, null, null, 5, 1, null),
                new PlayoffRankingRule(playoffConfig, "Rest of Teams", "Pacific", "NHL", 2, null, null, 5, 1, null),
                new PlayoffRankingRule(playoffConfig, "Combined", "Top Seeds", "NHL", 1, 5, 1, 6, 1, null),
                new PlayoffRankingRule(playoffConfig, "Combined", "Rest of Teams", "NHL", 1, 3, 6, 6, 1, null)
            };

            playoffConfig.RankingRules = playoffRankingRules;

            var playoffSeriesRules = new List<PlayoffSeriesRule>()
            {
//				CreateBestOfSeries(playoffConfig, "R1 A", 1, 4, gameRules, 1, null).SetHomeFromRanking("Top Seeds", 1).SetAwayFromRanking("Rest of Teams", 11).SetWinnerData("QUARTERFINALISTS", "NHL").SetLoserData(null, null).SetGameProgression(new int[]  { 0,0,1,1,0,1,0 }),
                new PlayoffSeriesRule(playoffConfig, "R1 A", 1, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "Top Seeds", 1, FROM_RANKING, "Rest of Teams", 11, 1, null, new int[]  { 0,0,1,1,0,1,0 }, "QUARTERFINALISTS", "NHL", null, null),
                new PlayoffSeriesRule(playoffConfig, "R1 B", 1, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "Top Seeds", 2, FROM_RANKING, "Rest of Teams", 10, 1, null, new int[]  { 0,0,1,1,0,1,0 }, "QUARTERFINALISTS", "NHL", null, null),
                new PlayoffSeriesRule(playoffConfig, "R1 C", 1, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "Top Seeds", 3, FROM_RANKING, "Rest of Teams", 9, 1, null, new int[]  { 0,0,1,1,0,1,0 }, "QUARTERFINALISTS", "NHL", null, null),
                new PlayoffSeriesRule(playoffConfig, "R1 D", 1, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "Top Seeds", 4, FROM_RANKING, "Rest of Teams", 8, 1, null, new int[]  { 0,0,1,1,0,1,0 }, "QUARTERFINALISTS", "NHL", null, null),
                new PlayoffSeriesRule(playoffConfig, "R1 E", 1, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "Top Seeds", 5, FROM_RANKING, "Rest of Teams", 7, 1, null, new int[]  { 0,0,1,1,0,1,0 }, "QUARTERFINALISTS", "NHL", null, null),
                new PlayoffSeriesRule(playoffConfig, "R1 F", 1, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "Rest of Teams", 1, FROM_RANKING, "Rest of Teams", 6, 1, null, new int[]  { 0,0,1,1,0,1,0 }, "QUARTERFINALISTS", "NHL", null, null),
                new PlayoffSeriesRule(playoffConfig, "R1 G", 1, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "Rest of Teams", 2, FROM_RANKING, "Rest of Teams", 5, 1, null, new int[]  { 0,0,1,1,0,1,0 }, "QUARTERFINALISTS", "NHL", null, null),
                new PlayoffSeriesRule(playoffConfig, "R1 H", 1, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "Rest of Teams", 3, FROM_RANKING, "Rest of Teams", 4, 1, null, new int[]  { 0,0,1,1,0,1,0 }, "QUARTERFINALISTS", "NHL", null, null),

                new PlayoffSeriesRule(playoffConfig, "QFinal A", 2, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "QUARTERFINALISTS", 1, FROM_RANKING, "QUARTERFINALISTS", 8, 1, null, new int[]  { 0,0,1,1,0,1,0 }, "SEMIFINALISTS", "NHL", null, null),
                new PlayoffSeriesRule(playoffConfig, "QFinal B", 2, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "QUARTERFINALISTS", 2, FROM_RANKING, "QUARTERFINALISTS", 7, 1, null, new int[]  { 0,0,1,1,0,1,0 }, "SEMIFINALISTS", "NHL", null, null),
                new PlayoffSeriesRule(playoffConfig, "QFinal C", 2, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "QUARTERFINALISTS", 3, FROM_RANKING, "QUARTERFINALISTS", 6, 1, null, new int[]  { 0,0,1,1,0,1,0 }, "SEMIFINALISTS", "NHL", null, null),
                new PlayoffSeriesRule(playoffConfig, "QFinal D", 2, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "QUARTERFINALISTS", 4, FROM_RANKING, "QUARTERFINALISTS", 5, 1, null, new int[]  { 0,0,1,1,0,1,0 }, "SEMIFINALISTS", "NHL", null, null),

                new PlayoffSeriesRule(playoffConfig, "Semi Final A", 3, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "SEMIFINALISTS", 1, FROM_RANKING, "SEMIFINALISTS", 4, 1, null, new int[]  { 0,0,1,1,0,1,0 }, "FINALISTS", "NHL", null, null),
                new PlayoffSeriesRule(playoffConfig, "Semi Final B", 3, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "SEMIFINALISTS", 2, FROM_RANKING, "SEMIFINALISTS", 3, 1, null, new int[] { 0, 0, 1, 1, 0, 1, 0 }, "FINALISTS", "NHL", null, null),

                new PlayoffSeriesRule(playoffConfig, "Final", 4, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "FINALISTS", 1, FROM_RANKING, "FINALISTS", 2, 1, null, new int[] { 0,0,1,1,0,1,0 }, null, null, null, null),
            };

            playoffConfig.SeriesRules = playoffSeriesRules;

            league.CompetitionConfigs.Add(playoffConfig);

            return playoffConfig;
        }
    }
}
