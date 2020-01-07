using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamApp.Services;
using TeamApp.ViewModels.Views;
using TeamApp.ViewModels.Views.Games;

namespace TeamApp.Interface.Blazor.Pages.Games
{
    public partial class ScheduleDaySummaryBase : ComponentBase
    {
        [Inject] public IScheduleGameService GameService { get; set; }
        
        public ScheduleDaySummaryViewModel Day { get; set; }
               
        [Parameter]
        public int GivenDay { get; set;}
        [Parameter]
        public int GivenYear { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await RefreshData();

        }

        public async Task RefreshData()
        {
           

            Day = await GameService.GetScheduleDay(@GivenDay, @GivenYear);
            StateHasChanged();
        }


    }
}
