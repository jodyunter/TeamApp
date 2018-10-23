﻿namespace TeamApp.Domain.Competitions.Seasons.Config
{
    public class SeasonScheduleRule:BaseDataObject,ITimePeriod
    {
        //todo a random setup, such as "This Division, Random, 2 home, 2 away"
        public const int TEAM_TYPE = 0;
        public const int DIVISION_TYPE = 1;
        public const int NONE = 2;

        public virtual SeasonCompetitionConfig Competition { get; set; }
        public virtual int HomeTeamType { get; set; } //division or team
        public virtual string HomeTeamValue { get; set; } //team or division name
        public virtual int AwayTeamType { get; set; } //division or team
        public virtual string AwayTeamValue { get; set; } //team or division name
        public virtual int Iterations { get; set; }
        public virtual bool HomeAndAway { get; set; }
        public virtual int? FirstYear { get; set; }
        public virtual int? LastYear { get; set; }

        public SeasonScheduleRule() { }
        public SeasonScheduleRule(SeasonCompetitionConfig competition, int homeTeamType, string homeTeamValue, int awayTeamType, string awayTeamValue, int iterations, bool homeAndAway, int? firstYear, int? lastYear)
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