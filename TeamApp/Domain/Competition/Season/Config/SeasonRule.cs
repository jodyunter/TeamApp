using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Competition.Season.Config
{    
    public class SeasonRule
    {
        public const int TEAM = 0;
        public const int DIVISION = 1;

        public Team Team { get; set; }
        public Division Division { get; set; }
        public int? FirstYear { get; set; }
        public int? LastYear { get; set; }
        public int Type { get; set; }

        public SeasonRule(Team team, Division division, int? firstYear, int? lastYear, int type)
        {
            Team = team;
            Division = division;
            FirstYear = firstYear;
            LastYear = lastYear;
            Type = type;
        }
    }
}
