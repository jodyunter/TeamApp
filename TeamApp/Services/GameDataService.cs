using System;
using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Repositories;

namespace TeamApp.Services
{
    public class GameDataService
    {
        private IGameDataRepository GameDataRepository;        
        private ILeagueRepository LeagueRepository;

        public GameDataService(IGameDataRepository gameDataRepository, ILeagueRepository leagueRepository)
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

 
    }
}
