using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Competition.Season.Config
{    
    public class SeasonRule
    {
        public const int TEAM = 0;
        public const int DIVISION = 1;

        public Team Team { get; set; }
        public Division Division { get; set; }
        public int FirstYear { get; set; }
        public int SecondYear { get; set; }
        public int Type { get; set; }

    }
}
