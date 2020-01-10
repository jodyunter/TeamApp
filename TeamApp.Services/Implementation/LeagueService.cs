using System;
using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Repositories;
using TeamApp.Services.Implementation.Mappers;
using TeamApp.ViewModels.Views;
using TeamApp.ViewModels.Views.CompetitionConfig;
using TeamApp.ViewModels.Views.CompetitionConfig.Season;

namespace TeamApp.Services.Implementation
{
    public class LeagueService : ILeagueService
    {        
        private ILeagueRepository leagueRepository;
        private BaseDomainModelMapper<League, LeagueViewModel> mapper;        

        public LeagueService(ILeagueRepository repo)
        {
            leagueRepository = repo;
            mapper = new BaseDomainModelMapper<League, LeagueViewModel>();
        }        

        public IEnumerable<LeagueViewModel> GetAll()
        {
            return mapper.MapDomainToModel(leagueRepository.GetAll());
        }

        public LeagueViewModel GetByName(string name)
        {
            return mapper.MapDomainToModel(leagueRepository.GetByName(name));
        }

        public IEnumerable<CompetitionConfigViewModel> GetCompetitionConfigs(long leagueId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SeasonCompetitionConfigViewModel> GetSeasonCompetitionConfig(long competitiongConfigId)
        {
            throw new NotImplementedException();
        }
       
    }
}
