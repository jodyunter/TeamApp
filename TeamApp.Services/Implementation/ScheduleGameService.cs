using System;
using System.Collections.Generic;
using System.Linq;
using TeamApp.ViewModels.Views.Games;
using TeamApp.Domain.Repositories;
using TeamApp.Domain.Schedules;
using System.Threading.Tasks;

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

        public Task<ScheduleDaySummaryViewModel> GetScheduleDay(int day, int year)
        {
            var games = scheduleGameRepository.GetGamesForDay(day, year);

            var gameSummaries = new List<GameSummaryViewModel>();

            var daySummary = new ScheduleDaySummaryViewModel()
            {
                Day = day,
                Year = year,
                Games = new List<GameSummaryViewModel>()
            };

            games.ToList().ForEach(g =>
            {
                var gameSummary = new GameSummaryViewModel()
                {
                    HomeTeamName = g.CompetitionHomeTeam.Name,
                    AwayTeamName = g.CompetitionAwayTeam.Name,
                    HomeScore = g.HomeScore,
                    AwayScore = g.AwayScore
                };

                gameSummaries.Add(gameSummary);
            });

            daySummary.Games = gameSummaries;

            return Task.FromResult(daySummary);

        }
        

    }
}
