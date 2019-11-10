

using FluentNHibernate.Mapping;
using TeamApp.Domain.Competitions.Config;
using TeamApp.Domain.Competitions.Config.Seasons;

namespace TeamApp.Data.Repositories.Relational.NHibernate.Mappers
{
    public class CompetitionConfigMap:BaseTimePeriod<CompetitionConfig>
    {

        public CompetitionConfigMap()
        {
            Map(x => x.Name);
            References(x => x.League);
            Map(x => x.Ordering);
            References(x => x.GameRules);
            HasMany(x => x.Parents);
            HasMany(x => x.FinalRankingRules);
            Map(x => x.CompetitionStartingDay);
            Map(x => x.FinalRankingGroupName);

            DiscriminateSubClassesOnColumn<string>("Type").AlwaysSelectWithValue();
        }
    }
    

    public class CompetitionConfigFinalRankingRuleMap:BaseTimePeriod<CompetitionConfigFinalRankingRule>
    {
        public CompetitionConfigFinalRankingRuleMap()
        {
            References(x => x.CompetitionConfig);
            Map(x => x.Name);
            Map(x => x.Rank);

            DiscriminateSubClassesOnColumn<string>("Type").AlwaysSelectWithValue();
        }
    }


}
