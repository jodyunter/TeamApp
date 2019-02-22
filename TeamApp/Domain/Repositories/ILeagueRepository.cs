using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Repositories
{
    public interface ILeagueRepository:IRepository<League>
    {
        League GetByName(string name);
        IList<League> GetActiveLeagues(int year);
    }
}
