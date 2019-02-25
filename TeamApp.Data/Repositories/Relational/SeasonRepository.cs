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
    }
}
