using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Schedules;

namespace TeamApp.Domain.Repositories
{
    public interface IScheduleGameRepository:IRepository<ScheduleGame>
    {
        IEnumerable<ScheduleGame> GetInCompleteGames(int currentDay, int newDay);

    }
}
