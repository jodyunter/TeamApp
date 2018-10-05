using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competition.Seasons;
using TeamApp.Domain.Scheduler;

namespace TeamApp.Domain.Competition
{
    public static class CompetitionExtensions
    {

        public static void PlayGame(this ICompetition competition, ScheduleGame game, Random random)
        {
            game.Play(random);
            competition.ProcessGame(game);
        }

        public static void PlayGames(this ICompetition competition, List<ScheduleGame> games, Random random)
        {
            games.ForEach(g => { g.Play(random); competition.ProcessGame(g); });
        }

        public static void PlayDay(this ICompetition competition, ScheduleDay day, Random random)
        {
            competition.PlayGames(day.Games, random);
        }

        public static void PlayNextDay(this ICompetition competition, Random random)
        {
            var day = competition.Schedule.GetNextInCompleteDay();

            if (day != null)
            {
                competition.PlayGames(day.Games, random);
            }
        }
    }
}
