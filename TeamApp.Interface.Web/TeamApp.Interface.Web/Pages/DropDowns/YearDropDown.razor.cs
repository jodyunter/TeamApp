using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamApp.Interface.Web.States;
using TeamApp.Services;
using TeamApp.ViewModels.Views;

namespace TeamApp.Interface.Web.Pages.DropDowns
{
    public partial class YearDropDown:ComponentBase
    {
        [Inject] ICompetitionService LeagueService { get; set; }
        [Inject] DropDownState DropDownState { get; set; }
        [Parameter] public LeagueViewModel SelectedLeague { get; set; }
                

        public string DropDownHeaderValue
        {
            get
            {
                var result = "League";
                return SelectedLeague == null ? result : result + " - " + SelectedLeague.Name
            }
        }
        protected override void OnInitialized()
        {            


        }

        protected void ChooseLeague(LeagueViewModel chosenLeague)
        {
            SelectedLeague = chosenLeague;
            DropDownState.SetLeague(SelectedLeague);
        }
    }
}
