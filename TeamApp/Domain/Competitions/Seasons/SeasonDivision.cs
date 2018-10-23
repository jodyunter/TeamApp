﻿using System.Collections.Generic;

namespace TeamApp.Domain.Competitions.Seasons
{
    public class SeasonDivision
    {
        public Season Season { get; set; }
        public SeasonDivision ParentDivision { get; set; }
        public int Year;
        public string Name { get; set; }
        public List<SeasonTeam> Teams { get; set; }
        public int Level { get; set; }
        public int Ordering { get; set; }
        //need to add the ranking rules

        public SeasonDivision(Season season, SeasonDivision parentDivision, int year, string name, int level, int order, List<SeasonTeam> teams)
        {
            Season = season;
            ParentDivision = parentDivision;
            Year = year;
            Name = name;
            Teams = teams;
            Ordering = order;
            Level = level;
        }

        internal void AddTeam(SeasonTeam newTeam)
        {
            if (Teams == null) Teams = new List<SeasonTeam>();
            if (!Teams.Contains(newTeam)) Teams.Add(newTeam);
        }        
    }
}