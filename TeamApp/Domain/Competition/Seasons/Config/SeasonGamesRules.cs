using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Competition.Seasons.Config
{
    public class SeasonGamesRules:GameRules, ITimePeriod
    {
        public SeasonCompetition Competition { get; set; }
        public int? FirstYear { get; set; }
        public int? LastYear { get; set; }

        public SeasonGamesRules(SeasonCompetition competition, int? firstYear, int? lastYear, string name, bool canTie, int maxOverTimePeriods, int minimumPeriods, int homeRange, int awayRange)
            : base(name, canTie, maxOverTimePeriods, minimumPeriods, homeRange, awayRange)
        {
            Competition = competition;
            FirstYear = firstYear;
            LastYear = lastYear;
        }
    }
}
