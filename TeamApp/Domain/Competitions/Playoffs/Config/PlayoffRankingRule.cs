using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Competitions.Playoffs.Config
{
    public class PlayoffRankingRule:BaseDataObject,ITimePeriod
    {
        public virtual PlayoffCompetitionConfig PlayoffConfig { get; set; }
        //you will get the same competition for the current year
        public virtual PlayoffRankingGroup Group { get; set; }
        public virtual int StartingRank { get; set; }
        public virtual CompetitionConfig SourceCompetition { get; set; }
        public virtual string SourceGroupName { get; set; }
        public virtual int SourceFirstRank { get; set; }
        public virtual int? SourceLastRank { get; set; }
        public virtual int? FirstYear { get; set; }
        public virtual int? LastYear { get; set; }

        //todo how to pool candidates, then sort them

        public PlayoffRankingRule() { }
        public PlayoffRankingRule(PlayoffCompetitionConfig config, string groupName, int startingRank, CompetitionConfig sourceCompetition, string sourceGroupName, int sourceFirstRank, int? sourceLastRank, int? firstYear, int? lastYear)
        {
            PlayoffConfig = config;
            GroupName = groupName;
            StartingRank = startingRank;
            SourceCompetition = sourceCompetition;
            SourceGroupName = sourceGroupName;
            SourceFirstRank = sourceFirstRank;
            SourceLastRank = sourceLastRank;
            FirstYear = firstYear;
            LastYear = lastYear;
        }
    }
}
