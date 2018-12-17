using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TeamApp.Services;
using TeamApp.ViewModels.Views.Standings;

namespace TeamApp.Web.Controllers
{
    [Route("api/[controller]")]
    public class StandingsController
    {
        private readonly IStandingsService standingsService;

        public StandingsController(IStandingsService StandingsService)
        {
            this.standingsService = StandingsService;
        }
        [HttpGet("[action]")]
        public StandingsViewModel Standings()
        {
            var model = standingsService.GetStandings(1);
            model.StandingsName = "NHL";
            model.Teams.ToList().ForEach(t =>
            {
                t.Rank = t.Rankings.Where(r => r.GroupName.Equals(model.StandingsName)).FirstOrDefault().Rank;
            });

            model.Teams = model.Teams.OrderBy(t => t.Rank).ToList();

            return model;
        }
    }
}
