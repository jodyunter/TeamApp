using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.ViewModels.Views.Competition
{
    public class CompetitionViewModel:CompetitionSimpleViewModel
    {        
        public int NextGameDay { get; set; }
        public List<GameViewModel> NextDayGames { get; set;}
        public List<GameViewModel> LastDayGames { get; set; }        
        public string Champion { get; set; }

        public CompetitionViewModel(long id, string name, int year, bool started, bool complete, string leagueName, string type, int nextGameDay, List<GameViewModel> nextDayGames, List<GameViewModel> lastDayGames, string champion)
            :base(id, name, year, started, complete, leagueName, type)
        {
            NextGameDay = nextGameDay;
            NextDayGames = nextDayGames;
            LastDayGames = lastDayGames;
            Champion = champion;
        }
    }
}
