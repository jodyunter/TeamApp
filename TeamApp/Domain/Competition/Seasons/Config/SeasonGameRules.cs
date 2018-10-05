using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Competition.Seasons.Config
{
    public class SeasonGameRules:GameRules
    {
        public SeasonCompetition Competition { get; set; }

        public SeasonGameRules(SeasonCompetition competition, string name, bool canTie, int maxOverTimePeriods, int minimumPeriods, int homeRange, int awayRange)
            : base(name, canTie, maxOverTimePeriods, minimumPeriods, homeRange, awayRange)
        {
            Competition = competition;
        }
    }
}
