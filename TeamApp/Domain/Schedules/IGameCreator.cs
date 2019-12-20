using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Games;
using TeamApp.Domain.Schedules;

namespace TeamApp.Domain.Schedules
{
    public interface IGameCreator
    {
        ScheduleGame CreateGame(int gameNumber, int day, int year, ITeam homeTeam, ITeam awayTeam, GameRules rules);
    }
}
