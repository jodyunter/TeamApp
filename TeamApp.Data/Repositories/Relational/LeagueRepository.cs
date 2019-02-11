using TeamApp.Domain;
using TeamApp.Domain.Repositories;

namespace TeamApp.Data.Relational.Repositories
{
    public class LeagueRepository : DataRepository<League>, ILeagueRepository
    {
        public LeagueRepository(IRepository<League> repo) : base(repo) { }        
    }
}
