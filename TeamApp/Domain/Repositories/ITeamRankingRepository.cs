﻿using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competitions;

namespace TeamApp.Domain.Repositories
{
    public interface ITeamRankingRepository:IRepository<TeamRanking>
    {
        IEnumerable<TeamRanking> GetByCompetition(long competitionId);
    }
}
