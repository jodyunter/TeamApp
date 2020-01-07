using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.ViewModels.Views.Competition;

namespace TeamApp.ViewModels.Views
{
    public class GameSummary : IViewModel
    {
        public int CurrentYear { get; set; }
        public int CurrentDay { get; set; }

        public IEnumerable<CompetitionSimpleViewModel> CompetitionForCurrentYear { get; set; }
        public bool AllowPlayGames { get; set; }
        public bool AllowStartNextCompetition { get; set; }
        public bool AllowIncrementYear { get; set; }
        public List<string> ErrorMessages { get; set; }
        public List<int> Years { get; set; } = new List<int>();

        public int Yesterday { get { return CurrentDay - 1; } }
        public int Today { get { return CurrentDay; } } 
        public int Tomorrow { get { return CurrentDay + 1; } }

        public void AddErrorMessage(string message)
        {
            if (ErrorMessages == null) ErrorMessages = new List<string>();

            ErrorMessages.Add(message);
        }
    }
}
