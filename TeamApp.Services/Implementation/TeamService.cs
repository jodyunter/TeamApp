
using System.Collections.Generic;
using TeamApp.Domain.Repositories;
using TeamApp.Services.ViewModels.Views;
using TeamApp.Domain;
using System.Linq;
using TeamApp.Services.Implementation.Mappers;

namespace TeamApp.Services.Implementation
{
    public class TeamService:ITeamService
    {
        private ITeamRepository repository;
        private BaseDomainModelMapper<Team, TeamViewModel> mapper;

        public TeamService(ITeamRepository teamRepository)
        {
            repository = teamRepository;
            mapper = new BaseDomainModelMapper<Team, TeamViewModel>();
        }

        public TeamViewModel GetTeamByName(string name)
        {            
            var team = repository.GetByName(name);

            return mapper.MapDomainToModel(team);
        }

        public TeamViewModel GetTeamById(int id)
        {
            var team = repository.Get(id);

            return mapper.MapDomainToModel(team);
        }

        public IEnumerable<TeamViewModel> GetTeamByStatus(bool active)
        {
            var teams = repository.GetByStatus(active);

            return mapper.MapDomainToModel(teams);
            
        }

        public IEnumerable<TeamViewModel> GetAllTeams()
        {
            var teams = repository.GetAll().ToList();

            return mapper.MapDomainToModel(teams);
        }
        

        public IEnumerable<TeamViewModel> SaveTeams(IEnumerable<TeamViewModel> models)
        {

            mapper.MapModelToDomain(models).ToList().ForEach(t =>
            {
                repository.Update(t);                
            });

            repository.Flush();

            return models.ToList();
        }


        public TeamViewModel SaveTeam(TeamViewModel model)
        {
            var newTeam = mapper.MapModelToDomain(model);            
            newTeam = repository.Update(newTeam);

            return mapper.MapDomainToModel(newTeam);
        }

    }
}
