using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.ViewModels.Views
{
    public interface IViewModel
    {
        List<string> ErrorMessages { get; set; }
        void AddErrorMessage(string message);

    }
}
