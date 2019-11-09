
using FluentNHibernate.Mapping;
using TeamApp.Domain.Competitions.Seasons;

namespace TeamApp.Data.Repositories.Relational.NHibernate.Mappers
{
    public class SeasonMap : SubclassMap<Season>
    {
        public SeasonMap()
        {
            DiscriminatorValue("Season");

            HasMany(x => x.Divisions);
        }
    }

    public class SeasonTeamMap : SubclassMap<SeasonTeam>
    {
        public SeasonTeamMap()
        {
            DiscriminatorValue("Season");
            HasOne(x => x.Division);
            HasOne(x => x.Stats);
        }
    }
}
