using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Repositories;
using TeamApp.Services.ViewModels.Views;
using System.Linq;
using AutoMapper;
using TeamApp.Domain;

namespace TeamApp.Services
{
    public class TeamService
    {
        ITeamRepository teamRepository;

        public TeamService()
        {

        }

        public TeamViewModel GetTeamByName(string name)
        {
            var teamModel = new TeamViewModel();

            var team = teamRepository.GetByName(name);

            return (TeamViewModel)MapDomainToModel(team);
        }

        public TeamViewModel GetTeamById(int id)
        {
            var team = teamRepository.Get(id);

            return (TeamViewModel)MapDomainToModel(team);
        }
        
        public IViewModel MapDomainToModel(DomainObject obj)
        {
            var team = (Team)obj;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Team, TeamViewModel>();
            });

            return config.CreateMapper().Map<Team, TeamViewModel>(team);
        }
    }
}
