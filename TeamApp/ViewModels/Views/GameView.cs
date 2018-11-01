using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.ViewModels.Views
{
    public class GameView
    {
        public string League { get; set; }
        public string Competition { get; set; }
        public bool Complete { get; set; }
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
    }
}
