using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.ViewModels.Views
{
    public abstract class BaseViewModel : IViewModel
    {
        public List<string> ErrorMessages { get; set; }

        public void AddErrorMessage(string message)
        {
            if (ErrorMessages == null) ErrorMessages = new List<string>();

            ErrorMessages.Add(message);
        }
    }
}
