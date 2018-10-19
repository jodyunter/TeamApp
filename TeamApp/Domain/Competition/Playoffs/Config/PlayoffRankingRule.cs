using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Competition.Playoffs.Config
{
    public class PlayoffRankingRule:BaseDataObject
    {
        //you will get the same competition for the current year
        public virtual string GroupName { get; set; }
        public virtual int StartingRank { get; set; }
        public virtual CompetitionConfig SourceCompetition { get; set; }
        public virtual string SourceGroupName { get; set; }
        public virtual int SourceFirstRank { get; set; }
        public virtual int SourceLastRank { get; set; }
        //todo how to pool candidates, then sort them

        public PlayoffRankingRule() { }
        public PlayoffRankingRule(string groupName, int startingRank, CompetitionConfig sourceCompetition, string sourceGroupName, int sourceFirstRank, int sourceLastRank)
        {
            GroupName = groupName;
            StartingRank = startingRank;
            SourceCompetition = sourceCompetition;
            SourceGroupName = sourceGroupName;
            SourceFirstRank = sourceFirstRank;
            SourceLastRank = sourceLastRank;
        }
    }
}
