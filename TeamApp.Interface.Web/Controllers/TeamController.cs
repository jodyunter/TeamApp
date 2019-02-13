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
        [HttpPost("[action]")]
        public TeamViewModel SaveTeam([FromBody]TeamViewModel models)
        {

            var result = teamService.SaveTeam(models, "no user yet");
            return result;
        }
    }
}