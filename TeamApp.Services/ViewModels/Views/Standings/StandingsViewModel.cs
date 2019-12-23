using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamApp.ViewModels.Views.Standings
{
    public class StandingsViewModel
    {
        public string StandingsName { get; set; }
        public IEnumerable<StandingsTeamViewModel> Teams { get; set; }

        public void SortByLevel(int level)
        {
            Teams.ToList().ForEach(t =>
            {
                t.SetRankByLevel(level);
            });

            Teams = Teams.OrderBy(t => t.Rank);
        }
    }

   
    public enum DivisionLevel
    {
        League = 1,
        Conference = 2,
        Division = 3
    }
}
