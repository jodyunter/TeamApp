

using FluentNHibernate.Mapping;
using TeamApp.Domain.Competitions.Playoffs;
using TeamApp.Domain.Competitions.Playoffs.Series;

namespace TeamApp.Data.Repositories.Relational.NHibernate.Mappers
{
    public class PlayoffMap:SubclassMap<Playoff>
    {
        public PlayoffMap()
        {
            DiscriminatorValue("Playoff");

            Map(x => x.CurrentRound);
            HasMany(x => x.Series).Not.LazyLoad();
        }
    }

    public class PlayoffGameMap:SubclassMap<PlayoffGame>
    {
        public PlayoffGameMap()
        {
            DiscriminatorValue("Playoff");

            References(x => x.Series);
        }
    }

    public class PlayoffTeamMap : SubclassMap<PlayoffTeam>
    {
        public PlayoffTeamMap()
        {
            DiscriminatorValue("Playoff");
        }
    }

    public class PlayoffSeriesMap:BaseMap<PlayoffSeries>
    {
        public PlayoffSeriesMap()
        {
            DiscriminateSubClassesOnColumn<string>("Type").AlwaysSelectWithValue();

            References(x => x.Playoff);
            Map(x => x.Name);
            Map(x => x.Round);
            Map(x => x.StartingDay);
            References(x => x.HomeTeam);
            References(x => x.AwayTeam);
            HasMany(x => x.Games);
        }
    }

    public class BestOfSeriesMap:SubclassMap<BestOfSeries>
    {
        public BestOfSeriesMap()
        {
            DiscriminatorValue("BestOf");

            Map(x => x.HomeWins);
            Map(x => x.AwayWins);
            Map(x => x.RequiredWins);
        }
    }

    public class TotalGoalsSeriesMap : SubclassMap<TotalGoalsSeries>
    {
        public TotalGoalsSeriesMap()
        {
            DiscriminatorValue("TotalGoals");

            Map(x => x.GamesPlayed);
            Map(x => x.HomeScore);
            Map(x => x.AwayScore);
            Map(x => x.MinimumGames);
        }
    }
}
