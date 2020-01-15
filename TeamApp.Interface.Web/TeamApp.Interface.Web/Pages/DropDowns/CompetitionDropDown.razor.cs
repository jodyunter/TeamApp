using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamApp.Interface.Web.States;
using TeamApp.Services;
using TeamApp.ViewModels.Views;
using TeamApp.ViewModels.Views.Competition;

namespace TeamApp.Interface.Web.Pages.DropDowns
{
    public partial class CompetitionDropDown:ComponentBase
    {
        [Inject] ICompetitionService CompetitionService { get; set; }
        [Inject] DropDownState DropDownState { get; set; }
        [Parameter] public IList<CompetitionViewModel> Competitions { get; set; }
        
        public string SelectedYear { get; set; }        

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
            if (Competitions == null)
            {
                Competitions =CompetitionService.GetCompetitionListLeaugeAndYear(AppState.SelectedLeague.Year = LeagueService.GetAll().ToList();
            }


        }

        protected void ChooseLeague(LeagueViewModel chosenLeague)
        {
            SelectedLeague = chosenLeague;
            AppState.SetLeague(SelectedLeague);
        }
    }
}
