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

        public int GetIncomleteGames()
        {
            if (Games == null) return 0;

            return Games.Select(g => !g.IsComplete()).Count();
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
    }
}
