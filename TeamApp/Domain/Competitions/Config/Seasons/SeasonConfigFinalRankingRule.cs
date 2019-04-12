using System.Linq;
using System.Collections.Generic;
using TeamApp.Domain.Competitions.Seasons;

namespace TeamApp.Domain.Competitions.Config.Seasons
{
    public class SeasonCompetitionConfigFinalRankingRule : CompetitionConfigFinalRankingRule
    {
        public virtual string TeamsComeFromGroup { get; set; }
        public virtual int? StartingRank { get; set; }
        public virtual int? EndingRank { get; set; }

        //we assume there is a division that is used as the final rankings
        public override IList<TeamRanking> GetTeamsForRule(Competition competition)
        {
            var season = (Season)competition;

            var sourceRankings = season.Rankings.Where(r => r.GroupName.Equals(TeamsComeFromGroup) 
            && (StartingRank == null || r.Rank >= StartingRank) //if null don't check starting rank
            && (EndingRank == null || r.Rank <= EndingRank)) //if null don't check ending rank
            .ToList();

            return sourceRankings;

        }

        public SeasonCompetitionConfigFinalRankingRule(string name, int? rank, string teamsComeFromGroupName, int? startingRank, int? endingRank, int? firstYear, int? lastYear)
            :base(name, rank, firstYear, lastYear)
        {
            TeamsComeFromGroup = teamsComeFromGroupName;
            StartingRank = startingRank;
            EndingRank = endingRank;
        }
    }
}
