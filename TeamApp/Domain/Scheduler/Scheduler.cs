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
        public static Dictionary<int, ScheduleDay> CreateGamesTwoDifferentGroups(League league, int year, int lastGameNumber, int startDay, List<Team> homeTeams, List<Team> awayTeams, int iterations, bool homeAndAway, bool canTie, int maxOverTimePeriods)
        {

            int totalDays = homeTeams.Count > awayTeams.Count ? homeTeams.Count : awayTeams.Count;

            if (homeAndAway) totalDays *= 2;

            var days = new Dictionary<int, ScheduleDay>();

            for (int i = 0 + startDay; i < totalDays + startDay; i++)
            {
                days.Add(i, new ScheduleDay(i));
            }

            int currentDay = startDay;
            int maxDay = totalDays + startDay - 1;

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

                lastGameNumber = UpdateGameNumbers(lastGameNumber, data.Value);                
            }

            return days;

        }

        private static int UpdateGameNumbers(int lastGameNumber, ScheduleDay day)
        {
            lastGameNumber++;

            day.Games.ForEach(g => { g.GameNumber = lastGameNumber; lastGameNumber++; });

            return lastGameNumber;
        }

        public static int GetNextDay(int currentDay, int startDay, int maxDay, int daysToIncrement)
        {
            //normalize to zero first
            if (currentDay < startDay || currentDay > maxDay) throw new ApplicationException("Invalid Current Day value.");

            currentDay -= startDay;
            var totalDays = maxDay - startDay + 1;

            currentDay += daysToIncrement;

            currentDay = Mod(currentDay, totalDays);

            currentDay += startDay;

            return currentDay;
        }

        private static int Mod(int k, int n) { return ((k %= n) < 0) ? k + n : k; }

        public static List<ScheduleGame> CreateGamesSingleGroup(League league, int lastGameNumber, int startDay, List<Team> teams, int iterations, bool homeAndAway)
        {
            return null;
        }
    

    }
}
