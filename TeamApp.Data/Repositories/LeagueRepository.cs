using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain;
using TeamApp.Domain.Repositories;

namespace TeamApp.Data.Repositories
{
    public class LeagueRepository : DataRepository<League>, ILeagueRepository
    {
        public LeagueRepository(IRepository<League> repo) : base(repo) { }
    }
}
