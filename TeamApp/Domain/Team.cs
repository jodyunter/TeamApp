﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain
{
   
    public class Team:BaseDataObject, ITeam, ITimePeriod
    {
        public virtual string Name { get; set; }
        public virtual string NickName { get; set; }
        public virtual string ShortName { get; set; }
        public virtual int Skill { get; set; }
        public virtual string Owner { get; set; }
        public virtual int? FirstYear { get; set; }
        public virtual int? LastYear { get; set; }
        public virtual bool Active { get; set; }

        public Team():base() { }
        public Team(string name, string nickName, string shortName, int skill, string owner, int? firstYear, int? lastYear, bool active):base()
        {
            Name = name;
            NickName = nickName;
            ShortName = shortName;
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

        public override bool Equals(object obj)
        {
            var team = obj as Team;
            return team != null &&
                   Name == team.Name &&
                   NickName == team.NickName &&
                   ShortName == team.ShortName &&
                   Skill == team.Skill &&
                   Owner == team.Owner &&
                   EqualityComparer<int?>.Default.Equals(FirstYear, team.FirstYear) &&
                   EqualityComparer<int?>.Default.Equals(LastYear, team.LastYear) &&
                   Active == team.Active;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, NickName, ShortName, Skill, Owner, FirstYear, LastYear, Active);
        }

    }
}
