using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamApp.Services;
using TeamApp.Services.ViewModels.Views;

namespace TeamApp.Web.Controllers
{
    [Route("api/[controller]")]
    public class TeamController : Controller
    {
        private readonly ITeamService teamService;
        

        public TeamController(ITeamService TeamService)
        {
            teamService = TeamService;
        }
        [HttpGet("[action]")]
        public IEnumerable<TeamViewModel> GetTeams()
        {
            var teams = teamService.GetAllTeams();
            return teams;

        }
        [HttpPut("[action]")]
        public IEnumerable<TeamViewModel> SaveTeams(TeamViewModel[] models)
        {

            var result = teamService.SaveTeams(models.ToList());
            return result;
        }
    }
}