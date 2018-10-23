﻿using TeamApp.Domain.Competitions;

namespace TeamApp.Domain.Schedules
{
    public class ScheduleGame:Game
    {        
        //todo should be a subclass of game
        //league, gameNumber, year are unique        
        public int GameNumber { get; set; }
        public int Day { get; set; }
        public int Year { get; set; }
        //todo set this into the constructors?
        public Competition Competition { get; set; }
        public bool Processed { get; set; }

        public ScheduleGame(Competition competition, int gameNumber, int day, int year, Team homeTeam, Team awayTeam, int homeScore, int awayScore, bool complete, int currentPeriod, GameRules rules, bool processed)
            :base(homeTeam, awayTeam, homeScore, awayScore, complete, currentPeriod, rules)
        {
            Competition = competition;         
            GameNumber = gameNumber;
            Day = day;
            Year = year;
            Processed = processed;
        }
    }
}
