
using System.Collections.Generic;
using TeamApp.Domain.Repositories;
using TeamApp.Services.ViewModels.Views;
using TeamApp.Domain;
using System.Linq;

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

        public List<TeamViewModel> GetAllTeams()
        {
            var teams = repository.GetAll().ToList();

            return MapDomainToModel(teams);
        }
        

        public List<TeamViewModel> SaveTeams(IEnumerable<TeamViewModel> models)
        {

            MapModelToDomain(models.ToList()).ForEach(t =>
            {
                repository.Update(t);                
            });

            repository.Flush();

            return models.ToList();
        }


        public TeamViewModel SaveTeam(TeamViewModel model)
        {
            var newTeam = MapModelToDomain(model);            
            newTeam = (Team)repository.Update(newTeam);

            return MapDomainToModel(newTeam);
        }

    }
}
