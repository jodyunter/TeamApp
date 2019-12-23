using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Repositories;
using TeamApp.Services.Implementation.Mappers;
using TeamApp.ViewModels.Views.Competition;

namespace TeamApp.Services.Implementation
{
    public class CompetitionService : ICompetitionService
    {
        private ICompetitionRepository competitionRepository;
        private CompetitionToCompetitionSimpleMapper simpleViewMapper;

        public CompetitionService(ICompetitionRepository repo)
        {
            competitionRepository = repo;
            simpleViewMapper = new CompetitionToCompetitionSimpleMapper();
        }

        public IEnumerable<CompetitionSimpleViewModel> GetActiveCompetitions(int year)
        {
            var competitions = competitionRepository.GetStartedAndUnfinishedCompetitionsByYear(year);

            return simpleViewMapper.MapDomainToModel(competitions);
        }

        public IEnumerable<CompetitionSimpleViewModel> GetCompetitionListByLeagueAndYear(int leagueId, int year)
        {
            var competitions = competitionRepository.GetByLeagueAndYear(leagueId, year).ToList();

            return simpleViewMapper.MapDomainToModel(competitions);
        }

        public IEnumerable<CompetitionSimpleViewModel> GetCompetitionListLeaugeAndYear(int leagueId, int year, bool started, bool finished)
        {
            var competitions = competitionRepository.GetByLeagueAndYear(leagueId, year, started, finished).ToList();

            return simpleViewMapper.MapDomainToModel(competitions);
        }

        public Task<CompetitionSimpleViewModel[]> GetCompetitionsByYear(int year)
        {
            var competitions = competitionRepository.GetByYear(year);

            var result = simpleViewMapper.MapDomainToModel(competitions);

            return Task.FromResult(result.ToArray());
        }

        public CompetitionSimpleViewModel GetCompetition(long id)
        {
            return simpleViewMapper.MapDomainToModel(competitionRepository.Get(id));
        }
    }
}
