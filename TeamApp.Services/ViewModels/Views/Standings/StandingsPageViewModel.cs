
using System.Collections.Generic;

namespace TeamApp.ViewModels.Views.Standings
{
    public class StandingsPageViewModel
    {
        IList<int> Years { get; set; }
        IList<SeasonListViewModel> Seasons { get; set; }
        StandingsViewModel SelectedStandings { get; set; }

        
    }
}
