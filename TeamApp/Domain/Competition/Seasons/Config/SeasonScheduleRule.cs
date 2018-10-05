using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Competition.Seasons.Config
{
    public class SeasonScheduleRule:ITimePeriod
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
        public int? FirstYear { get; set; }
        public int? LastYear { get; set; }

        public SeasonScheduleRule(SeasonCompetition competition, int homeTeamType, string homeTeamValue, int awayTeamType, string awayTeamValue, int iterations, bool homeAndAway, int? firstYear, int? lastYear)
        {
            Competition = competition;
            HomeTeamType = homeTeamType;
            HomeTeamValue = homeTeamValue;
            AwayTeamType = awayTeamType;
            AwayTeamValue = awayTeamValue;
            Iterations = iterations;
            HomeAndAway = homeAndAway;
            FirstYear = firstYear;
            LastYear = lastYear;                   
        }
    }
}
