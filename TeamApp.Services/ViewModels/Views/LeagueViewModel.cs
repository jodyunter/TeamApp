using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.ViewModels.Views.CompetitionConfig;

namespace TeamApp.ViewModels.Views
{
    public class LeagueViewModel : BaseViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int? FirstYear { get; set; }
        public int? LastYear { get; set; }
        public CompetitionConfigViewModel CompetitionDefinitions { get; set; }
        public CompetitionConfigViewModel 
    }
}
