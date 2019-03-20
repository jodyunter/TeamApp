
using System.Collections.Generic;
using TeamApp.Domain.Repositories;
using TeamApp.Services.ViewModels.Views;
using TeamApp.Domain;
using System.Linq;
using TeamApp.Services.Implementation.Mappers;
using System;

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

        public TeamViewModel GetTeamById(int id)
        {
            var team = repository.Get(id);

            return mapper.MapDomainToModel(team);
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

        public void RandomlyChangeSkillLevels(int currentYear, Random random)
        {
            var dict = new Dictionary<int, int[]>()
            {
                {1, new int[] {0,45 } },
                {2, new int[] {10,60 } },
                {3, new int[] {20,65 } },
                {4, new int[] {30,70 } },
                {5, new int[] {35,75 } },
                {6, new int[] {40,80 } },
                {7, new int[] {45,85 } },
                {8, new int[] {50,90 } },
                {9, new int[] {55,95 } },
                {10, new int[] {60,100 } },
            };
            var teams = repository.GetAll().Where(t => t.IsActive(currentYear)).ToList();

            teams.ForEach(team =>
            {
                var num = random.Next(1, 101);

                var increase = dict[team.Skill][1];
                var decrease = dict[team.Skill][0];

                if (num >= increase) team.Skill++;
                else if (num <= decrease) team.Skill--;

                if (team.Skill > 10) team.Skill = 10;
                if (team.Skill < 1) team.Skill = 1;

                
            });
        }

    }
}
