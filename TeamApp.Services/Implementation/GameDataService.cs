using System;
using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Repositories;

namespace TeamApp.Services.Implementation
{
    public class GameDataService: IGameDataService
    {
        private IGameDataRepository gameDataRepo;
        private ILeagueRepository leagueRepo;
        private IScheduleGameRepository scheduleGameRepo;
        private ICompetitionRepository competitionRepo;
        private ICompetitionConfigRepository competitionConfigRepo;

        public GameDataService(IGameDataRepository gameDataRepository, ILeagueRepository leagueRepository, IScheduleGameRepository scheduleGameRepository, ICompetitionRepository competitionRepository, ICompetitionConfigRepository competitionConfigRepository)
        {
            gameDataRepo = gameDataRepository;
            leagueRepo = leagueRepository;
            scheduleGameRepo = scheduleGameRepository;
            competitionRepo = competitionRepository;
            competitionConfigRepo = competitionConfigRepository;
        }

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
            var gamesToPlay = scheduleGameRepo.GetInCompleteGamesForDay(gameData.CurrentDay, gameData.CurrentYear).ToList();

            gamesToPlay.ForEach(game =>
            {
                var competition = game.Competition;
                competition.PlayGame(game, random);
                scheduleGameRepo.Update(game);
            });

            leagueRepo.Flush();
        }

        public void ProcessDay()
        {
            var gameData = gameDataRepo.GetCurrentData();

            //var gamesToProcess = scheduleGameRepository.GetGamesForDay(gameData.CurrentDay, gameData.CurrentYear).Where(g => g.Complete && !g.Processed).ToList();
            var gamesToProcess = scheduleGameRepo.GetCompleteAndUnProcessedGamesForDay(gameData.CurrentDay, gameData.CurrentYear).ToList();

            var competitionList = new HashSet<Competition>();

            gamesToProcess.ForEach(game =>
            {
                var competition = game.Competition;
                competition.ProcessGame(game);
                scheduleGameRepo.Update(game);
                competitionRepo.Update(competition);
                competitionList.Add(competition);
            });

            competitionList.ToList().ForEach(competition =>
            {
                if (competition.AreGamesComplete()) competition.ProcessEndOfCompetition(gameData.CurrentDay);
            });

            leagueRepo.Flush();
        }
       
        //should probably NOT have parameters here
        public bool IncrementDay()
        {
            var gameData = gameDataRepo.GetCurrentData();

            int unfinishedGames = scheduleGameRepo.GetInCompleteOrUnProcessedGamesForDay(gameData.CurrentDay, gameData.CurrentYear).Count();

            if (unfinishedGames > 0)
            {
                //add a mesage about needing to compelte or process games
                return false;
            }
            else
            {
                gameData.CurrentDay = gameData.CurrentDay + 1;
                SetupComeptitionsForDay(gameData.CurrentDay, gameData.CurrentYear);
                gameDataRepo.Update(gameData);
                gameDataRepo.Flush();

                return true;
            }
                      
        }

        public void SetupComeptitionsForDay(int day, int year)
        {
            //this doesn't let us start at an unknown date.
            var configs = competitionConfigRepo.GetConfigByStartingDayAndYear(day, year).ToList();

            configs.ForEach(config =>
            {
                var comp = competitionRepo.GetCompetitionForCompetitionConfig(config, year);

                //assume that if it's been setup we completed this part
                if (comp == null)
                {                    
                    var parents = competitionRepo.GetParentCompetitionsForCompetitionConfig(config, year).ToList();
                    comp = config.CreateCompetition(day, year, parents);
                    comp.Schedule.Days.ToList().ForEach(scheduleDay =>
                    {
                        scheduleDay.Value.Games.ForEach(game => { scheduleGameRepo.Update(game); });
                    });
                    competitionRepo.Update(comp);
                    competitionRepo.Flush();
                }
               
            });

            
        }

        public GameData GetCurrentData()
        {
            return gameDataRepo.GetCurrentData();
        }

        public void SaveCurrentData(GameData data)
        {
            gameDataRepo.Update(data);
        }
    }
}
