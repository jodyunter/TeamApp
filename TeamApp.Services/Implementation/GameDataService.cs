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
        private ICompetitionConfigRepository competitionConfigRepo;


        public bool IsYearComplete(int year)
        {
            bool complete = true;

            competitionConfigRepo.GetConfigByYear(year).ToList().ForEach(config =>
            {
                complete = complete && competitionRepo.IsCompetitionCompleteForYear(year, config);
            });

            return complete;
        }
       
        public bool IncrementYear()
        {
            //add a check to make sure previous year is done?
            var gameData = gameDataRepo.GetCurrentData();

            if (IsYearComplete(gameData.CurrentYear))
            {
                gameData.CurrentYear = gameData.CurrentYear + 1;
                gameData.CurrentDay = 1;
                SetupComeptitionsForDay(gameData.CurrentDay, gameData.CurrentYear);
                gameDataRepo.Update(gameData);
                gameDataRepo.Flush();

                return true;
            }
            else
            {
                //thow message unable to do this.

                return false;
            }
                        
            
        }

        public void PlayDay(Random random)
        {
            var gameData = gameDataRepo.GetCurrentData();

            //var gamesToPlay = scheduleGameRepository.GetGamesForDay(gameData.CurrentDay, gameData.CurrentYear).Where(g => !g.Complete).ToList();
            var gamesToPlay = scheduleGameRepository.GetInCompleteGamesForDay(gameData.CurrentDay, gameData.CurrentYear).ToList();

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

            //var gamesToProcess = scheduleGameRepository.GetGamesForDay(gameData.CurrentDay, gameData.CurrentYear).Where(g => g.Complete && !g.Processed).ToList();
            var gamesToProcess = scheduleGameRepository.GetCompleteAndUnProcessedGamesForDay(gameData.CurrentDay, gameData.CurrentYear).ToList();

            var competitionList = new HashSet<Competition>();

            gamesToProcess.ForEach(game =>
            {
                var competition = game.Competition;
                competition.ProcessGame(game);
                scheduleGameRepository.Update(game);
                competitionRepo.Update(competition);
                competitionList.Add(competition);
            });

            competitionList.ToList().ForEach(competition =>
            {
                if (competition.AreGamesComplete()) competition.ProcessEndOfCompetition(gameData.CurrentDay);
            });

            leagueRepo.Flush();
        }
       
        public bool IncrementDay(int currentDay, int currentYear)
        {
            var gameData = gameDataRepo.GetCurrentData();

            int unfinishedGames = scheduleGameRepository.GetInCompleteOrUnProcessedGamesForDay(gameData.CurrentDay, gameData.CurrentYear).Count();

            if (unfinishedGames > 0)
            {
                //add a mesage about needing to compelte or process games
                return false;
            }
            else
            {
                gameData.CurrentDay = currentDay + 1;
                SetupComeptitionsForDay(gameData.CurrentDay, gameData.CurrentYear);
                gameDataRepo.Update(gameData);
                gameDataRepo.Flush();

                return true;
            }
                      
        }

        public void SetupComeptitionsForDay(int day, int year)
        {
            var configs = competitionConfigRepo.GetConfigByStartingDayAndYear(day, year).ToList();


            configs.ForEach(config => {
                var parents = competitionRepo.GetParentCompetitionsForCompetitionConfig(config, year).ToList();

                var comp = config.CreateCompetition(day, year, parents);

                competitionRepo.Update(comp);
            });

            competitionRepo.Flush();
        }
    }
}
