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
        //todo iterations!
        public static Dictionary<int, ScheduleDay> CreateGamesTwoDifferentGroups(League league, int year, int lastGameNumber, int startDay, List<Team> homeTeams, List<Team> awayTeams, int iterations, bool homeAndAway, bool canTie, int maxOverTimePeriods)
        {

            int initialDays = 0;
            var aTeamList = new List<Team>();
            var bTeamList = new List<Team>();
            bool reverseHomeAndAway = false;

            //the larger team list has to be the top loop
            if (homeTeams.Count >= awayTeams.Count)
            {
                aTeamList = homeTeams;
                bTeamList = awayTeams;
                initialDays = homeTeams.Count;
            }
            else
            {
                bTeamList = homeTeams;
                aTeamList = awayTeams;
                reverseHomeAndAway = true;
                initialDays = awayTeams.Count;
            }

            int totalDays = initialDays;            

            var days = new Dictionary<int, ScheduleDay>();

            for (int i = 0 + startDay; i < totalDays + startDay; i++)
            {
                days.Add(i, new ScheduleDay(i));
            }

            int currentDay = startDay;            
            int teamStartDay = currentDay;   
            
            aTeamList.ForEach(aTeam =>
            {
                currentDay = teamStartDay;
                //for each home team loop through the away teams, increment the day by one and add the next game.
                bTeamList.ForEach(bTeam =>
                {
                    var game = new ScheduleGame(league, 0, currentDay, year,
                        reverseHomeAndAway ? bTeam:aTeam, reverseHomeAndAway ? aTeam:bTeam,
                        0, 0, false, canTie, maxOverTimePeriods);
                    days[currentDay].Games.Add(game);
                    
                    currentDay = GetNextDay(currentDay, startDay, initialDays, 1);

                });
                //when done the home team games, start on the previous day the last team started on and go through it again
                teamStartDay = GetNextDay(teamStartDay, startDay, initialDays, -1);
            });


            if (homeAndAway) CreateAwayGamesForHomeAndAway(days, totalDays + startDay);
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

        //todo iterations!
        public static Dictionary<int, ScheduleDay> CreateGamesSingleGroup(League league, int year, int lastGameNumber, int startDay, List<Team> teams, int iterations, bool homeAndAway, bool canTie, int maxOverTimePeriods)
        {        

            int[,] array = CreateArrayForScheduling(teams.Count);            

            int totalDays = teams.Count % 2 == 0 ? teams.Count - 1 : teams.Count;
            

            var days = new Dictionary<int, ScheduleDay>();

            for (int i = 0; i < totalDays; i++) days.Add(i + startDay, new ScheduleDay(i + startDay));
            //agorithm for swapping the values

            
            for (int d = startDay; d < totalDays + startDay; d++)
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    if (array[i, 0] != -1)
                    {
                        var g = new ScheduleGame(league, 0, i, year, teams[array[i, 0]], teams[array[i, 1]], 0, 0, false, canTie, maxOverTimePeriods);
                        days[d].Games.Add(g);
                    }

                }

                array = ProcessNextPosition(array);
            }

            if (homeAndAway) CreateAwayGamesForHomeAndAway(days, totalDays + startDay);

            foreach (KeyValuePair<int, ScheduleDay> data in days)
            {
                lastGameNumber = UpdateGameNumbers(lastGameNumber, data.Value);
            }

            return days;
        }

        public static Dictionary<int, ScheduleDay> CreateAwayGamesForHomeAndAway(Dictionary<int, ScheduleDay> days, int dayToStartHomeAndAway)
        {
            int count = 0;

            days.Keys.ToList().ForEach(dayNumber =>
            {
                int newDay = dayToStartHomeAndAway + count;
                if (!days.ContainsKey(newDay)) days.Add(newDay,new ScheduleDay(dayToStartHomeAndAway + count));

                days[dayNumber].Games.ForEach(game =>
                {
                    var g = new ScheduleGame(game.League, 0, newDay, game.Year, game.AwayTeam, game.HomeTeam, 0, 0, false, game.CanTie, game.MaxOverTimePeriods);
                    days[newDay].Games.Add(g);

                });

                count++;
            });
            return days;
        }

        public static int[,] CreateArrayForScheduling(int teams)
        {
            int firstSpot = 0;
            int size = -1;
            if (teams % 2 == 0)
            {
                size = teams / 2;
            }
            else
            {
                firstSpot = -1;
                size = teams / 2 + 1;

            }

            int[,] newArray = new int[size, 2];

            newArray[0, 0] = firstSpot;

            for (int i = 0; i < size; i++)
            {
                newArray[i, 1] = teams - 1 - i;
                if (i == 0) newArray[0, 0] = firstSpot;
                else newArray[i, 0] = firstSpot + i;
            }

            return newArray;

        }
        public static int[,] ProcessNextPosition(int[,] array)
        {

            int[,] oldArray = (int[,])array.Clone();
            int size = array.GetLength(0);

            array[0, 0] = oldArray[0, 0]; //keep the pivot point

            for (int i = 0; i < size; i++)
            {

                if (i == 0)
                {
                    array[0, 0] = oldArray[0, 0];
                    array[0, 1] = oldArray[1, 1];
                }
                else if (i == 1)
                {
                    array[1, 0] = oldArray[0, 1];
                    if (size == 2) array[1, 1] = oldArray[1, 0];
                    else array[1, 1] = oldArray[2, 1];
                }  
                else if (i == size - 1)
                {
                    array[size - 1, 0] = oldArray[size - 2, 0];
                    array[size - 1, 1] = oldArray[size - 1, 0];
                }
                else
                {
                    array[i, 0] = oldArray[i - 1, 0];
                    array[i, 1] = oldArray[i + 1, 1];
                }

            }


            return array;
        }



    }
}
