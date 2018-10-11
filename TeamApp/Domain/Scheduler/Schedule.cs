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
            if (Days[dayNumber] != null) throw new ApplicationException("Day already exists");
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

        public Dictionary<string, int> GetHomeGamesVsTeams(string teamName, List<string> opponents)
        {
            var result = new Dictionary<string, int>();

            Days.Values.ToList().ForEach(day =>
            {                
                day.Games.Where(g => g.HomeTeam.Name.Equals(teamName) && opponents.Contains(g.AwayTeam.Name)).ToList().ForEach(game =>
                {
                    if (!result.ContainsKey(game.AwayTeam.Name))
                    {
                        result[game.AwayTeam.Name] = 0;
                    }

                    result[game.AwayTeam.Name]++;
                });

                
            });

            return result;
        }

        public Dictionary<string, int> GetAwayGamesVsTeams(string teamName, List<string> opponents)
        {
            var result = new Dictionary<string, int>();

            Days.Values.ToList().ForEach(day =>
            {
                day.Games.Where(g => g.AwayTeam.Name.Equals(teamName) && opponents.Contains(g.HomeTeam.Name)).ToList().ForEach(game =>
                {
                    if (!result.ContainsKey(game.HomeTeam.Name))
                    {
                        result[game.HomeTeam.Name] = 0;
                    }

                    result[game.HomeTeam.Name]++;
                });


            });

            return result;
        }
    }
}
