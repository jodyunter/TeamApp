using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.ViewModels.Views
{
    public class StandingsViewModel
    {
        public string StandingsName { get; set; }
        public IEnumerable<StandingsTeamViewModel> Teams { get; set; }
    }
}
