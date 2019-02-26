using Moq;
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
            StrictEqual(1, team.Id);
            StrictEqual(15, team.FirstYear);
            StrictEqual(27, team.LastYear);
            Equals("Nick1", team.NickName);
            Equals("Short", team.ShortName);
            StrictEqual(5, team.Skill);
            Equals("Me", team.Owner);
            Equals(false, team.Active);
            
        }

        [Fact]
        public void GetTeamById()
        {
            True(false);
        }
        [Fact]
        public void GetTeamByStatus()
        {
            True(false);
        }
        [Fact]
        public void GetAllTeams()
        {
            True(false);
        }
        [Fact]
        public void SaveTeams()
        {
            True(false);
        }
        [Fact]
        public void SaveTeam()
        {
            True(false);
        }

    }
}
