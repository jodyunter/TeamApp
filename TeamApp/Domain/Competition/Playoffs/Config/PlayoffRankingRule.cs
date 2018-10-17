using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Competition.Playoffs.Config
{
    public class PlayoffRankingRule
    {
        //you will get the same competition for the current year
        public string GroupName { get; set; }
        public int StartingRank { get; set; }        
        public ICompetitionConfig SourceCompetition { get; set; }        
        public string SourceGroupName { get; set; }
        public int SourceFirstRank { get; set; }
        public int SourceLastRank { get; set; }

    }
}
