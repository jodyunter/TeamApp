using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Schedules;
using TeamApp.ViewModels.Views.Games;

namespace TeamApp.Services.Implementation.Mappers
{
    public class GameSummaryMapper:BaseDomainModelMapper<ScheduleGame, GameSummaryViewModel>
    {
        public override GameSummaryViewModel MapDomainToModel(ScheduleGame g)
        {
            return new GameSummaryViewModel()
            {
                DayNumber = g.Day,
                HomeTeamName = g.CompetitionHomeTeam.Name,
                AwayTeamName = g.CompetitionAwayTeam.Name,
                HomeScore = g.HomeScore,
                AwayScore = g.AwayScore
            };            
        }
    }
}
