using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Scheduler;

namespace TeamApp.Domain.Competition.Playoffs
{
    public class Playoff : ICompetition
    {
        public CompetitionConfig CompetitionRule { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public List<PlayoffSeries> Series { get; set; }
        public Schedule Schedule { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void ProcessGame(ScheduleGame game)
        {
            throw new NotImplementedException();
        }
    }
}
