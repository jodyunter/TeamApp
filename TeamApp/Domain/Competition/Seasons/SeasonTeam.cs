using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Competition.Seasons
{
    public class SeasonTeam:ISingleYearTeam,IComparable<SeasonTeam>
    {
        public string Name { get; set; }
        public int Skill { get; set; }        
        public Team Parent { get; set; }
        public Season Competition { get; set; }

        public SeasonDivision Division { get; set; }
        public SeasonTeamStats Stats { get; set; }
        public string Owner { get; set; }
        public int? FirstYear { get; set; }
        public int? LastYear { get; set; }

        public SeasonTeam(string name, int skill, Team parent, Season competition, SeasonDivision division, SeasonTeamStats stats, string owner, int year)
        {
            Name = name;
            Skill = skill;
            Parent = parent;
            Competition = competition;
            Division = division;            
            Stats = stats;            
            Owner = owner;
            FirstYear = year;
            LastYear = year;
            if (Stats == null) Stats = new SeasonTeamStats(this);
        }

        public int CompareTo(SeasonTeam other)
        {
            var thisStat = Stats;
            var thatStats = other.Stats;

            int statCompare = Stats.CompareTo(other.Stats);

            if (statCompare == 0)
            {
                return Name.CompareTo(other.Name);
            }
            else
                return statCompare;
        }
    }
}
