using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeamApp.ViewModels.Views.Competition.Playoff;

namespace TeamApp.Services
{
    public interface IPlayoffService
    {
        Task<PlayoffSummaryViewModel> GetPlayoffSummary(long competitionId);        
    }
}
