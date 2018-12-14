using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competitions.Seasons;

namespace TeamApp.Domain.Repositories
{
    public interface IStandingsRepository:IRepository<SeasonTeam>
    {
        IList<SeasonTeam> GetByCompetition(int competitionId);
    }
}
