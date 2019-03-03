using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Schedules;

namespace TeamApp.Domain.Repositories
{
    public interface IScheduleGameRepository:IRepository<ScheduleGame>
    { 
        IEnumerable<ScheduleGame> GetGamesForDay(int day, int year);
        IEnumerable<ScheduleGame> GetInCompleteGamesForDay(int day, int year);
        IEnumerable<ScheduleGame> GetCompleteAndUnProcessedGamesForDay(int day, int year);
        IEnumerable<ScheduleGame> GetInCompleteOrUnProcessedGamesOnOrBeforeDay(int day, int year);
        void UpdateAll(IEnumerable<ScheduleGame> games);

    }
}
