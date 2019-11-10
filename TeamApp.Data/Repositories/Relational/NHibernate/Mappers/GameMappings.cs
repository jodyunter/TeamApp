using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain;
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
            HasMany(x => x.HomePlayers);
            HasMany(x => x.AwayPlayers);

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

    public class GamePlayerMap:BaseTimePeriod<GamePlayer>
    {
         public GamePlayerMap()
        {
            Map(x => x.Name);
            Map(x => x.Age);
            Map(x => x.Offense);
            Map(x => x.Defense);
            Map(x => x.Goaltending);
            HasOne(x => x.Game);
            HasOne(x => x.Stats);
            HasOne(x => x.CurrentTeam);
            HasOne(x => x.ParentPlayer);

            DiscriminateSubClassesOnColumn<string>("Type").AlwaysSelectWithValue();
        }
    }

    public class PlayerStatsMap:BaseMap<PlayerStats>
    {
        public PlayerStatsMap()
        {
            HasOne(x => x.Player);
            Map(x => x.FaceOffsWon);
            Map(x => x.FaceOffsLoses);
            Map(x => x.CarrySuccess);
            Map(x => x.CarryFail);
            Map(x => x.CheckingSuccess);
            Map(x => x.CheckingFail);
            Map(x => x.ShotsOnGoal);
            Map(x => x.ShotsBlocked);
            Map(x => x.BlockingSuccess);
            Map(x => x.BlockingFail);
            Map(x => x.Goals);
            Map(x => x.Assists);
            Map(x => x.Saves);
            Map(x => x.GoalsAgainst);
            Map(x => x.PassSuccess);
            Map(x => x.PassFail);
            Map(x => x.PassMissed);
            Map(x => x.PassReceived);
            Map(x => x.InterceptionSuccess);
            Map(x => x.InterceptionFail);
            Map(x => x.CoverSuccess);
            Map(x => x.CoverFail);
            Map(x => x.Rebounds);
            Map(x => x.Wins);
            Map(x => x.Loses);
            Map(x => x.Ties);
            Map(x => x.GamesPlayed);

        }
    }
}
