using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain;
using TeamApp.Domain.Competitions.Playoffs;
using TeamApp.Domain.Competitions.Playoffs.Config;
using TeamApp.Domain.Competitions.Playoffs.Series;
using TeamApp.Services.Implementation.Mappers;
using TeamApp.ViewModels.Views.Competition;
using Xunit;
using static Xunit.Assert;

namespace TeamApp.Test.Service.Services
{
    public class PlayoffServiceTests
    {
        [Fact]
        public void ShouldMapBestOfSeriesSummary()
        {
            var mapper = new BestOfSeriesToBestofSeriesSummaryMapper();
            var series = new BestOfSeries(new Playoff() { Name = "P Name", Year = 5 },
                "Series 1", 1, 5, new PlayoffTeam() { Name = "Team 1" }, new PlayoffTeam() { Name = "Team 2" },
                3, 2, 4, new List<PlayoffGame>() { new PlayoffGame(), new PlayoffGame(), new PlayoffGame(), new PlayoffGame() }, new int[] { });
            series.Id = 15;

            var mappedSeries = mapper.MapDomainToModel(series);

            StrictEqual(15, mappedSeries.Id);
            Equals("P Name", mappedSeries.PlayoffName);
            Equals("Series 1", mappedSeries.Name);
            StrictEqual(5, mappedSeries.Year);
            Equals("Team 1", mappedSeries.HomeTeamName);
            Equals("Team 2", mappedSeries.AwayTeamName);
            StrictEqual(3, mappedSeries.HomeWins);
            StrictEqual(2, mappedSeries.AwayWins);
            StrictEqual(4, mappedSeries.Games);
            StrictEqual(1, mappedSeries.Round);
        }
        [Fact] 
        public void ShouldMapPlayoffSummary()
        {
            var mapper = new PlayoffToPlayoffSummaryMapper();

            var league = new League("League 1", 1, null);
            var competitionConfig = new PlayoffCompetitionConfig("P Config", league, 1, 1, null, 1, null, null, null, null);
            var playoff = new Playoff(competitionConfig, "Playoff 1", 1, 5, null, null, null, null, true, false, 1, 15);
            var series = new List<PlayoffSeries>()
            {
                new BestOfSeries(playoff, "Series 1", 1, 1, new PlayoffTeam() {Name = "Team 1" }, new PlayoffTeam { Name = "Team 2" }, 1, 4, 4, new List<PlayoffGame>() { new PlayoffGame(), new PlayoffGame() }, new int[] { }),
                new BestOfSeries(playoff, "Series 2", 2, 12, new PlayoffTeam() {Name = "Team 3" }, new PlayoffTeam { Name = "Team 4" }, 1, 4, 4, new List<PlayoffGame>() { new PlayoffGame(), new PlayoffGame() }, new int[] { })
            };
            playoff.Series = series;

            var playoffSummaryModel = mapper.MapDomainToModel(playoff);

            StrictEqual(2, playoffSummaryModel.Series.ToList().Count);
            StrictEqual(5, playoffSummaryModel.CurrentRound);
            StrictEqual(1, playoffSummaryModel.Year);
            Equals(CompetitionViewModel.PLAYOFF_TYPE, playoffSummaryModel.Type);

        }
        [Fact]
        public void ShouldGetPlayoffSummary()
        {
            True(false);
        }
    }
}
