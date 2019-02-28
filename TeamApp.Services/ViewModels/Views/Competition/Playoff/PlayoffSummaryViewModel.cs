using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.ViewModels.Views.Competition;

namespace TeamApp.Services.ViewModels.Views.Competition.Playoff
{
    public class PlayoffSummaryViewModel:CompetitionSimpleViewModel
    {
 
        public IEnumerable<BestOfSeriesSummaryViewModel> Series { get; set; }

        public PlayoffSummaryViewModel() { }
        public PlayoffSummaryViewModel(CompetitionSimpleViewModel model, IEnumerable<BestOfSeriesSummaryViewModel> series)
        {

        }
        public PlayoffSummaryViewModel(long id, string name, int year, bool started, bool complete, string leagueName, IEnumerable<BestOfSeriesSummaryViewModel> series)
            :base(id, name, year, started, complete, leagueName)
        {
            this.Series = series;
        }
    }
}
