using FluentNHibernate.Mapping;
using TeamApp.Domain;

namespace TeamApp.Data.Repositories.Relational.NHibernate.Mappers
{
    public class TeamMap:BaseTimePeriod<Team>
    {
        public TeamMap()
        {            
            Map(x => x.Name)
                .Length(32)
                .Not.Nullable();
            Map(x => x.NickName)
                .Length(32)
                .Nullable();
            Map(x => x.ShortName)
                .Length(32)
                .Nullable();
            Map(x => x.Skill);
            Map(x => x.Owner);                
            Map(x => x.Active);
            HasMany(x => x.Players);

        }    
        
    }
}
