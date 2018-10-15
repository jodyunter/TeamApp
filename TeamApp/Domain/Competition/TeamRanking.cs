using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Competition
{
    public class TeamRanking
    {
        public int Rank { get; set; }
        public string Group { get; set; }
        public ISingleYearTeam Team { get; set; }

        public TeamRanking(int rank, string group, ISingleYearTeam team)
        {
            Rank = rank;
            Group = group;
            Team = team;
        }
    }
}
