using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain;
using TeamApp.Domain.Repositories;
using TeamApp.Services.Implementation;
using TeamApp.Services.ViewModels.Views;
using Xunit;
using static Xunit.Assert;

namespace TeamApp.Test.Services
{
    public class TeamServiceTests
    {
        [Fact]
        public void ShouldGetTeamByName()
        {            
            var mock = new Mock<ITeamRepository>();
            mock.Setup(p => p.GetByName("Team 1")).Returns(
                new Team()
                {
                    Id = 1,
                    FirstYear = 15,
                    LastYear = 27,
                    Name = "Team 1",
                    NickName = "Nick1",
                    ShortName = "Short",
                    Skill = 5,
                    Owner = "Me",
                    Active = false
                });

            var teamService = new TeamService(mock.Object);

            var team = teamService.GetTeamByName("Team 1");

            True(team is TeamViewModel);
            Equals("Team 1", team.Name);
            Equals(1, team.Id);
            Equals(15, team.FirstYear);
            Equals(27, team.LastYear);
            Equals("Nick1", team.NickName);
            Equals("Short", team.ShortName);
            Equals(5, team.Skill);
            Equals("Me", team.Owner);
            Equals(false, team.Active);
            
        }

    }
}
