using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competitions.Playoffs.Series;
using TeamApp.Services.ViewModels.Views.Competition.Playoff;

namespace TeamApp.Services.Implementation.Mappers
{
    public class BestOfSeriesToBestofSeriesSummaryMapper:BaseDomainModelMapper<BestOfSeries, BestOfSeriesSummaryViewModel>
    {
        public override BestOfSeriesSummaryViewModel MapDomainToModel(BestOfSeries obj)
        {
            var model = new BestOfSeriesSummaryViewModel();
            model.Id = obj.Id;
            model.AwayTeamName = obj.AwayTeam == null ? "None" : obj.AwayTeam.Name;
            model.HomeTeamName = obj.HomeTeam == null ? "None" : obj.HomeTeam.Name;
            model.HomeWins = obj.HomeWins;
            model.AwayWins = obj.AwayWins;
            model.PlayoffName = obj.Playoff.Name;
            model.Year = obj.Playoff.Year;
            model.Games = obj.Games.Count;
            model.Round = obj.Round;
            return model;
            
        }
    }
}
