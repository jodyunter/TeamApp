using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamApp.Services;
using TeamApp.ViewModels.Views;
using TeamApp.ViewModels.Views.Competition;
using TeamApp.ViewModels.Views.Standings;

namespace TeamApp.Interface.Web.Pages.StandingsPage
{
    public partial class StandingsViewBase:ComponentBase
    {
        [Inject] IStandingsService StandingsService { get; set; }
        [Inject] ILeagueService LeagueService { get; set; }
        [Inject] IGameDataService GameDataService { get; set; }
        [Inject] ICompetitionService CompetitionService { get; set; }

        [Parameter] public int CompetitionConfigId { get; set; }
        [Parameter] public int Year { get; set; }
        [Parameter] public int SortingLevel { get; set; }

        public StandingsViewModel StandingsModel { get; set; }
        public IList<LeagueViewModel> Leagues { get; set; }

        public GameSummary GameData { get; set; }
        protected override void OnInitialized()
        {
            GameData = GameDataService.GetGameSummary().Result;
            Leagues = LeagueService.GetAll().ToList();
            var seasons = CompetitionService.GetCompetitionsByYear(GameData.CurrentYear).Result.Where(c => c.Type == CompetitionViewModel.SEASON_TYPE).ToList();
            if (seasons.Count > 0)
            {
                StandingsModel = StandingsService.GetStandings(seasons[0].Id, 1).Result;
            }
            else
            {
                StandingsModel = null;
            }


            
        }
        
    }
}
