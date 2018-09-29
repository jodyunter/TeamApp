using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Competition.Seasons
{
    public class SeasonDivision
    {
        public Season Season { get; set; }
        public SeasonDivision ParentDivision { get; set; }
        public int Year;
        public string Name { get; set; }
        public List<SeasonTeam> Teams { get; set; }

        public SeasonDivision(Season season, SeasonDivision parentDivision, int year, string name, int level, int order, List<SeasonTeam> teams)
        {
            Season = season;
            ParentDivision = parentDivision;
            Year = year;
            Name = name;
            Teams = teams;
        }

        internal void AddTeam(SeasonTeam newTeam)
        {
            if (Teams == null) Teams = new List<SeasonTeam>();
            if (!Teams.Contains(newTeam)) Teams.Add(newTeam);
        }        
    }
}
