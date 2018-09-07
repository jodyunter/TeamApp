using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Services;
using static Xunit.Assert;
using TeamApp.Test.Helpers;
using TeamApp.Domain.Competition.Season.Config;

namespace TeamApp.Test.Services
{
    public class SeasonServiceTests
    {
        [Xunit.Fact]
        public void ShouldCreateSeason()
        {
            var seasonName = "My Season";
            int seasonNumber = 2;

            var data = Data1.CreateBasicSeasonConfiguration();

            var seasonService = new SeasonService();

            var season = seasonService.CreateNewSeason(((List<SeasonCompetition>)data[Data1.BASIC_SEASON_COMPETITION_LSIT])[0], seasonName, seasonNumber);

            Equal(seasonNumber, season.Year);
            Equal(seasonName, season.Name);
            Equal(12, season.Teams.Count);
            Equal(3, season.Divisions.Count);
                        
        }
    }
}
