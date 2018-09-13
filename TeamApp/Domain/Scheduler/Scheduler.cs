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
            if (homeAndAway) totalDays *= 2;

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

                    if (homeAndAway)
                    {
                        int daysToSkip = totalDays / 2;
                        int gameDay = GetNextDay(currentDay, startDay, totalDays, daysToSkip);

                        var extraGame = new ScheduleGame(league, 0, gameDay, year, 
                            reverseHomeAndAway ? aTeam : bTeam, reverseHomeAndAway ? bTeam : aTeam,
                            0, 0, false, canTie, maxOverTimePeriods);
                        days[gameDay].Games.Add(game);

                    }
                });
                //when done the home team games, start on the previous day the last team started on and go through it again
                teamStartDay = GetNextDay(teamStartDay, startDay, initialDays, -1);
            });
            
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

        public static Dictionary<int, ScheduleDay> CreateGamesSingleGroup(League league, int year, int lastGameNumber, int startDay, List<Team> teams, int iterations, bool homeAndAway, bool canTie, int maxOverTimePeriods)
        {        

            int[,] array = CreateArrayForScheduling(teams.Count);            

            int totalDays = teams.Count % 2 == 0 ? teams.Count - 1 : teams.Count;
            

            var days = new Dictionary<int, ScheduleDay>();

            for (int i = 0; i < totalDays; i++) days.Add(i + startDay, new ScheduleDay(i + startDay));
            //agorithm for swapping the values

            array = ProcessNextPosition(array);
            for (int d = startDay; d < totalDays + startDay; d++)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i, 0] != -1)
                    {
                        var g = new ScheduleGame(league, 0, i, year, teams[array[i, 0]], teams[array[i, 1]], 0, 0, false, canTie, maxOverTimePeriods);
                        days[d].Games.Add(g);
                    }

                }
            }

            foreach (KeyValuePair<int, ScheduleDay> data in days)
            {
                lastGameNumber = UpdateGameNumbers(lastGameNumber, data.Value);
            }

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

            int[,] newArray = new int[size, size];                                   

            for (int i = 0; i < newArray.Length; i++)
            {
                for (int j = 0; j <= 1; j++)
                {
                    if (i == 0 && j == 0) newArray[i, j] = firstSpot;
                    else
                    {
                        if (j == 0) newArray[i, j] = i + firstSpot;
                        else newArray[i, j] = teams - i - 1;
                    }
                }
            }

            return newArray;

        }
        public static int[,] ProcessNextPosition(int[,] array)
        {

            int[,] oldArray = (int[,])array.Clone();

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j <= 1; j++)
                {
                    //never change the 0,0 item, this is the pivot
                    if (i != 0 && j != 0)
                    {
                        //first deal with the two side swapping cases
                        //if we are in the first position, take it from the "top right"
                        if (i == 1 && j == 0) array[i, j] = oldArray[0, 1];
                        //if we are in the bottom right position, take it from the bottom left position
                        else if (i == array.Length - 1 && j == array.Length - 1) array[array.Length - 1, array.Length - 1] = oldArray[0, array.Length - 1];

                        //if we are on the left side somewhere, take the one above
                        else if (j == 0) array[i, 0] = oldArray[i - 1, 0];
                        //if we are on the right side somewhere, take the one below it
                        else array[i, j] = oldArray[i + 1, 1];

                    }
                }
            }


            return array;
        }



    }
}
