using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Schedules;

namespace TeamApp.Domain.Repositories
{
    public interface IScheduleGameRepository:IRepository<ScheduleGame>
    {
        IEnumerable<ScheduleGame> GetInCompleteGamesBetweenDays(int currentDay, int newDay);
        IEnumerable<ScheduleGame> GetGamesForDays(int firstDay, int lastDay);
        IEnumerable<ScheduleGame> GetGamesForDay(int day, int year);

    }
}
