using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competitions;

namespace TeamApp.Domain.Repositories
{
    public interface ICompetitionConfigRepository:IRepository<CompetitionConfig>
    {
        IEnumerable<CompetitionConfig> GetConfigByStartingDayAndYear(int day, int year);
        IEnumerable<CompetitionConfig> GetConfigByYear(int year);
    }
}
