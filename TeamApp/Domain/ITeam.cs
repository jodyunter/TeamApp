using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain
{
    public interface ITeam
    {
        string Name { get; set; }
        int Skill { get; set; }
        string Owner { get; set; }
        int StartYear { get; set; }
        int EndYear { get; set; }        

    }
}
