using TeamApp.Domain;

namespace TeamApp.Data.Repositories.Relational.NHibernate.Mappers
{
    public class PlayerMap:BaseTimePeriod<Player>
    {
        public PlayerMap()
        {
           
            Map(x => x.Name);
            Map(x => x.Age);
            References(x => x.CurrentTeam);
            Map(x => x.Offense);
            Map(x => x.Defense);
            Map(x => x.Goaltending);
            //Not.Map(x => x.Team);
        }
    }
}
