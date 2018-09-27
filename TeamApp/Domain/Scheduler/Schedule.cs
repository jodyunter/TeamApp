using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Scheduler
{
    public class Schedule
    {
        public Dictionary<int, ScheduleDay> Days { get; set; }

        public void AddDay(int dayNumber)
        {
            Days.Add(dayNumber, new ScheduleDay(dayNumber));
        }

    }
}
