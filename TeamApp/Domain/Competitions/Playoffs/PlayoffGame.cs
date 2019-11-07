using TeamApp.Domain.Schedules;
using TeamApp.Domain.Games;

namespace TeamApp.Domain.Competitions.Playoffs
{
    public class PlayoffGame:ScheduleGame
    {
        public virtual PlayoffSeries Series { get; set; }

        public PlayoffGame() : base() { }
        public PlayoffGame(Competition competition, PlayoffSeries series, int gameNumber, int day, int year, Team homeTeam, Team awayTeam, int homeScore, int awayScore, bool complete,
            int currentPeriod, GameRules rules, bool processed):base(competition, gameNumber, day, year, homeTeam, awayTeam, homeScore, awayScore, complete, currentPeriod, rules, processed)
        {
            Series = series;
        }

    }
}
