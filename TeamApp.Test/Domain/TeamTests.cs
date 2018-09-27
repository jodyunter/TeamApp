using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competition.Seasons;
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
            SeasonTeamStats stats = new SeasonTeamStats(null, wins, loses, ties, 0, 0);

            Equal(stats.Games, expected);
        }

        [Theory]
        [InlineData(1, 0, 0, 2)]
        [InlineData(0, 1, 0, 0)]
        [InlineData(0, 0, 1, 1)]
        [InlineData(10, 0, 5, 25)]
        public void CanCalculatePoints(int wins, int loses, int ties, int expected)
        {
            SeasonTeamStats stats = new SeasonTeamStats(null, wins, loses, ties, 0, 0);

            Equal(stats.Points, expected);
        }

        [Theory]
        [InlineData(0, 10, -10)]
        [InlineData(5, 0, 5)]
        [InlineData(45, 7, 38)]
        public void CanCalculatedGoalDifference(int goalsFor, int goalsAgainst, int expected)
        {
            SeasonTeamStats stats = new SeasonTeamStats(null, 0, 0, 0, goalsFor, goalsAgainst);

            Equal(stats.GoalDifference, expected);
        }
    }
}
