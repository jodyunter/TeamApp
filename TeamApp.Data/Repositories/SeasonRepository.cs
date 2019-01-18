using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competitions.Seasons;
using TeamApp.Domain.Repositories;

namespace TeamApp.Data.Repositories
{
    public class SeasonRepository:DataRepository<Season> : ISeasonRepository
    {
        public SeasonRepository(IRepository<Season> repo) : base(repo) { }

        public Season GetByLeagueAndYear(int leagueId, int year)
        {
            return this.Where
        }
    }
}
