using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Competitions.Playoffs.Config
{
    public class PlayoffRankingRule:BaseDataObject,ITimePeriod
    {
        public virtual PlayoffCompetitionConfig PlayoffConfig { get; set; }        
        public virtual string GroupName { get; set; } //this is the name of the group we are creating
        public virtual string RankingGroupName { get; set; } //this is the name of the group you want the rank from
        public virtual string SourceGroupName { get; set; } //this is where the team(s) is coming from       
        public virtual int SourceFirstRank { get; set; } //this is the first rank you take
        public virtual int? SourceLastRank { get; set; } //this is the last rank you take, if it's null take them all
        public virtual int? FirstYear { get; set; } //this is the first effective year
        public virtual int? LastYear { get; set; }  //this is the lats effective year

        //todo how to pool candidates, then sort them
        //todo HOW TO RE POOL after a round?
        //todo how to create a second pool based on ranks from a previous pool?  TOP SEEDS combined with other groups
        public PlayoffRankingRule() { }
        public PlayoffRankingRule(PlayoffCompetitionConfig config, string groupName, string sourceGroupName, string rankingGroupName, int sourceFirstRank, int? sourceLastRank, int? firstYear, int? lastYear)
        {
            PlayoffConfig = config;
            GroupName = groupName;            
            SourceGroupName = sourceGroupName;
            SourceFirstRank = sourceFirstRank;
            SourceLastRank = sourceLastRank;
            FirstYear = firstYear;
            LastYear = lastYear;
            RankingGroupName = rankingGroupName;
        }
    }
}
