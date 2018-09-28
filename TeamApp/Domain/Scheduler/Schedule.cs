using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamApp.Domain.Scheduler
{
    public class Schedule
    {
        public Dictionary<int, ScheduleDay> Days { get; set; }

        public Schedule()
        {
            Days = new Dictionary<int, ScheduleDay>();
        }

        public void AddDay(int dayNumber)
        {
            Days.Add(dayNumber, new ScheduleDay(dayNumber));
        }

        public ScheduleDay GetNextInCompleteDay()
        {
            ScheduleDay nextDay = null;

            var list = Days.Keys.ToList();
            list.Sort();
            bool found = false;
            for (int i = 0; i < list.Count && !found; i++)
            {
                if (!Days[list[i]].IsComplete())
                {
                    found = true;
                    nextDay = Days[list[i]];
                }
            }

            return nextDay;
            
        }

        public bool IsComplete()
        {
            return GetNextInCompleteDay() == null;
        }
    }
}
