using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competitions.Config.Seasons;
using Xunit;
using static Xunit.Assert;

namespace TeamApp.Test.Domain.Competitions.Seasons.Config
{
    public class SeasonCompetitionConfigFinalRankingRuleTests
    {
        [Fact]
        //turn to theory with each option
        public void ShouldTestGetTeamFromRule()
        {
            var rule = new SeasonCompetitionConfigFinalRankingRule("Test Rule", 5, "NHL", 1, 6, 1, null);
        }
    }
}
