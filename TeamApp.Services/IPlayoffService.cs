using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Services.ViewModels.Views.Competition.Playoff;

namespace TeamApp.Services
{
    public interface IPlayoffService
    {
        PlayoffSummaryViewModel GetPlayoffSummary(int competitionId);        
    }
}
