using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competition.Seasons;
using TeamApp.Domain.Schedules;

namespace TeamApp.Domain.Competition
{
    public static class CompetitionExtensions
    {

        public static void PlayGame(this ICompetition competition, ScheduleGame game, Random random)
        {
            if (!game.IsComplete()) game.Play(random);
            if (!game.Processed) { competition.ProcessGame(game); game.Processed = true; }
        }

        public static List<ScheduleGame> PlayGames(this ICompetition competition, List<ScheduleGame> games, Random random)
        {
            games.ForEach(g => { g.Play(random); competition.ProcessGame(g); });

            return games;
        }

        public static List<ScheduleGame> PlayDay(this ICompetition competition, ScheduleDay day, Random random)
        {
            return competition.PlayGames(day.Games, random);
        }

        public static List<ScheduleGame> PlayNextDay(this ICompetition competition, Random random)
        {
            var day = competition.Schedule.GetNextInCompleteDay();

            if (day != null)
            {
                competition.PlayGames(day.Games, random);
            }

            return day.Games;
        }
    }
}
