using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Repositories;

namespace TeamApp.Data.Repositories.NHibernate
{
    public class CompetitionRepositoryNHibernate:RepositoryNHibernate<Competition>, ICompetitionRepository
    {        
        public Competition GetByNameAndYear(string name, int year)
        {
            return this.Where(c => c.Name.Equals(name) && c.Year == year).First();
        }

        public IList<Competition> GetByYear(int year)
        {
            return this.Where(c => c.Year == year).ToList();
        }
    }
}
