using System.Collections.Generic;

namespace TeamApp.Domain.Competitions.Config.Seasons
{
    public class SeasonDivisionRule:BaseDataObject,ITimePeriod
    {
        public virtual SeasonCompetitionConfig Competition { get; set; }
        //todo eventually add a "from competition config"
        public virtual string DivisionName { get; set; }
        public virtual SeasonDivisionRule Parent { get; set; }
        public virtual int Level { get; set; }
        public virtual int Ordering { get; set; }
        public virtual int? FirstYear { get; set; }
        public virtual int? LastYear { get; set; }
        public virtual IEnumerable<SeasonTeamRule> Teams { get; set; }

        public SeasonDivisionRule() { }
        public SeasonDivisionRule(SeasonCompetitionConfig competition, string divisionName, SeasonDivisionRule parent, int level, int order, IEnumerable<SeasonTeamRule> teams, int? firstYear, int? lastYear)
        {
            Competition = competition;
            DivisionName = divisionName;
            Parent = parent;
            Teams = teams;
            FirstYear = firstYear;
            LastYear = lastYear;
            Ordering = order;
            Level = level;
        }
    }
}
