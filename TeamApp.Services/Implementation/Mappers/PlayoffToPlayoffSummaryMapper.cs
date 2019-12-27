using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Competitions.Playoffs;
using TeamApp.Domain.Competitions.Playoffs.Series;
using TeamApp.ViewModels.Views.Competition.Playoff;
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
            var rounds = new List<PlayoffRoundViewModel>();

            if (obj == null) return null;

            if (obj.Series != null)
            {
                obj.Series.ToList().ForEach(s =>
                {
                    var seriesModel = seriesMapper.MapDomainToModel((BestOfSeries)s.Self);
                    series.Add(seriesModel);
                    var round = rounds.Where(r => r.RoundNumber == seriesModel.Round).FirstOrDefault();
                    if (round == null)
                    {
                        round = new PlayoffRoundViewModel() { Name = "Round " + seriesModel.Round, RoundNumber = seriesModel.Round, Series = new List<BestOfSeriesSummaryViewModel>() };
                        rounds.Add(round);
                    }
                    var seriesModels = round.Series.ToList();
                    seriesModels.Add(seriesModel);
                    round.Series = seriesModels;

                });
            }
                

            var model = new PlayoffSummaryViewModel(compMapper.MapDomainToModel(obj), obj.CurrentRound, series, rounds);

            return model;

        }
    }
}
