using System.Collections.Generic;
using System.Linq;
using TeamApp.Data.Repositories.Relational;
using TeamApp.Domain.Repositories;
using TeamApp.Domain.Schedules;

namespace TeamApp.Data.Relational.Repositories
{
    public class ScheduleGameRepository:DataRepository<ScheduleGame>, IScheduleGameRepository
    {
        public ScheduleGameRepository(IRelationalRepository<ScheduleGame> repo) : base(repo) { }

        public IEnumerable<ScheduleGame> GetGamesForDays(int firstDay, int lastDay)
        {
            return baseRepo.Where(g => g.Day >= firstDay && g.Day <= lastDay).ToList();
        }

        public IEnumerable<ScheduleGame> GetGamesForDay(int day, int year)
        {
            return baseRepo.Where(g => g.Day == day && g.Year == year).ToList();
        }

        public IEnumerable<ScheduleGame> GetInCompleteGamesForDay(int day, int year)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ScheduleGame> GetCompleteAndUnProcessedGamesForDay(int day, int year)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ScheduleGame> GetInCompleteOrUnProcessedGamesForDay(int day, int year)
        {
            throw new System.NotImplementedException();
        }
    }
}
