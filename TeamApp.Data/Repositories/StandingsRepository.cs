using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Competitions.Seasons;
using TeamApp.Domain.Repositories;

namespace TeamApp.Data.Repositories
{
    public class StandingsRepository : DataRepository<SeasonTeam>, IStandingsRepository
    {
        private ICompetitionRepository compRepo;
        private NHibernate.RepositoryNHibernate<SeasonTeam> repositoryNHibernate;

        public StandingsRepository(IRepository<SeasonTeam> repo, ICompetitionRepository competitionRepo) : base(repo) { compRepo = competitionRepo;  }

        public IList<SeasonTeam> GetByCompetition(long competitionId)
        {
            var competition = compRepo.Where(c => c.Id == competitionId).First();

            return this.Where(st => st.Competition == competition).ToList();
        }
    }
}
