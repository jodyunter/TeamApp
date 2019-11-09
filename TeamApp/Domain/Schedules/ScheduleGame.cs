using TeamApp.Domain.Games;
using TeamApp.Domain.Competitions;

namespace TeamApp.Domain.Schedules
{
    public class ScheduleGame:Game
    {
        //todo should be a subclass of game
        //league, gameNumber, year are unique        
        public virtual int GameNumber { get; set; }
        public virtual int Day { get; set; }
        public virtual int Year { get; set; }
        //todo set this into the constructors?
        public virtual Competition Competition { get; set; }
        public virtual bool Processed { get; set; }

        public ScheduleGame() : base() { }
        public ScheduleGame(Competition competition, int gameNumber, int day, int year, Team homeTeam, Team awayTeam, int homeScore, int awayScore, bool complete, int currentPeriod, int currentTime, GameRules rules, bool processed)            
            :base(homeTeam, awayTeam, rules, homeScore, awayScore, complete, currentPeriod, currentTime)
        {
            Competition = competition;         
            GameNumber = gameNumber;
            Day = day;
            Year = year;
            Processed = processed;
        }
    }
}
