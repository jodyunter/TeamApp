using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Games;
using TeamApp.Domain.Schedules;

namespace TeamApp.Data.Repositories.Relational.NHibernate.Mappers
{
    public class GameMap : BaseMap<Game>
    {
        public GameMap()
        {
            HasOne(x => x.Home);
            HasOne(x => x.Away);
            Map(x => x.HomeScore);
            Map(x => x.AwayScore);
            Map(x => x.Complete);
            Map(x => x.CurrentPeriod);
            Map(x => x.CurrentTime);
            HasOne(x => x.Rules);

            DiscriminateSubClassesOnColumn<string>("Type").AlwaysSelectWithValue();
        }
    }

    public class ScheduleGameMap:SubclassMap<ScheduleGame>
    {
        public ScheduleGameMap()
        {
            Map(x => x.GameNumber);
            Map(x => x.Day);
            Map(x => x.Year);
            HasOne(x => x.Competition);
            Map(x => x.Processed);

            DiscriminatorValue("ScheduleGame");
        }
    }
    public class GameRulesMap:BaseMap<GameRules>
    {
        public GameRulesMap()
        {
            Map(x => x.Name);
            Map(x => x.CanTie);
            Map(x => x.MaxOverTimePeriods);
            Map(x => x.MinimumPeriods);
            Map(x => x.TimePerPeriod);
            Map(x => x.IsGoldenGoal);
        }

    }
}
