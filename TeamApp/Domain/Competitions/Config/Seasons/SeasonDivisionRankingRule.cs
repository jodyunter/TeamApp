namespace TeamApp.Domain.Competitions.Config.Seasons
{
    public class SeasonDivisionRankingRule :ITimePeriod
    {
        public int? FirstYear { get; set; }
        public int? LastYear { get; set; }

    }
}
