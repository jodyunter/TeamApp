using System;
using System.Collections.Generic;
using System.Linq;
using TeamApp.ViewModels.Views.Competition;

namespace TeamApp.ViewModels.Views.Competition.Playoff
{
    public class PlayoffSummaryViewModel:CompetitionSimpleViewModel
    {
 
        public int CurrentRound { get; set; }
        public IEnumerable<BestOfSeriesSummaryViewModel> Series { get; set; }

        public IEnumerable<PlayoffRoundViewModel> Rounds { get; set; }
        
        public PlayoffSummaryViewModel() { }
        public PlayoffSummaryViewModel(CompetitionSimpleViewModel model, int currentRound, IEnumerable<BestOfSeriesSummaryViewModel> series, IEnumerable<PlayoffRoundViewModel> rounds)
            :base(model.Id, model.Name, model.Year, model.Started, model.Complete, model.LeagueName, model.Type)
        {
            CurrentRound = currentRound;
            Series = series;
            Rounds = rounds;
        }
    }
}
