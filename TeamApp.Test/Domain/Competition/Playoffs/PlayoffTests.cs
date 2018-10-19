using System.Collections.Generic;
using TeamApp.Domain.Competition;
using TeamApp.Domain.Competition.Playoffs;
using TeamApp.Domain.Competition.Playoffs.Config;
using Xunit;
using static Xunit.Assert;
using static TeamApp.Test.Domain.Competition.Playoffs.PlayoffSeriesTests;
using static TeamApp.Domain.Competition.Playoffs.Config.PlayoffSeriesRule;
using TeamApp.Domain;
using TeamApp.Domain.Competition.Playoffs.Series;

namespace TeamApp.Test.Domain.Competition.Playoffs
{
    public class PlayoffTests
    {
        public static IEnumerable<object[]> PlayoffDataForGetTeamByRuleTests()
        {
            var config = new PlayoffCompetitionConfig("My Playoff", null, 1, null, 1, null, null, null, null);
            var playoff = new Playoff(null, null, 1, 1, 1, new List<PlayoffSeries>(), new List<ISingleYearTeam>(), null, new Dictionary<string, List<TeamRanking>>());

            playoff.CompetitionConfig = config;
            playoff.Rankings.Add("R1", new List<TeamRanking>());

            for (int i = 0; i < 10; i++)
            {
                playoff.Rankings["R1"].Add(new TeamRanking(i + 1, "R1", CreateTeam("Team " + i)));
            }

            var gameRules = new GameRules("Rule 1", false, 3, 1, 7, 6);

            var seriesA = new BestOfSeries(playoff, "Series A", 2, 15, CreateTeam("Team A1"), CreateTeam("Team B1"), 4, 3, 4, null, null);

            playoff.Series.Add(seriesA);

            //need to add series to get teams from
            yield return new object[] { 1, playoff, new PlayoffSeriesRule("Series 1", 1, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "R1", 1, FROM_RANKING, "R1", 10, 1, null, new int[] { 0, 0, 0, 1, 1, 1 }, null, null, null, null), "Team 0", "Team 9" };
            yield return new object[] { 1, playoff, new PlayoffSeriesRule("Series 1", 1, BEST_OF_SERIES, 4, gameRules, FROM_RANKING, "R1", 4, FROM_RANKING, "R1", 2, 1, null, new int[] { 0, 0, 0, 1, 1, 1 }, null, null, null, null), "Team 3", "Team 1" };
            yield return new object[] { 1, playoff, new PlayoffSeriesRule("Series 1", 1, BEST_OF_SERIES, 4, gameRules, FROM_SERIES, "Series A", GET_WINNER, FROM_SERIES, "Series A", GET_LOSER, 1, null, new int[] { 0, 0, 0, 1, 1, 1 }, null, null, null, null), "Team A1", "Team B1" };
            //todo add get from ranking rule
        }
    
        //todo this is now a playoff config test
        [Theory]
        [MemberData(nameof(PlayoffDataForGetTeamByRuleTests))]
        public void ShouldGetTeamFromRule(int testNo, Playoff p, PlayoffSeriesRule rule, string expectedHomeName, string expectedAwayName)
        {
            var number = testNo;

            var playoffConfig = (PlayoffCompetitionConfig)p.CompetitionConfig;

            var homeTeam = playoffConfig.GetTeamByRule(p, rule.HomeFromType, rule.HomeFromName, rule.HomeFromValue);
            var awayTeam = playoffConfig.GetTeamByRule(p, rule.AwayFromType, rule.AwayFromName, rule.AwayFromValue);

            Equal(expectedHomeName, homeTeam.Name);
            Equal(expectedAwayName, awayTeam.Name);
            
        }
    }
}
