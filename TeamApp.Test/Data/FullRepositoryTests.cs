using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Data.Repositories.NHibernate;
using TeamApp.Domain;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Competitions.Playoffs;
using TeamApp.Domain.Competitions.Playoffs.Series;
using TeamApp.Domain.Competitions.Seasons;
using TeamApp.Domain.Schedules;
using TeamApp.Test.Helpers;
using Xunit;
using static Xunit.Assert;

namespace TeamApp.Test.Data
{
    public class FullRepositoryTests
    {
        //this can be used to populate the database for testing

        private ISession session;
        private Configuration configuration;

        private bool dropDatabase = false;
        private bool setupDatabase = true;

        public FullRepositoryTests()
        {
            session = NHibernateHelper.OpenSession();
            configuration = NHibernateHelper.GetConfiguration().BuildConfiguration();
            
            SetupDatabase();
            DropDatabase();
        }

        [Fact]
        public void ShouldDoSomething()
        {
            var test = new RepositoryNHibernate<League>();

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
            test.Update(league);
            session.Flush();

            var playoff = playoffConfig.CreateCompetition(1, new List<Competition> { season });

            while (!playoff.IsComplete())
            {
                playoff.PlayNextDay(random);  
            }
            test.Update(league);
            session.Flush();


            test.Update(league);
            session.Flush();
        }
        private void SetupDatabase()
        {
            if (setupDatabase)
            {
                var schemaExport = new SchemaExport(configuration);
                schemaExport.SetOutputFile("../../../sqloutput/ddl.sql");
                schemaExport.Execute(false, true, false);
            }
        }

        private void DropDatabase()
        {
            if (dropDatabase)
            {
                var schemaExport = new SchemaExport(configuration);
                schemaExport.Drop(false, true);
            }
        }
    }
}
