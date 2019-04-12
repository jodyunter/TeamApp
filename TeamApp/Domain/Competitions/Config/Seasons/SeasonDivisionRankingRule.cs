namespace TeamApp.Domain.Competitions.Config.Seasons
{
    public class SeasonDivisionRankingRule :ITimePeriod
    {
        //would be similar to playoff ranking rule, maybe just genericize it?
        public int? FirstYear { get; set; }
        public int? LastYear { get; set; }

    }
}
