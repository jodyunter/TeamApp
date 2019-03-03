using System.Collections.Generic;
using TeamApp.Domain.Competitions.Seasons.Config;
using TeamApp.Test.Helpers;
using Xunit;
using static Xunit.Assert;

namespace TeamApp.Test.Domain.Competitions.Seasons.Config
{
    public class SeasonCompetitionTests
    {
        [Theory]
        [InlineData("East", 8)]
        [InlineData("NHL", 20)]
        [InlineData("Atlantic", 4)]
        [InlineData("NorthEast", 4)]
        [InlineData("Central", 6)]
        [InlineData("West", 6)]
        public void ShouldGetTeamsInDivision(string divisionName, int expected)
        {
            var data = Data1.CreateBasicSeasonConfiguration();

            var competition = ((List<SeasonCompetitionConfig>)data[Data1.BASIC_SEASON_COMPETITION_LSIT])[0];

            StrictEqual(expected, competition.GetTeamsInDivision(divisionName).Count);
        }

        [Theory]
        [InlineData("New York", "East", true)]
        [InlineData("New York", "Atlantic", true)]
        [InlineData("New York", "West", false)]
        [InlineData("New York", "NHL", true)]
        [InlineData("Winnipeg", "NHL", true)]
        [InlineData("Edmonton", "West", true)]
        [InlineData("Edmonton", "East", false)]
        public void IsTeamInDivision(string teamName, string divisionName, bool expected)
        {
            var data = Data1.CreateBasicSeasonConfiguration();

            var competition = ((List<SeasonCompetitionConfig>)data[Data1.BASIC_SEASON_COMPETITION_LSIT])[0];

            StrictEqual(expected, competition.IsTeamInDivision(teamName, divisionName));


        }
        
    }
}
