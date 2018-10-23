using System.Collections.Generic;

namespace TeamApp.Domain.Competitions
{
    public abstract class CompetitionConfig:BaseDataObject, ITimePeriod
    {
        public virtual string Name { get; set; }
        public virtual League League { get; set; }
        public virtual int Ordering { get; set; }
        public virtual GameRules GameRules { get; set; }
        //how do we setup generic rules?
        public virtual IList<CompetitionConfig> Parents { get; set; } //this would be the list of competitions where they could get thier teams from
        public virtual int? FirstYear { get; set; }
        public virtual int? LastYear { get; set; }

        protected CompetitionConfig() { }
        protected CompetitionConfig(string name, League league, int order, GameRules gameRules, List<CompetitionConfig> parents, int? firstYear, int? lastYear)
        {
            Name = name;
            League = league;
            Ordering = order;
            GameRules = gameRules;
            Parents = parents;
            FirstYear = firstYear;
            LastYear = lastYear;
        }

        public abstract Competition CreateCompetition(int year, List<Competition> parents);
    }
}
