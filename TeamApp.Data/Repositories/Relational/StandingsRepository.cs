using System.Collections.Generic;
using System.Linq;
using TeamApp.Data.Repositories.Relational;
using TeamApp.Domain.Competitions.Seasons;
using TeamApp.Domain.Repositories;

namespace TeamApp.Data.Relational.Repositories
{
    public class StandingsRepository : DataRepository<SeasonTeam>, IStandingsRepository
    {
        private ICompetitionRepository compRepo;
        //private RepositoryNHibernate<SeasonTeam> repositoryNHibernate;

        public StandingsRepository(IRelationalRepository<SeasonTeam> repo, ICompetitionRepository competitionRepo) : base(repo) { compRepo = competitionRepo;  }

        public IList<SeasonTeam> GetByCompetition(long competitionId)
        {
            var competition = compRepo.Where(c => c.Id == competitionId).First();

            return baseRepo.Where(st => st.Competition == competition).ToList();
        }
    }
}
