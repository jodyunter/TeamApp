using System;
using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain.Competition.Playoffs.Config;

namespace TeamApp.Domain.Competition.Playoffs
{
    public class PlayoffSeries
    {
        public Playoff Playoff { get; set; }
        public string Name { get; set; }
        public int Round { get; set; }
        public PlayoffTeam HomeTeam { get; set; }
        public PlayoffTeam AwayTeam { get; set; }
        public int SeriesType { get; set; }
        public int HomeScore { get; set; }  //this can represent wins, or goals for
        public int AwayScore { get; set; }
        public int HomeWins { get { return HomeScore; } set { HomeScore = value; } }
        public int AwayWins { get { return AwayScore; } set { AwayScore = value; } }        
        public int MinimumGames { get; set; }
        public int RequiredWins { get { return MinimumGames; } set { MinimumGames = value; } }
        public int GamesPlayed { get; set; }
        public List<PlayoffGame> Games { get; set; }
        public int[] HomeGameProgression { get; set; }

        public PlayoffSeries(Playoff playoff, string name, int round, PlayoffTeam homeTeam, PlayoffTeam awayTeam, 
            int seriesType, int homeScore, int awayScore, int minimumGames, int gamesPlayed, 
            List<PlayoffGame> games, int[] homeGameProgression)
        {
            Playoff = playoff;
            Name = name;
            Round = round;
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            SeriesType = seriesType;
            HomeScore = homeScore;
            AwayScore = awayScore;
            MinimumGames = minimumGames;            
            GamesPlayed = gamesPlayed;
            Games = games;
            HomeGameProgression = homeGameProgression;
        }

        //add games, and wins             
        public bool IsComplete()
        {
            switch (SeriesType)
            {
                case PlayoffSeriesRule.TOTAL_GOALS:
                    return ((GamesPlayed >= MinimumGames) && (HomeScore != AwayScore));
                case PlayoffSeriesRule.BEST_OF_SERIES:
                    return ((HomeWins == RequiredWins) || (AwayWins == RequiredWins));
                default:
                    throw new ApplicationException("Bad Series Type. ");
            }
        }

        public void ProcessGame(PlayoffGame game)
        {
            if (IsComplete()) throw new ApplicationException("Series is complete, why are we trying to play another game?");

            switch(SeriesType)
            {
                case PlayoffSeriesRule.BEST_OF_SERIES:
                    var winner = game.GetWinner();

                    if (winner == null)
                    {
                        //todo so what if they tie?
                        throw new ApplicationException("No winner in game for a best of series!");
                    }

                    if (winner.Name.Equals(HomeTeam.Name))
                    {
                        HomeWins++;
                    }
                    else
                        AwayWins++;
                    
                    break;
                case PlayoffSeriesRule.TOTAL_GOALS:
                    HomeScore += game.HomeScore;
                    AwayScore += game.AwayScore;
                    break;
                default:
                    throw new ApplicationException("Bad Series Type. " + SeriesType);
            }

            GamesPlayed++;
        }        

        public int GetIncomleteGames()
        {
            if (Games == null) return 0;

            return Games.Select(g => !g.IsComplete()).Count();
        }

        public int NumberOfGamesNeeded()
        {
            int completeGames = GamesPlayed;
            int incompleteGames = GetIncomleteGames();
            
            switch(SeriesType)
            {
                case PlayoffSeriesRule.TOTAL_GOALS:
                    if (!IsComplete() && incompleteGames == 0)
                        return completeGames >= MinimumGames ? 1 : MinimumGames - completeGames;
                    else
                        return 0;                     
                case PlayoffSeriesRule.BEST_OF_SERIES:
                    if (!IsComplete())
                    {
                        int neededWins = HomeWins > AwayWins ? RequiredWins - HomeWins : RequiredWins - AwayWins;

                        return neededWins - incompleteGames;
                    }
                    return 0;                    
                default:
                    throw new ApplicationException("Bad Series Type. " + SeriesType);
            }
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
