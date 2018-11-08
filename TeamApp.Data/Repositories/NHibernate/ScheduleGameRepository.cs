using System;
using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain.Repositories;
using TeamApp.Domain.Schedules;

namespace TeamApp.Data.Repositories.NHibernate
{
    public class ScheduleGameRepository:Repository<ScheduleGame>, IScheduleGameRepository
    {
        public IEnumerable<ScheduleGame> GetInCompleteGames(int currentDay, int newDay)
        {
            return this.Where(g => g.Day >= currentDay && g.Day < newDay && g.Complete == false).ToList();
        }
        
    }
}
