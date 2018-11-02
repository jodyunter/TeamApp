using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.ViewModels.Views
{
    public class LeagueStatusViewModel
    {
        public string Name { get; set; }
        public string CurrentYear { get; set; }
        public List<CompetitionViewModel> Competitions { get; set; }
        public CompetitionViewModel CurrentCompetition { get; set; }        
        
    }
}
