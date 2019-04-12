using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Competitions.Config
{
    public abstract class CompetitionConfigFinalRankingRule: BaseDataObject, ITimePeriod
    {        
        public virtual string Name { get; set; }
        public virtual int? FirstYear { get; set; }
        public virtual int? LastYear { get; set; }        
        public virtual int? Rank { get; set; }  //either assign a rank or get it from a group        
        public abstract IList<TeamRanking> GetTeamsForRule(Competition competition);

        public CompetitionConfigFinalRankingRule(string name, int? rank, int? firstYear, int? lastYear)
        {
            Name = name;
            FirstYear = firstYear;
            LastYear = lastYear;
            Rank = rank;
        }
    }
}
