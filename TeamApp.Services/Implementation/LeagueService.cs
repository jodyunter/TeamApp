using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain;
using TeamApp.Domain.Repositories;
using TeamApp.Services.ViewModels.Views;
using TeamApp.Services.ViewModels.Views.CompetitionConfig;
using TeamApp.Services.ViewModels.Views.CompetitionConfig.Season;

namespace TeamApp.Services.Implementation
{
    public class LeagueService : BaseService<League, LeagueViewModel>, ILeagueService
    {
        private ILeagueRepository repository;
        public LeagueService(ILeagueRepository repo)
        {
            repository = repo;
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
    }
}
