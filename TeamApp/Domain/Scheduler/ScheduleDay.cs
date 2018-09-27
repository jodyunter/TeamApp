﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Scheduler
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


        public bool DoesTeamPlayInDay(string teamName)
        {
            var result = false;

            Games.ForEach(game =>
            {
                if (game.HomeTeam.Name.Equals(teamName)) result = true;
                else if (game.AwayTeam.Name.Equals(teamName)) result = true;
            });

            return result;
        }

        public bool DoesAnyTeamPlayInDay(ScheduleDay other)
        {
            var result = false;

            other.Games.ForEach(game =>
            {
                result = result || DoesTeamPlayInDay(game.HomeTeam.Name) || DoesTeamPlayInDay(game.AwayTeam.Name);
            });

            return result;
        }


        public void AddGame(ScheduleGame game)
        {            
            game.Day = DayNumber;
            Games.Add(game);
        }
        public void AddGamesToDay(ScheduleDay day, List<ScheduleGame> games)
        {
            games.ForEach(g =>
            {
                g.Day = day.DayNumber;
                day.Games.Add(g);
            });
        }

    }
}
