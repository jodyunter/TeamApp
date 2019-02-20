using System;
using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Repositories;
using TeamApp.Services.ViewModels.Views;
using TeamApp.Services.ViewModels.Views.CompetitionConfig;
using TeamApp.Services.ViewModels.Views.CompetitionConfig.Season;

namespace TeamApp.Services.Implementation
{
    public class LeagueService : BaseService<League, LeagueViewModel>, ILeagueService
    {
        //should replace all repos with services except for league repo
        private ILeagueRepository leagueRepository;
        private ICompetitionRepository competitionRepository;
        private IScheduleGameRepository scheduleGameRepository;

        public LeagueService(ILeagueRepository repo, ICompetitionRepository compRepo, IScheduleGameRepository gameRepo)
        {
            leagueRepository = repo;
            competitionRepository = compRepo;
            scheduleGameRepository = gameRepo;
        }        
        
        public int GetCurrentYearForLeague(League l)
        {            
            return competitionRepository.GetCurrentYearForLeague(l);
        }

        public IEnumerable<LeagueViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CompetitionConfigViewModel> GetCompetitionConfigs(long leagueId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SeasonCompetitionConfigViewModel> GetSeasonCompetitionConfig(long competitiongConfigId)
        {
            throw new NotImplementedException();
        }
       

        //currently only works for a full year, we need to change this to slowly pick up where the series picks up
        //eventually we want to be able to say "play this day" or "play next game" or "play next 5 games"
        public void PlayAnotherYear(string leagueName, Random random)
        {

            var league = leagueRepository.GetByName(leagueName);

            var year = GetCurrentYearForLeague(league);

            CompetitionConfig competitionConfig = null;

            //if year is 0, there are no years yet for this league
            if (year != 0)
            {
                competitionConfig = league.GetNextCompetitionConfig(null, year);
                
                //if there are no competition configs for the year, then they are all done, go to next year
                if (competitionConfig == null)
                {
                    year++;
                }
            }
            else
            {
                //if it's all new set the year up one
                year++;
            }

            //get the first config for the new year
            competitionConfig = league.GetNextCompetitionConfig(null, year);

            while (competitionConfig != null)
            {
  
                //get all parents for this competition in the year
                var parentCompList = new List<Competition>();

                competitionConfig.Parents.ToList().ForEach(p =>
                {
                    parentCompList.Add(competitionRepository.GetByNameAndYear(p.Name, year));
                });

                //get the competitoin if it exists
                var competition = competitionRepository.GetByNameAndYear(competitionConfig.Name, year);
                //if it doesn't create it
                if (competition == null) competition = competitionConfig.CreateCompetition(year, parentCompList);
                //check if it is complete
                bool isComplete = competition.IsComplete();
                //if not complete, play it
                if (!isComplete)
                {
                    while (!competition.IsComplete())
                    {
                        competition.PlayNextDay(random).ForEach(g =>
                        {
                            scheduleGameRepository.Update(g);
                        });
                    }

                    competition.ProcessEndOfCompetition();

                    competitionRepository.Update(competition);
                }
                //get the next config
                competitionConfig = league.GetNextCompetitionConfig(competitionConfig, year);
            }

            leagueRepository.Flush();
        }
    }
}
