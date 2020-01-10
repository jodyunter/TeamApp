using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamApp.Interface.Web.States;
using TeamApp.Services;
using TeamApp.ViewModels.Views;
using TeamApp.ViewModels.Views.Competition;
using TeamApp.ViewModels.Views.Standings;

namespace TeamApp.Interface.Web.Pages.StandingsPage
{
    public partial class StandingsViewBase:ComponentBase
    {
        [Inject] IStandingsService StandingsService { get; set; }
       
        [Inject] IGameDataService GameDataService { get; set; }
        [Inject] ICompetitionService CompetitionService { get; set; }

        [Inject] public AppState AppState { get; set; }

        [Parameter] public int CompetitionConfigId { get; set; }
        [Parameter] public int Year { get; set; }
        [Parameter] public int SortingLevel { get; set; }

        
        public StandingsViewModel StandingsModel { get; set; }        

        public GameSummary GameData { get; set; }
        protected override void OnInitialized()
        {
            GameData = GameDataService.GetGameSummary().Result;            
            var seasons = CompetitionService.GetCompetitionsByYear(GameData.CurrentYear).Result.Where(c => c.Type == CompetitionViewModel.SEASON_TYPE).ToList();
            if (seasons.Count > 0)
            {
                StandingsModel = StandingsService.GetStandings(seasons[0].Id, 1).Result;
            }
            else
            {
                StandingsModel = null;
            }

            AppState.OnChange += StateHasChanged;
        }

        public void Dispose()
        {
            AppState.OnChange -= StateHasChanged;
        }
    }
}
