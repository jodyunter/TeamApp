using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competition.Season;
using System.Linq;

namespace TeamApp.Domain.Scheduler
{
    public class Scheduler
    {
        //Assumption is that they can add days afterwards.  Different methods need to handle adding games to already established days
        public static List<ScheduleGame> CreateGamesTwoDifferentGroups(League league, int year, int lastGameNumber, int startDay, List<Team> homeTeams, List<Team> awayTeams, int iterations, bool homeAndAway, bool canTie, int maxOverTimePeriods)
        {

            int totalDays = homeTeams.Count > awayTeams.Count ? homeTeams.Count : awayTeams.Count;

            if (homeAndAway) totalDays *= 2;

            var days = new Dictionary<int, ScheduleDay>();

            for (int i = 1; i <= totalDays; i++)
            {
                days.Add(i, new ScheduleDay(i));
            }

            int currentDay = startDay;
            int maxDay = totalDays + startDay;

            int teamStartDay = currentDay;   
            
            homeTeams.ForEach(home =>
            {
                //for each home team loop through the away teams, increment the day by one and add the next game.
                awayTeams.ForEach(away =>
                {
                    var game = new ScheduleGame(league, 0, currentDay, year, home, away, 0, 0, false, canTie, maxOverTimePeriods);
                    days[currentDay].Games.Add(game);

                    currentDay = GetNextDay(currentDay, startDay, maxDay, 1);

                    if (homeAndAway)
                    {
                        int daysToSkip = totalDays / 2;
                        int gameDay = GetNextDay(currentDay, startDay, maxDay, daysToSkip);

                        var extraGame = new ScheduleGame(league, 0, gameDay, year, away, home, 0, 0, false, canTie, maxOverTimePeriods);
                        days[gameDay].Games.Add(game);

                    }
                });
                //when done the home team games, start on the previous day the last team started on and go through it again
                teamStartDay = GetNextDay(teamStartDay, startDay, maxDay, -1);
            });

            var result = new List<ScheduleGame>();

            //do the game numbers last so that they are in order by day
            foreach (KeyValuePair<int, ScheduleDay> data in days)
            {
                lastGameNumber++;

                data.Value.Games.ForEach(g => g.GameNumber = lastGameNumber);

                result.AddRange(data.Value.Games);
            }

            return result;

        }

        public static int GetNextDay(int currentDay, int startDay, int maxDay, int daysToIncrement)
        {
            currentDay += daysToIncrement;

            while (currentDay > maxDay) currentDay -= (maxDay - startDay);
            while (currentDay < startDay) return currentDay += (maxDay - startDay);

            return currentDay;
        }

        public static List<ScheduleGame> CreateGamesSingleGroup(League league, int lastGameNumber, int startDay, List<Team> teams, int iterations, bool homeAndAway)
        {
            return null;
        }

        private class ScheduleDay
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
}
