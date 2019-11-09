

using FluentNHibernate.Mapping;
using TeamApp.Domain.Competitions.Playoffs;

namespace TeamApp.Data.Repositories.Relational.NHibernate.Mappers
{
    public class PlayoffTeamMap : SubclassMap<PlayoffTeam>
    {
        public PlayoffTeamMap()
        {
            DiscriminatorValue("Playoff");
        }
    }
}
