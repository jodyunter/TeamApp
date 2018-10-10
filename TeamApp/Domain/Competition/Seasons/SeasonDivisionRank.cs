using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Competition.Seasons
{
    public class SeasonDivisionRank:TeamRanking
    {                       
        public SeasonDivisionRank(int rank, string group, SeasonTeam team)
        {
            Rank = rank;
            Group = group;
            Team = team;
        }
    }
}
