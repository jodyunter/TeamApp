using System.Threading.Tasks;
using TeamApp.Domain.Competitions.Playoffs;
using TeamApp.Domain.Repositories;
using TeamApp.Services.Implementation.Mappers;
using TeamApp.ViewModels.Views.Competition.Playoff;
using System.Linq;

namespace TeamApp.Services.Implementation
{
    public class PlayoffService:IPlayoffService
    {
        private ICompetitionRepository competitionRepo;
        private PlayoffToPlayoffSummaryMapper mapper;

        public PlayoffService(ICompetitionRepository competitionRepository)
        {
            competitionRepo = competitionRepository;

            mapper = new PlayoffToPlayoffSummaryMapper();
        }


        public Task<PlayoffSummaryViewModel> GetPlayoffSummary(long competitionId)
        {
            var competition = (Playoff)competitionRepo.Get(competitionId);
            //var i = competition.Series.Count;
            //var series = competition.Series[0];

            return Task.FromResult(mapper.MapDomainToModel(competition));
        }

        public Task<PlayoffSummaryViewModel> GetPlayoffSummary(long competitionConfigId, int year)
        {
            var competition = (Playoff)competitionRepo.GetByYearAndConfigId(competitionConfigId, year);

            return Task.FromResult(mapper.MapDomainToModel(competition));
        }

    }
}
