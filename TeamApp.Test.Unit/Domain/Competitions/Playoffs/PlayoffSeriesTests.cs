using System.Collections.Generic;
using TeamApp.Domain.Competitions.Playoffs;
using TeamApp.Domain;
using TeamApp.Domain.Competitions.Playoffs.Series;
using Xunit;
using static Xunit.Assert;
using TeamApp.Domain.Competitions.Playoffs.Config;

namespace TeamApp.Test.Domain.Competitions.Playoffs
{
    public class PlayoffSeriesTests
    {
        public static IEnumerable<object[]> SeriesForIsCompleteTests()
        {
            //best of cases            
            yield return new object[] { 1, new BestOfSeries(null, null, 1, 1, null, null, 0, 1, 2, null, null), false };
            yield return new object[] { 2, new BestOfSeries(null, null, 1, 1, null, null, 1, 0, 2, null, null), false };
            yield return new object[] { 3, new BestOfSeries(null, null, 1, 1, null, null, 1, 1, 2, null, null), false };
            yield return new object[] { 4, new BestOfSeries(null, null, 1, 1, null, null, 1, 2, 2, null, null), true };
            yield return new object[] { 5, new BestOfSeries(null, null, 1, 1, null, null, 2, 1, 2, null, null), true };
            yield return new object[] { 6, new BestOfSeries(null, null, 1, 1, null, null, 0, 2, 2, null, null), true };
            yield return new object[] { 7, new BestOfSeries(null, null, 1, 1, null, null, 2, 0, 2, null, null), true };
            yield return new object[] { 8, new BestOfSeries(null, null, 1, 1, null, null, 0, 0, 2, null, null), false };
            //total goals cases
            yield return new object[] { 9, new TotalGoalsSeries(null, null, 1, 1, null, null, 0, 0, 3, 0, null, null), false };
            yield return new object[] { 10, new TotalGoalsSeries(null, null, 1, 1, null, null, 2, 0, 3, 1, null, null), false };
            yield return new object[] { 11, new TotalGoalsSeries(null, null, 1, 1, null, null, 2, 3, 3, 2, null, null), false };
            yield return new object[] { 12, new TotalGoalsSeries(null, null, 1, 1, null, null, 4, 3, 3, 3, null, null), true };
            yield return new object[] { 13, new TotalGoalsSeries(null, null, 1, 1, null, null, 3, 3, 3, 3, null, null), false };
            yield return new object[] { 14, new TotalGoalsSeries(null, null, 1, 1, null, null, 3, 3, 3, 4, null, null), false };
            yield return new object[] { 15, new TotalGoalsSeries(null, null, 1, 1, null, null, 3, 3, 3, 5, null, null), false };
            yield return new object[] { 16, new TotalGoalsSeries(null, null, 1, 1, null, null, 3, 12, 3, 6, null, null), true };
        }

        [Theory]
        [MemberData(nameof(SeriesForIsCompleteTests))]
        public void ShouldTestIsCompleteSeries(int testNo, PlayoffSeries series, bool expectedIsComplete)
        {
            var number = testNo;

            StrictEqual(expectedIsComplete, series.IsComplete());            
        }

        public static IEnumerable<object[]> SeriesForGamesNeededTests()
        {
            //no games in list cases
            //best of cases
            yield return new object[] { 1, new BestOfSeries(null, null, 1, 1, null, null, 0, 0, 2, null, null), 2 };
            yield return new object[] { 1, new BestOfSeries(null, null, 1, 1, null, null, 0, 1, 2, null, null), 1 };
            yield return new object[] { 2, new BestOfSeries(null, null, 1, 1, null, null, 1, 0, 2, null, null), 1 };
            yield return new object[] { 3, new BestOfSeries(null, null, 1, 1, null, null, 1, 1, 2, null, null), 1 };
            yield return new object[] { 4, new BestOfSeries(null, null, 1, 1, null, null, 1, 2, 2, null, null), 0 };
            yield return new object[] { 5, new BestOfSeries(null, null, 1, 1, null, null, 2, 1, 2, null, null), 0 };
            yield return new object[] { 6, new BestOfSeries(null, null, 1, 1, null, null, 0, 2, 2, null, null), 0 };
            yield return new object[] { 7, new BestOfSeries(null, null, 1, 1, null, null, 2, 0, 2, null, null), 0 };
            //total goals cases
            yield return new object[] { 8, new TotalGoalsSeries(null, null, 1, 1, null, null, 0, 0, 3, 0, null, null), 3 };
            yield return new object[] { 8, new TotalGoalsSeries(null, null, 1, 1, null, null, 0, 0, 3, 1, null, null), 2 };
            yield return new object[] { 8, new TotalGoalsSeries(null, null, 1, 1, null, null, 0, 0, 3, 2, null, null), 1 };
            yield return new object[] { 8, new TotalGoalsSeries(null, null, 1, 1, null, null, 0, 0, 3, 3, null, null), 1 };
            yield return new object[] { 8, new TotalGoalsSeries(null, null, 1, 1, null, null, 0, 0, 3, 4, null, null), 1 };
            yield return new object[] { 8, new TotalGoalsSeries(null, null, 1, 1, null, null, 0, 1, 3, 5, null, null), 0 };
            yield return new object[] { 8, new TotalGoalsSeries(null, null, 1, 1, null, null, 0, 2, 3, 3, null, null), 0 };
            yield return new object[] { 8, new TotalGoalsSeries(null, null, 1, 1, null, null, 2, 0, 3, 3, null, null), 0 };
            
        }


        [Theory]
        [MemberData(nameof(SeriesForGamesNeededTests))]
        public void ShouldGetExpectedNeededGames(int testNo, PlayoffSeries series, int expectedNeededGames)
        {
            var number = testNo;

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

            yield return new object[] { 1, new BestOfSeries(null, null, 1, 1, team1, team2, 1, 2, 2, inCompleteGamesNull, null), 0 };
            yield return new object[] { 2, new BestOfSeries(null, null, 1, 1, team1, team2, 1, 2, 2, inCompleteGames0, null), 0 };
            yield return new object[] { 3, new BestOfSeries(null, null, 1, 1, team1, team2, 1, 2, 2, inCompleteGames1, null), 1 };
            yield return new object[] { 4, new BestOfSeries(null, null, 1, 1, team1, team2, 1, 2, 2, inCompleteGames2, null), 1 };
            yield return new object[] { 5, new BestOfSeries(null, null, 1, 1, team1, team2, 1, 2, 2, inCompleteGames3, null), 2 };
            yield return new object[] { 6, new BestOfSeries(null, null, 1, 1, team1, team2, 1, 2, 2, inCompleteGames4, null), 3 };
            yield return new object[] { 7, new BestOfSeries(null, null, 1, 1, team1, team2, 1, 2, 2, inCompleteGames5, null), 4 };
        }

        public static PlayoffGame CreateGameWithCompleteStatus(bool complete, PlayoffTeam team1, PlayoffTeam team2)
        {
            return CreateGame(0, 0, complete, team1, team2);
        }
        public static PlayoffGame CreateGame(int homeScore, int awayScore, bool complete, PlayoffTeam team1, PlayoffTeam team2)
        {
            return new PlayoffGame(null, null, -1, -1, -1, team1.Parent, team2.Parent, homeScore, awayScore, complete, 1, null, false);
        }
        public static PlayoffTeam CreateTeam(string name)
        {
            return new PlayoffTeam(null, new Team(name, null, null, 5, null, 1, null, true), name, null, null, 5, null, 1);
        }
        [Theory]
        [MemberData(nameof(SeriesForInCompleteGames))]
        public void ShouldGetInCompleteGames(int testNo, PlayoffSeries series, int expectedInCompleteGames)
        {
            var number = testNo;

            StrictEqual(expectedInCompleteGames, series.GetInCompleteGames());
        }

        [Fact]
        public void ProcessGamesForBestofSeries()
        {
            var teamA = CreateTeam("Team A");
            var teamB = CreateTeam("Team B");

            var series = new BestOfSeries(null, "Test", 1, 1, teamA, teamB, 0, 0, 4, new List<PlayoffGame>(), new int[] { 0, 0, 1, 1, 0, 1, 0 });

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

        [Theory]
        //first no progression
        [InlineData(1, 1, null, 0)]
        [InlineData(2, 2, null, 1)]
        [InlineData(3, 3, null, 0)]
        [InlineData(4, 4, null, 1)]
        //next get it from the the progress
        [InlineData(5, 1, new int[] { 1, 1, 0, 0, 1 }, 1)]
        [InlineData(6, 2, new int[] { 1, 1, 0, 0, 1 }, 1)]
        [InlineData(7, 3, new int[] { 1, 1, 0, 0, 1 }, 0)]
        [InlineData(8, 4, new int[] { 1, 1, 0, 0, 1 }, 0)]
        [InlineData(9, 5, new int[] { 1, 1, 0, 0, 1 }, 1)]
        //next get it after the progression
        [InlineData(10, 6, new int[] { 1, 1, 0, 0, 1 }, 1)]
        [InlineData(11, 7, new int[] { 1, 1, 0, 0, 1 }, 0)]
        [InlineData(12, 8, new int[] { 1, 1, 0, 0, 1 }, 1)]
        [InlineData(13, 9, new int[] { 1, 1, 0, 0, 1 }, 0)]
        [InlineData(14, 10, new int[] { 1, 1, 0, 0, 1 }, 1)]
        public void ShouldGetProperTeamForGameNumber(int testNo, int gameToTest, int[] homeTeamProgression, int expectedResult)
        {
            var number = testNo;

            var series = new BestOfSeries(null, null, 1, 1, null, null, 0, 0, 0, null, homeTeamProgression);

            StrictEqual(expectedResult, series.GetHomeValueForGame(gameToTest));
        }

        [Theory]
        //first no progression
        [InlineData(1, 1, null, 0)]
        [InlineData(2, 2, null, 1)]
        [InlineData(3, 3, null, 0)]
        [InlineData(4, 4, null, 1)]
        //next get it from the the progress
        [InlineData(5, 1, new int[] { 1, 1, 0, 0, 1 }, 1)]
        [InlineData(6, 2, new int[] { 1, 1, 0, 0, 1 }, 1)]
        [InlineData(7, 3, new int[] { 1, 1, 0, 0, 1 }, 0)]
        [InlineData(8, 4, new int[] { 1, 1, 0, 0, 1 }, 0)]
        [InlineData(9, 5, new int[] { 1, 1, 0, 0, 1 }, 1)]
        //next get it after the progression
        [InlineData(10, 6, new int[] { 1, 1, 0, 0, 1 }, 1)]
        [InlineData(11, 7, new int[] { 1, 1, 0, 0, 1 }, 0)]
        [InlineData(12, 8, new int[] { 1, 1, 0, 0, 1 }, 1)]
        [InlineData(13, 9, new int[] { 1, 1, 0, 0, 1 }, 0)]
        [InlineData(14, 10, new int[] { 1, 1, 0, 0, 1 }, 1)]
        public void ShouldCreateGameProperly(int testNo, int gameToTest, int[] homeTeamProgression, int expectedResult)
        {
            var number = testNo;

            var gameRules = new GameRules("Test", false, 3, 1, 7, 6);
            var playoffConfig = new PlayoffCompetitionConfig("My Playoff", null, 1, 55, gameRules, 1, null, null, null, null); //todo eventually can't use this constructor
            var playoff = new Playoff(playoffConfig, "My Playoff", 1, 1, null, null, null, null, true, false, 1, null);
            
            playoff.CompetitionConfig = playoffConfig;
            playoffConfig.GameRules = gameRules;

            var homeTeam = CreateTeam("A Team");
            var awayTeam = CreateTeam("B Team");

            var series = new BestOfSeries(playoff, "Test", 1, 1, homeTeam, awayTeam, 0, 0, 0, null, homeTeamProgression);

            var game = series.CreateGameForSeries(gameToTest);

            if (expectedResult == 0)
            {
                Equal("A Team", game.HomeTeam.Name);
                Equal("B Team", game.AwayTeam.Name);
            }
            else
            {
                Equal("B Team", game.HomeTeam.Name);
                Equal("A Team", game.AwayTeam.Name);
            }
        }

        [Fact]
        public void ShouldProcessSeriesGameBestOf()
        {

            var homeTeam = CreateTeam("A Team");
            var awayTeam = CreateTeam("B Team");

            var series = new BestOfSeries(null, "Test", 1, 1, homeTeam, awayTeam, 0, 0, 2, null, null);

            var game1 = CreateGame(5, 4, true, homeTeam, awayTeam);
            var game2 = CreateGame(8, 3, true, awayTeam, homeTeam);
            var game3 = CreateGame(2, 3, true, awayTeam, homeTeam);

            False(series.IsComplete());
            series.ProcessGame(game1);

            StrictEqual(1, series.HomeWins);
            StrictEqual(0, series.AwayWins);

            False(series.IsComplete());
            series.ProcessGame(game2);

            StrictEqual(1, series.HomeWins);
            StrictEqual(1, series.AwayWins);

            False(series.IsComplete());
            series.ProcessGame(game3);

            StrictEqual(2, series.HomeWins);
            StrictEqual(1, series.AwayWins);
            
            True(series.IsComplete());
        }

        [Fact]
        public void ShouldGetWinnerAndLoserForBestOf()
        {

            var homeTeam = CreateTeam("A Team");
            var awayTeam = CreateTeam("B Team");

            var series1 = new BestOfSeries(null, "Test", 1, 2, homeTeam, awayTeam, 0, 0, 2, null, null);
            var series2 = new BestOfSeries(null, "Test", 1, 1, homeTeam, awayTeam, 0, 0, 2, null, null);
            var series3 = new BestOfSeries(null, "Test", 1, 1, homeTeam, awayTeam, 0, 0, 2, null, null);

            Equal("A Team", series1.GetWinner().Name);
            Equal("B Team", series1.GetLoser().Name);

            Equal("B Team", series2.GetWinner().Name);
            Equal("A Team", series2.GetLoser().Name);
                        
            Null(series3.GetWinner());
            Null(series3.GetLoser());
        }


        [Fact]
        public void ShouldGetWinnerAndLoserForTotalGoals()
        {

            var homeTeam = CreateTeam("A Team");
            var awayTeam = CreateTeam("B Team");

            var series1 = new TotalGoalsSeries(null, "Test", 1, 1, homeTeam, awayTeam, 3, 0, 2, 2, null, null);
            var series2 = new TotalGoalsSeries(null, "Test", 1, 1, homeTeam, awayTeam, 2, 5, 2, 2, null, null);
            var series3 = new TotalGoalsSeries(null, "Test", 1, 0, homeTeam, awayTeam, 16, 12, 2, 1, null, null);

            Equal("A Team", series1.GetWinner().Name);
            Equal("B Team", series1.GetLoser().Name);

            Equal("B Team", series2.GetWinner().Name);
            Equal("A Team", series2.GetLoser().Name);

            Null(series3.GetWinner());
            Null(series3.GetLoser());
        }
    }
}
