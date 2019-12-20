using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competitions.Config.Playoffs;

namespace TeamApp.Data.Repositories.Relational.NHibernate.Mappers
{
    public class PlayoffCompetitionConfigMap : SubclassMap<PlayoffCompetitionConfig>
    {
        public PlayoffCompetitionConfigMap()
        {
            DiscriminatorValue("Playoff");

            HasMany(x => x.SeriesRules);
            HasMany(x => x.RankingRules);            
        }

    }

    public class PlayoffSeriesRuleMap:BaseTimePeriod<PlayoffSeriesRule>
    {
        public PlayoffSeriesRuleMap()
        {
            References(x => x.PlayoffConfig);
            Map(x => x.Name);
            Map(x => x.Round);
            Map(x => x.SeriesType);
            Map(x => x.SeriesNumber);
            References(x => x.GameRules);
            Map(x => x.HomeFromName);
            Map(x => x.HomeFromValue);
            Map(x => x.AwayFromName);
            Map(x => x.AwayFromValue);
            Map(x => x.HomeGameProgressionString);
            Map(x => x.WinnerGroupName);
            Map(x => x.WinnerRankFrom);
            Map(x => x.LoserGroupName);
            Map(x => x.LoserRankFrom);
            
        }
    }

    public class PlayoffRankingRuleMap:BaseTimePeriod<PlayoffRankingRule>
    {

        public PlayoffRankingRuleMap()
        {
            References(x => x.PlayoffConfig);
            Map(x => x.GroupName);
            Map(x => x.RankingGroupName);
            Map(x => x.SourceGroupName);
            Map(x => x.SourceFirstRank);
            Map(x => x.SourceLastRank);
            Map(x => x.DestinationFirstRank);
            Map(x => x.GroupSetupLevel);
        }
    }
}
