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
            var days = new Dictionary<int, ScheduleDay>();

            int totalDays = teams.Count;
            if (teams.Count % 2 == 0) totalDays -= 1;

            for (int i = 1; i <= totalDays; i++) days.Add(i, new ScheduleDay(i + startDay));

            int currentDay = 1;
            int teamStartDay = 1;
            for (int i = 0; i < teams.Count - 1; i++)
            {
                currentDay = teamStartDay;
                for (int j = i + 1; j < teams.Count; j++)
                {
                    var game = new ScheduleGame(league, 0, currentDay + startDay, year, teams[i], teams[j], 0, 0, false, canTie, maxOverTimePeriods);
                    days[currentDay].Games.Add(game);
                    currentDay = GetNextDay(currentDay, 1, totalDays, 1);
                }

                teamStartDay = GetNextDay(teamStartDay, 1, totalDays, -1);
            }

            //duplicate the schedule but reverse the home and away
            if (homeAndAway)
            {
                for (int i = totalDays + 1; i <= totalDays * 2; i++)
                {
                    days.Add(i, new ScheduleDay(i + startDay));

                    days[i - totalDays].Games.ForEach(game =>
                    {
                        var g = new ScheduleGame(game.League, 0, i, year, game.AwayTeam, game.HomeTeam, 0, 0, false, canTie, maxOverTimePeriods);
                        days[i].Games.Add(g);
                    });                    
                }                
            }

            //do the game numbers last so that they are in order by day
            foreach (KeyValuePair<int, ScheduleDay> data in days)
            {
                lastGameNumber = UpdateGameNumbers(lastGameNumber, data.Value);
            }

            return days;
        }
    

    }
}
