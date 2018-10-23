using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competitions.Seasons;
using TeamApp.Domain.Schedules;

namespace TeamApp.Domain.Competitions
{
    public static class CompetitionExtensions
    {

        public static void PlayGame(this Competition competition, ScheduleGame game, Random random)
        {
            if (!game.IsComplete()) game.Play(random);
            if (!game.Processed) { competition.ProcessGame(game); game.Processed = true; }
        }

        public static List<ScheduleGame> PlayGames(this Competition competition, List<ScheduleGame> games, Random random)
        {
            games.ForEach(g => { PlayGame(competition, g, random); });

            return games;
        }

        public static List<ScheduleGame> PlayDay(this Competition competition, ScheduleDay day, Random random)
        {
            return competition.PlayGames(day.Games, random);
        }
        
        public static List<ScheduleGame> PlayNextDay(this Competition competition, Random random)
        {
            var day = GetNextDayToPlay(competition);

            if (day != null)
            {
                competition.PlayGames(day.Games, random);
            }            

            return day == null ? null : day.Games;
        }

        public static ScheduleDay GetNextDayToPlay(this Competition competition)
        {
            var day = competition.Schedule.GetNextInCompleteDay();

            return day == null ? null : day;
        }
    }
}
