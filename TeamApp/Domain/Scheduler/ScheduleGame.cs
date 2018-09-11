using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competition.Season;

namespace TeamApp.Domain.Scheduler
{
    public class ScheduleGame
    {        
        League League { get; set; }
        int GameNumber { get; set; }
        int Day { get; set; }
        int Year { get; set; }
        Team Team { get; set; }  //this unifies it among all competitions and history
        Season Season { get; set; } //if null it is exhibition game
        //future playoff option too
        int HomeScore { get; set; }
        int AwayScore { get; set; }
        bool Complete { get; set; }
        bool CanTie { get; set; }
        int MaxOverTimePeriods { get; set; }
    }
}
