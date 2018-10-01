using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Competition.Seasons.Config
{
    public class SeasonScheduleRule
    {
        public const int TEAM_TYPE = 0;
        public const int DIVISION_TYPE = 1;
        public const int NONE = 2;

        public SeasonCompetition Competition { get; set; }
        public int HomeTeamType { get; set; } //division or team
        public string HomeTeamValue { get; set; } //team or division name
        public int AwayTeamType { get; set; } //division or team
        public string AwayTeamValue { get; set; } //team or division name
        public int Iterations { get; set; }
        public bool HomeAndAway { get; set; }


                
    }
}
