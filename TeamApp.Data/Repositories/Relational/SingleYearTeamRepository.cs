using System.Linq;
using System.Collections.Generic;
using TeamApp.Data.Relational.Repositories;
using TeamApp.Domain;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Repositories;

namespace TeamApp.Data.Repositories.Relational
{
    public class SingleYearTeamRepository : DataRepository<SingleYearTeam>, ISingleYearTeamRepository
    {
        public SingleYearTeamRepository(IRelationalRepository<SingleYearTeam> repo) : base(repo) { }

        public IEnumerable<SingleYearTeam> GetByCompetition(Competition competition)
        {
            return baseRepo.Where(t => t.Competition == competition).ToList();
        }
    }
}
