using System;
using System.Collections.Generic;
using static TeamApp.Domain.Competitions.Config.Playoffs.PlayoffSeriesRule;

namespace TeamApp.Domain.Competitions.Config.Playoffs
{
    public static class PlayoffSeriesRuleExtensions
    {
        public static PlayoffSeriesRule SetGameProgression(this PlayoffSeriesRule rule, int[] progression)
        {
            rule.HomeGameProgression = progression;

            return rule;
        }

        public static PlayoffSeriesRule SetWinnerData(this PlayoffSeriesRule rule, string winnerGroup, string winnerRankFrom)
        {
            rule.WinnerGroupName = winnerGroup;
            rule.WinnerRankFrom = winnerRankFrom;

            return rule;
        }

        public static PlayoffSeriesRule SetLoserData(this PlayoffSeriesRule rule, string loserGroup, string loserRankFrom)
        {
            rule.LoserGroupName = loserGroup;
            rule.LoserRankFrom = loserRankFrom;

            return rule;
        }

        public static PlayoffSeriesRule SetHomeFromRules(this PlayoffSeriesRule rule, string fromName, int fromValue)
        {            
            rule.HomeFromName = fromName;
            rule.HomeFromValue = fromValue;

            return rule;
        }

        public static PlayoffSeriesRule SetAwayFromRules(this PlayoffSeriesRule rule, string fromName, int fromValue)
        {            
            rule.AwayFromName = fromName;
            rule.AwayFromValue = fromValue;

            return rule;
        }
    }
}
