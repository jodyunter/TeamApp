using FluentNHibernate.Mapping;
using TeamApp.Domain;

namespace TeamApp.Data.Repositories.Relational.NHibernate.Mappers
{
    public class GameDataMap:BaseMap<GameData>
    {
        /*
        public virtual int CurrentYear { get; set; }
        public virtual int CurrentDay { get; set; }
        */
        public GameDataMap()
        {
            Map(x => x.CurrentDay);
            Map(x => x.CurrentYear);
        }
        
    }

}
