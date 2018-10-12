using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Scheduler;

namespace TeamApp.Domain.Competition.Playoffs
{
    public class PlayoffGame:ScheduleGame
    {
        public PlayoffSeries Series { get; set; }

        public PlayoffGame(League league, PlayoffSeries series, int gameNumber, int day, int year, Team homeTeam, Team awayTeam, int homeScore, int awayScore, bool complete,
            int currentPeriod, GameRules rules):base(league, gameNumber, day, year, homeTeam, awayTeam, homeScore, awayScore, complete, currentPeriod, rules)
        {
            Series = series;
        }
    }
}
