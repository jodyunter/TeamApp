using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Scheduler;

namespace TeamApp.Domain.Competition.Playoffs
{
    public class PlayoffGame:ScheduleGame
    {
        public PlayoffSeries Series { get; set; }
    }
}
