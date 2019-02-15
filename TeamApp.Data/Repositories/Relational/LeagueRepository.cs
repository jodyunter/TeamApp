using TeamApp.Data.Repositories.Relational;
using TeamApp.Domain;
using TeamApp.Domain.Repositories;
using System.Linq;

namespace TeamApp.Data.Relational.Repositories
{
    public class LeagueRepository : DataRepository<League>, ILeagueRepository
    {
        public LeagueRepository(IRelationalRepository<League> repo) : base(repo) { }        

        public League GetByName(string name)
        {
            return this.Where(l => l.Name == name).FirstOrDefault();
        }
    }
}
