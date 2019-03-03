using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Services.ViewModels.Views;

namespace TeamApp.Services
{
    public interface ITeamService
    {

        TeamViewModel GetTeamByName(string name);
        TeamViewModel GetTeamById(int id);        
        IEnumerable<TeamViewModel> GetAllTeams();
        IEnumerable<TeamViewModel> SaveTeams(IEnumerable<TeamViewModel> models);        
        TeamViewModel SaveTeam(TeamViewModel model);

    }
}
