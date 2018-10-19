using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain;

namespace TeamApp.Data.Maps
{
    public class TeamMap:ClassMap<Team>
    {
        public TeamMap()
        {            
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.Name).Not.Nullable();
            Map(x => x.NickName);
            Map(x => x.ShortName);
            Map(x => x.Skill);
            Map(x => x.Owner);
            Map(x => x.FirstYear);
            Map(x => x.LastYear);
            Map(x => x.Active);
            Map(x => x.CreatedBy);
            Map(x => x.LastModifiedBy);
            Map(x => x.LastModifiedOn);           
        }
    }
}
