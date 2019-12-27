using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.ViewModels.Views.Competition.Playoff;

namespace TeamApp.ViewModels.Views.Competition.Playoff
{
    public class PlayoffRoundViewModel
    {
        public string Name { get; set; }
        public int RoundNumber { get; set; }
        public IEnumerable<BestOfSeriesSummaryViewModel> Series { get; set; }
    }
}
