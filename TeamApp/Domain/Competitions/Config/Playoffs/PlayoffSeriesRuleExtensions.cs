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

        public static PlayoffSeriesRule SetHomeFromRanking(this PlayoffSeriesRule rule, string fromGroup, int fromGroupRank)
        {
            return SetHomeFromRules(rule, FROM_RANKING, fromGroup, fromGroupRank);
        }

        public static PlayoffSeriesRule SetHomeFromSeriesWinner(this PlayoffSeriesRule rule, string winnerComesFrom)
        {
            return SetHomeFromRules(rule, FROM_SERIES, winnerComesFrom, GET_WINNER);
        }

        public static PlayoffSeriesRule SetHomeFromSeriesLoser(this PlayoffSeriesRule rule, string winnerComesFrom)
        {
            return SetHomeFromRules(rule, FROM_SERIES, winnerComesFrom, GET_LOSER);
        }

        public static PlayoffSeriesRule SetAwayFromRanking(this PlayoffSeriesRule rule, string fromGroup, int fromGroupRank)
        {
            return SetAwayFromRules(rule, FROM_RANKING, fromGroup, fromGroupRank);
        }

        public static PlayoffSeriesRule SetAwayFromSeriesWinner(this PlayoffSeriesRule rule, string winnerComesFrom)
        {
            return SetAwayFromRules(rule, FROM_SERIES, winnerComesFrom, GET_WINNER);
        }

        public static PlayoffSeriesRule SetAwayFromSeriesLoser(this PlayoffSeriesRule rule, string winnerComesFrom)
        {
            return SetAwayFromRules(rule, FROM_SERIES, winnerComesFrom, GET_LOSER);
        }

        public static PlayoffSeriesRule SetHomeFromRules(this PlayoffSeriesRule rule, int fromType, string fromName, int fromValue)
        {
            rule.HomeFromType = fromType;
            rule.HomeFromName = fromName;
            rule.HomeFromValue = fromValue;

            return rule;
        }

        public static PlayoffSeriesRule SetAwayFromRules(this PlayoffSeriesRule rule, int fromType, string fromName, int fromValue)
        {
            rule.AwayFromType = fromType;
            rule.AwayFromName = fromName;
            rule.AwayFromValue = fromValue;

            return rule;
        }
    }
}
