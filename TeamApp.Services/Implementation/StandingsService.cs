using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Competitions.Seasons;
using TeamApp.Domain.Repositories;
using TeamApp.Services.Implementation.Mappers;
using TeamApp.ViewModels.Views.Standings;

namespace TeamApp.Services.Implementation
{
    public class StandingsService: IStandingsService
    {
        private IStandingsRepository standingsRepository;            
        private ICompetitionRepository competitionRepository;
        private SeasonTeamToStandingsTeamViewModelMapper mapper;

        public StandingsService(IStandingsRepository StandingsRepository, ICompetitionRepository CompetitionRepository)
        {
            standingsRepository = StandingsRepository;            
            competitionRepository = CompetitionRepository;
            mapper = new SeasonTeamToStandingsTeamViewModelMapper();
        }

        public SeasonListViewModel GetSeasonList()
        {
            return null;   
        }

        public Task<StandingsViewModel> GetStandings(long competitionConfigId, int year, int sortingLevel)
        {
            var competitions = competitionRepository.GetByYear(year).ToList();
            var competition = competitions.Where(c => c.CompetitionConfig.Id == competitionConfigId).First();
            
            return GetStandings(competition.Id, sortingLevel);
        }
        public Task<StandingsViewModel> GetStandings(long competitionId, int sortingLevel)
        {
            var competition = competitionRepository.Get(competitionId);
            
            var teams = competition.Teams;
                        
            var models = mapper.MapMulitpleDomainToModel(teams).ToList();

            var ranks = competition.Rankings.ToList();

            models.ForEach(model =>
            {
                ranks.Where(r => r.CompetitionTeam.Id == model.SeasonTeamId).ToList().ForEach(rank =>
                {
                    AddRankToModel(rank.GroupName, rank.Rank, rank.GroupLevel, model);
                });
            });

            var result = new StandingsViewModel()
            {
                Teams = models
            };

            result.SortByLevel(sortingLevel);

            return Task.FromResult(result);

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
