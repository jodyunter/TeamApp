using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamApp.Console.Views
{
    public class ScheduleDayView
    {
        public int CurrentYear { get; set; }
        public int CurrentDay { get; set; }
        public IList<ScheduleGameDayView> Games { get; set; }
        public string GetView()
        {
            var result = "Year: " + CurrentYear;
            result += "\nDay: " + CurrentDay;

            Games.ToList().ForEach(game =>
            {
                game.GetView();
            });

            return result;
        }
    }
}
