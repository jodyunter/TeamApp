using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Data.Repositories.NHibernate;
using TeamApp.Domain;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Competitions.Seasons;
using TeamApp.Test.Helpers;
using Xunit;
using static Xunit.Assert;

namespace TeamApp.Test.Data
{
    public class FullRepositoryTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            var test = new Repository<League>();

            var league = Data2.CreateBasicLeague("NHL");
            var seasonConfig = Data2.CreateBasicSeasonConfiguration(league);
            var playoffConfig = Data2.CreateBasicPlayoffConfiguration(seasonConfig);

            var season = seasonConfig.CreateCompetition(1, null);

            var random = new Random(55123);

            while (!season.IsComplete())
            {
                season.PlayNextDay(random);
            }

            ((Season)season).SortAllTeams();

            var playoff = playoffConfig.CreateCompetition(1, new List<Competition> { season });

            while (!playoff.IsComplete())
            {
                playoff.PlayNextDay(random);
            }
        }
    }
}
