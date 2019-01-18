using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Services.ViewModels.Views.Season
{
    public class CompetitionSimpleViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public bool Complete { get; set; }
        public string LeagueName { get; set; }
    }
}
