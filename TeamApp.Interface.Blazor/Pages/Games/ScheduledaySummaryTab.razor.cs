using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamApp.ViewModels.Views.Games;

namespace TeamApp.Interface.Blazor.Pages.Games
{
    public partial class ScheduledaySummaryTabBase:ComponentBase
    {
        [Parameter]
        public ScheduleDaySummaryViewModel Day { get; set; }
        [Parameter]
        public int CurrentDay { get; set; }

        protected string GetDayString(int dayNumber)
        {
            return "Day " + dayNumber;
        }
    }
}
