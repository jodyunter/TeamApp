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

        [Parameter]
        public int FirstDay { get; set; }
        [Parameter]
        public int CurrentDay { get; set; }
        [Parameter]
        public int Year { get; set; }

        [Inject] public IScheduleGameService GameService { get; set; }

        public int Yesterday { get { return CurrentDay - 1; } }
        public int Today { get { return CurrentDay - 1; } }
        public int Tomorrow  { get { return CurrentDay +1; } }

    }
}
