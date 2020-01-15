using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamApp.ViewModels.Views;

namespace TeamApp.Interface.Web.States
{
    public class DropDownState
    {
        public LeagueViewModel SelectedLeague { get; private set; }
        public CompetitionViewModel SelectedCompetition { get; private set; }

        public event Action OnChange;

        public void SetLeague(LeagueViewModel league)
        {
            SelectedLeague = league;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
