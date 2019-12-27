using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Competitions.Config;
using TeamApp.Domain.Competitions.Playoffs;

namespace TeamApp.Domain.Repositories
{
    public interface ICompetitionRepository:IRepository<Competition>
    {
        Competition GetByNameAndYear(string name, int year);        
        IEnumerable<Competition> GetByYear(int year);
        IEnumerable<Competition> GetByLeagueAndYear(long leagueId, int year);
        IEnumerable<Competition> GetByLeagueAndYear(long leagueId, int year, bool started, bool finished);
        IEnumerable<Competition> GetStartedAndUnfinishedCompetitionsByYear(int year);
        Competition GetCompetitionForCompetitionConfig(CompetitionConfig config, int year);
        IEnumerable<Competition> GetParentCompetitionsForCompetitionConfig(CompetitionConfig config, int year);
        bool IsCompetitionCompleteForYear(int year, CompetitionConfig config);
        Competition GetCompetition(long id);
        Competition GetByYearAndConfigId(long competitionConfigId, int year);
    }
}
