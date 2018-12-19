using System;
using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Repositories;

namespace TeamApp.Data.Repositories.NHibernate
{
    public class TeamRankingRepositoryNHibernate : RepositoryNHibernate<TeamRanking>, ITeamRankingRepository
    {
        public IList<TeamRanking> GetByCompetition(long competitionId)
        {
            return this.Where(tr => tr.Team.Competition.Id == competitionId).ToList();
        }
    }
}
