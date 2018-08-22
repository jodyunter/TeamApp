using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Competition.Season
{
    public class SeasonTeam:ITeam
    {
        public string Name { get; set; }
        public int Skill { get; set; }        
        public Team Parent { get; set; }
        public Season Competition { get; set; }

        public SeasonDivision Division { get; set; }
        public SeasonTeamStats Stats { get; set; }
        public string Owner { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }

        public SeasonTeam(string name, int skill, Team parent, Season competition, SeasonDivision division, SeasonTeamStats stats, string owner, int year)
        {
            Name = name;
            Skill = skill;
            Parent = parent;
            Competition = competition;
            Division = division;
            Stats = stats;
            Owner = owner;
            StartYear = year;
            EndYear = year;
        }
    }
}
