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
        int? FirstYear { get; set; }
        int? LastYear { get; set; }        
        string NickName { get; set; }
        string ShortName { get; set; }

    }
}
