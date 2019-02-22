using System;
using System.Collections.Generic;
using System.Linq;
using TeamApp.Data.Repositories.Relational;
using TeamApp.Domain;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Repositories;

namespace TeamApp.Data.Relational.Repositories
{
    public class CompetitionRepository : DataRepository<Competition>, ICompetitionRepository
    {
        public CompetitionRepository(IRelationalRepository<Competition> repo) : base(repo) { }

        public Competition GetByNameAndYear(string name, int year)
        {
            return baseRepo.Where(c => c.Name.Equals(name) && c.Year == year).FirstOrDefault();
        }

        public IEnumerable<Competition> GetByYear(int year)
        {
            return baseRepo.Where(c => c.Year == year).ToList();
        }

        public IEnumerable<Competition> GetParentCompetitionsForCompetitionConfig(CompetitionConfig config, int year)
        {
            return baseRepo.Where(c => c.CompetitionConfig == config && c.Year == year);
        }

        public IEnumerable<Competition> GetStartedAndUnfinishedCompetitionsByYear(int year)
        {
            return baseRepo.Where(c => c.Started && !c.Finished && c.Year == year);
        }

        public bool IsCompetitionCompleteForYear(int year, CompetitionConfig config)
        {
            return baseRepo.Where(c => c.Finished && c.CompetitionConfig == config).Count() > 0;
        }
    }
}
