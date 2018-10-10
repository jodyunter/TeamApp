using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Competition.Playoffs
{
    public class PlayoffTeam : ISingleYearTeam
    {
        public Team Parent { get; set; }
        public string Name { get; set; }
        public int Skill { get; set; }
        public string Owner { get; set; }
        public int? FirstYear { get; set; }
        public int? LastYear { get; set; }
    }
}
