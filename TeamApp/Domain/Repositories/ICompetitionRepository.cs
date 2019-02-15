using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competitions;

namespace TeamApp.Domain.Repositories
{
    public interface ICompetitionRepository:IRepository<Competition>
    {
        Competition GetByNameAndYear(string name, int year);
        IList<Competition> GetByYear(int year);
        int GetCurrentYearForLeague(League l);
    }
}
