using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Services;
using static Xunit.Assert;

namespace TeamApp.Test.Services
{
    public class SeasonServiceTests
    {
        [Xunit.Fact]
        public void ShouldCreateSeason()
        {
            var data = Helpers.Data1.CreateBasicSeasonConfiguration();

            var seasonService = new SeasonService();
                        
        }
    }
}
