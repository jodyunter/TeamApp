using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.ViewModels.Views
{
    public class CompetitionView
    {
        public string LeaugeName { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int NextGameDay { get; set; }
        public List<GameView> NextDayGames { get; set;}
        public List<GameView> LastDayGames { get; set; }
        public bool Complete { get; set; }
        public string Champion { get; set; }

    }
}
