using System.Collections.Generic;
using TeamApp.Domain;
using TeamApp.Domain.Competitions.Seasons.Config;
using System.Linq;
using Xunit;
using static Xunit.Assert;

namespace TeamApp.Test.Domain.Competitions.Seasons.Config
{
    public class SeasonCompetitionConfigTests
    {
        private SeasonCompetitionConfig CreateConfig()
        {
            var seasonConfig = new SeasonCompetitionConfig("My Season", null, 1, 1, null, 1, null, null, null, null, null);
            var divisionRules = new List<SeasonDivisionRule>()
            {
                new SeasonDivisionRule(seasonConfig, "NHL", null, 1, 1, 1, null) {Id = 1 },
                new SeasonDivisionRule(seasonConfig, "Eastern", "NHL", 2, 1, 1, null) {Id = 2 },
                new SeasonDivisionRule(seasonConfig, "Western", "NHL", 2, 2, 1, null) {Id = 3 },
                new SeasonDivisionRule(seasonConfig, "East", "Eastern",2,1,1,null) {Id = 4 },
                new SeasonDivisionRule(seasonConfig, "Atlantic", "Eastern",2,2,1,null) {Id = 5 },
                new SeasonDivisionRule(seasonConfig, "NorthEast", "Eastern",2,3,1,null) {Id = 6 },
                new SeasonDivisionRule(seasonConfig, "West", "Western",2,4,1,null) {Id = 7 },
                new SeasonDivisionRule(seasonConfig, "Central", "Western",2,5,1,null) {Id = 8 },
                new SeasonDivisionRule(seasonConfig, "Central A", "Central",3,1,1,null) {Id = 9 },
                new SeasonDivisionRule(seasonConfig, "Central B", "Central",3,2,1,null) {Id = 10 }
            };

            var teams = new Dictionary<string, Team>()
            {
                { "Key",null },
                {"Boston Bruins", new Team(){Name="Boston", NickName="Bruins", FirstYear = 1, Active = true, Id = 1} }, //east
                {"Montreal Canadiens", new Team(){Name="Montreal", NickName="Canadiens", FirstYear = 1, Active = true, Id = 2 }  }, //east
                {"Toronto Maple Leafs", new Team(){Name="Toronto", NickName="Maple Leafs", FirstYear = 1, Active = true, Id = 3 }  }, //east
                {"Quebec Nordiques", new Team(){Name="Quebec", NickName="Nordiques", FirstYear = 1, Active = true, Id = 4 } }, //atlantic
                {"Pittsburgh Penguins", new Team(){Name="Pittsburgh", NickName="Penguins", FirstYear = 1, Active = true, Id = 5 }  }, //northeast
                {"New Jersey Devils", new Team(){Name="New Jersey", NickName="Devils", FirstYear = 1, Active = true, Id = 6 }  }, //northesat
                {"San Jose Sharks", new Team(){Name="San Josey", NickName="Sharks", FirstYear = 1, Active = true, Id = 7 }  }, //west
                {"Edmonton Oilers", new Team(){Name="Edmonton", NickName="Oilers", FirstYear = 1, Active = true, Id = 8 }  }, //west
                {"Calgary Flames", new Team(){Name="Calgary", NickName="Flames", FirstYear = 1, Active = true, Id = 9 } }, //west
                {"Vancouver Canucks", new Team(){Name="Vancouver", NickName="Canucks", FirstYear = 1, Active = true, Id = 10 }  }, //west
                {"Winnipeg Jets", new Team(){Name="Winnipeg", NickName="Jets", FirstYear = 1, Active = true, Id = 11 }  }, //Central A
                {"Minnesota Stars", new Team(){Name="Minnesota", NickName="Stars", FirstYear = 1, Active = true, Id = 12 }  }, //Central A
                {"Chicago Blackhawks", new Team(){Name="Chicago", NickName="Blackhawks", FirstYear = 1, Active = true, Id = 13 }  }, //Central B
                {"Detroit Red Wings", new Team(){Name="Detroit", NickName="Red Wings", FirstYear = 1, Active = true, Id = 14 }  }, //Central B

            };

            var seasonTeamRules = new List<SeasonTeamRule>()
            {
                new SeasonTeamRule(seasonConfig, teams["Boston Bruins"], "East", 1, null) { Id = 1 },
                new SeasonTeamRule(seasonConfig, teams["Montreal Canadiens"], "East", 1, null) { Id = 2 },
                new SeasonTeamRule(seasonConfig, teams["Toronto Maple Leafs"], "East", 1, null) { Id = 3 },
                new SeasonTeamRule(seasonConfig, teams["Quebec Nordiques"], "Atlantic", 1, null) { Id = 4 },
                new SeasonTeamRule(seasonConfig, teams["Pittsburgh Penguins"], "NorthEast", 1, null) { Id = 5 },
                new SeasonTeamRule(seasonConfig, teams["New Jersey Devils"], "NorthEast", 1, null) { Id = 6 },
                new SeasonTeamRule(seasonConfig, teams["San Jose Sharks"], "West", 1, null) { Id = 7 },
                new SeasonTeamRule(seasonConfig, teams["Edmonton Oilers"], "West", 1, null) { Id = 8 },
                new SeasonTeamRule(seasonConfig, teams["Calgary Flames"], "West", 1, null) { Id = 9 },
                new SeasonTeamRule(seasonConfig, teams["Vancouver Canucks"], "West", 1, null) { Id = 10 },
                new SeasonTeamRule(seasonConfig, teams["Winnipeg Jets"], "Central A", 1, null) { Id = 11 },
                new SeasonTeamRule(seasonConfig, teams["Minnesota Stars"], "Central A", 1, null) { Id = 12 },
                new SeasonTeamRule(seasonConfig, teams["Chicago Blackhawks"], "Central B", 1, null) { Id = 13 },
                new SeasonTeamRule(seasonConfig, teams["Detroit Red Wings"], "Central B", 1, null) { Id = 14 }
            };

            var scheduleRules = new List<SeasonScheduleRule>()
            {
                new SeasonScheduleRule(seasonConfig, null, divisionRules.Where(dr => dr.DivisionName.Equals("NHL")).First(), null, null, 1, true, 1, null) {Id = 1 }
            };

            seasonConfig.DivisionRules = divisionRules;
            seasonConfig.TeamRules = seasonTeamRules;
            seasonConfig.ScheduleRules = scheduleRules;

            return seasonConfig;

        }
        [Theory]
        [InlineData("NHL", 14)]
        [InlineData("Eastern", 6)]
        [InlineData("Western", 8)]
        [InlineData("East", 3)]
        [InlineData("NorthEast", 2)]
        [InlineData("Atlantic", 1)]
        [InlineData("West", 4)]
        [InlineData("Central", 4)]
        [InlineData("Central A", 2)]
        [InlineData("Central B", 2)]
        public void ShouldGetTeamsInDivision(string divisionName, int expected)
        {

            var seasonConfig = CreateConfig();

            StrictEqual(expected, seasonConfig.GetTeamsInDivision(divisionName).Count);
        }

        [Theory]
        [InlineData("New York Rangers", "NorthEast", true)]
        [InlineData("New York Rangers", "Atlantic", true)]
        [InlineData("New York Rangers", "West", false)]
        [InlineData("New York Rangers", "NHL", true)]
        [InlineData("Winnipeg Jets", "NHL", true)]
        [InlineData("Edmonton Oilers", "West", true)]
        [InlineData("Edmonton Oilers", "East", false)]
        public void IsTeamInDivision(string teamName, string divisionName, bool expected)
        {
            var data = CreateConfig();            

            StrictEqual(expected, data.IsTeamInDivision(teamName, divisionName));


        }

        [Fact]
        public void ShouldValidateConfig()
        {
            var data = CreateConfig();
            var validator = new SeasonCompetitionConfigValidator();
            var result = validator.Validate(data, 1);

            True(result);
        }
        
    }
}
