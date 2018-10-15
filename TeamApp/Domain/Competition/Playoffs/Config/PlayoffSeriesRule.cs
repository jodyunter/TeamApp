using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Competition.Playoffs.Config
{
    public class PlayoffSeriesRule:ITimePeriod
    {
        public const int FROM_SERIES = 0;
        public const int FROM_RANKING = 1;

        public const int BEST_OF_SERIES = 0;
        public const int TOTAL_GOALS = 1;

        public const int GET_WINNER = 0;
        public const int GET_LOSER = 1;

        public string Name { get; set; }
        public int Round { get; set; }
        public int SeriesType { get; set; }
        public int SeriesNumber { get; set; } //total games for total goals, or required wins        
        public GameRules GameRules { get; set; } //can be different!

        public int HomeFromType { get; set; }
        public string HomeFromName { get; set; } //ranking group name
        public int HomeFromValue { get; set; } //ranking number, or winner or loser
        public int AwayFromType { get; set; }
        public string AwayFromName { get; set; }
        public int AwayFromValue { get; set; }
        public int? FirstYear { get; set; }
        public int? LastYear { get; set; }
        public int[] HomeGameProgression { get; set; }

        public PlayoffSeriesRule(string name, int round, int seriesType, int seriesNumber, GameRules gameRules, int homeFromType, string homeFromName, int homeFromValue, int awayFromType, string awayFromName, int awayFromValue, int? firstYear, int? lastYear, int[] homeGameProgression)
        {
            Name = name;
            Round = round;
            SeriesType = seriesType;
            SeriesNumber = seriesNumber;
            GameRules = gameRules;
            HomeFromType = homeFromType;
            HomeFromName = homeFromName;
            HomeFromValue = homeFromValue;
            AwayFromType = awayFromType;
            AwayFromName = awayFromName;
            AwayFromValue = awayFromValue;
            FirstYear = firstYear;
            LastYear = lastYear;
            HomeGameProgression = homeGameProgression;
        }
    }
}
