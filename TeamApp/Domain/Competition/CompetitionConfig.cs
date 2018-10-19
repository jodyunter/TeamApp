using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Competition
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

        public abstract ICompetition CreateCompetition(int year, List<ICompetition> parents);
    }
}
