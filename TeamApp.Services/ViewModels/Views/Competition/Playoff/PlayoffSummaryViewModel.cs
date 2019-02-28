using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Services.ViewModels.Views.Competition.Playoff
{
    public class PlayoffSummaryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }        
        public List<BestOfSeriesSummaryViewModel> Series { get; set; }
    }
}
