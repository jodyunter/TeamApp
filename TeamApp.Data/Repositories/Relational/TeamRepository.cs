using System.Collections.Generic;
using TeamApp.Domain;
using TeamApp.Domain.Repositories;
using System.Linq;
namespace TeamApp.Data.Relational.Repositories
{
    public class TeamRepository:DataRepository<Team>, ITeamRepository
    {
        public TeamRepository(IRepository<Team> baseRepo) : base(baseRepo) { }
        public Team GetByName(string name)
        {
            return this.Where(t => t.Name.Equals(name)).FirstOrDefault();
        }

        public List<Team> GetByStatus(bool active)
        {
            return this.Where(t => t.Active == active).ToList();
        }
    }
}
