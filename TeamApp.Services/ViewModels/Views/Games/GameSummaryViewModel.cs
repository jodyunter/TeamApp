﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.ViewModels.Views.Games
{
    public class GameSummaryViewModel
    {
        public int DayNumber { get; set; }
        public string League { get; set; }
        public string Competition { get; set; }
        public bool Complete { get; set; }
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
    }
}
