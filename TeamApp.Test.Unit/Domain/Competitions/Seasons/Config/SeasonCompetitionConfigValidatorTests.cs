using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain;
using TeamApp.Domain.Competitions.Seasons.Config;
using Xunit;
using static Xunit.Assert;

namespace TeamApp.Test.Domain.Competitions.Seasons.Config
{
    public class SeasonCompetitionConfigValidatorTests
    {
        private static readonly SeasonTeamRule activeTeamRule = new SeasonTeamRule(null, new Team() { Name = "Name1", Active = true, FirstYear = 5, LastYear = 12 }, "NHL", 1, 15) { Id = 15 };        
        private static readonly SeasonTeamRule inActiveByFlagTeamRule = new SeasonTeamRule(null, new Team() { Name = "Name1", Active = false, FirstYear = 5, LastYear = 12 }, "NHL", 1, 15) { Id = 16 };
        private static readonly SeasonTeamRule inActiveByYearTeamRule = new SeasonTeamRule(null, new Team() { Name = "Name1", Active = true, FirstYear = 6, LastYear = 12 }, "NHL", 1, 15) { Id = 17 };
        private static readonly SeasonTeamRule activeRule = new SeasonTeamRule(null, new Team() { Name = "Name1", Active = true, FirstYear = 5, LastYear = 12 }, "NHL", 1, 15) { Id = 18 };
        private static readonly SeasonTeamRule inactiveRule = new SeasonTeamRule(null, new Team() { Name = "Name1", Active = true, FirstYear = 5, LastYear = 12 }, "NHL", 6, 15) { Id = 19 };

        private static readonly SeasonTeamRule ruleWithDivision = new SeasonTeamRule(null, new Team() { Name = "Name1", Active = true, FirstYear = 5, LastYear = 12 }, "Division 1", 5, 15) { Id = 20 };
        private static readonly SeasonTeamRule ruleWithoutDivision  = new SeasonTeamRule(null, new Team() { Name = "Name1", Active = true, FirstYear = 5, LastYear = 12 }, "Blah", 5, 15) { Id = 21 };
        private static readonly SeasonTeamRule ruleWithInactiveDivision = new SeasonTeamRule(null, new Team() { Name = "Name1", Active = true, FirstYear = 5, LastYear = 12 }, "Inactive Div", 5, 15) { Id = 22 };

        private static readonly SeasonDivisionRule divisionRule1 = new SeasonDivisionRule(null, "Division 1", null, 1, 1, 5, 15) { Id = 1 };
        private static readonly SeasonDivisionRule divisionRule2 = new SeasonDivisionRule(null, "NHL", null, 1, 1, 5, 15) { Id = 2 };
        private static readonly SeasonDivisionRule inactiveDivisionRule = new SeasonDivisionRule(null, "Inactive Div", null, 1, 1, 6, 15) { Id = 3 };

        public static IEnumerable<object[]> DataForTestTeamisActive()
        {
            yield return new object[] { 1, activeTeamRule, 5, true };
            yield return new object[] { 2, inActiveByFlagTeamRule, 5, false };
            yield return new object[] { 3, inActiveByYearTeamRule, 5, false };
        }

        public static IEnumerable<object[]> DataForTestSeasonTeamRuleActive()
        {
            yield return new object[] { 1, activeRule, 5, true };
            yield return new object[] { 2, inactiveRule, 5, false };
        }

        public static IEnumerable<object[]> DataForTestSeasonDivisionRuleActive()
        {
            yield return new object[] { 1, divisionRule1, 5, true };
            yield return new object[] { 2, inactiveDivisionRule, 5, false };
        }

        public static IEnumerable<object[]> DataForTestDvisionConfigExistsForTeamRule()
        {
            yield return new object[] { 1, ruleWithDivision, true };
            yield return new object[] { 2, ruleWithoutDivision, false };
            yield return new object[] { 2, ruleWithInactiveDivision, true };
        }
        [Theory]
        [MemberData(nameof(DataForTestTeamisActive))]

        public void ShouldTestTeamIsActive(int testNumber, SeasonTeamRule rule, int year, bool expected)
        {
            var config = new SeasonCompetitionConfigValidator();
            var result = config.IsTeamActive(rule, year);

            Equal(expected, result);
        }

        [Fact]
        public void ShouldValidateActiveTeams()
        {
            var list = new List<SeasonTeamRule>() { activeTeamRule, inActiveByYearTeamRule, inActiveByFlagTeamRule };

            var config = new SeasonCompetitionConfigValidator();

            var result = config.ValidateActiveTeams(list, 5);
            False(result);
            StrictEqual(2, config.Messages.Count);
            Equal("SeasonTeamRule\tTeam is not active\t16 - Name1", config.Messages[1]);  
            Equal("SeasonTeamRule\tTeam is not active\t17 - Name1", config.Messages[0]);
        }

        [Theory]
        [MemberData(nameof(DataForTestSeasonTeamRuleActive))]
        public void ShouldTestSeasonTeamRuleIsActive(int testNumber, SeasonTeamRule rule, int year, bool expected)
        {
            var config = new SeasonCompetitionConfigValidator();
            var result = config.IsSeasonTeamRuleActive(rule, year);
            Equal(expected, result);
        }

        [Fact]
        public void ShouldValidateActiveSeasonRules()
        {
            var list = new List<SeasonTeamRule>() { activeRule, inactiveRule };

            var config = new SeasonCompetitionConfigValidator();
            var result = config.ValidateActiveTeamRules(list, 5);
            False(result);
            StrictEqual(1, config.Messages.Count);
            Equal("SeasonTeamRule\tRule is not active\t19", config.Messages[0]);            
        }

        [Theory]
        [MemberData(nameof(DataForTestSeasonDivisionRuleActive))]
        public void ShouldTestSeaonDivisionRuleActive(int testNumber, SeasonDivisionRule rule, int year, bool expected)
        {
            var config = new SeasonCompetitionConfigValidator();
            var result = config.IsSeasonDivisionRuleActive(rule, year);
            Equal(expected, result);
        }

        [Fact]
        public void ShouldValidateActiveDivisionRules()
        {
            var list = new List<SeasonDivisionRule>() { divisionRule1, divisionRule2, inactiveDivisionRule };

            var config = new SeasonCompetitionConfigValidator();
            var result = config.ValidateActiveDivisionRules(list, 5);
            False(result);
            StrictEqual(1, config.Messages.Count);
            Equal("SeasonDivisionRule\tRule is not active\t3", config.Messages[0]);
        }

        [Theory]
        [MemberData(nameof(DataForTestDvisionConfigExistsForTeamRule))]
        public void ShouldTestForDivisionConfigExists(int testNumber, SeasonTeamRule rule, bool expected)
        {
            var list = new List<SeasonDivisionRule>() { divisionRule1, divisionRule2, inactiveDivisionRule };
            var config = new SeasonCompetitionConfigValidator();
            var result = config.DoesSeasonDivisionRuleExistForSeasonTeamRule(list, rule);
            Equal(expected, result);
        }

        [Fact]
        public void ShouldValidateDivisionsExistForTeamRules()
        {
            var list = new List<SeasonDivisionRule>() { divisionRule1, divisionRule2, inactiveDivisionRule };
            var teamRules = new List<SeasonTeamRule>() { ruleWithDivision, ruleWithInactiveDivision, ruleWithoutDivision, activeTeamRule };
            var config = new SeasonCompetitionConfigValidator();
            var result = config.ValidateDivisionRuleExistsForTeamRules(list, teamRules);

            False(result);
            StrictEqual(1, config.Messages.Count);
            Equal("SeasonDivisionRule\tRule Does Not Exist For Division\tDivision:Blah TeamRule:22", config.Messages[0]);
        }
    }
}
