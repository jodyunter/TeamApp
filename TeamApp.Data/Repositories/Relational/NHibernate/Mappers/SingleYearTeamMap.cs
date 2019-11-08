
using FluentNHibernate.Mapping;
using TeamApp.Domain;
using TeamApp.Domain.Competitions.Playoffs;
using TeamApp.Domain.Competitions.Seasons;

namespace TeamApp.Data.Repositories.Relational.NHibernate.Mappers
{
    public class SingleYearTeamMap:BaseTimePeriod<SingleYearTeam>
    {

        public SingleYearTeamMap()
        {
            HasOne(x => x.Competition);
            HasOne(x => x.Parent);
            Map(x => x.Name);
            Map(x => x.NickName);
            Map(x => x.ShortName);
            Map(x => x.Skill);
            Map(x => x.Owner);

            DiscriminateSubClassesOnColumn<string>("Type").AlwaysSelectWithValue();
        }
        
    }

    public class SeasonTeamMap:SubclassMap<SeasonTeam>
    {
        public SeasonTeamMap()
        {
            DiscriminatorValue("Season");
            HasOne(x => x.Division);
            HasOne(x => x.Stats);
        }
    }

    public class PlayoffTeamMap:SubclassMap<PlayoffTeam>
    {
        public PlayoffTeamMap()
        {
            DiscriminatorValue("Playoff");
        }
    }
}
