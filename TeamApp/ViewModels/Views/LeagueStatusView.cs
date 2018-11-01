using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.ViewModels.Views
{
    public class LeagueStatusView
    {
        public string Name { get; set; }
        public string CurrentYear { get; set; }
        public List<CompetitionView> Competitions { get; set; }
        public CompetitionView CurrentCompetition { get; set; }        
        
    }
}
