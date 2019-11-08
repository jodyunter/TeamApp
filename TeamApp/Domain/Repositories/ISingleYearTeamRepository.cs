using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competitions;

namespace TeamApp.Domain.Repositories
{
    public interface ISingleYearTeamRepository:IRepository<SingleYearTeam>
    {
        IEnumerable<SingleYearTeam> GetByCompetition(Competition competition);
    }
}
