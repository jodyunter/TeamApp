using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamApp.Domain.Competitions.Playoffs
{
    public abstract class PlayoffSeries:BaseDataObject
    {
        public virtual Playoff Playoff { get; set; }
        public virtual string Name { get; set; }
        public virtual int Round { get; set; }
        public virtual int StartingDay { get; set; }
        public virtual PlayoffTeam HomeTeam { get; set; }
        public virtual PlayoffTeam AwayTeam { get; set; }
        public virtual IList<PlayoffGame> Games { get; set; }
        public virtual int[] HomeGameProgression { get; set; }
        
        public virtual PlayoffSeries Self { get { return this; } }

        public PlayoffSeries() { }
        public PlayoffSeries(Playoff playoff, string name, int round, int startingDay, PlayoffTeam homeTeam, PlayoffTeam awayTeam,            
            List<PlayoffGame> games, int[] homeGameProgression)
        {
            Playoff = playoff;
            Name = name;
            Round = round;
            StartingDay = startingDay;
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;            
            Games = games;
            HomeGameProgression = homeGameProgression;
        }

        //add games, and wins             
        public abstract bool IsComplete();
        public abstract void ProcessSeriesGame(PlayoffGame game);
        public abstract int NumberOfGamesNeeded();
        public abstract PlayoffTeam GetWinner();
        public abstract PlayoffTeam GetLoser();

        public virtual void ProcessGame(PlayoffGame game)
        {
            if (IsComplete()) throw new ApplicationException("Series is complete, why are we trying to play another game?");

            ProcessSeriesGame(game);    
            
        }

        public virtual int GetInCompleteGames()
        {
            if (Games == null) return 0;

            return Games.Where(g => !g.Complete).ToList().Count();
        }

        public virtual List<PlayoffGame> CreateNeededGamesForSeries()
        {
            var newGamesList = new List<PlayoffGame>();

            var neededGames = NumberOfGamesNeeded();

            for (int i = 0; i < neededGames; i++)
            {
                int nextGameNumber = Games.Count + 1;
                var nextGame = CreateGameForSeries(nextGameNumber);

                newGamesList.Add(nextGame);
                Games.Add(nextGame);
            }

            return newGamesList;
        }

        public virtual PlayoffGame CreateGameForSeries(int gameNumber)
        {
            var homeValue = GetHomeValueForGame(gameNumber);

            return new PlayoffGame(Playoff, this, gameNumber, -1, Playoff.Year, 
                homeValue == 0 ? HomeTeam.Parent: AwayTeam.Parent, homeValue == 0 ? AwayTeam.Parent: HomeTeam.Parent,
                0, 0, false, 1, 0, Playoff.CompetitionConfig.GameRules, false);
        }

        public virtual int GetHomeValueForGame(int gameNumber)
        {            
            if (HomeGameProgression == null || (gameNumber > HomeGameProgression.Length))
            {
                if (gameNumber % 2 == 0)
                    return 1;
                else
                    return 0;
            } 
            else
            {
                return HomeGameProgression[gameNumber - 1];
            }
        }
    }
}
