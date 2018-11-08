using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamApp.Services.ViewModels.Views;

namespace TeamApp.Web.Controllers
{
    [Route("api/[controller]")]
    public class TeamController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<TeamViewModel> GetTeams()
        {
            var rng = new Random();
            return Enumerable.Range(1, 45).Select(index => new TeamViewModel() {
                Name = "Team " + index,
                NickName = "The " + index + "s",
                Owner = "Me",
                FirstYear = 1,
                LastYear = null,
                ShortName = "T-" + index,
                Skill = 5,
                Active = true
            });
        }
    }
}