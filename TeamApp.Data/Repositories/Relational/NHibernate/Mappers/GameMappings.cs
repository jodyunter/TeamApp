using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Games;

namespace TeamApp.Data.Repositories.Relational.NHibernate.Mappers
{
    public class GameRulesMap:BaseMap<GameRules>
    {
        public GameRulesMap()
        {
            Map(x => x.Name);
            Map(x => x.CanTie);
            Map(x => x.MaxOverTimePeriods);
            Map(x => x.MinimumPeriods);
            Map(x => x.HomeRange);
            Map(x => x.AwayRange);
        }

    }
}
