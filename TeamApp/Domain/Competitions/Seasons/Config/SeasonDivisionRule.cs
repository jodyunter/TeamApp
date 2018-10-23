namespace TeamApp.Domain.Competitions.Seasons.Config
{
    public class SeasonDivisionRule:BaseDataObject,ITimePeriod
    {
        public virtual SeasonCompetitionConfig Competition { get; set; }
        //todo eventually add a "from competition config"
        public virtual string DivisionName { get; set; }
        public virtual string ParentName { get; set; }
        public virtual int Level { get; set; }
        public virtual int Ordering { get; set; }
        public virtual int? FirstYear { get; set; }
        public virtual int? LastYear { get; set; }

        public SeasonDivisionRule() { }
        public SeasonDivisionRule(SeasonCompetitionConfig competition, string divisionName, string parentName, int level, int order, int? firstYear, int? lastYear)
        {
            Competition = competition;
            DivisionName = divisionName;
            ParentName = parentName;
            FirstYear = firstYear;
            LastYear = lastYear;
            Ordering = order;
            Level = level;
        }
    }
}
