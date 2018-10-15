using System;
using System.Collections.Generic;
using System.Text;

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
        public Dictionary<string, ICompetitionConfig> Parents { get; set; }

        public PlayoffCompetitionConfig(string name, League league, int order, GameRules gameRules, int? firstYear, int? lastYear, List<PlayoffSeriesRule> seriesRules, Dictionary<string, ICompetitionConfig> parents)
        {
            Name = name;
            League = league;
            Order = order;
            GameRules = gameRules;
            FirstYear = firstYear;
            LastYear = lastYear;
            SeriesRules = seriesRules;
            Parents = parents;
        }
    }
}
