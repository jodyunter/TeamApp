﻿using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competitions.Playoffs;

namespace TeamApp.Domain.Competitions.Playoffs.Series
{
    public class TotalGoalsSeries : PlayoffSeries
    {
        public virtual int GamesPlayed { get; set; }
        public virtual int HomeScore { get; set; }
        public virtual int AwayScore { get; set; }
        public virtual int MinimumGames { get; set; }

        public TotalGoalsSeries() : base() { }

        public TotalGoalsSeries(Playoff playoff, string name, int round, int startingDay, PlayoffTeam homeTeam, PlayoffTeam awayTeam,
                int homeScore, int awayScore, int minimumGames, int gamesPlayed,
                List<PlayoffGame> games, int[] homeGameProgression)
            :base(playoff, name, round, startingDay, homeTeam, awayTeam, games, homeGameProgression)            
        {
            HomeScore = homeScore;
            AwayScore = awayScore;
            GamesPlayed = gamesPlayed;
            MinimumGames = minimumGames;
        }

        public override bool IsComplete()
        {
            return ((GamesPlayed >= MinimumGames) && (HomeScore != AwayScore));
        }

        public override void ProcessSeriesGame(PlayoffGame game)
        {
            HomeScore += game.HomeScore;
            AwayScore += game.AwayScore;
            GamesPlayed++;
            game.Processed = true;
        }

        public override int NumberOfGamesNeeded()
        {
            int completeGames = GamesPlayed;
            int incompleteGames = GetInCompleteGames();
            if (!IsComplete() && incompleteGames == 0)
                return completeGames >= MinimumGames ? 1 : MinimumGames - completeGames;
            else
                return 0;
        }

        public override PlayoffTeam GetWinner()
        {
            if (IsComplete())
            {
                return HomeScore > AwayScore ? HomeTeam : AwayTeam;
            }

            return null;
        }

        public override PlayoffTeam GetLoser()
        {
            if (IsComplete())
            {
                return HomeScore > AwayScore ? AwayTeam : HomeTeam;
            }

            return null;
        }
    }
}
