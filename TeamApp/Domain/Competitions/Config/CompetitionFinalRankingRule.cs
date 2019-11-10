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
        public virtual CompetitionConfig CompetitionConfig { get; set; }
        public abstract IList<TeamRanking> GetTeamsForRule(Competition competition);

        public CompetitionConfigFinalRankingRule() { }
        public CompetitionConfigFinalRankingRule(CompetitionConfig competitionConfig, string name, int? rank, int? firstYear, int? lastYear)
        {
            CompetitionConfig = competitionConfig;
            Name = name;
            FirstYear = firstYear;
            LastYear = lastYear;
            Rank = rank;
        }
    }
}
