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
        public virtual CompetitionTeam CompetitionHomeTeam { get; set; }
        public virtual CompetitionTeam CompetitionAwayTeam { get; set; }

        
        public ScheduleGame() : base() { }
        public ScheduleGame(Competition competition, int gameNumber, int day, int year, Team homeTeam, CompetitionTeam homeCompetitionTeam, Team awayTeam, CompetitionTeam awayCompetitionTeam, int homeScore, int awayScore, bool complete, int currentPeriod, int currentTime, GameRules rules, bool processed)            
            :base(homeTeam, awayTeam, rules, homeScore, awayScore, complete, currentPeriod, currentTime)
        {
            Competition = competition;         
            GameNumber = gameNumber;
            Day = day;
            Year = year;
            Processed = processed;
            CompetitionHomeTeam = homeCompetitionTeam;
            CompetitionAwayTeam = awayCompetitionTeam;
            
        }

        public override void SetupGamePlayers()
        {
            HomePlayers = SetupCompetitionPlayers(CompetitionHomeTeam);
            AwayPlayers = SetupCompetitionPlayers(CompetitionAwayTeam);
        }
        //override this for competition game players
        public virtual IList<GamePlayer> SetupCompetitionPlayers(CompetitionTeam team)
        {
            var result = new List<GamePlayer>();            

            team.Players.ToList().ForEach(player =>
            {
                result.Add(
                    new CompetitionGamePlayer(this, player.Parent, team.Parent, player.FirstYear, player, team)
                    );
            });

            return result;
        }
        
        //these suck don't use
        public virtual CompetitionTeam GetCompettitionWinner()
        {
            var winner = GetWinner();
            if (winner.Id == Home.Id) return CompetitionHomeTeam;
            else if (winner.Id == Away.Id) return CompetitionAwayTeam;

            return null;
        }

        public virtual CompetitionTeam GetCompetitionLoser()
        {
            var loser = GetLoser();
            if (loser.Id == Home.Id) return CompetitionHomeTeam;
            else if (loser.Id == Away.Id) return CompetitionAwayTeam;

            return null;
        }

    }
}
