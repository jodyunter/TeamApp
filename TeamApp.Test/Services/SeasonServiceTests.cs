using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Services;
using static Xunit.Assert;
using TeamApp.Test.Helpers;
using TeamApp.Domain.Competition.Season.Config;
using System.Linq;

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
            Equal(6, season.Divisions.Where(t => t.Name == "Division 1").First().Teams.Count);
            Equal(6, season.Divisions.Where(t => t.Name == "Division 2").First().Teams.Count);
            Equals("League 1", season.Divisions.Where(t => t.Name == "Division 1").First().ParentDivision.Name);
            Equals("League 1", season.Divisions.Where(t => t.Name == "Division 2").First().ParentDivision.Name);

        }
    }
}
