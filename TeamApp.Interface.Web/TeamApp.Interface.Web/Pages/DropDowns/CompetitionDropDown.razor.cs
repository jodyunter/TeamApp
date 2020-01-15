using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamApp.Interface.Web.States;
using TeamApp.Services;
using TeamApp.ViewModels.Views;
using TeamApp.ViewModels.Views.Competition;
using TeamApp.ViewModels.Views.CompetitionConfig;

namespace TeamApp.Interface.Web.Pages.DropDowns
{
    public partial class CompetitionDropDownBase:ComponentBase
    {
        [Inject] ILeagueService LeagueService { get; set; }
        [Inject] DropDownState DropDownState { get; set; }
        [Parameter] public IList<CompetitionConfigViewModel> Competitions { get; set; }
        
        public LeagueViewModel SelectedLeague { get; set; }        
        public CompetitionConfigViewModel SelectedCompetition { get; set; }
        public string DropDownHeaderValue
        {
            get
            {
                var result = SelectedLeague == null ? "" : SelectedLeague.Name;

                if (SelectedCompetition != null)
                {
                    result += " - "  + SelectedCompetition.Name;
                }

                return result;
            }
        }
        protected override void OnInitialized()
        {
            if (Competitions == null)
            {
                Competitions = LeagueService.GetCompetitionConfigs(SelectedLeague.Id).ToList();
            }

            DropDownState.OnChange += StateHasChanged;

        }

        protected void ChooseCompetition(CompetitionConfigViewModel chosenCompetition)
        {
            SelectedCompetition = chosenCompetition;
            DropDownState.SetSelectedCompetition(SelectedCompetition);
        }
    }
}
