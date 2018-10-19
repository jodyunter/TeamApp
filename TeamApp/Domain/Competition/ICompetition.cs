using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Schedules;

namespace TeamApp.Domain.Competition
{
    public interface ICompetition
    {
        CompetitionConfig CompetitionConfig { get; set; }
        string Name { get; set; }
        int Year { get; set; }
        Schedule Schedule { get; set; }
        Dictionary<string, List<TeamRanking>> Rankings { get; set; }
        List<ISingleYearTeam> Teams { get; set; }
        void ProcessGame(ScheduleGame game);
        bool IsComplete();
    
    }
}
