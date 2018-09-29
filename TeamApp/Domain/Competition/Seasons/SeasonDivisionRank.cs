using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Competition.Seasons
{
    public class SeasonDivisionRank
    {
        public int Rank { get; set; }
        public SeasonDivision Division { get; set; }
        public SeasonTeam Team { get; set; }

        public SeasonDivisionRank(int rank, SeasonDivision division, SeasonTeam team)
        {
            Rank = rank;
            Division = division;
            Team = team;
        }
    }
}
