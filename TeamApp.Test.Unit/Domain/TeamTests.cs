using TeamApp.Domain.Competitions.Seasons;
using static Xunit.Assert;
using Xunit;

namespace TeamApp.Test.Domain
{
    public class TeamTests
    {
        [Theory]        
        [InlineData(0, 0, 2, 2)]
        [InlineData(3, 0, 0, 3)]
        [InlineData(0, 1, 0, 1)]
        [InlineData(5, 3, 1, 9)]
        public void CanAddGames(int wins, int loses, int ties, int expected)
        {
            SeasonTeamStats stats = new SeasonTeamStats(wins, loses, ties, 0, 0, 2, 1);

            Equal(stats.Games, expected);
        }

        [Theory]
        [InlineData(1, 0, 0, 2, 1, 2)]
        [InlineData(0, 1, 0, 2, 1, 0)]
        [InlineData(0, 0, 1, 2, 1, 1)]
        [InlineData(10, 0, 5, 2, 1, 25)]
        [InlineData(10, 0, 5, 3, 0, 30)]
        [InlineData(10, 0, 5, 0, 15, 75)]
        [InlineData(3, 0, 3, 5, 2, 21)]
        public void CanCalculatePoints(int wins, int loses, int ties, int ppw, int ppt, int expected)
        {
            SeasonTeamStats stats = new SeasonTeamStats(wins, loses, ties, 0, 0, ppw, ppt);

            Equal(stats.Points, expected);
        }

        [Theory]
        [InlineData(0, 10, -10)]
        [InlineData(5, 0, 5)]
        [InlineData(45, 7, 38)]
        public void CanCalculatedGoalDifference(int goalsFor, int goalsAgainst, int expected)
        {
            SeasonTeamStats stats = new SeasonTeamStats(0, 0, 0, goalsFor, goalsAgainst, 2, 1);

            Equal(stats.GoalDifference, expected);
        }
    }
}
