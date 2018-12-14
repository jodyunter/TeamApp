
using System.Collections.Generic;
using TeamApp.Domain.Repositories;
using TeamApp.Services.ViewModels.Views;
using TeamApp.Domain;

namespace TeamApp.Services.Implementation
{
    public class TeamService:BaseService<Team, TeamViewModel>, ITeamService
    {
        private ITeamRepository repository;
        

        public TeamService(ITeamRepository teamRepository)
        {
            repository = teamRepository;
        }

        public TeamViewModel GetTeamByName(string name)
        {            
            var team = repository.GetByName(name);

            return MapDomainToModel(team);
        }

        public TeamViewModel GetTeamById(int id)
        {
            var team = repository.Get(id);

            return MapDomainToModel(team);
        }

        public List<TeamViewModel> GetTeamByStatus(bool active)
        {
            var teams = repository.GetByStatus(active);

            return MapDomainToModel(teams);
            
        }
        
        

    }
}
