using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Games;
using TeamApp.Domain.Schedules;

namespace TeamApp.Domain.Competitions.Seasons
{
    public class SeasonGameCreator : IGameCreator
    {
        public Competition Competition { get; set; }
        
        public SeasonGameCreator(Competition competition)
        {
            Competition = competition;
        }
        //may be able to turn thi sinto competition team creator
        public ScheduleGame CreateGame(int gameNumber, int day, int year, ITeam homeTeam, ITeam awayTeam, GameRules rules)
        {
            //must be comp team
            var homeCompTeam = (SeasonTeam)homeTeam;
            var awayCompTeam = (SeasonTeam)awayTeam;
            
            return new ScheduleGame(Competition, gameNumber, day, year, homeCompTeam.Parent, homeCompTeam, awayCompTeam.Parent, awayCompTeam, 0, 0, false, 1, 0, rules, false);
        }
    }
}
