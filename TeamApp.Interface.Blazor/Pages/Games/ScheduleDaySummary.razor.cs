using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamApp.ViewModels.Views.Games;

namespace TeamApp.Interface.Blazor.Pages.Games
{
    public partial class ScheduleDaySummaryBase:ComponentBase
    {
        [Parameter]
        public ScheduleDaySummaryViewModel Day { get; set; }

        public async Task DayChanged(ScheduleDaySummaryViewModel newDay)
        {
            Day = newDay;
            StateHasChanged();
        }

    }
}
