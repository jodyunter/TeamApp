using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using TeamApp.Interface.Blazor.Pages.Games;
using TeamApp.Services;
using TeamApp.ViewModels.Views;
using TeamApp.ViewModels.Views.Competition.Playoff;
using TeamApp.ViewModels.Views.Games;
using TeamApp.ViewModels.Views.Standings;

namespace TeamApp.Interface.Blazor.Pages
{
    public partial class SummaryCode: ComponentBase
    {
        public GameSummary summary;
        public StandingsViewModel standings;
        public ScheduleDaySummaryViewModel[] days;
        public PlayoffSummaryViewModel playoffs;
        public ScheduleDaySummaryTabs DayTabs;

        [Inject] IGameDataService GameDataService { get; set; }
        [Inject] ICompetitionService CompetitionService { get; set; }
        [Inject] IStandingsService StandingsService { get; set; }
        [Inject] IPlayoffService PlayoffService { get; set; }

        public int FirstDay { get; set; }


        protected override async Task OnInitializedAsync()
        {
            await RefreshData();

        }

        public async Task RefreshData()
        {
            summary = await GameDataService.GetGameSummary();
            FirstDay = summary.CurrentDay - 1;
            standings = await StandingsService.GetStandings(1, summary.CurrentYear, 1);
            playoffs = await PlayoffService.GetPlayoffSummary(2, summary.CurrentYear);

            if (DayTabs != null)
            {
                await DayTabs.FirstDayChanged(FirstDay);
            }

            StateHasChanged();

        }

        public bool ShowPlayDay()
        {
            return summary.AllowPlayGames;
        }

        public bool ShowStartNextYear()
        {
            return summary.AllowIncrementYear;
        }

        public bool ShowStartNextCompetition()
        {
            return summary.AllowStartNextCompetition;
        }

        async public void PlayDay(MouseEventArgs args)
        {
            GameDataService.PlayAndProcessDay();
            await RefreshData();
        }

        async public void StartNextCompetition(MouseEventArgs args)
        {
            GameDataService.StartNextCompetition();
            await RefreshData();
        }

        async public void StartNextYear(MouseEventArgs args)
        {
            GameDataService.StartNextYear();
            await RefreshData();
        }


    }
}
