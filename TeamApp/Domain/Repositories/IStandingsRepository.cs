using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Repositories
{
    public interface IStandingsRepository<SeasonTeam>
    {
        IList<SeasonTeam> GetByYearAndName(int year, string name);
}
