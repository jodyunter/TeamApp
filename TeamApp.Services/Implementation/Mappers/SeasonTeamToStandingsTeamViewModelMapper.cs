using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competitions.Seasons;
using TeamApp.ViewModels.Views.Standings;

namespace TeamApp.Services.Implementation.Mappers
{
    public class SeasonTeamToStandingsTeamViewModelMapper:BaseDomainModelMapper<SeasonTeam, StandingsTeamViewModel>
    {
        public override StandingsTeamViewModel MapDomainToModel(SeasonTeam obj)
        {
            var model = new StandingsTeamViewModel
            {
                TeamName = obj.Name,
                Division = obj.Division.Name,
                Wins = obj.Stats.Wins,
                Ties = obj.Stats.Ties,
                Loses = obj.Stats.Loses,
                GoalsFor = obj.Stats.GoalsFor,
                GoalsAgainst = obj.Stats.GoalsAgainst,
                GamesPlayed = obj.Stats.Games,
                GoalDifference = obj.Stats.GoalDifference,
                Points = obj.Stats.Points
            };

            return model;
        }
    }
}
