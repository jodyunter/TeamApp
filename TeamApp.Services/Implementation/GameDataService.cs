using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamApp.Domain;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Competitions.Config;
using TeamApp.Domain.Competitions.Seasons;
using TeamApp.Domain.Repositories;
using TeamApp.ViewModels.Views;

namespace TeamApp.Services.Implementation
{
    public class GameDataService: IGameDataService
    {
        //todo most of these shouldn't be repos
        private IGameDataRepository gameDataRepo;
        private ILeagueRepository leagueRepo;
        private IScheduleGameRepository scheduleGameRepo;
        private ICompetitionRepository competitionRepo;
        private ICompetitionConfigRepository competitionConfigRepo;
        private ITeamService teamService;
        private ICompetitionService competitionService;

        public string DebugError { get; set; }
        public GameDataService(IGameDataRepository gameDataRepository, ILeagueRepository leagueRepository, IScheduleGameRepository scheduleGameRepository, ICompetitionRepository competitionRepository, ICompetitionConfigRepository competitionConfigRepository, ITeamService teamServ, ICompetitionService compService)
        {
            gameDataRepo = gameDataRepository;
            leagueRepo = leagueRepository;
            scheduleGameRepo = scheduleGameRepository;
            competitionRepo = competitionRepository;
            competitionConfigRepo = competitionConfigRepository;
            teamService = teamServ;
            competitionService = compService;
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
                //setup the game players here
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
            
            var competitionList = competitionRepo.GetStartedAndUnfinishedCompetitionsByYear(gameData.CurrentYear).ToDictionary(key => key.Id);
               
            gamesToProcess.ForEach(game =>
            {
                //here we want to add all the player stats to the competition player stats
                var competition = competitionList[game.Competition.Id];
                var newGames = competition.ProcessGame(game, gameData.CurrentDay);
                if (competition.GetType() == typeof(Season) || competition.GetType().FullName.Contains("SeasonProxy"))
                    ((Season)competition).SortAllTeams();
                scheduleGameRepo.Update(game);
                scheduleGameRepo.UpdateAll(newGames);
                competitionRepo.Update(competition);
            });

            competitionList.Values.ToList().ForEach(competition =>
            {
                if (competition.GetType() == typeof(Season)) NHibernateUtil.Initialize(((Season)competition).Schedule);
                if (competition.AreGamesComplete())
                {
                    competition.ProcessEndOfCompetition(gameData.CurrentDay);
                }

                competitionRepo.Update(competition);
            });

            leagueRepo.Flush();
        }
               
        //todo:  what happens if we try to increment the day when there are no active competitions
        public bool IncrementDay()
        {
            var gameData = gameDataRepo.GetCurrentData();

            var unfinishedGames = scheduleGameRepo.GetInCompleteOrUnProcessedGamesOnOrBeforeDay(gameData.CurrentDay, gameData.CurrentYear);

            if (unfinishedGames.Count() > 0)
            {
                //add a mesage about needing to compelte or process games

                leagueRepo.Flush();

                return false;
            }
            else
            {
                gameData.CurrentDay = gameData.CurrentDay + 1;
                //this should be a manual process
                //SetupComeptitionsForDay(gameData.CurrentDay, gameData.CurrentYear);
                gameDataRepo.Update(gameData);
                gameDataRepo.Flush();

                return true;
            }
                      
        }

        //maybe move to a different sevice method
        public bool IsCompetitionReadyToStart(CompetitionConfig config, int year)
        {
            if (config.IsActive(year))
            {
                var comp = competitionRepo.GetCompetitionForCompetitionConfig(config, year);
                var parents = competitionRepo.GetParentCompetitionsForCompetitionConfig(config, year).ToList();
                return config.AreAllParentsDone(year, parents) && (comp == null);
            }
            else
            {
                return false;
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
                    //if it's null it isn't ready to be created
                    if (comp != null)
                    {
                        comp.Schedule.Days.ToList().ForEach(scheduleDay =>
                        {
                            scheduleDay.Value.Games.ForEach(game => { scheduleGameRepo.Update(game); });
                        });
                        competitionRepo.Update(comp);
                        competitionRepo.Flush();
                    }
                }
               
            });

            leagueRepo.Flush();
        }

        public GameData GetCurrentData()
        {
            return gameDataRepo.GetCurrentData();
        }

        public void SaveCurrentData(GameData data)
        {
            gameDataRepo.Update(data);
            gameDataRepo.Flush();
        }

        public void RandomlyChangeSkillLevels(Random random)
        {
            var currentData = GetCurrentData();

            teamService.RandomlyChangeSkillLevels(currentData.CurrentYear, random);
        }


        public Task<GameSummary> GetGameSummary()
        {
            var data = gameDataRepo.GetCurrentData();
            var competitions = competitionService.GetCompetitionsByYear(data.CurrentYear).Result;
            var configs = competitionConfigRepo.GetConfigByYear(data.CurrentYear).ToList();

            var summary = new GameSummary()
            {
                CurrentDay = data.CurrentDay,
                CurrentYear = data.CurrentYear,
                CompetitionForCurrentYear = competitions
            };            

            bool allowIncrementYear = IsYearComplete(data.CurrentYear);
            bool allowStartNextCompetition = false;
            //check if any competition is ready to start
            configs.ForEach(c =>
            {
                if (IsCompetitionReadyToStart(c, data.CurrentYear))
                {
                    allowStartNextCompetition = true;
                }
            });
            //first check is if we have an active competition, then disable if a competition needs to start
            bool allowPlayGames = competitions.Where(c => c.Started && !c.Complete).FirstOrDefault() != null && !allowStartNextCompetition;
            
            summary.AllowIncrementYear = allowIncrementYear;
            summary.AllowPlayGames = allowPlayGames;
            summary.AllowStartNextCompetition = allowStartNextCompetition;

            for (int i = 1; i <= summary.CurrentYear;i++)
            {
                summary.Years.Add(i);
            }
      
            return Task.FromResult(summary);
        }

        public void PlayAndProcessDay()
        {
            var data = gameDataRepo.GetCurrentData();            
            ProcessDay();
            PlayDay(new Random());
            ProcessDay();
            IncrementDay();
            gameDataRepo.Flush();

        }

        public void StartNextCompetition()
        {
            var data = gameDataRepo.GetCurrentData();
            SetupComeptitionsForDay(data.CurrentDay, data.CurrentYear);
        }

        public void StartNextYear()
        {
            IncrementYear();
            RandomlyChangeSkillLevels(new Random());
        }
    }
}
