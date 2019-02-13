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
        private ILeagueRepository leagueRepository;
        private ICompetitionRepository competitionRepository;
        private IScheduleGameRepository scheduleGameRepository;

        public LeagueService(ILeagueRepository repo, ICompetitionRepository compRepo, IScheduleGameRepository gameRepo)
        {
            leagueRepository = repo;
            competitionRepository = compRepo;
            scheduleGameRepository = gameRepo;
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
        public void PlayAnotherYear(string leagueName, Random random, string user)
        {

            var nextYear = 1;

            if (competitionRepository.Count() != 0) nextYear = competitionRepository.Max(c => c == null ? 0 : c.Year) + 1;
            
            var league = leagueRepository.Where(m => m.Name.Equals(leagueName)).First();

            league.CompetitionConfigs.OrderBy(m => m.Ordering).ToList().ForEach(c =>
            {
                var parentCompList = new List<Competition>();

                c.Parents.ToList().ForEach(p =>
                {
                    parentCompList.Add(competitionRepository.GetByNameAndYear(p.Name, nextYear));
                });
                
                var competition = c.CreateCompetition(nextYear, parentCompList);

                while (!competition.IsComplete())
                {
                    competition.PlayNextDay(random).ForEach(g =>
                    {
                        scheduleGameRepository.Update(g, user);
                    });
                }

                competition.ProcessEndOfCompetition();

                competitionRepository.Update(competition, user);

            });

            leagueRepository.Flush();
        }
    }
}
