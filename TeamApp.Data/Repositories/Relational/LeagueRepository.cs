using TeamApp.Data.Repositories.Relational;
using TeamApp.Domain;
using TeamApp.Domain.Repositories;

namespace TeamApp.Data.Relational.Repositories
{
    public class LeagueRepository : DataRepository<League>, ILeagueRepository
    {
        public LeagueRepository(IRelationalRepository<League> repo) : base(repo) { }        
    }
}
