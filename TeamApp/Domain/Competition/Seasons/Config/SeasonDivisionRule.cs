using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Competition.Seasons.Config
{
    public class SeasonDivisionRule:ITimePeriod
    { 
        public SeasonCompetition Competition { get; set; }
        public string DivisionName { get; set; }
        public string ParentName { get; set; }
        public int Level { get; set; }
        public int Order { get; set; }
        public int? FirstYear { get; set; }
        public int? LastYear { get; set; }

        public SeasonDivisionRule(SeasonCompetition competition, string divisionName, string parentName, int level, int order, int? firstYear, int? lastYear)
        {
            Competition = competition;
            DivisionName = divisionName;
            ParentName = parentName;
            FirstYear = firstYear;
            LastYear = lastYear;
            Order = order;
            Level = level;
        }
    }
}
