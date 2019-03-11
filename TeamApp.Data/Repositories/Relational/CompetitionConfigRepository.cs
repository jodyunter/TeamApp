using System;
using System.Collections.Generic;
using TeamApp.Data.Relational.Repositories;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Repositories;
using System.Linq;
using TeamApp.Domain;
using TeamApp.Domain.Competitions.Config;

namespace TeamApp.Data.Repositories.Relational
{
    public class CompetitionConfigRepository : DataRepository<CompetitionConfig>, ICompetitionConfigRepository
    {
        public CompetitionConfigRepository(IRelationalRepository<CompetitionConfig> repo) : base(repo) { }

        public IEnumerable<CompetitionConfig> GetConfigByStartingDayAndYear(int day, int year)
        {
            return baseRepo.Where(c => c.CompetitionStartingDay == null || c.CompetitionStartingDay == day).ToList().Where(c => c.IsActive(year));
        }

        public IEnumerable<CompetitionConfig> GetConfigByYear(int year)
        {
            return baseRepo.ToList().Where(c => c.IsActive(year));
        }
    }
}
