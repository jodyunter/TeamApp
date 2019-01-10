using System;
using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Repositories;

namespace TeamApp.Data.Repositories
{
    public class CompetitionRepository : DataRepository<Competition>, ICompetitionRepository
    {
        public CompetitionRepository(IRepository<Competition> repo) : base(repo) { }

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
