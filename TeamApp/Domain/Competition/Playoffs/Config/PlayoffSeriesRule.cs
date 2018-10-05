using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Competition.Playoffs.Config
{
    public class PlayoffSeriesRule
    {
        public const int FROM_SERIES = 0;
        public const int FROM_RANKING = 1;

        public const int GET_WINNER = 0;
        public const int GET_LOSER = 1;

        public string Name { get; set; }
        public int Round { get; set; }
        public GameRules GameRules { get; set; } //can be different!

        public int HomeFromType { get; set; }
        public string HomeFromName { get; set; }

    }
}
