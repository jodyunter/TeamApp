using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Scheduler;

namespace TeamApp.Domain.Competition
{
    public interface ICompetition
    {
        Schedule Schedule { get; set; }
        void ProcessGame(ScheduleGame game);
    }
}
