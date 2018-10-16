using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamApp.Domain.Competition.Playoffs.Config
{
    public class PlayoffCompetitionConfig:ICompetitionConfig
    {
        public string Name { get; set; }
        public League League { get; set; }
        public int Order { get; set; }
        public GameRules GameRules { get; set; }
        public int? FirstYear { get; set; }
        public int? LastYear { get; set; }
        public List<PlayoffSeriesRule> SeriesRules { get; set; }
        public List<PlayoffRankingRule> Rankings { get; set; }
        public Dictionary<string, ICompetitionConfig> Parents { get; set; }

        public PlayoffCompetitionConfig(string name, League league, int order, GameRules gameRules, int? firstYear, int? lastYear, List<PlayoffRankingRule> rankings, List<PlayoffSeriesRule> seriesRules, Dictionary<string, ICompetitionConfig> parents)
        {
            Name = name;
            League = league;
            Order = order;
            GameRules = gameRules;
            FirstYear = firstYear;
            LastYear = lastYear;
            Rankings = rankings;
            SeriesRules = seriesRules;
            Parents = parents;
        }

        public ICompetition CreateCompetition(int year, List<ICompetition> Parents)
        {
            var playoff = new Playoff(this, Name, year, -1, 1, null, null, null);
            
            throw new NotImplementedException();
        }

        public void ProcessRankingRules(Playoff playoff, List<ICompetition> Parents)
        {
            Rankings.ForEach(rule =>
            {
                //get the competition
                var source = Parents.Where(p => p.Name.Equals(rule.SourceCompetition.Name)).FirstOrDefault();

                if (source == null) throw new ApplicationException("Playoff Ranking Rule has bad source competition: " + source);
                
            });
        }
        
    }
}
