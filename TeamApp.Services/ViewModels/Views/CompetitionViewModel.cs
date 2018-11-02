using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.ViewModels.Views
{
    public class CompetitionViewModel
    {
        public string LeaugeName { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int NextGameDay { get; set; }
        public List<GameViewModel> NextDayGames { get; set;}
        public List<GameViewModel> LastDayGames { get; set; }
        public bool Complete { get; set; }
        public string Champion { get; set; }

    }
}
