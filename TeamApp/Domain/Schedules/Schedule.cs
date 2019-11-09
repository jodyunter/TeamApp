using System;
using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain.Extensions;

namespace TeamApp.Domain.Schedules
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
            if (Days.ContainsKey(dayNumber)) throw new ApplicationException("Day already exists");
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

        public ScheduleDay GetNextNotStartedDay()
        {
            ScheduleDay nextDay = null;

            var list = Days.Keys.ToList();
            list.Sort();
            bool found = false;
            for (int i = 0; i < list.Count && !found; i++)
            {
                if (!Days[list[i]].IsStarted())
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

        public Dictionary<string, int> GetHomeGamesVsTeams(string teamName, List<string> opponents)
        {
            var result = new Dictionary<string, int>();

            Days.Values.ToList().ForEach(day =>
            {                
                day.Games.Where(g => g.Home.Name.Equals(teamName) && opponents.Contains(g.Away.Name)).ToList().ForEach(game =>
                {
                    if (!result.ContainsKey(game.Away.Name))
                    {
                        result[game.Away.Name] = 0;
                    }

                    result[game.Away.Name]++;
                });

                
            });

            return result;
        }

        public IEnumerable<ScheduleGame> GetGamesBetweenDays(int startingDay, int? finalDay)
        {
            var result = new List<ScheduleGame>();
            var lastDay = finalDay == null ? Days.Keys.Max() : finalDay;
            Days.ForEach((key,value) =>
            {
                result.AddRange(value.Games.Where(g => g.Day >= startingDay && g.Day <= lastDay));
            });

            return result;
            
        }
        public Dictionary<string, int> GetAwayGamesVsTeams(string teamName, List<string> opponents)
        {
            var result = new Dictionary<string, int>();

            Days.Values.ToList().ForEach(day =>
            {
                day.Games.Where(g => g.Away.Name.Equals(teamName) && opponents.Contains(g.Home.Name)).ToList().ForEach(game =>
                {
                    if (!result.ContainsKey(game.Home.Name))
                    {
                        result[game.Home.Name] = 0;
                    }

                    result[game.Home.Name]++;
                });


            });

            return result;
        }
    }
}
