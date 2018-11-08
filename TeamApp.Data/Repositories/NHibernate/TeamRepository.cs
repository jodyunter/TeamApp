using System.Linq;
using TeamApp.Domain;
using TeamApp.Domain.Repositories;

namespace TeamApp.Data.Repositories.NHibernate
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        public Team GetByName(string name)
        {
            return this.Where(t => t.Name.Equals(name)).FirstOrDefault();
        }
    }
}
