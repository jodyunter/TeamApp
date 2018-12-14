using System.Linq;
using System.Collections.Generic;
using TeamApp.Domain.Competitions.Seasons;
using TeamApp.Domain.Repositories;
using TeamApp.Domain.Competitions;

namespace TeamApp.Data.Repositories.NHibernate
{
    public class StandingsRepositoryNHibernate : RepositoryNHibernate<SeasonTeam>, IStandingsRepository
    {
        private RepositoryNHibernate<Competition> compRepo;
        public StandingsRepositoryNHibernate()
        {
            compRepo = new RepositoryNHibernate<Competition>();
        }
        public IList<SeasonTeam> GetByCompetition(int competitionId)
        {
            return this.Where(st => st.Competition.Id == competitionId).ToList();
        }
    }
}
