using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Games;
using TeamApp.Domain.Schedules;

namespace TeamApp.Console.Views
{
    public class ScheduleGameDayView
    {
        public ScheduleGame Game { get; set; }

        public ScheduleGameDayView(ScheduleGame game)
        {
            Game = game;
        }

        public string GetView()
        {
            var formatter = "{0,15}: {1,2}{5,2}{2,2} :{3,-15} {4}";
            var result = "";

            if (Game.Complete) result += " Final";
            else result += " " + Game.CurrentPeriod.DisplayWithSuffix();

            return string.Format(formatter, Game.Home.Name, Game.HomeScore, Game.AwayScore, Game.Away.Name, result, "-");
        }
    }
}
