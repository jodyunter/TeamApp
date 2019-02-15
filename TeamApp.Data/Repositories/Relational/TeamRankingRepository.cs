using TeamApp.Domain.Competitions;
using TeamApp.Domain.Repositories;
using System.Linq;
using System.Collections.Generic;
using TeamApp.Data.Repositories.Relational;

namespace TeamApp.Data.Relational.Repositories
{
    public class TeamRankingRepository : DataRepository<TeamRanking>, ITeamRankingRepository
    {
        public TeamRankingRepository(IRelationalRepository<TeamRanking> repo) : base(repo) { }
        public IList<TeamRanking> GetByCompetition(long competitionId)
        {
            return baseRepo.Where(tr => tr.Team.Competition.Id == competitionId).ToList();
        }
    }
}
