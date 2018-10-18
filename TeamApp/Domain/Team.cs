using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain
{
   
    public class Team:DataObject, ITeam, ITimePeriod
    {
        public virtual string Name { get; set; }
        public virtual int Skill { get; set; }
        public virtual string Owner { get; set; }
        public virtual int? FirstYear { get; set; }
        public virtual int? LastYear { get; set; }
        public virtual bool Active { get; set; }

        public Team() { }
        public Team(string name, int skill, string owner, int? firstYear, int? lastYear, bool active)
        {
            Name = name;
            Skill = skill;
            Owner = owner;
            FirstYear = firstYear;
            LastYear = lastYear;
            Active = active;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
