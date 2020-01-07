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
        public ScheduleDaySummaryViewModel day1;
        public ScheduleDaySummaryViewModel day2;
        public ScheduleDaySummaryViewModel day3;
        public PlayoffSummaryViewModel playoffs;
        public ScheduleDaySummaryTabs DayTabs;

        [Inject] public IScheduleGameService GameService { get; set; }
        [Inject] IGameDataService GameDataService { get; set; }
        [Inject] ICompetitionService CompetitionService { get; set; }
        [Inject] IStandingsService StandingsService { get; set; }
        [Inject] IPlayoffService PlayoffService { get; set; }

        public int FirstDay { get; set; }
        private int daysToShow = 3;

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
            
            var days = await GameService.GetScheduleDays(FirstDay, daysToShow, @summary.CurrentYear);
            day1 = days[0];
            day2 = days[1];
            day3 = days[2];

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
