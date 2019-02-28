using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competitions.Playoffs;
using TeamApp.Domain.Repositories;
using TeamApp.Services.Implementation.Mappers;
using TeamApp.Services.ViewModels.Views.Competition.Playoff;

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


        public PlayoffSummaryViewModel GetPlayoffSummary(long competitionId)
        {
            var competition = (Playoff)competitionRepo.Get(competitionId);

            return mapper.MapDomainToModel(competition);
        }
    }
}
