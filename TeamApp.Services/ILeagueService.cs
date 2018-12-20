using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Services
{
    public interface ILeagueService
    {
        IEnumerable<CompetitionConfigViewModel> GetCompetitionConfigs(long leagueId);
        IEnumerable<SeasonCompetitionConfigViewModel> GetSeasonCompetitionConfig(long competitiongConfigId);
    }
}
