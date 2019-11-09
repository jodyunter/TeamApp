using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competitions.Config.Seasons;

namespace TeamApp.Data.Repositories.Relational.NHibernate.Mappers
{
    public class SeasonCompetitionConfigMap : SubclassMap<SeasonCompetitionConfig>
    {
        public SeasonCompetitionConfigMap()
        {
            DiscriminatorValue("Season");

            HasMany(x => x.TeamRules);
            HasMany(x => x.DivisionRules);
            HasMany(x => x.ScheduleRules);
        }


    }

    public class SeasonCompetitionConfigFinalRankingRuleMap : SubclassMap<SeasonCompetitionConfigFinalRankingRule>
    {
        public SeasonCompetitionConfigFinalRankingRuleMap()
        {
            DiscriminatorValue("Season");
            Map(x => x.TeamsComeFromGroup);
            Map(x => x.StartingRank);
            Map(x => x.EndingRank);
        }
    }

    public class SeasonDivisionRuleMap : BaseTimePeriod<SeasonDivisionRule>
    {
        public SeasonDivisionRuleMap()
        {
            HasOne(x => x.Competition);
            Map(x => x.DivisionName);
            HasOne(x => x.Parent);
            Map(x => x.Level);
            Map(x => x.Ordering);
            HasMany(x => x.Teams);
        }
    }

    public class SeasonScheduleRuleMap:BaseTimePeriod<SeasonScheduleRule>
    {
        public SeasonScheduleRuleMap()
        {

            HasOne(x => x.Competition);
            HasOne(x => x.HomeTeam);
            HasOne(x => x.AwayTeam);
            HasOne(x => x.HomeDivisionRule);
            HasOne(x => x.AwayDivisionRule);
            Map(x => x.Iterations);
            Map(x => x.HomeAndAway);            
        }
    }

    public class SeasonTeamRuleMap:BaseTimePeriod<SeasonTeamRule>
    {
        public SeasonTeamRuleMap()
        {
            HasOne(x => x.Competition);
            HasOne(x => x.Team);
            HasOne(x => x.Division);
        
        }
    }
}
