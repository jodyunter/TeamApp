using System;
using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Repositories;

namespace TeamApp.Services.Implementation
{
    public class GameDataService
    {
        private IGameDataRepository gameDataRepo;
        private ILeagueRepository leagueRepo;
        private IScheduleGameRepository scheduleGameRepository;
        private ICompetitionRepository competitionRepo;        

        public int GetCurrentDay()
        {
            var gameData = gameDataRepo.GetCurrentData();

            return gameData.CurrentDay;
        }

        public int GetCurrentYear()
        {
            var gameData = gameDataRepo.GetCurrentData();

            return gameData.CurrentYear;
        }

        public void PlayDay(Random random)
        {
            var gameData = gameDataRepo.GetCurrentData();

            var gamesToPlay = scheduleGameRepository.GetGamesForDay(gameData.CurrentDay, gameData.CurrentYear).Where(g => !g.Complete).ToList();

            gamesToPlay.ForEach(game =>
            {
                var competition = game.Competition;
                competition.PlayGame(game, random);
                scheduleGameRepository.Update(game);
            });

            leagueRepo.Flush();
        }

        public void ProcessDay()
        {
            var gameData = gameDataRepo.GetCurrentData();

            var gamesToPlay = scheduleGameRepository.GetGamesForDay(gameData.CurrentDay, gameData.CurrentYear).Where(g => !g.Complete).ToList();

            var competitionList = new HashSet<Competition>();

            gamesToPlay.ForEach(game =>
            {
                var competition = game.Competition;
                competition.ProcessGame(game);
                scheduleGameRepository.Update(game);
                competitionRepo.Update(competition);
                competitionList.Add(competition);
            });

            competitionList.ToList().ForEach(competition =>
            {
                if (competition.IsComplete()) competition.ProcessEndOfCompetition();
            });

            leagueRepo.Flush();
        }
       
        public bool IncrementDay(int currentDay, int currentYear)
        {
            var gameData = gameDataRepo.GetCurrentData();

            //any incomplete games on this day?
            var incompleteOrNotProcessedGames = scheduleGameRepository.GetGamesForDay(currentDay, currentYear).Where(g => !g.Complete || !g.Processed).Count() > 0;

            if (incompleteOrNotProcessedGames)
            {
                //set a message that says we can't go to the next day, games incomplete or not processed
            }
            else
            {
                competitionRepo.GetByYear(gameData.CurrentYear).ToList().ForEach(comp =>
                {
                    if (comp.IsComplete())
                    {
                        //if the competition is complete find the next and try to start it
                        comp.CompetitionConfig.League.GetNextCompetitionConfig(comp.CompetitionConfig, currentYear);
                    }
                });
            }

            return false;
        }
    }
}
