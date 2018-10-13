using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Competition.Playoffs
{
    public class PlayoffTeam : ISingleYearTeam
    {

        public string Name { get; set; }
        public int Skill { get; set; }
        public ICompetition Competition { get; set; }
        public Team Parent { get; set; }
        public string Owner { get; set; }
        public int? FirstYear { get; set; }
        public int? LastYear { get; set; }

        public PlayoffTeam(string name, int skill, Playoff competition, Team parent, string owner, int? firstYear)
        {
            Name = name;
            Skill = skill;
            Competition = competition;
            Parent = parent;
            Owner = owner;
            FirstYear = firstYear;
            LastYear = firstYear;
        }
    }
}
