using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competitions.Seasons;

namespace TeamApp.Domain.Repositories
{
    public interface ISeasonRepository:IRepository<Season>
    {
        Season GetByLeagueAndYear(int leagueId, int year);
    }
}
