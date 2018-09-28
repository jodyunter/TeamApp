using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competition.Seasons;

namespace TeamApp.Domain.Scheduler
{
    public class ScheduleGame:Game
    {        
        //todo should be a subclass of game
        //league, gameNumber, year are unique
        public League League { get; set; }
        public int GameNumber { get; set; }
        public int Day { get; set; }
        public int Year { get; set; }

        public ScheduleGame() { }
        public ScheduleGame(League league, int gameNumber, int day, int year, Team homeTeam, Team awayTeam, int homeScore, int awayScore, bool complete, int currentPeriod, GameRules rules)
            :base(homeTeam, awayTeam, homeScore, awayScore, complete, currentPeriod, rules)
        {
            League = league;
            GameNumber = gameNumber;
            Day = day;
            Year = year;
        }
    }
}
