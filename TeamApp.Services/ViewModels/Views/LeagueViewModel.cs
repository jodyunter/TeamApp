using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.ViewModels.Views
{
    public class LeagueViewModel:BaseViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int? FirstYear { get; set; }
        public int? LastYear { get; set; }
    }
}
