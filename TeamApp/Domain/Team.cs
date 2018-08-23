using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain
{
    public class Team:ITeam
    {
        public string Name { get; set; }
        public int Skill { get; set; }
        public string Owner { get; set; }
        public int? FirstYear { get; set; }
        public int? LastYear { get; set; }


    }
}
