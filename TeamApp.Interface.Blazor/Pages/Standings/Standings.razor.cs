using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamApp.ViewModels.Views.Standings;

namespace TeamApp.Interface.Blazor.Pages.Standings
{
    public partial class StandingsCode : ComponentBase
    {

        [Parameter]
        public StandingsViewModel model { get; set; }


    }
}
