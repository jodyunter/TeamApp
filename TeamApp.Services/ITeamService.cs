using System;
using System.Collections.Generic;
using TeamApp.Services.ViewModels.Views;

namespace TeamApp.Services
{
    public interface ITeamService
    {
        TeamViewModel GetTeamById(int id);

        IEnumerable<TeamViewModel> GetAllTeams();

        IEnumerable<TeamViewModel> SaveTeams(IEnumerable<TeamViewModel> models);

        TeamViewModel SaveTeam(TeamViewModel model);

        void RandomlyChangeSkillLevels(int currentYear, Random random);
    }
}