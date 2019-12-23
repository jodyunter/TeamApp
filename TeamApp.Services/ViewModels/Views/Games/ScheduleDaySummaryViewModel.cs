using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.ViewModels.Views.Games
{
    public class ScheduleDaySummaryViewModel
    {
        public string League { get; set; }
        public int Year { get; set; }
        public int Day { get; set; }
        public IEnumerable<GameSummaryViewModel> Games { get; set; }
    }
}
