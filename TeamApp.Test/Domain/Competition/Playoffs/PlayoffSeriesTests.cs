using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competition.Playoffs;
using TeamApp.Domain.Competition.Playoffs.Config;
using Xunit;
using static Xunit.Assert;

namespace TeamApp.Test.Domain.Competition.Playoffs
{
    public class PlayoffSeriesTests
    {
        public static IEnumerable<object[]> SeriesForIsCompleteTests()
        {
            //best of cases            
            yield return new object[] { 1, new PlayoffSeries(null, null, 1, null, null, PlayoffSeriesRule.BEST_OF_SERIES, 0, 1, 2, 0, null, null), false };
            yield return new object[] { 2, new PlayoffSeries(null, null, 1, null, null, PlayoffSeriesRule.BEST_OF_SERIES, 1, 0, 2, 0, null, null), false };
            yield return new object[] { 3, new PlayoffSeries(null, null, 1, null, null, PlayoffSeriesRule.BEST_OF_SERIES, 1, 1, 2, 0, null, null), false };
            yield return new object[] { 4, new PlayoffSeries(null, null, 1, null, null, PlayoffSeriesRule.BEST_OF_SERIES, 1, 2, 2, 0, null, null), true };
            yield return new object[] { 5, new PlayoffSeries(null, null, 1, null, null, PlayoffSeriesRule.BEST_OF_SERIES, 2, 1, 2, 0, null, null), true };
            yield return new object[] { 6, new PlayoffSeries(null, null, 1, null, null, PlayoffSeriesRule.BEST_OF_SERIES, 0, 2, 2, 0, null, null), true };
            yield return new object[] { 7, new PlayoffSeries(null, null, 1, null, null, PlayoffSeriesRule.BEST_OF_SERIES, 2, 0, 2, 0, null, null), true };
            yield return new object[] { 8, new PlayoffSeries(null, null, 1, null, null, PlayoffSeriesRule.BEST_OF_SERIES, 0, 0, 2, 0, null, null), false };
            //total goals cases
            yield return new object[] { 9, new PlayoffSeries(null, null, 1, null, null, PlayoffSeriesRule.TOTAL_GOALS, 0, 0, 3, 0, null, null), false };
            yield return new object[] { 10, new PlayoffSeries(null, null, 1, null, null, PlayoffSeriesRule.TOTAL_GOALS, 2, 0, 3, 1, null, null), false };
            yield return new object[] { 11, new PlayoffSeries(null, null, 1, null, null, PlayoffSeriesRule.TOTAL_GOALS, 2, 3, 3, 2, null, null), false };
            yield return new object[] { 12, new PlayoffSeries(null, null, 1, null, null, PlayoffSeriesRule.TOTAL_GOALS, 4, 3, 3, 3, null, null), true };
            yield return new object[] { 13, new PlayoffSeries(null, null, 1, null, null, PlayoffSeriesRule.TOTAL_GOALS, 3, 3, 3, 3, null, null), false };
            yield return new object[] { 14, new PlayoffSeries(null, null, 1, null, null, PlayoffSeriesRule.TOTAL_GOALS, 3, 3, 3, 4, null, null), false };
            yield return new object[] { 15, new PlayoffSeries(null, null, 1, null, null, PlayoffSeriesRule.TOTAL_GOALS, 3, 3, 3, 5, null, null), false };
            yield return new object[] { 16, new PlayoffSeries(null, null, 1, null, null, PlayoffSeriesRule.TOTAL_GOALS, 3, 12, 3, 6, null, null), true };
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
            yield return new object[] { 1, new PlayoffSeries(null, null, 1, null, null, PlayoffSeriesRule.BEST_OF_SERIES, 0, 0, 2, 0, null, null), 2 };
            yield return new object[] { 1, new PlayoffSeries(null, null, 1, null, null, PlayoffSeriesRule.BEST_OF_SERIES, 0, 1, 2, 0, null, null), 1 };
            yield return new object[] { 2, new PlayoffSeries(null, null, 1, null, null, PlayoffSeriesRule.BEST_OF_SERIES, 1, 0, 2, 0, null, null), 1 };
            yield return new object[] { 3, new PlayoffSeries(null, null, 1, null, null, PlayoffSeriesRule.BEST_OF_SERIES, 1, 1, 2, 0, null, null), 1 };
            yield return new object[] { 4, new PlayoffSeries(null, null, 1, null, null, PlayoffSeriesRule.BEST_OF_SERIES, 1, 2, 2, 0, null, null), 0 };
            yield return new object[] { 5, new PlayoffSeries(null, null, 1, null, null, PlayoffSeriesRule.BEST_OF_SERIES, 2, 1, 2, 0, null, null), 0 };
            yield return new object[] { 6, new PlayoffSeries(null, null, 1, null, null, PlayoffSeriesRule.BEST_OF_SERIES, 0, 2, 2, 0, null, null), 0 };
            yield return new object[] { 7, new PlayoffSeries(null, null, 1, null, null, PlayoffSeriesRule.BEST_OF_SERIES, 2, 0, 2, 0, null, null), 0 };
        }

        [Theory]
        [MemberData(nameof(SeriesForGamesNeededTests))]
        public void ShouldGetExpectedNeededGames(int testNo, PlayoffSeries series, int expectedNeededGames)
        {
            StrictEqual(expectedNeededGames, series.NumberOfGamesNeeded());
        }
    }
}
