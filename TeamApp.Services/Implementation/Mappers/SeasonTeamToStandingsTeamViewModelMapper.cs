using System;
using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Competitions.Seasons;
using TeamApp.ViewModels.Views.Standings;

namespace TeamApp.Services.Implementation.Mappers
{
    public class SeasonTeamToStandingsTeamViewModelMapper:BaseDomainModelMapper<SeasonTeam, StandingsTeamViewModel>
    {

        public IEnumerable<StandingsTeamViewModel> MapMulitpleDomainToModel(IEnumerable<CompetitionTeam> objs)
        {
            var result = new List<StandingsTeamViewModel>();

            objs.ToList().ForEach(team =>
            {
                result.Add(MapDomainToModel((SeasonTeam)team));
            });

            return result;
        }

        public override StandingsTeamViewModel MapDomainToModel(SeasonTeam obj)
        {
            var model = new StandingsTeamViewModel
            {
                SeasonTeamId = obj.Id,
                TeamName = obj.Name,
                TeamNickName = obj.NickName,
                Division = obj.Division.Name,
                Wins = obj.Stats.Wins,
                Ties = obj.Stats.Ties,
                Loses = obj.Stats.Loses,
                GoalsFor = obj.Stats.GoalsFor,
                GoalsAgainst = obj.Stats.GoalsAgainst,
                GamesPlayed = obj.Stats.Games,
                GoalDifference = obj.Stats.GoalDifference,
                Points = obj.Stats.Points,
                Skill = obj.Skill
            };
            
            return model;
        }
    }
}
