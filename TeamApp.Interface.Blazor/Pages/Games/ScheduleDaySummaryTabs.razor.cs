using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamApp.Services;
using TeamApp.ViewModels.Views.Games;

namespace TeamApp.Interface.Blazor.Pages.Games
{
    public partial class ScheduleDaySummaryTabsBase : ComponentBase
    {
        private int daysToShow = 3;

        public ScheduleDaySummaryViewModel[] Days { get; set; }        

        public ScheduleDaySummaryTab Day1 { get; set; }
        public ScheduleDaySummaryTab Day2 { get; set; }
        public ScheduleDaySummaryTab Day3 { get; set; }
        [Parameter]
        public int FirstDay { get; set; }
        [Parameter]
        public int CurrentDay { get; set; }
        [Parameter]
        public int Year { get; set; }

        [Inject] public IScheduleGameService GameService { get; set; }



    }
}
