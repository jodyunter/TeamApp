using System.Collections.Generic;
using TeamApp.Domain;
using System.Linq;
using Xunit;
using static Xunit.Assert;
using TeamApp.Domain.Competitions.Config.Seasons;

namespace TeamApp.Test.Domain.Competitions.Seasons.Config
{
    public class SeasonCompetitionConfigTests
    {
        private SeasonCompetitionConfig CreateConfig()
        {
            var seasonConfig = new SeasonCompetitionConfig("My Season", null, 1, 1, null, 1, null, null, null, null, null);
            var sdrNHL = new SeasonDivisionRule(seasonConfig, "NHL", null, 1, 1, null, 1, null) { Id = 1 };
            var sdrEastern = new SeasonDivisionRule(seasonConfig, "Eastern", sdrNHL, 2, 1, null, 1, null) { Id = 2 };
            var sdrWestern = new SeasonDivisionRule(seasonConfig, "Western", sdrNHL, 2, 2, null, 1, null) { Id = 3 };
            var sdrEast = new SeasonDivisionRule(seasonConfig, "East", sdrEastern, 2, 1, null, 1, null) { Id = 4 };
            var sdrAtlantic = new SeasonDivisionRule(seasonConfig, "Atlantic", sdrEastern, 2, 2, null, 1, null) { Id = 5 };
            var sdrNorthEast = new SeasonDivisionRule(seasonConfig, "NorthEast", sdrEastern, 2, 3, null, 1, null) { Id = 6 };
            var sdrWest = new SeasonDivisionRule(seasonConfig, "West", sdrWestern, 2, 4, null, 1, null) { Id = 7 };
            var sdrCentral = new SeasonDivisionRule(seasonConfig, "Central", sdrWestern, 2, 5, null, 1, null) { Id = 8 };
            var sdrCentralA = new SeasonDivisionRule(seasonConfig, "Central A", sdrCentral, 3, 1, null, 1, null) { Id = 9 };
            var sdrCentralB = new SeasonDivisionRule(seasonConfig, "Central B", sdrCentral, 3, 2, null, 1, null) { Id = 10 };


            var bruins = new Team() { Name = "Boston", NickName = "Bruins", FirstYear = 1, Active = true, Id = 1 }; //east
            var canadiens = new Team() { Name = "Montreal", NickName = "Canadiens", FirstYear = 1, Active = true, Id = 2 }; //east
            var mapleLeafs = new Team() { Name = "Toronto", NickName = "Maple Leafs", FirstYear = 1, Active = true, Id = 3 }; //esat
            var nordiques = new Team() { Name = "Quebec", NickName = "Nordiques", FirstYear = 1, Active = true, Id = 4 }; //atlantic
            var penguins = new Team() { Name = "Pittsburgh", NickName = "Penguins", FirstYear = 1, Active = true, Id = 5 }; //northeast
            var devils = new Team() { Name = "New Jersey", NickName = "Devils", FirstYear = 1, Active = true, Id = 6 }; //northeast
            var sharks = new Team() { Name = "San Josey", NickName = "Sharks", FirstYear = 1, Active = true, Id = 7 }; //west
            var oilers = new Team() { Name = "Edmonton", NickName = "Oilers", FirstYear = 1, Active = true, Id = 8 }; //west
            var flames = new Team() { Name = "Calgary", NickName = "Flames", FirstYear = 1, Active = true, Id = 9 }; //west
            var canucks = new Team() { Name = "Vancouver", NickName = "Canucks", FirstYear = 1, Active = true, Id = 10 }; //west
            var jets = new Team() { Name = "Winnipeg", NickName = "Jets", FirstYear = 1, Active = true, Id = 11 };//Central A
            var stars = new Team() { Name = "Minnesota", NickName = "Stars", FirstYear = 1, Active = true, Id = 12 };//Central A
            var blackHawks = new Team() { Name = "Chicago", NickName = "Blackhawks", FirstYear = 1, Active = true, Id = 13 };//Central B
            var redWings = new Team() { Name = "Detroit", NickName = "Red Wings", FirstYear = 1, Active = true, Id = 14 };//Central B


            var seasonTeamRules = new List<SeasonTeamRule>()
            {
                new SeasonTeamRule(seasonConfig, bruins, sdrEast, 1, null) { Id = 1 },
                new SeasonTeamRule(seasonConfig, canadiens, sdrEast, 1, null) { Id = 2 },
                new SeasonTeamRule(seasonConfig, mapleLeafs, sdrEast, 1, null) { Id = 3 },
                new SeasonTeamRule(seasonConfig, nordiques, sdrAtlantic, 1, null) { Id = 4 },
                new SeasonTeamRule(seasonConfig, penguins, sdrNorthEast, 1, null) { Id = 5 },
                new SeasonTeamRule(seasonConfig, devils, sdrNorthEast, 1, null) { Id = 6 },
                new SeasonTeamRule(seasonConfig, sharks, sdrWest, 1, null) { Id = 7 },
                new SeasonTeamRule(seasonConfig, oilers, sdrWest, 1, null) { Id = 8 },
                new SeasonTeamRule(seasonConfig, flames, sdrWest, 1, null) { Id = 9 },
                new SeasonTeamRule(seasonConfig, canucks, sdrWest, 1, null) { Id = 10 },
                new SeasonTeamRule(seasonConfig, jets, sdrCentralA, 1, null) { Id = 11 },
                new SeasonTeamRule(seasonConfig, stars, sdrCentralA, 1, null) { Id = 12 },
                new SeasonTeamRule(seasonConfig, blackHawks, sdrCentralB, 1, null) { Id = 13 },
                new SeasonTeamRule(seasonConfig, redWings, sdrCentralB, 1, null) { Id = 14 }
            };            

            var scheduleRules = new List<SeasonScheduleRule>()
            {
                new SeasonScheduleRule(seasonConfig, null, sdrNHL, null, null, 1, true, 1, null) {Id = 1 }
            };

            var divisionRules = new List<SeasonDivisionRule>()
            {
                sdrNHL,
                sdrEastern,
                sdrWestern,
                sdrEast,
                sdrAtlantic,
                sdrNorthEast,
                sdrWest,
                sdrCentral,
                sdrCentralA,
                sdrCentralB
            };

            seasonConfig.DivisionRules = divisionRules;
            seasonConfig.TeamRules = seasonTeamRules;
            seasonConfig.ScheduleRules = scheduleRules;

            sdrEast.Teams = seasonTeamRules.Where(str => str.Division.DivisionName.Equals("East"));
            sdrAtlantic.Teams = seasonTeamRules.Where(str => str.Division.DivisionName.Equals("Atlantic"));
            sdrNorthEast.Teams = seasonTeamRules.Where(str => str.Division.DivisionName.Equals("NorthEast"));
            sdrWest.Teams = seasonTeamRules.Where(str => str.Division.DivisionName.Equals("West"));
            sdrCentralA.Teams = seasonTeamRules.Where(str => str.Division.DivisionName.Equals("Central A"));
            sdrCentralB.Teams = seasonTeamRules.Where(str => str.Division.DivisionName.Equals("Central B"));

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

        [Fact]
        public void ShouldValidateConfig()
        {
            var data = CreateConfig();
            var validator = new SeasonCompetitionConfigValidator();
            var result = validator.Validate(data, 1);

            True(result);
        }

        [Fact]
        public void ShouldTestCreateCompetitionTeam()
        {
            True(false);
        }

        [Theory]
        [InlineData("NHL", 9)]
        [InlineData("Eastern", 3)]
        [InlineData("Western", 4)]
        [InlineData("East", 0)]
        [InlineData("NorthEast", 0)]
        [InlineData("Atlantic", 0)]
        [InlineData("West", 0)]
        [InlineData("Central", 2)]
        [InlineData("Central A", 0)]
        [InlineData("Central B", 0)]
        public void ShouldGetChildDivisions(string divisionName, int expected)
        {
            var seasonConfig = CreateConfig();
            var rule = seasonConfig.DivisionRules.Where(dr => dr.DivisionName.Equals(divisionName)).First();

            StrictEqual(expected, seasonConfig.GetChildDivisions(rule).Count);
        }

        [Fact]
        public void ShouldGetFinalRankings()
        {
            True(false);
        }
    }
}
