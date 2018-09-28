using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Competition.Seasons.Config
{
    public class SeasonGameRules:GameRules
    {
        public SeasonCompetition Competition { get; set; }

        public SeasonGameRules(SeasonCompetition competition, bool canTie, int maxOverTimePeriods, int minimumPeriods, int homeRange, int awayRange)
            : base(canTie, maxOverTimePeriods, minimumPeriods, homeRange, awayRange)
        {
            Competition = competition;
        }
    }
}
