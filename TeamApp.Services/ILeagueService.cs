using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Services.ViewModels.Views;
using TeamApp.Services.ViewModels.Views.CompetitionConfig;
using TeamApp.Services.ViewModels.Views.CompetitionConfig.Season;

namespace TeamApp.Services
{
    public interface ILeagueService
    {
        IEnumerable<LeagueViewModel> GetAll();
        IEnumerable<CompetitionConfigViewModel> GetCompetitionConfigs(long leagueId);
        IEnumerable<SeasonCompetitionConfigViewModel> GetSeasonCompetitionConfig(long competitiongConfigId);
        
    }
}
