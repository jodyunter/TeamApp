﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Competition.Seasons.Config
{
    public class SeasonDivisionRule:ITimePeriod
    { 
        public SeasonCompetitionConfig Competition { get; set; }
        //todo eventually add a "from competition config"
        public string DivisionName { get; set; }
        public string ParentName { get; set; }
        public int Level { get; set; }
        public int Order { get; set; }
        public int? FirstYear { get; set; }
        public int? LastYear { get; set; }

        public SeasonDivisionRule(SeasonCompetitionConfig competition, string divisionName, string parentName, int level, int order, int? firstYear, int? lastYear)
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
