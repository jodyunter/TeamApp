using System;
using System.Collections.Generic;
using System.Text;
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
        //add games, and wins

        public bool IsComplete()
        {
            return ((GamesPlayed >= MinimumGames) && (HomeScore != AwayScore)) ||
                ((HomeWins == RequiredWins) || (AwayWins == RequiredWins));
            
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
            }

            GamesPlayed++;
        }

    }
}
