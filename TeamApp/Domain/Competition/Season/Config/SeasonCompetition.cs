using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Competition.Season.Config
{
    //this is the configuration setup for seasons
    public class SeasonCompetition:ICompetition
    {
        public string Name { get; set; }
        public League League { get; set; }
        public int? FirstYear { get; set; }
        public int? LastYear { get; set; }
        public int Order { get; set; }
        public int StartDay { get; set; }
        public List<SeasonRule> Rules { get; set; }

        public SeasonCompetition(string name, League league, int? firstYear, int? lastYear, int order, int startDay, List<SeasonRule> rules)
        {
            Name = name;
            League = league;
            FirstYear = firstYear;
            LastYear = lastYear;
            Order = order;
            StartDay = startDay;
            Rules = rules;
        }
    }
}
