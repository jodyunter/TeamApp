using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static Xunit.Assert;
using TeamApp.Domain;
using static TeamApp.Test.Domain.SchedulerTests.SchedulerTests;
using TeamApp.Test.Helpers;

namespace TeamApp.Test.Domain
{
    public class GameTests
    {
        [Fact]
        public void ShouldGetWinnerAndLoser()
        {
            var rules = new GameRules(true, 1, 0, 7, 6);
        
            var g = new Game(CreateTeam("Team 1"), CreateTeam("Team 2"), 5, 3, true, 0, rules);

            Equal("Team 1", g.GetWinner().Name);
            Equal("Team 2", g.GetLoser().Name);
        }


        [Fact]
        public void ShouldGetTier()
        {
            var rules = new GameRules(true, 1, 0, 7, 6);

            var g = new Game(CreateTeam("Team 1"), CreateTeam("Team 2"), 3, 3, true, 0, rules);
            Null(g.GetWinner());
            Null(g.GetLoser());
        }


        public static IEnumerable<object[]> GetShouldPlayGamesData()
        {
            var rules1 = new GameRules(true, 3, 0, 7, 6);
            var rules2 = new GameRules(true, 3, 3, 7, 6);
            var rules3 = new GameRules(false, 3, 1, 7, 6);

            yield return new object[] { 1, new Game(CreateTeam("Team 1"), CreateTeam("Team 2"), 0, 0, false, 1, rules1), new int[] { 1, 0, 2, 3, 0, 0 }, 3, 3, 4 };            
            yield return new object[] { 2, new Game(CreateTeam("Team 3"), CreateTeam("Team 4"), 0, 0, false, 1, rules2), new int[] { 1, 0, 2, 3, 0, 0, 5, 5, 5 }, 3, 3, 7 };
            yield return new object[] { 3, new Game(CreateTeam("Team 5"), CreateTeam("Team 6"), 0, 0, false, 1, rules3), new int[] { 1, 0, 2, 3, 0, 0, 5, 5, 6}, 4, 3, 7 };

        }

        [Theory]
        [MemberData(nameof(GetShouldPlayGamesData))]
        public void ShouldPlayGame(int testNumber, Game game, int[] RandomizedValues, int expectedHome, int expectedAway, int expectedPeriod)
        {          
            var r = new GameTestRandom(RandomizedValues);

            testNumber += 1;

            game.Play(r);

            StrictEqual(expectedHome, game.HomeScore);
            StrictEqual(expectedAway, game.AwayScore);
            StrictEqual(expectedPeriod, game.CurrentPeriod);
            True(game.Complete);                        

        }

        public static IEnumerable<object[]> GetIsGameCompleteData()
        {
            var rules1 = new GameRules(true, 1, 0, 7, 6);
            var rules2 = new GameRules(true, 1, 0, 7, 6);
            var rules3 = new GameRules(false, 1, 2, 7, 6);
            var rules4 = new GameRules(true, 5, 2, 7, 6);

            yield return new object[] { 1, new Game(CreateTeam("Team 1"), CreateTeam("Team 2"), 0, 0, true, 1, rules1), false };
            yield return new object[] { 2, new Game(CreateTeam("Team 1"), CreateTeam("Team 2"), 0, 0, true, 2, rules2), true };
            yield return new object[] { 3, new Game(CreateTeam("Team 1"), CreateTeam("Team 2"), 0, 0, true, 4, rules3), false };
            yield return new object[] { 4, new Game(CreateTeam("Team 1"), CreateTeam("Team 2"), 0, 0, true, 8, rules4), true };
        }

        [Theory]
        [MemberData(nameof(GetIsGameCompleteData))]
        public void IsGameComplete(int testNumber, Game game, bool expected)
        {
            testNumber += 1;

            StrictEqual(expected, game.IsComplete());
        }

        [Fact]
        public void ShouldPlayOverTimePeriod()
        {
            var rules = new GameRules(true, 1, 0, 7, 6);

            var g = new Game(CreateTeam("Team 1"), CreateTeam("Team 2"), 0, 0, false, 1, rules);

            var random = new GameTestRandom(new int[] { 5, 5, 10, 2 });

            g.PlayOverTimePeriod(random);
            StrictEqual(0, g.HomeScore);
            StrictEqual(0, g.AwayScore);

            g.PlayOverTimePeriod(random);
            StrictEqual(0, g.HomeScore);
            StrictEqual(0, g.AwayScore);

            g.PlayOverTimePeriod(random);
            StrictEqual(1, g.HomeScore);
            StrictEqual(0, g.AwayScore);

            g.PlayOverTimePeriod(random);
            StrictEqual(1, g.HomeScore);
            StrictEqual(1, g.AwayScore);

        }

        [Fact]
        public void ShouldPlayRegulationPeriod()
        {
            var rules = new GameRules(true, 1, 0, 7, 6);

            var g = new Game(CreateTeam("Team 1"), CreateTeam("Team 2"), 0, 0, false, 1, rules);

            var random = new GameTestRandom(new int[] { 5, 5, 10, 2, 0, 3, 3, 0 });

            g.PlayRegulationPeriod(random);
            StrictEqual(5, g.HomeScore);
            StrictEqual(5, g.AwayScore);

            g.PlayRegulationPeriod(random);
            StrictEqual(15, g.HomeScore);
            StrictEqual(7, g.AwayScore);

            g.PlayRegulationPeriod(random);
            StrictEqual(15, g.HomeScore);
            StrictEqual(10, g.AwayScore);

            g.PlayRegulationPeriod(random);
            StrictEqual(18, g.HomeScore);
            StrictEqual(10, g.AwayScore);

        }

    }
}
