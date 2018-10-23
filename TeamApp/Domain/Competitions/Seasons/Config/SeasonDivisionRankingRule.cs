
namespace TeamApp.Domain.Competitions.Seasons.Config
{
    public class SeasonDivisionRankingRule :ITimePeriod
    {
        public int? FirstYear { get; set; }
        public int? LastYear { get; set; }

    }
}
