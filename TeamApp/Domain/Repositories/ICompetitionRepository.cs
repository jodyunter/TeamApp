using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competitions;

namespace TeamApp.Domain.Repositories
{
    public interface ICompetitionRepository:IRepository<Competition>
    {
        Competition GetByNameAndYear(string name, int year);        
        IEnumerable<Competition> GetByYear(int year);
       
        IEnumerable<Competition> GetStartedAndUnfinishedCompetitionsByYear(int year);
        IEnumerable<Competition> GetCompetitionsForCompetitionConfig(CompetitionConfig config, int year);
        IEnumerable<Competition> GetParentCompetitionsForCompetitionConfig(CompetitionConfig config, int year);
        bool IsCompetitionCompleteForYear(int year, CompetitionConfig config);
    }
}
