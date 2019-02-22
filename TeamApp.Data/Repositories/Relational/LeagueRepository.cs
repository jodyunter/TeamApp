using TeamApp.Data.Repositories.Relational;
using TeamApp.Domain;
using TeamApp.Domain.Repositories;
using System.Linq;
using System.Collections.Generic;

namespace TeamApp.Data.Relational.Repositories
{
    public class LeagueRepository : DataRepository<League>, ILeagueRepository
    {
        public LeagueRepository(IRelationalRepository<League> repo) : base(repo) { }        

        public League GetByName(string name)
        {
            return baseRepo.Where(l => l.Name == name).FirstOrDefault();
        }

        public IEnumerable<League> GetActiveLeagues(int year)
        {
            return baseRepo.Where(l => l.IsActive(year)).ToList();
        }
    }
}
