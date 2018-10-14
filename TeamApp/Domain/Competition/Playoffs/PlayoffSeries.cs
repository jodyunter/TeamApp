using System;
using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain.Competition.Playoffs.Config;

namespace TeamApp.Domain.Competition.Playoffs
{
    public abstract class PlayoffSeries
    {
        public Playoff Playoff { get; set; }
        public string Name { get; set; }
        public int Round { get; set; }
        public PlayoffTeam HomeTeam { get; set; }
        public PlayoffTeam AwayTeam { get; set; }        
        public List<PlayoffGame> Games { get; set; }
        public int[] HomeGameProgression { get; set; }

        public PlayoffSeries(Playoff playoff, string name, int round, PlayoffTeam homeTeam, PlayoffTeam awayTeam,            
            List<PlayoffGame> games, int[] homeGameProgression)
        {
            Playoff = playoff;
            Name = name;
            Round = round;
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;            
            Games = games;
            HomeGameProgression = homeGameProgression;
        }

        //add games, and wins             
        public abstract bool IsComplete();
        public abstract void ProcessSeriesGame(PlayoffGame game);
        public abstract int NumberOfGamesNeeded();

        public void ProcessGame(PlayoffGame game)
        {
            if (IsComplete()) throw new ApplicationException("Series is complete, why are we trying to play another game?");

            ProcessSeriesGame(game);            
        }        

        public int GetInCompleteGames()
        {
            if (Games == null) return 0;

            return Games.Where(g => !g.Complete).ToList().Count();
        }


        public PlayoffTeam GetHomeTeamForGameNumber(int seriesGameNumber)
        {
            return GetTeamForGameNumber(seriesGameNumber, true);
        }

        public PlayoffTeam GetAwayTeamForGameNumber(int seriesGameNumber)
        {
            return GetTeamForGameNumber(seriesGameNumber, false);
        }
        public PlayoffTeam GetTeamForGameNumber(int seriesGameNumber, bool homeTeam)
        {
            if (HomeGameProgression.Length >= seriesGameNumber)
            {
                if (HomeGameProgression[seriesGameNumber] == 0)
                    if (homeTeam) return HomeTeam;
                    else return AwayTeam;
                else                
                    if (homeTeam) return AwayTeam;
                    else return HomeTeam;
            }
            else
            {
                if (seriesGameNumber % 2 == 0) return HomeTeam;
                else return AwayTeam;
            }
        }
        public PlayoffGame CreateGameForSeries(int gameNumber)
        {
            var homeValue = GetHomeValueForGame(gameNumber);


            return new PlayoffGame(Playoff.CompetitionConfig.League, this, gameNumber, -1, Playoff.Year, 
                homeValue == 0 ? HomeTeam.Parent: AwayTeam.Parent, homeValue == 0 ? AwayTeam.Parent: HomeTeam.Parent,
                0, 0, false, 1, Playoff.CompetitionConfig.GameRules);
        }

        public int GetHomeValueForGame(int gameNumber)
        {
            if (HomeGameProgression.Length > gameNumber)
            {
                if (gameNumber % 2 == 0)
                    return 0;
                else
                    return 1;
            } 
            else
            {
                return HomeGameProgression[gameNumber - 1];
            }
        }
    }
}
