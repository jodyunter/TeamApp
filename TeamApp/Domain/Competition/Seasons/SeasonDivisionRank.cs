using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Competition.Seasons
{
    public class SeasonDivisionRank:TeamRanking
    {                       
        public SeasonDivisionRank(int rank, string group, SeasonTeam team):base(rank, group, team)
        {
        }
    }
}
