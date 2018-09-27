using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competition.Seasons;

namespace TeamApp.Domain.Scheduler
{
    public class ScheduleGame
    {        
        //team league and year can be used to get the proper season or playoff or other team        
        public League League { get; set; }
        public int GameNumber { get; set; }
        public int Day { get; set; }
        public int Year { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public bool Complete { get; set; }
        public bool CanTie { get; set; }
        public int MaxOverTimePeriods { get; set; }

        public ScheduleGame() { }
        public ScheduleGame(League league, int gameNumber, int day, int year, Team homeTeam, Team awayTeam, int homeScore, int awayScore, bool complete, bool canTie, int maxOverTimePeriods)
        {
            League = league;
            GameNumber = gameNumber;
            Day = day;
            Year = year;
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            HomeScore = homeScore;
            AwayScore = awayScore;
            Complete = complete;
            CanTie = canTie;
            MaxOverTimePeriods = maxOverTimePeriods;
        }

        public Team GetWinner()
        {
            if (HomeScore > AwayScore) return HomeTeam;
            else if (AwayScore > HomeScore) return AwayTeam;
            else return null;
        }

        public Team GetLoser()
        {
            if (HomeScore > AwayScore) return AwayTeam;
            else if (AwayScore > HomeScore) return HomeTeam;
            else return null;
        }
    }
}
