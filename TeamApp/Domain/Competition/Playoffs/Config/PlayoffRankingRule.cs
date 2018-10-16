using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Competition.Playoffs.Config
{
    public class PlayoffRankingRule
    {
        //you will get the same competition for the current year
        public ICompetitionConfig SourceCompetition { get; set; }
        public string GroupName { get; set; }        
        public string SourceGroupName { get; set; }
        public int FirstRank { get; set; }
        public int? LastRank { get; set; }
    }
}
