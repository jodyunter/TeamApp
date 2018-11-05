using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Services.ViewModels.Views
{
    public interface IViewModel
    {
        IViewModel GetViewModel(object obj);

    }
}
