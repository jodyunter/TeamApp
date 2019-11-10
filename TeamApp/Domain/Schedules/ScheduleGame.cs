using TeamApp.Domain.Games;
using TeamApp.Domain.Competitions;
using System.Collections.Generic;
using System.Linq;

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
        public virtual CompetitionTeam HomeTeam { get; set; }
        public virtual CompetitionTeam AwayTeam { get; set; }

        
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

        public override void SetupGamePlayers()
        {
            HomePlayers = SetupPlayers(Home);
            AwayPlayers = SetupPlayers(Away);
        }
        //override this for competition game players
        public virtual IList<GamePlayer> SetupPlayers(CompetitionTeam team)
        {
            var result = new List<GamePlayer>();

            var competitionTeam = 

            team.Players.ToList().ForEach(player =>
            {
                result.Add(
                    new CompetitionGamePlayer(this, player, team, player.FirstYear, competitionTeam, compPlayer)
                    );
            });

            return result;
        }
    }
}
