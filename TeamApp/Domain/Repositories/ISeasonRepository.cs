using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competitions.Seasons;

namespace TeamApp.Domain.Repositories
{
    public interface ISeasonRepository:IRepository<Season>
    {
        IList<Season> GetByLeagueAndYear(long leagueId, int year);
        Season GetBySeasonCompetitionConfigAndYear(long seasonCompetitionConfigId, int year);
    }
}
