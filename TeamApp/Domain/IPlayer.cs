using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain
{
    public interface IPlayer:ITimePeriod
    {
        string Name { get; set; }
        int Age { get; set; }
        ITeam Team { get; set; }
        int Offense { get; set; }
        int Defense { get; set; }
        int Goaltending { get; set; }        
    }
}
