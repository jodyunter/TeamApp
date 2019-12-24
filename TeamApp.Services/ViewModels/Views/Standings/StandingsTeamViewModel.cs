using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamApp.ViewModels.Views.Standings
{
    public class StandingsTeamViewModel
    {
        public long SeasonTeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamNickName { get; set; }
        public int Rank { get; set; }
        public string Division { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }
        public int Ties { get; set; }
        public int GamesPlayed { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDifference { get; set; }
        public int Points { get; set; }
        public int Skill { get; set; }
        public IList<StandingsRankingViewModel> Rankings { get; set; } = new List<StandingsRankingViewModel>();

        public void SetRankByLevel(int level)
        {
            var rank = Rankings.Where(r => r.GroupLevel == level).FirstOrDefault();

            if (rank == null) Rank = 1;
            else
                Rank = rank.Rank;
        }
    }
}
