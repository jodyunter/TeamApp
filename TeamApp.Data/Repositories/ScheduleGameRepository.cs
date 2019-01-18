﻿using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain.Repositories;
using TeamApp.Domain.Schedules;

namespace TeamApp.Data.Repositories
{
    public class ScheduleGameRepository:DataRepository<ScheduleGame>, IScheduleGameRepository
    {
        public ScheduleGameRepository(IRepository<ScheduleGame> repo) : base(repo) { }

        public IEnumerable<ScheduleGame> GetGamesForDays(int firstDay, int lastDay)
        {
            return this.Where(g => g.Day >= firstDay && g.Day <= lastDay).ToList();
        }

        public IEnumerable<ScheduleGame> GetInCompleteGamesBetweenDays(int currentDay, int newDay)
        {
            return this.Where(g => g.Day >= currentDay && g.Day < newDay && g.Complete == false).ToList();
        }
    
    }
}