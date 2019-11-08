using System.Linq;
using System.Collections.Generic;
using TeamApp.Data.Relational.Repositories;
using TeamApp.Domain;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Repositories;

namespace TeamApp.Data.Repositories.Relational
{
    public class CompetitionTeamRepository : DataRepository<CompetitionTeam>, ICompetitionTeamRepository
    {
        public CompetitionTeamRepository(IRelationalRepository<CompetitionTeam> repo) : base(repo) { }

        public IEnumerable<CompetitionTeam> GetByCompetition(Competition competition)
        {
            return baseRepo.Where(t => t.Competition == competition).ToList();
        }
    }
}
