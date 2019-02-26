using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Repositories;
using TeamApp.Domain.Schedules;

namespace TeamApp.Services.Implementation
{
    public class ScheduleGameService : IScheduleGameService
    {
        private IScheduleGameRepository scheduleGameRepository;

        public ScheduleGameService(IScheduleGameRepository repo)
        {
            scheduleGameRepository = repo;
        }
        public IEnumerable<ScheduleGame> GetGamesForDay(int day, int year)
        {
            return scheduleGameRepository.GetGamesForDay(day, year);
        }
    }
}
