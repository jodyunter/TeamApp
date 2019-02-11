using TeamApp.Domain.Competitions;
using TeamApp.Domain.Repositories;
using System.Linq;
using System.Collections.Generic;

namespace TeamApp.Data.Relational.Repositories
{
    public class TeamRankingRepository : DataRepository<TeamRanking>, ITeamRankingRepository
    {
        public TeamRankingRepository(IRepository<TeamRanking> repo) : base(repo) { }
        public IList<TeamRanking> GetByCompetition(long competitionId)
        {
            return this.Where(tr => tr.Team.Competition.Id == competitionId).ToList();
        }
    }
}
