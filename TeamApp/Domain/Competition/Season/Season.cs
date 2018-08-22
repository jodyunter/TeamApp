using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competition.Season.Config;

namespace TeamApp.Domain.Competition.Season
{
    public class Season
    {
        public SeasonCompetition Parent { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public List<SeasonDivision> Divisions { get; set; }
        public List<SeasonTeam> Teams { get; set; }

        public Season(SeasonCompetition parent, string name, int year)
        {
            Parent = parent;
            Name = name;
            Year = year;
        }
        
    }
}
