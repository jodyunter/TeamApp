using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Services.ViewModels.Views
{
    public class GameSummary:IViewModel
    {
        public int CurrentYear { get; set; }
        public int CurrentDay { get; set; }
        public List<string> ErrorMessages { get; set; }

        public void AddErrorMessage(string message)
        {
            if (ErrorMessages == null) ErrorMessages = new List<string>();

            ErrorMessages.Add(message);
        }
    }
}
