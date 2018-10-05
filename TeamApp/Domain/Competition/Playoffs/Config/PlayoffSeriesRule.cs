﻿using System;
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
        public string HomeFromName { get; set; } //series or division or pool name
        public int HomeFromValue { get; set; } //ranking number, or winner or loser
        public int AwayFromType { get; set; }
        public string AwayFromName { get; set; }
        public int AwayFromValue { get; set; }
        public int? FirstYear { get; set; }
        public int? LastYear { get; set; }
        //derrived info
        public int RequiredWins { get { return SeriesNumber; } set { SeriesNumber = value; } }
        public int RequiredGames { get { return SeriesNumber; } set { SeriesNumber = value; } }

    }
}
