using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Competitions.Playoffs;
using TeamApp.Domain.Competitions.Playoffs.Series;
using TeamApp.Services.ViewModels.Views.Competition.Playoff;
using TeamApp.ViewModels.Views.Competition;

namespace TeamApp.Services.Implementation.Mappers
{
    public class PlayoffToPlayoffSummaryMapper:BaseDomainModelMapper<Playoff, PlayoffSummaryViewModel>
    {
        private BestOfSeriesToBestofSeriesSummaryMapper seriesMapper = new BestOfSeriesToBestofSeriesSummaryMapper();
        private CompetitionToCompetitionSimpleMapper compMapper = new CompetitionToCompetitionSimpleMapper();

        public override PlayoffSummaryViewModel MapDomainToModel(Playoff obj)
        {            
            var series = new List<BestOfSeriesSummaryViewModel>();
            
            if (obj.Series != null)
            {
                obj.Series.ToList().ForEach(s =>
                {
                    series.Add(seriesMapper.MapDomainToModel((BestOfSeries)s.Self));
                });
            }
                

            var model = new PlayoffSummaryViewModel(compMapper.MapDomainToModel(obj), obj.CurrentRound, series);

            return model;

        }
    }
}
