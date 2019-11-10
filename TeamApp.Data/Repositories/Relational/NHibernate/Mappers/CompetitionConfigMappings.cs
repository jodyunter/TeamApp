

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
            References(x => x.League).Cascade.All();
            Map(x => x.Ordering);            
            HasOne(x => x.GameRules).Cascade.All();
            HasMany(x => x.Parents).Cascade.All();
            HasMany(x => x.FinalRankingRules).Cascade.All();
            Map(x => x.CompetitionStartingDay);
            Map(x => x.FinalRankingGroupName);

            DiscriminateSubClassesOnColumn<string>("Type").AlwaysSelectWithValue();
        }
    }
    

    public class CompetitionConfigFinalRankingRuleMap:BaseTimePeriod<CompetitionConfigFinalRankingRule>
    {
        public CompetitionConfigFinalRankingRuleMap()
        {

            Map(x => x.Name);
            Map(x => x.Rank);

            DiscriminateSubClassesOnColumn<string>("Type").AlwaysSelectWithValue();
        }
    }


}
