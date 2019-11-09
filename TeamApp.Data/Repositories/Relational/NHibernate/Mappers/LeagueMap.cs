
using TeamApp.Domain;

namespace TeamApp.Data.Repositories.Relational.NHibernate.Mappers
{
    public class LeagueMap:BaseTimePeriod<League>
    {
        public LeagueMap()
        {
            Map(x => x.Name);
            HasMany(x => x.CompetitionConfigs).Cascade.All();
        }
    }
}
