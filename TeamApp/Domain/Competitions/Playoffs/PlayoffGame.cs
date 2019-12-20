using TeamApp.Domain.Schedules;
using TeamApp.Domain.Games;

namespace TeamApp.Domain.Competitions.Playoffs
{
    public class PlayoffGame:ScheduleGame
    {
        public virtual PlayoffSeries Series { get; set; }

        public PlayoffGame() : base() { }
        public PlayoffGame(Competition competition, PlayoffSeries series, int gameNumber, int day, int year, Team homeTeam, CompetitionTeam homeCompetitionTeam,
            Team awayTeam, CompetitionTeam awayCompetitionTeam, int homeScore, int awayScore, bool complete, int currentPeriod, int currentTime, GameRules rules, bool processed)
            :base(competition, gameNumber, day, year, homeTeam, homeCompetitionTeam, awayTeam, awayCompetitionTeam, homeScore, awayScore, complete, currentPeriod, currentTime, rules, processed)
        {
            Series = series;
        }

    }
}
