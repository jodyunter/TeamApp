using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamApp.Services;
using TeamApp.ViewModels.Views.Standings;

namespace TeamApp.Interface.Web.Pages.StandingsPage
{
    public partial class StandingsViewBase:ComponentBase
    {
        [Inject] IStandingsService StandingsService { get; set; }
        [Parameter] public int CompetitionConfigId { get; set; }
        [Parameter] public int Year { get; set; }
        [Parameter] public int SortingLevel { get; set; }

        public StandingsViewModel StandingsModel { get; set; }

        protected override void OnInitialized()
        {
            CompetitionConfigId = 1;
            Year = 1;
            SortingLevel = 1;
            StandingsModel = StandingsService.GetStandings(CompetitionConfigId, Year, SortingLevel).Result;
            Year = 2;
        }
        
    }
}
