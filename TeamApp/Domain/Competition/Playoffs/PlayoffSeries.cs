using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Competition.Playoffs
{
    public class PlayoffSeries
    {
        public Playoff Playoff { get; set; }
        public string Name { get; set; }
        public int Round { get; set; }
        public PlayoffTeam HomeTeam { get; set; }
        public PlayoffTeam AwayTeam { get; set; }
        //add games, and wins

    }
}
