using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain.Competitions.Seasons;
using TeamApp.Domain.Repositories;
using TeamApp.Services.Implementation.Mappers;
using TeamApp.ViewModels.Views.Standings;

namespace TeamApp.Services.Implementation
{
    public class StandingsService: IStandingsService
    {
        private IStandingsRepository standingsRepository;
        private ITeamRankingRepository teamRankingRepository;
        private SeasonTeamToStandingsTeamViewModelMapper mapper;

        public StandingsService(IStandingsRepository StandingsRepository, ITeamRankingRepository TeamRankingRepository)
        {
            standingsRepository = StandingsRepository;
            teamRankingRepository = TeamRankingRepository;
            mapper = new SeasonTeamToStandingsTeamViewModelMapper();
        }

        public SeasonListViewModel GetSeasonList()
        {
            return null;   
        }

        public StandingsViewModel GetStandings(long competitionId)
        {
            var teams = standingsRepository.GetByCompetition(competitionId);

            var models = mapper.MapDomainToModel(teams).ToList();

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
    }
}
