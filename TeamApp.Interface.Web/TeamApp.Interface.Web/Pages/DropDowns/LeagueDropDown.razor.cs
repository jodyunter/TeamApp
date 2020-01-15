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
    public partial class LeagueDropDownBase:ComponentBase
    {
        [Inject] ILeagueService LeagueService { get; set; }
        [Inject] DropDownState DropDownState { get; set; }
        [Parameter] public IList<LeagueViewModel> Leagues { get; set; }
        
        public LeagueViewModel SelectedLeague { get; set; }        

        public string DropDownHeaderValue
        {
            get
            {
                var result = "League";
                return SelectedLeague == null ? result : result + " - " + SelectedLeague.Name;
            }
        }
        protected override void OnInitialized()
        {
            if (Leagues == null)
            {
                Leagues = LeagueService.GetAll().ToList();
            }


        }

        protected void ChooseLeague(LeagueViewModel chosenLeague)
        {
            SelectedLeague = chosenLeague;
            DropDownState.SetLeague(SelectedLeague);
        }
    }
}
