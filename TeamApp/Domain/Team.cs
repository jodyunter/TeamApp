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
        public int StartYear { get; set; }
        public int EndYear { get; set; }


    }
}
