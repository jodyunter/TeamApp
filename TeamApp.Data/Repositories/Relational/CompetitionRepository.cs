using System;
using System.Collections.Generic;
using System.Linq;
using TeamApp.Data.Repositories.Relational;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Competitions.Config;
using TeamApp.Domain.Repositories;

namespace TeamApp.Data.Relational.Repositories
{
    public class CompetitionRepository : DataRepository<Competition>, ICompetitionRepository
    {        
        public CompetitionRepository(IRelationalRepository<Competition> repo) : base(repo) { }

        public IEnumerable<Competition> GetByLeagueAndYear(long leagueId, int year)
        {
            return baseRepo.Where(c => c.CompetitionConfig.League.Id == leagueId && c.Year == year).ToList();
        }

        public IEnumerable<Competition> GetByLeagueAndYear(long leagueId, int year, bool started, bool finished)
        {
            return baseRepo.Where(c => c.CompetitionConfig.League.Id == leagueId && c.Year == year && c.Started == started && c.Finished == finished).ToList();
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

            if (config.Parents == null)
                return new List<Competition>();

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

        public Competition GetCompetition(long id)
        {
            return baseRepo.Get(id);
        }
    }
}
