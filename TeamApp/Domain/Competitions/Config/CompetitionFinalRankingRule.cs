using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Competitions.Config
{
    public abstract class CompetitionConfigFinalRankingRule: BaseDataObject, ITimePeriod
    {
        public const string FINAL_GROUP_NAME = "FINAL STANDINGS";
        public string Name { get; set; }
        public int? FirstYear { get; set; }
        public int? LastYear { get; set; }        
        public int? StaringRank { get; set; }  //either assign a rank or get it from a group
        public int? EndingRank { get; set; }
        public abstract List<TeamRanking> GetTeamsForRule(Competition competition);
    }
}
