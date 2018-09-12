using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Scheduler
{
    public class ScheduleDay
    {
        public int DayNumber { get; set; }
        public List<ScheduleGame> Games { get; set; }

        public ScheduleDay(int dayNumber)
        {
            DayNumber = dayNumber;
            Games = new List<ScheduleGame>();
        }
    }
}
