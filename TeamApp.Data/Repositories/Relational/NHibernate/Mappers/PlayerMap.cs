using TeamApp.Domain;

namespace TeamApp.Data.Repositories.Relational.NHibernate.Mappers
{
    public class PlayerMap:BaseTimePeriod<Player>
    {
        public PlayerMap()
        {
            /*
             public virtual string Name { get; set; }
            public virtual int Age { get; set; } = 20;
            public virtual Team CurrentTeam { get; set; }
            public virtual int Offense { get; set; } = 10;
            public virtual int Defense { get; set; } = 10;
            public virtual int Goaltending { get; set; } = 10;
             */

            Map(x => x.Name);
            Map(x => x.Age);
            HasOne(x => x.CurrentTeam);
            Map(x => x.Offense);
            Map(x => x.Defense);
            Map(x => x.Goaltending);
        }
    }
}
