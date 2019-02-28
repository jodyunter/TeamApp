using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.ViewModels.Views.Competition;

namespace TeamApp.Services.ViewModels.Views.Competition.Playoff
{
    public class PlayoffSummaryViewModel:CompetitionSimpleViewModel
    {
 
        public int CurrentRound { get; set; }
        public IEnumerable<BestOfSeriesSummaryViewModel> Series { get; set; }

        public PlayoffSummaryViewModel() { }
        public PlayoffSummaryViewModel(CompetitionSimpleViewModel model, int currentRound, IEnumerable<BestOfSeriesSummaryViewModel> series)
            :base(model.Id, model.Name, model.Year, model.Started, model.Complete, model.LeagueName, model.Type)
        {
            CurrentRound = currentRound;
            Series = series;
        }
    }
}
