using System;
using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Repositories;
using TeamApp.Domain.Schedules;

namespace TeamApp.Services
{
    public class GameDataService
    {
        private IGameDataRepository GameDataRepository;        
        private ILeagueRepository LeagueRepository;
        private IScheduleRepository ScheduleRepository;

        public GameDataService(IGameDataRepository gameDataRepository, ILeagueRepository leagueRepository, IScheduleRepository scheduleRepository)
        {
            GameDataRepository = gameDataRepository;
            LeagueRepository = leagueRepository;
        }

        public GameData GetGameData()
        {
            return GameDataRepository.First();
        }

        public List<League> GetActiveLeagues()
        {
            var currentYear = GameDataRepository.First().CurrentYear;

            return LeagueRepository.Where(l => l.FirstYear != null && l.FirstYear <= currentYear && (l.LastYear == null || l.LastYear >= currentYear)).ToList();
        }

        public List<League> GetAllLeagues()
        {
            return LeagueRepository.ToList();
        }

        public void StartNextCompetition()
        {
            var data = GameDataRepository.First();

            //var competitions = null;
        }

        public int GetCurrentYear()
        {
            return GameDataRepository.First().CurrentYear;
        }

        public int GetCurrentDay()
        {
            return GameDataRepository.First().CurrentDay;
        }

        public List<ScheduleGame> GetTodaysGames()
        {
            return GetGamesOnDay(GetCurrentYear(), GetCurrentDay());
        }

        public List<ScheduleGame> GetGamesOnDay(int year, int dayNumber)
        {
            return ScheduleRepository.Where(s => s.Year == year && s.Day == dayNumber).ToList();
        }

        public Dictionary<int, List<ScheduleGame>> GetGamesForDayRange(int year, int firstDay, int lastDay)
        {
            var results = new Dictionary<int, List<ScheduleGame>>();

            for (int i = firstDay; i <= lastDay; i++)
            {
                results.Add(i, GetGamesOnDay(year, i));
            }

            return results;
        }
 
    }
}
