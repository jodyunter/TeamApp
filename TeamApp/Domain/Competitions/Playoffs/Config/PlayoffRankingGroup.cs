using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Competitions.Playoffs.Config
{
    public class PlayoffRankingGroup:BaseDataObject, ITimePeriod
    {
        public string Name { get; set; }
        public virtual PlayoffCompetitionConfig PlayoffConfig { get; set; }
        public PlayoffRankingGroup SourceRanks { get; set; } //if null then use the ranking rules to completely order them
        public int? FirstYear { get; set; }
        public int? LastYear { get; set; }
        public IEnumerable<PlayoffRankingRule> RankingRules { get; set; }
    }
}
