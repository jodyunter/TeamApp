using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain
{
    public interface ITeam:ITimePeriod
    {
        string Name { get; set; }
        string NickName { get; set; }
        string ShortName { get; set; }
        int Skill { get; set; }
        string Owner { get; set; }   

       
    }
}
