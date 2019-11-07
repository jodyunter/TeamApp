using System.Collections.Generic;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Competitions.Playoffs;
using Xunit;
using static Xunit.Assert;
using static TeamApp.Test.Domain.Competitions.Playoffs.PlayoffSeriesTests;
using TeamApp.Domain.Games;
using TeamApp.Domain;
using TeamApp.Domain.Competitions.Playoffs.Series;
using TeamApp.Domain.Competitions.Config.Playoffs;
using System.Linq;

namespace TeamApp.Test.Domain.Competitions.Playoffs
{
    public class PlayoffTests
    {
        public static IEnumerable<object[]> PlayoffDataForGetTeamByRuleTests()
        {
            var config = new PlayoffCompetitionConfig("My Playoff", null, 1, 12, null, 1, null, null, null, null, null);
            var playoff = new Playoff(null, null, 1, 1, new List<PlayoffSeries>(), new List<SingleYearTeam>(), null, new List<TeamRanking>(), true, false, 1, null);

            playoff.CompetitionConfig = config;            

            for (int i = 0; i < 10; i++)
            {
                var name = "Team " + i;
                playoff.Teams.Add(CreateTeam(name, i, i));
                playoff.Rankings.Add(new TeamRanking(i + 1, "R1", playoff.Teams.Where(t => t.Name.Equals(name)).First() , 1));
            }

            var gameRules = new GameRules("Rule 1", false, 3, 1, 7, 6);

            var seriesA = new BestOfSeries(playoff, "Series A", 2, 15, (PlayoffTeam)playoff.Teams.Where(t => t.Name.Equals("Team 1")).First(), (PlayoffTeam)playoff.Teams.Where(t => t.Name.Equals("Team 2")).First(), 4, 3, 4, null, null);

            playoff.Series.Add(seriesA);

            //need to add series to get teams from
            yield return new object[] { 1, playoff, new PlayoffSeriesRule(config, "Series 1", 1, PlayoffSeriesRule.Type.BestOf, 4, gameRules, "R1", 1, "R1", 10, 1, null, new int[] { 0, 0, 0, 1, 1, 1 }, null, null, null, null), "Team 0", "Team 9" };
            yield return new object[] { 1, playoff, new PlayoffSeriesRule(config, "Series 1", 1, PlayoffSeriesRule.Type.BestOf, 4, gameRules, "R1", 4, "R1", 2, 1, null, new int[] { 0, 0, 0, 1, 1, 1 }, null, null, null, null), "Team 3", "Team 1" };            
            //todo add get from ranking rule
        }
    
        //todo this is now a playoff config test
        [Theory]
        [MemberData(nameof(PlayoffDataForGetTeamByRuleTests))]
        public void ShouldGetTeamFromRule(int testNo, Playoff p, PlayoffSeriesRule rule, string expectedHomeName, string expectedAwayName)
        {
            var number = testNo;

            var playoffConfig = (PlayoffCompetitionConfig)p.CompetitionConfig;

            var homeTeam = playoffConfig.GetTeamByRule(p, rule.HomeFromName, rule.HomeFromValue);
            var awayTeam = playoffConfig.GetTeamByRule(p, rule.AwayFromName, rule.AwayFromValue);

            Equal(expectedHomeName, homeTeam.Name);
            Equal(expectedAwayName, awayTeam.Name);
            
        }

        [Fact]
        public void ShouldGetLastDayOfRound()
        {
            True(false);
        }

        [Fact]
        public void ShouldSeedRankingGroups()
        {
            True(false);
        }

        [Fact]
        public void ShouldBeginRound()
        {
            True(false);
        }

        [Fact]
        public void ShouldProcessGame()
        {
            True(false);
        }

        [Fact]
        public void ShouldSetupSeriesGames()
        {
            True(false);
        }

        [Fact]
        public void ShouldAddSeries()
        {
            True(false);
        }

        [Fact]
        public void ShouldTestIsRoundComplete()
        {
            True(false);
        }

        [Fact]
        public void ShouldProcessEndOfSeries()
        {
            True(false);
        }

        [Fact]
        public void ShouldProcessEndOfSeriesTeam()
        {
            True(false);
        }

        [Fact]
        public void ShouldTestAreGamesComplete()
        {
            True(false);
        }
        [Fact]
        public void ShouldGetFinalRanking()
        {
            True(false);
        }
    }
}
