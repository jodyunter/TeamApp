using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain
{
    public class Team:DataObject, ITeam
    {
        public string Name { get; set; }
        public int Skill { get; set; }
        public string Owner { get; set; }
        public int? FirstYear { get; set; }
        public int? LastYear { get; set; }

        public Team() { }
        public Team(string name, int skill, string owner, int? firstYear, int? lastYear)
        {
            Name = name;
            Skill = skill;
            Owner = owner;
            FirstYear = firstYear;
            LastYear = lastYear;
        }
    }
}
