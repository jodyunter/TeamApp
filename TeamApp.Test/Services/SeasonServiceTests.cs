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
            Equal(20, season.Teams.Count);
            Equal(6, season.Divisions.Count);
            Equal(4, season.Divisions.Where(t => t.Name == "Atlantic").First().Teams.Count);
            Equal(4, season.Divisions.Where(t => t.Name == "NorthEast").First().Teams.Count);
            Equal(6, season.Divisions.Where(t => t.Name == "West").First().Teams.Count);
            Equal(6, season.Divisions.Where(t => t.Name == "Central").First().Teams.Count);
            Equals("EAST", season.Divisions.Where(t => t.Name == "Atlantic").First().ParentDivision.Name);
            Equals("EAST", season.Divisions.Where(t => t.Name == "NorthEast").First().ParentDivision.Name);
            Equals("NHL", season.Divisions.Where(t => t.Name == "West").First().ParentDivision.Name);
            Equals("NHL", season.Divisions.Where(t => t.Name == "Central").First().ParentDivision.Name);

        }
    }
}
