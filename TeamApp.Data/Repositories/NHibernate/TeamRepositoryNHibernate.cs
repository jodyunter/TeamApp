using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain;
using TeamApp.Domain.Repositories;

namespace TeamApp.Data.Repositories.NHibernate
{
    public class TeamRepositoryNHibernate : RepositoryNHibernate<Team>, ITeamRepository
    {
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
