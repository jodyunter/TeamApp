using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Competition.Season.Config
{
    public class SeasonDivisionRule
    {
        public SeasonCompetition Competition { get; set; }
        public string Name { get; set; }
        public string Parent { get; set; }
        public int? FirstYear { get; set; }
        public int? LastYear { get; set; }

        public SeasonDivisionRule(SeasonCompetition competition, string name, string parent, int? firstYear, int? lastYear)
        {
            Competition = competition;
            Name = name;
            Parent = parent;
            FirstYear = firstYear;
            LastYear = lastYear;
        }
    }
}
