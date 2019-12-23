using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competitions.Playoffs.Series;
using TeamApp.ViewModels.Views.Competition.Playoff;

namespace TeamApp.Services.Implementation.Mappers
{
    public class BestOfSeriesToBestofSeriesSummaryMapper:BaseDomainModelMapper<BestOfSeries, BestOfSeriesSummaryViewModel>
    {
        public override BestOfSeriesSummaryViewModel MapDomainToModel(BestOfSeries obj)
        {
            var model = new BestOfSeriesSummaryViewModel();
            model.Id = obj.Id;
            model.AwayTeamName = obj.AwayTeam == null ? "None" : obj.AwayTeam.Name;
            model.AwayTeamNickName = obj.AwayTeam == null ? "None" : obj.AwayTeam.NickName;
            model.HomeTeamName = obj.HomeTeam == null ? "None" : obj.HomeTeam.Name;
            model.HomeTeamNickName = obj.HomeTeam == null ? "None" : obj.HomeTeam.NickName;
            model.HomeWins = obj.HomeWins;
            model.AwayWins = obj.AwayWins;
            model.PlayoffName = obj.Playoff.Name;
            model.Year = obj.Playoff.Year;
            model.Games = obj.Games.Count;
            model.Round = obj.Round;
            model.Name = obj.Name;
            return model;
            
        }
    }
}
