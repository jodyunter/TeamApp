using System.Collections.Generic;
using TeamApp.Domain;
using TeamApp.Domain.Competitions.Seasons.Config;
using TeamApp.Test.Helpers;
using Xunit;
using static Xunit.Assert;

namespace TeamApp.Test.Domain.Competitions.Seasons.Config
{
    public class SeasonCompetitionTests
    {
        [Theory]
        [InlineData("NHL", 14)]
        [InlineData("Eastern", 6)]
        [InlineData("Western", 7)]
        [InlineData("East", 3)]
        [InlineData("NorthEast", 2)]
        [InlineData("Atlantic", 1)]
        [InlineData("West", 4)]
        [InlineData("Central", 4)]
        [InlineData("Central A", 2)]
        [InlineData("Central B", 2)]
        public void ShouldGetTeamsInDivision(string divisionName, int expected)
        {
            var seasonConfig = new SeasonCompetitionConfig("My Season", null, 1, 1, null, 1, null, null, null, null, null);
            var divisionRules = new List<SeasonDivisionRule>()
            {
                new SeasonDivisionRule(seasonConfig, "NHL", null, 1, 1, 1, null),
                new SeasonDivisionRule(seasonConfig, "Eastern", "NHL", 2, 1, 1, null),
                new SeasonDivisionRule(seasonConfig, "Western", "NHL", 2, 2, 1, null),
                new SeasonDivisionRule(seasonConfig, "East", "Eastern",2,1,1,null),
                new SeasonDivisionRule(seasonConfig, "Atlantic", "Eastern",2,2,1,null),
                new SeasonDivisionRule(seasonConfig, "NorthEast", "Eastern",2,3,1,null),
                new SeasonDivisionRule(seasonConfig, "West", "Western",2,4,1,null),
                new SeasonDivisionRule(seasonConfig, "Central", "Western",2,5,1,null),
                new SeasonDivisionRule(seasonConfig, "Central A", "Central",3,1,1,null),
                new SeasonDivisionRule(seasonConfig, "Central B", "Central",3,2,1,null)
            };

            var teams = new Dictionary<string, Team>()
            {
                { "Key",null },
                {"Boston Bruins", new Team(){Name="Boston", NickName="Bruins" } }, //east
                {"Montreal Canadiens", new Team(){Name="Montreal", NickName="Canadiens" } }, //east
                {"Toronto Maple Leafs", new Team(){Name="Toronto", NickName="Maple Leafs" } }, //east
                {"Quebec Nordiques", new Team(){Name="Quebec", NickName="Nordiques" } }, //atlantic
                {"Pittsburgh Penguins", new Team(){Name="Pittsburgh", NickName="Penguins" } }, //northeast
                {"New Jersey Devils", new Team(){Name="New Jersey", NickName="Devils" } }, //northesat
                {"San Jose Sharks", new Team(){Name="San Josey", NickName="Sharks" } }, //west
                {"Edmonton Oilers", new Team(){Name="Edmonton", NickName="Oilers" } }, //west
                {"Calgary Flames", new Team(){Name="Calgary", NickName="Flames" } }, //west
                {"Vancouver Canucks", new Team(){Name="Vancouver", NickName="Canucks" } }, //west
                {"Winnipeg Jets", new Team(){Name="Winnipeg", NickName="Jets" } }, //Central A
                {"Minnesota Stars", new Team(){Name="Minnesota", NickName="Stars" } }, //Central A
                {"Chicago Blackhawks", new Team(){Name="Chicago", NickName="Blackhawks" } }, //Central B
                {"Detroit Red Wings", new Team(){Name="Detroit", NickName="Red Wings" } }, //Central B

            };

            var seasonTeamRules = new List<SeasonTeamRule>()
            {
                new SeasonTeamRule(seasonConfig, teams["Boston Bruins"], "East", 1, null),
                new SeasonTeamRule(seasonConfig, teams["Montreal Canadiens"], "East", 1, null),
                new SeasonTeamRule(seasonConfig, teams["Toronto Maple Leafs"], "East", 1, null),
                new SeasonTeamRule(seasonConfig, teams["Quebec Nordiques"], "Atlantic", 1, null),
                new SeasonTeamRule(seasonConfig, teams["Pittsburgh Penguins"], "NortEast", 1, null),
                new SeasonTeamRule(seasonConfig, teams["New Jersey Devils"], "NorthEast", 1, null),
                new SeasonTeamRule(seasonConfig, teams["San Jose Sharks"], "West", 1, null),
                new SeasonTeamRule(seasonConfig, teams["Edmonton Oilers"], "West", 1, null),
                new SeasonTeamRule(seasonConfig, teams["Calgary Flames"], "West", 1, null),
                new SeasonTeamRule(seasonConfig, teams["Vancouver Canucks"], "West", 1, null),
                new SeasonTeamRule(seasonConfig, teams["Winnipeg Jets"], "Central A", 1, null),
                new SeasonTeamRule(seasonConfig, teams["Minnesota Stars"], "Central A", 1, null),
                new SeasonTeamRule(seasonConfig, teams["Chicago Blackhawks"], "Central B", 1, null),
                new SeasonTeamRule(seasonConfig, teams["Detroit Red Wings"], "Central B", 1, null)
            };

            seasonConfig.DivisionRules = divisionRules;
            seasonConfig.TeamRules = seasonTeamRules;
                                   

            StrictEqual(expected, seasonConfig.GetTeamsInDivision(divisionName).Count);
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
