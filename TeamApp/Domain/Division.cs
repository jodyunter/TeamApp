using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain
{
    public class Division
    {
        public string Name { get; set; }
        public int FirstYear { get; set; }
        public int LastYear { get; set; }
        public List<Team> Teams { get; set; }
        public Division Parent { get; set; }
        public List<Division> Children { get; set; }
        
    }
}
