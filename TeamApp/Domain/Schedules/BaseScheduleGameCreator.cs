using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Games;

namespace TeamApp.Domain.Schedules
{
    public class BaseScheduleGameCreator:IGameCreator
    {        
        //may be able to turn thi sinto competition team creator
        public ScheduleGame CreateGame(int gameNumber, int day, int year, ITeam homeTeam, ITeam awayTeam, GameRules rules)
        {
            //must be comp team            

            return new ScheduleGame(null, gameNumber, day, year, (Team)homeTeam, null, (Team)awayTeam, null, 0, 0, false, 1, 0, rules, false);
        }
    }
}
