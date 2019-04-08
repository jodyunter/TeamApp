using System;
using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain.Competitions.Playoffs;

namespace TeamApp.Domain.Competitions.Config.Playoffs
{
    public class PlayoffCompetitionConfigFinalRankingRule : CompetitionConfigFinalRankingRule
    {
        public PlayoffSeriesRule FromSeries { get; set; }
        public PlayoffSeriesRule.Result TeamStatus { get; set; } //winner or loser
        public string TieBreakingRankGroupName { get; set; }

        public override List<TeamRanking> GetTeamsForRule(Competition competition)
        {
            var playoff = (Playoff)competition;

            var series = playoff.Series.Where(s => s.Name.Equals(FromSeries.Name)).First();

            if (TeamStatus == PlayoffSeriesRule.Result.Winner)
            {
                return new List<TeamRanking>() { new TeamRanking((int)StaringRank, FINAL_GROUP_NAME, series.GetWinner(), 1) };
            }
            else if (TeamStatus == PlayoffSeriesRule.Result.Loser)
            {
                return new List<TeamRanking>() { new TeamRanking((int)StaringRank, FINAL_GROUP_NAME, series.GetLoser(), 1) };
            }
            else
            {
                throw new Exception("Bad value in Team Status.");
            }
        }
    }
}
