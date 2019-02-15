using System.Collections.Generic;
using System.Linq;
using TeamApp.Data.Repositories.Relational;
using TeamApp.Domain.Competitions.Seasons;
using TeamApp.Domain.Repositories;

namespace TeamApp.Data.Relational.Repositories
{
    public class SeasonRepository:DataRepository<Season>, ISeasonRepository
    {
        public SeasonRepository(IRelationalRepository<Season> repo) : base(repo) { }

        public Season GetBySeasonCompetitionConfigAndYear(long seasonCompetitionConfigId, int year)
        {
            return baseRepo.Where(s => s.CompetitionConfig.Id == seasonCompetitionConfigId && s.Year == year).FirstOrDefault();
        }
        public IList<Season> GetByLeagueAndYear(long leagueId, int year)
        {
            return baseRepo.Where(s => s.CompetitionConfig.League.Id == leagueId && s.Year == year).ToList();
        }
    }
}
