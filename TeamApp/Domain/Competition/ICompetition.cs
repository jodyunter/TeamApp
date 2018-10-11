using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Scheduler;

namespace TeamApp.Domain.Competition
{
    public interface ICompetition
    {
        CompetitionConfig CompetitionRule { get; set; }
        string Name { get; set; }
        int Year { get; set; }
        Schedule Schedule { get; set; }
        void ProcessGame(ScheduleGame game);
    }
}
