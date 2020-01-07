using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamApp.ViewModels.Views.Competition.Playoff;

namespace TeamApp.Interface.Blazor.Pages.Playoffs
{
    public partial class PlayoffsBase:ComponentBase
    {
        [Parameter]
        public PlayoffSummaryViewModel model { get; set; }

    }
}
