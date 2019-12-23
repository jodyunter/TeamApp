using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.ViewModels.Views;
using TeamApp.ViewModels.Views.CompetitionConfig;
using TeamApp.ViewModels.Views.CompetitionConfig.Season;

namespace TeamApp.Services
{
    public interface ILeagueService
    {
        IEnumerable<LeagueViewModel> GetAll();
        IEnumerable<CompetitionConfigViewModel> GetCompetitionConfigs(long leagueId);
        IEnumerable<SeasonCompetitionConfigViewModel> GetSeasonCompetitionConfig(long competitiongConfigId);
        LeagueViewModel GetByName(string name);


    }
}
