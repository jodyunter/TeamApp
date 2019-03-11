using System.Collections.Generic;
using TeamApp.Domain;
using TeamApp.Domain.Competitions.Config.Seasons;
using Xunit;
using static Xunit.Assert;

namespace TeamApp.Test.Domain.Competitions.Seasons.Config
{
    public class SeasonCompetitionConfigValidatorTests
    {
        private static readonly SeasonTeamRule activeTeamRule = new SeasonTeamRule(null, new Team() { Name = "Name1", Active = true, FirstYear = 5, LastYear = 12 }, "NHL", 1, 15) { Id = 15 };        
        private static readonly SeasonTeamRule inActiveByFlagTeamRule = new SeasonTeamRule(null, new Team() { Name = "Name1", Active = false, FirstYear = 5, LastYear = 12 }, "NHL", 1, 15) { Id = 16 };
        private static readonly SeasonTeamRule inActiveByYearTeamRule = new SeasonTeamRule(null, new Team() { Name = "Name1", Active = true, FirstYear = 6, LastYear = 12 }, "NHL", 1, 15) { Id = 17 };

        private static readonly SeasonTeamRule ruleWithDivision = new SeasonTeamRule(null, new Team() { Name = "Name1", Active = true, FirstYear = 5, LastYear = 12 }, "Division 1", 5, 15) { Id = 20 };
        private static readonly SeasonTeamRule ruleWithoutDivision  = new SeasonTeamRule(null, new Team() { Name = "Name1", Active = true, FirstYear = 5, LastYear = 12 }, "Blah", 5, 15) { Id = 21 };
        private static readonly SeasonTeamRule ruleWithInactiveDivision = new SeasonTeamRule(null, new Team() { Name = "Name1", Active = true, FirstYear = 5, LastYear = 12 }, "Inactive Div", 5, 15) { Id = 22 };

        private static readonly SeasonDivisionRule divisionRule1 = new SeasonDivisionRule(null, "Division 1", null, 1, 1, 5, 15) { Id = 1 };
        private static readonly SeasonDivisionRule divisionRule2 = new SeasonDivisionRule(null, "NHL", null, 1, 1, 5, 15) { Id = 2 };
        private static readonly SeasonDivisionRule inactiveDivisionRule = new SeasonDivisionRule(null, "Inactive Div", null, 1, 1, 6, 15) { Id = 3 };

        public static IEnumerable<object[]> DataForTestDvisionConfigExistsForTeamRule()
        {
            yield return new object[] { 1, ruleWithDivision, true };
            yield return new object[] { 2, ruleWithoutDivision, false };
            yield return new object[] { 2, ruleWithInactiveDivision, true };
        }

        [Fact]
        public void ShouldValidateActiveTeams()
        {
            var list = new List<SeasonTeamRule>() { activeTeamRule, inActiveByYearTeamRule, inActiveByFlagTeamRule };
            var expected1 = "SeasonTeamRule\tTeam is not active for year.\tId:16 Name:Name1 Year:5";
            var expected2 = "SeasonTeamRule\tTeam is not active for year.\tId:17 Name:Name1 Year:5";
            var config = new SeasonCompetitionConfigValidator();

            var result = config.ValidateActiveTeams(list, 5);
            False(result);
            StrictEqual(2, config.Messages.Count);
            Equal(expected1, config.Messages[1]);  
            Equal(expected2, config.Messages[0]);
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
            var expected = "SeasonDivisionRule\tRule does not exist for division.\tDivision:Blah TeamRule:21";

            False(result);
            StrictEqual(1, config.Messages.Count);
            Equal(expected, config.Messages[0]);
        }

    }
}
