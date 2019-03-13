using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competitions.Config.Playoffs;
using Xunit;
using static Xunit.Assert;

namespace TeamApp.Test.Domain.Competitions.Playoffs.Config
{
    public class PlayoffCompetitionConfigValidatorTests
    {
        [Theory]
        [InlineData(1, "PlayoffCompetitionConfig\tCompetition Configuration is not active for year.\tId:12345 Name:This is my config Year:1", false)]
        [InlineData(5, "", true)]
        [InlineData(25, "", true)]
        [InlineData(55, "", true)]
        [InlineData(66, "PlayoffCompetitionConfig\tCompetition Configuration is not active for year.\tId:12345 Name:This is my config Year:66", false)]
        public void ShouldTestIsConfigActive(int year, string expectedMessage, bool expectedResult)
        {
            var config = new PlayoffCompetitionConfig();
            config.Name = "This is my config";
            config.Id = 12345;
            config.FirstYear = 5;
            config.LastYear = 55;

            var validator = new PlayoffCompetitionConfigValidator();
            var result = validator.ConfigIsActive(config, year);
            

            string message = "";

            if (validator.Messages != null && validator.Messages.Count > 0)
            {
                message = validator.Messages[0];
            }            

            Equal(expectedResult, result);
            Equal(expectedMessage, message);
        }
    }
}
