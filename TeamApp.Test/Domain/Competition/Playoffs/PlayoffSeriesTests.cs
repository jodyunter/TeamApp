using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competition.Playoffs;
using TeamApp.Domain;
using TeamApp.Domain.Competition.Playoffs.Series;
using Xunit;
using static Xunit.Assert;

namespace TeamApp.Test.Domain.Competition.Playoffs
{
    public class PlayoffSeriesTests
    {
        public static IEnumerable<object[]> SeriesForIsCompleteTests()
        {
            //best of cases            
            yield return new object[] { 1, new BestOfSeries(null, null, 1, null, null, 0, 1, 2, null, null), false };
            yield return new object[] { 2, new BestOfSeries(null, null, 1, null, null, 1, 0, 2, null, null), false };
            yield return new object[] { 3, new BestOfSeries(null, null, 1, null, null, 1, 1, 2, null, null), false };
            yield return new object[] { 4, new BestOfSeries(null, null, 1, null, null, 1, 2, 2, null, null), true };
            yield return new object[] { 5, new BestOfSeries(null, null, 1, null, null, 2, 1, 2, null, null), true };
            yield return new object[] { 6, new BestOfSeries(null, null, 1, null, null, 0, 2, 2, null, null), true };
            yield return new object[] { 7, new BestOfSeries(null, null, 1, null, null, 2, 0, 2, null, null), true };
            yield return new object[] { 8, new BestOfSeries(null, null, 1, null, null, 0, 0, 2, null, null), false };
            //total goals cases
            yield return new object[] { 9, new TotalGoalsSeries(null, null, 1, null, null, 0, 0, 3, 0, null, null), false };
            yield return new object[] { 10, new TotalGoalsSeries(null, null, 1, null, null, 2, 0, 3, 1, null, null), false };
            yield return new object[] { 11, new TotalGoalsSeries(null, null, 1, null, null, 2, 3, 3, 2, null, null), false };
            yield return new object[] { 12, new TotalGoalsSeries(null, null, 1, null, null, 4, 3, 3, 3, null, null), true };
            yield return new object[] { 13, new TotalGoalsSeries(null, null, 1, null, null, 3, 3, 3, 3, null, null), false };
            yield return new object[] { 14, new TotalGoalsSeries(null, null, 1, null, null, 3, 3, 3, 4, null, null), false };
            yield return new object[] { 15, new TotalGoalsSeries(null, null, 1, null, null, 3, 3, 3, 5, null, null), false };
            yield return new object[] { 16, new TotalGoalsSeries(null, null, 1, null, null, 3, 12, 3, 6, null, null), true };
        }

        [Theory]
        [MemberData(nameof(SeriesForIsCompleteTests))]
        public void ShouldTestIsCompleteSeries(int testNo, PlayoffSeries series, bool expectedIsComplete)
        {
            StrictEqual(expectedIsComplete, series.IsComplete());            
        }

        public static IEnumerable<object[]> SeriesForGamesNeededTests()
        {
            //no games in list cases
            //best of cases
            yield return new object[] { 1, new BestOfSeries(null, null, 1, null, null, 0, 0, 2, null, null), 2 };
            yield return new object[] { 1, new BestOfSeries(null, null, 1, null, null, 0, 1, 2, null, null), 1 };
            yield return new object[] { 2, new BestOfSeries(null, null, 1, null, null, 1, 0, 2, null, null), 1 };
            yield return new object[] { 3, new BestOfSeries(null, null, 1, null, null, 1, 1, 2, null, null), 1 };
            yield return new object[] { 4, new BestOfSeries(null, null, 1, null, null, 1, 2, 2, null, null), 0 };
            yield return new object[] { 5, new BestOfSeries(null, null, 1, null, null, 2, 1, 2, null, null), 0 };
            yield return new object[] { 6, new BestOfSeries(null, null, 1, null, null, 0, 2, 2, null, null), 0 };
            yield return new object[] { 7, new BestOfSeries(null, null, 1, null, null, 2, 0, 2, null, null), 0 };
            //total goals cases
            yield return new object[] { 8, new TotalGoalsSeries(null, null, 1, null, null, 0, 0, 3, 0, null, null), 3 };
            yield return new object[] { 8, new TotalGoalsSeries(null, null, 1, null, null, 0, 0, 3, 1, null, null), 2 };
            yield return new object[] { 8, new TotalGoalsSeries(null, null, 1, null, null, 0, 0, 3, 2, null, null), 1 };
            yield return new object[] { 8, new TotalGoalsSeries(null, null, 1, null, null, 0, 0, 3, 3, null, null), 1 };
            yield return new object[] { 8, new TotalGoalsSeries(null, null, 1, null, null, 0, 0, 3, 4, null, null), 1 };
            yield return new object[] { 8, new TotalGoalsSeries(null, null, 1, null, null, 0, 1, 3, 5, null, null), 0 };
            yield return new object[] { 8, new TotalGoalsSeries(null, null, 1, null, null, 0, 2, 3, 3, null, null), 0 };
            yield return new object[] { 8, new TotalGoalsSeries(null, null, 1, null, null, 2, 0, 3, 3, null, null), 0 };
            
        }


        [Theory]
        [MemberData(nameof(SeriesForGamesNeededTests))]
        public void ShouldGetExpectedNeededGames(int testNo, PlayoffSeries series, int expectedNeededGames)
        {
            StrictEqual(expectedNeededGames, series.NumberOfGamesNeeded());
        }

        public static IEnumerable<object[]> SeriesForInCompleteGames()
        {
            var team1 = CreateTeam("Team 1");
            var team2 = CreateTeam("Team 2");
            List<PlayoffGame> inCompleteGamesNull = null;
            var inCompleteGames0 = new List<PlayoffGame>();
            var inCompleteGames1 = new List<PlayoffGame> { CreateGameWithCompleteStatus(false, team1, team2) };
            var inCompleteGames2 = new List<PlayoffGame> { CreateGameWithCompleteStatus(false, team1, team2), CreateGameWithCompleteStatus(true, team1, team2) };
            var inCompleteGames3 = new List<PlayoffGame> { CreateGameWithCompleteStatus(false, team1, team2), CreateGameWithCompleteStatus(false, team1, team2), CreateGameWithCompleteStatus(true, team1, team2) };
            var inCompleteGames4 = new List<PlayoffGame> { CreateGameWithCompleteStatus(false, team1, team2), CreateGameWithCompleteStatus(false, team1, team2), CreateGameWithCompleteStatus(false, team1, team2), CreateGameWithCompleteStatus(true, team1, team2) };
            var inCompleteGames5 = new List<PlayoffGame> { CreateGameWithCompleteStatus(false, team1, team2), CreateGameWithCompleteStatus(false, team1, team2), CreateGameWithCompleteStatus(false, team1, team2), CreateGameWithCompleteStatus(false, team1, team2), CreateGameWithCompleteStatus(true, team1, team2) };

            yield return new object[] { 1, new BestOfSeries(null, null, 1, team1, team2, 1, 2, 2, inCompleteGamesNull, null), 0 };
            yield return new object[] { 2, new BestOfSeries(null, null, 1, team1, team2, 1, 2, 2, inCompleteGames0, null), 0 };
            yield return new object[] { 3, new BestOfSeries(null, null, 1, team1, team2, 1, 2, 2, inCompleteGames1, null), 1 };
            yield return new object[] { 4, new BestOfSeries(null, null, 1, team1, team2, 1, 2, 2, inCompleteGames2, null), 1 };
            yield return new object[] { 5, new BestOfSeries(null, null, 1, team1, team2, 1, 2, 2, inCompleteGames3, null), 2 };
            yield return new object[] { 6, new BestOfSeries(null, null, 1, team1, team2, 1, 2, 2, inCompleteGames4, null), 3 };
            yield return new object[] { 7, new BestOfSeries(null, null, 1, team1, team2, 1, 2, 2, inCompleteGames5, null), 4 };
        }

        public static PlayoffGame CreateGameWithCompleteStatus(bool complete, PlayoffTeam team1, PlayoffTeam team2)
        {
            return CreateGame(0, 0, complete, team1, team2);
        }
        public static PlayoffGame CreateGame(int homeScore, int awayScore, bool complete, PlayoffTeam team1, PlayoffTeam team2)
        {
            return new PlayoffGame(null, null, -1, -1, -1, team1.Parent, team2.Parent, homeScore, awayScore, complete, 1, null);
        }
        public static PlayoffTeam CreateTeam(string name)
        {
            return new PlayoffTeam(name, 5, null, new Team(name, 5, null, 1, null, true), null, 1, null);
        }
        [Theory]
        [MemberData(nameof(SeriesForInCompleteGames))]
        public void ShouldGetInCompleteGames(int testNo, PlayoffSeries series, int expectedInCompleteGames)
        {
            StrictEqual(expectedInCompleteGames, series.GetInCompleteGames());
        }

        [Fact]
        public void ProcessGamesForBestofSeries()
        {
            var teamA = CreateTeam("Team A");
            var teamB = CreateTeam("Team B");

            var series = new BestOfSeries(null, "Test", 1, teamA, teamB, 0, 0, 4, new List<PlayoffGame>(), new int[] { 0, 0, 1, 1, 0, 1, 0 });

            var game1 = CreateGame(1, 0, true, teamA, teamB);
            var game2 = CreateGame(0, 0, false, teamA, teamB);
            var game3 = CreateGame(0, 0, false, teamA, teamB);
            var game4 = CreateGame(0, 0, false, teamA, teamB);
            var game5 = CreateGame(0, 0, false, teamA, teamB);
            var game6 = CreateGame(0, 0, false, teamA, teamB);
            var game7 = CreateGame(0, 0, false, teamA, teamB);

            series.ProcessGame(game1);

            StrictEqual(1, series.HomeWins);
            StrictEqual(0, series.AwayWins);            

            series.Games.Add(game1);
            series.Games.Add(game2);

            StrictEqual(2, series.NumberOfGamesNeeded());
            series.Games.Add(game3);

            StrictEqual(1, series.NumberOfGamesNeeded());
            series.Games.Add(game4);

            StrictEqual(0, series.NumberOfGamesNeeded());
            game2.AwayScore = 3;
            game2.Complete = true;
            series.ProcessGame(game2);

            StrictEqual(1, series.NumberOfGamesNeeded());
            game3.HomeScore = 5;
            game3.Complete = true;
            game4.AwayScore = 3;
            game4.Complete = true;
            series.ProcessGame(game3);
            series.ProcessGame(game4);

            StrictEqual(2, series.NumberOfGamesNeeded());

        }

        [Fact]
        public void ShouldGetProperTeamForGameNumber()
        {

        }
    }
}
