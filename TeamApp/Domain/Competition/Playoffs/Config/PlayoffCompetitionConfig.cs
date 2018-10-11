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
        public Dictionary<string, ICompetitionConfig> Parents { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }        
    }
}
