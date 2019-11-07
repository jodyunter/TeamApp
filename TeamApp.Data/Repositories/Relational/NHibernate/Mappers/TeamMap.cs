using FluentNHibernate.Mapping;
using TeamApp.Domain;

namespace TeamApp.Data.Repositories.Relational.NHibernate.Mappers
{
    public class TeamMap:ClassMap<Team>
    {/*
                public virtual string Name { get; set; }
        public virtual string NickName { get; set; }
        public virtual string ShortName { get; set; }
        public virtual int Skill { get; set; }
        public virtual string Owner { get; set; }
        public virtual int? FirstYear { get; set; }
        public virtual int? LastYear { get; set; }
        public virtual bool Active { get; set; }
        public virtual IList<Player> Players { get; set; }
                public virtual string CreatedBy { get; set; }
        public virtual DateTime CreatedOn { get; set; }
        public virtual string LastModifiedBy { get; set; }
        public virtual DateTime LastModifiedOn { get; set; }
        */
        public TeamMap()
        {
            Id(x => x.Id);
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
            Map(x => x.FirstYear)
                .Nullable();
            Map(x => x.LastYear)
                .Nullable();
            Map(x => x.Active);
            HasMany(x => x.Players);
            Map(x => x.CreatedBy);
            Map(x => x.CreatedOn);
            Map(x => x.LastModifiedBy);
            Map(x => x.LastModifiedOn);

        }    
        
    }
}
