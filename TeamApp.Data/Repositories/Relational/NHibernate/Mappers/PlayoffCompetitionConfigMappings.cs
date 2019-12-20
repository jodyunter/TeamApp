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

            /*
                    public enum Type { BestOf, TotalGoals };
        public enum Result { Winner, Loser };

        public virtual PlayoffCompetitionConfig PlayoffConfig { get; set; }
        public virtual string Name { get; set; }
        public virtual int Round { get; set; }
        public virtual Type SeriesType { get; set; }
        public virtual int SeriesNumber { get; set; } //total games for total goals, or required wins
        public virtual GameRules GameRules { get; set; } //can be different!

        public virtual string HomeFromName { get; set; } //ranking group name
        public virtual int HomeFromValue { get; set; } //ranking number, or winner or loser        
        public virtual string AwayFromName { get; set; }
        public virtual int AwayFromValue { get; set; }
        public virtual int? FirstYear { get; set; }
        public virtual int? LastYear { get; set; }
        public virtual int[] HomeGameProgression { get; set; }
        public virtual string WinnerGroupName { get; set; } //this is where the winner goes to after the series is done
        public virtual string WinnerRankFrom { get; set; }  //this is the group from where the ranking number will be taken
        public virtual string LoserGroupName { get; set; }
        public virtual string LoserRankFrom { get; set; }
        */
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
}
