using FluentNHibernate.Mapping;
using TeamApp.Domain;

namespace TeamApp.Data.Repositories.Relational.NHibernate.Mappers
{
    public abstract class BaseMap<T>:ClassMap<T> where T : BaseDataObject
    {
        public BaseMap()
        {
            Id(x => x.Id);
            Map(x => x.CreatedBy);
            Map(x => x.CreatedOn);
            Map(x => x.LastModifiedBy);
            Map(x => x.LastModifiedOn);

        }    
        
    }
}
