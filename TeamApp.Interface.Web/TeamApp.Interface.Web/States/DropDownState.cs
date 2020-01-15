using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamApp.ViewModels.Views;
using TeamApp.ViewModels.Views.CompetitionConfig;

namespace TeamApp.Interface.Web.States
{
    public class DropDownState
    {
        public LeagueViewModel SelectedLeague { get; private set; }
        public CompetitionConfigViewModel SelectedCompetition { get; private set; }

        public event Action OnChange;

        public void SetSelectedCompetition(CompetitionConfigViewModel competition)
        {
            SelectedCompetition = competition;
            NotifyStateChanged();
        }

        public void SetLeague(LeagueViewModel league)
        {
            SelectedLeague = league;
            NotifyStateChanged();
        }
        
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
