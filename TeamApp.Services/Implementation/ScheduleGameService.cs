using System;
using System.Collections.Generic;
using System.Linq;
using TeamApp.ViewModels.Views.Games;
using TeamApp.Domain.Repositories;
using TeamApp.Domain.Schedules;
using System.Threading.Tasks;
using TeamApp.Services.Implementation.Mappers;

namespace TeamApp.Services.Implementation
{
    public class ScheduleGameService : IScheduleGameService
    {
        private IScheduleGameRepository scheduleGameRepository;
        private GameSummaryMapper gameMapper;

        public ScheduleGameService(IScheduleGameRepository repo)
        {
            scheduleGameRepository = repo;
            gameMapper = new GameSummaryMapper();
        }
        public IEnumerable<ScheduleGame> GetGamesForDay(int day, int year)
        {
            return scheduleGameRepository.GetGamesForDay(day, year);
        }


        //this could be optimized with a different repo method
        public Task<ScheduleDaySummaryViewModel[]> GetScheduleDays(int startingDay, int daysToGet, int year)
        {

            if (startingDay < 1) startingDay = 1;

            var days = new List<ScheduleDaySummaryViewModel>();

            for (int i = startingDay; i < startingDay + daysToGet; i++)
            {
                var daySummary = GetScheduleDay(i, year).Result;
                days.Add(daySummary);
            }

            return Task.FromResult(days.ToArray());

        }



        public Task<ScheduleDaySummaryViewModel> GetScheduleDay(int day, int year)
        {
            var games = scheduleGameRepository.GetGamesForDay(day, year);            

            var daySummary = new ScheduleDaySummaryViewModel()
            {
                Day = day,
                Year = year,
                Games = new List<GameSummaryViewModel>()
            };

            var gameSummaries = gameMapper.MapDomainToModel(games).ToList<GameSummaryViewModel>();

            daySummary.Games = gameSummaries;

            return Task.FromResult(daySummary);

        }


    }
}

