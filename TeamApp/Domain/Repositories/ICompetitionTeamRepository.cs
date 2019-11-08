using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competitions;

namespace TeamApp.Domain.Repositories
{
    public interface ICompetitionTeamRepository:IRepository<CompetitionTeam>
    {
        IEnumerable<CompetitionTeam> GetByCompetition(Competition competition);
    }
}
