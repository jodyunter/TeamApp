using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Competitions.Config.Seasons
{
    public class SeasonCompetitionConfigFinalRankingRule : CompetitionConfigFinalRankingRule
    {
        public string TeamsComeFromGroup { get; set; }        

        public override List<TeamRanking> GetTeamsForRule(Competition competition)
        {
            throw new NotImplementedException();
        }
    }
}
