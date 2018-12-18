using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain.Competitions.Seasons;
using TeamApp.Domain.Repositories;
using TeamApp.ViewModels.Views.Standings;

namespace TeamApp.Services.Implementation
{
    public class StandingsService:BaseService<SeasonTeam, StandingsTeamViewModel>, IStandingsService
    {
        private IStandingsRepository standingsRepository;
        private ITeamRankingRepository teamRankingRepository;

        public StandingsService(IStandingsRepository StandingsRepository, ITeamRankingRepository TeamRankingRepository)
        {
            standingsRepository = StandingsRepository;
            teamRankingRepository = TeamRankingRepository;
        }

        public SeasonListViewModel GetSeasonList()
        {
            return null;   
        }

        public StandingsViewModel GetStandings(int competitionId)
        {
            var teams = standingsRepository.GetByCompetition(competitionId);
            
            var models = MapDomainToModel(teams.ToList());

            var ranks = teamRankingRepository.GetByCompetition(competitionId).ToList();

            models.ForEach(model =>
            {
                ranks.Where(r => r.Team.Name.Equals(model.TeamName)).ToList().ForEach(rank =>
                {
                    AddRankToModel(rank.GroupName, rank.Rank, rank.GroupLevel, model);
                });
            });

            return new StandingsViewModel()
            {
                Teams = models
            };


            
        }
        

        private void AddRankToModel(string divname, int rank, int level, StandingsTeamViewModel model)
        {
            if (model.Rankings == null)
            {
                model.Rankings = new List<StandingsRankingViewModel>();
            }

            model.Rankings.Add(new StandingsRankingViewModel() { GroupName = divname, Rank = rank, GroupLevel = level });
        }
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
