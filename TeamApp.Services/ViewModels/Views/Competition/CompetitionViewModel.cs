using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.ViewModels.Views.Games;

namespace TeamApp.ViewModels.Views.Competition
{
    public class CompetitionViewModel:CompetitionSimpleViewModel
    {
        public const string PLAYOFF_TYPE = "Playoff";
        public const string SEASON_TYPE = "Season";

        public int NextGameDay { get; set; }
        public ScheduleDaySummaryViewModel NextDayGames { get; set; }
        public ScheduleDaySummaryViewModel LastDayGames { get; set; }
        public string Champion { get; set; }

        public CompetitionViewModel(long id, string name, int year, bool started, bool complete, string leagueName, int nextGameDay, ScheduleDaySummaryViewModel nextDayGames, ScheduleDaySummaryViewModel lastDayGames, string champion, string type)
            :base(id, name, year, started, complete, leagueName, type)
        {
            NextGameDay = nextGameDay;
            NextDayGames = nextDayGames;
            LastDayGames = lastDayGames;
            Champion = champion;
        }
    }
}
