using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Services.ViewModels.Views.Competition.Playoff
{
    public class BestOfSeriesSummaryViewModel
    {
        public long Id { get; set; }
        public string PlayoffName { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public int HomeWins { get; set; }
        public int AwayWins { get; set; }
        public int Games { get; set; }
    }
}
