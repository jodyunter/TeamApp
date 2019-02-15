using System.Collections.Generic;
using TeamApp.Domain;
using TeamApp.Domain.Repositories;
using System.Linq;
using TeamApp.Data.Repositories.Relational;

namespace TeamApp.Data.Relational.Repositories
{
    public class TeamRepository:DataRepository<Team>, ITeamRepository
    {
        public TeamRepository(IRelationalRepository<Team> baseRepo) : base(baseRepo) { }
        public Team GetByName(string name)
        {
            return baseRepo.Where(t => t.Name.Equals(name)).FirstOrDefault();
        }

        public List<Team> GetByStatus(bool active)
        {
            return baseRepo.Where(t => t.Active == active).ToList();
        }
    }
}
