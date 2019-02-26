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

        public IEnumerable<Competition> GetByLeagueAndYear(int leagueId, int year)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Competition> GetByLeagueAndYear(int leagueId, int year, bool started, bool finished)
        {
            throw new NotImplementedException();
        }

        public Competition GetByNameAndYear(string name, int year)
        {
            return baseRepo.Where(c => c.Name.Equals(name) && c.Year == year).FirstOrDefault();
        }

        public IEnumerable<Competition> GetByYear(int year)
        {
            return baseRepo.Where(c => c.Year == year).ToList();
        }

        public Competition GetCompetitionForCompetitionConfig(CompetitionConfig config, int year)
        {
            return baseRepo.Where(c => c.CompetitionConfig == config && c.Year == year).FirstOrDefault();
        }

        public IEnumerable<Competition> GetParentCompetitionsForCompetitionConfig(CompetitionConfig config, int year)
        {
            var parentComps = new List<Competition>();

            config.Parents.ToList().ForEach(parentConfig =>
            {
                var parentComp = GetCompetitionForCompetitionConfig(parentConfig, year);
                if (parentComp != null) parentComps.Add(parentComp);
            });

            return parentComps;
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
