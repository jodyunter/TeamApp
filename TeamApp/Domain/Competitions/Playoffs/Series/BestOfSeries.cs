using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Competitions.Playoffs.Series
{
    public class BestOfSeries : PlayoffSeries
    {
        public virtual int HomeWins { get; set; }
        public virtual int AwayWins { get; set; }
        public virtual int RequiredWins { get; set; }

        public BestOfSeries() : base() { }

        public BestOfSeries(Playoff playoff, string name, int round, int startingDay, PlayoffTeam homeTeam, PlayoffTeam awayTeam,
        int homeWins, int awayWins, int requiredWins, List<PlayoffGame> games, int[] homeGameProgression)
    : base(playoff, name, round, startingDay, homeTeam, awayTeam, games, homeGameProgression)
        {
            HomeWins = homeWins;
            AwayWins = awayWins;
            RequiredWins = requiredWins;
        }

        public override bool IsComplete()
        {            
            return ((HomeWins == RequiredWins) || (AwayWins == RequiredWins));
        }

        public override void ProcessSeriesGame(PlayoffGame game)
        {
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
        }

        public override int NumberOfGamesNeeded()
        {
            int incompleteGames = GetInCompleteGames();
            if (!IsComplete())
            {
                int neededWins = HomeWins > AwayWins ? RequiredWins - HomeWins : RequiredWins - AwayWins;

                return neededWins - incompleteGames;
            }
            return 0;

        }

        public override PlayoffTeam GetWinner()
        {
            if (IsComplete())
            {
                return HomeWins == RequiredWins ? HomeTeam : AwayTeam;
            }
            return null;
        }

        public override PlayoffTeam GetLoser()
        {
            if (IsComplete())
            {
                return HomeWins == RequiredWins ? AwayTeam : HomeTeam;
            }
            return null;
        }
    }
}

