

using FluentNHibernate.Mapping;
using TeamApp.Domain.Competitions.Playoffs;

namespace TeamApp.Data.Repositories.Relational.NHibernate.Mappers
{
    public class PlayoffMap:SubclassMap<Playoff>
    {
        public PlayoffMap()
        {
            DiscriminatorValue("Playoff");

            Map(x => x.CurrentRound);
            HasMany(x => x.Series);
        }
    }
    public class PlayoffTeamMap : SubclassMap<PlayoffTeam>
    {
        public PlayoffTeamMap()
        {
            DiscriminatorValue("Playoff");
        }
    }
}
