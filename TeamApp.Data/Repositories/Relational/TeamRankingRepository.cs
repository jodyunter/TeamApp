﻿using TeamApp.Domain.Competitions;
using TeamApp.Domain.Repositories;
using System.Linq;
using System.Collections.Generic;
using TeamApp.Data.Repositories.Relational;

namespace TeamApp.Data.Relational.Repositories
{
    public class TeamRankingRepository : DataRepository<TeamRanking>, ITeamRankingRepository
    {
        public TeamRankingRepository(IRelationalRepository<TeamRanking> repo) : base(repo) { }
        //this is no good, it doesn't make sense
        public IEnumerable<TeamRanking> GetByCompetition(long competitionId)
        {            
            return baseRepo.Where(tr => tr.CompetitionTeam.Competition.Id == competitionId).ToList();
        }
    }
}
