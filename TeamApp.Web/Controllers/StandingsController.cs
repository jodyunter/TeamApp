using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamApp.Services;
using TeamApp.ViewModels.Views;

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
                t.Rank = t.Rankings.Where(r => r.Key.Equals(model.StandingsName)).FirstOrDefault().Value;
            });

            return model;
        }
    }
}
