

using TeamApp.Domain.Competitions.Config;

namespace TeamApp.Data.Repositories.Relational.NHibernate.Mappers
{
    public class CompetitionConfigMap:BaseTimePeriod<CompetitionConfig>
    {

        public CompetitionConfigMap()
        {
            Map(x => x.Name);
            HasOne(x => x.League);
            Map(x => x.Ordering);
            HasOne(x => x.GameRules);
            HasMany(x => x.Parents);
            HasMany(x => x.FinalRankingRules);
            Map(x => x.CompetitionStartingDay);
            Map(x => x.FinalRankingGroupName);
        }
    }

    public class CompetitionConfigFinalRankingRuleMap:BaseTimePeriod<CompetitionConfigFinalRankingRule>
    {
        public CompetitionConfigFinalRankingRuleMap()
        {

            Map(x => x.Name);
            Map(x => x.Rank);            
        }
    }
}
