using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Services.ViewModels.Views
{
    public abstract class BaseViewModel : IViewModel
    {
        public List<string> ErrorMessages { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void AddErrorMessage(string message)
        {
            if (ErrorMessages == null) ErrorMessages = new List<string>();

            ErrorMessages.Add(message);
        }
    }
}
