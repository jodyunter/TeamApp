using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Schedules
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

        //this should include a processed check too
        public bool IsComplete()
        {
            return Games.TrueForAll(g => g.Complete && g.Processed);
        }
        public bool DoesTeamPlayInDay(long teamId)
        {
            var result = false;

            Games.ForEach(game =>
            {
                if (game.HomeTeam.Id == teamId) result = true;
                else if (game.AwayTeam.Id == teamId) result = true;
            });

            return result;
        }

        public bool IsStarted()
        {
            return Games.TrueForAll(g => !g.Complete && !g.Processed);
        }

        public bool DoesAnyTeamPlayInDay(ScheduleDay other)
        {
            var result = false;

            other.Games.ForEach(game =>
            {
                result = result || DoesTeamPlayInDay(game.HomeTeam.Id) || DoesTeamPlayInDay(game.AwayTeam.Id);
            });

            return result;
        }


        public void AddGame(ScheduleGame game)
        {            
            game.Day = DayNumber;
            Games.Add(game);
        }
        public void AddGamesToDay(List<ScheduleGame> games)
        {
            games.ForEach(g =>
            {
                g.Day = DayNumber;
                Games.Add(g);
            });
        }

    }
}
