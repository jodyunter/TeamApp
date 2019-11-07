using FluentNHibernate.Mapping;
using TeamApp.Domain;

namespace TeamApp.Data.Repositories.Relational.NHibernate.Mappers
{
    public abstract class BaseTimePeriod<T>:BaseMap<T> where T : BaseDataObject, ITimePeriod
    {
        public BaseTimePeriod()
        {
            Map(x => x.FirstYear)
                .Nullable();
            Map(x => x.LastYear);

        }    
        
    }
}
