
using FluentNHibernate.Mapping;
using TeamApp.Domain.Competitions.Seasons;

namespace TeamApp.Data.Repositories.Relational.NHibernate.Mappers
{
    public class SeasonMap : SubclassMap<Season>
    {
        public SeasonMap()
        {
            DiscriminatorValue("Season");

            HasMany(x => x.Divisions).Cascade.All();
        }
    }

    public class SeasonTeamMap : SubclassMap<SeasonTeam>
    {
        public SeasonTeamMap()
        {
            DiscriminatorValue("Season");
            References(x => x.Division);
            References(x => x.Stats);
        }
    }

    public class SeasonDivisionMap:BaseMap<SeasonDivision>
    {

        public SeasonDivisionMap()
        {
            References(x => x.Season);
            References(x => x.ParentDivision);
            Map(x => x.Year);
            Map(x => x.Name);
            HasMany(x => x.Teams);
            Map(x => x.Level);
            Map(x => x.Ordering);
        }
    }

    public class SeasonTeamStatsMap:BaseMap<SeasonTeamStats>
    {
        public SeasonTeamStatsMap()
        {
            Map(x => x.Wins);
            Map(x => x.Loses);
            Map(x => x.Ties);
            Map(x => x.GoalsFor);
            Map(x => x.GoalsAgainst);
            Map(x => x.PointsPerWin);
            Map(x => x.PointsPerTie);            
        }
    }
}
