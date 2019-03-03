using System;
using System.Collections.Generic;
using System.Text;
using static Xunit.Assert;
using Xunit;
using TeamApp.Domain.Repositories;
using TeamApp.Domain;
using Moq;
using TeamApp.Services.Implementation;
using TeamApp.Services.ViewModels.Views;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Competitions.Seasons.Config;
using TeamApp.Domain.Competitions.Playoffs.Config;

namespace TeamApp.Test.Services
{
    public class LeagueServiceTests
    {
        [Fact]
        public void ShouldGetByName()
        {
            var leagueRepoMock = new Mock<ILeagueRepository>();

            leagueRepoMock.Setup(p => p.GetByName("NHL")).Returns(
                new League()
                {
                    Name = "NHL",
                    FirstYear = 1,
                    LastYear = null,
                    Id = 1,
                    CompetitionConfigs = new List<CompetitionConfig>() { new SeasonCompetitionConfig() { Id = 5 }, new PlayoffCompetitionConfig() { Id = 15 } }
                }
                );

            var leagueService = new LeagueService(leagueRepoMock.Object);

            var league = leagueService.GetByName("NHL");

            True(league is LeagueViewModel);
            Equals("NHL", league.Name);
            StrictEqual(1, league.Id);
            StrictEqual(1, league.FirstYear);
            Null(league.LastYear);            

        }

        [Fact]
        public void ShouldTestGetAll()
        {
            True(false);
        }
        [Fact]
        public void ShouldTestGetCompetitionConfigs()
        {
            True(false);
        }
        [Fact]
        public void ShouldTestGetSeasonCompetitionConfig()
        {
            True(false);
        }
        
    }
}
