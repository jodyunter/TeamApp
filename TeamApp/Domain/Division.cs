using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain
{
    public class Division:DataObject
    {
        public string Name { get; set; }
        public int? FirstYear { get; set; }
        public int? LastYear { get; set; }
        public List<Team> Teams { get; set; }
        public Division Parent { get; set; }
        public List<Division> Children { get; set; }

        public Division(string name, int? firstYear, int? lastYear, List<Team> teams, Division parent, List<Division> children)
        {
            Name = name;
            FirstYear = firstYear;
            LastYear = lastYear;
            Teams = teams;
            Parent = parent;
            Children = children;
        }
    }
}
