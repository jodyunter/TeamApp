using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Competition.Seasons.Config
{
    public class SeasonDivisionRankingRule :ITimePeriod
    {
        public int? FirstYear { get; set; }
        public int? LastYear { get; set; }

    }
}
