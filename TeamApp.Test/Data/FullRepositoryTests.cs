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
            var seasonRepo = new RepositoryNHibernate<Season>();
            var playoffRepo = new RepositoryNHibernate<Playoff>();
            var gameRepo = new RepositoryNHibernate<ScheduleGame>();
            var seriesRepo = new RepositoryNHibernate<PlayoffSeries>();
            var bestOfRepo = new RepositoryNHibernate<BestOfSeries>();

            var league = Data2.CreateBasicLeague("NHL");
            var seasonConfig = Data2.CreateBasicSeasonConfiguration(league);
            var playoffConfig = Data2.CreateBasicPlayoffConfiguration(seasonConfig);

            var season = seasonConfig.CreateCompetition(1, null);

            seasonRepo.Update((Season)season);            

            var random = new Random(55123);

            while (!season.IsComplete())
            {
                season.PlayNextDay(random).ForEach(g =>
                {
                    //gameRepo.Update(g);
                });
                
            }

            ((Season)season).SortAllTeams();

            seasonRepo.Update((Season)season);
            

            var playoff = playoffConfig.CreateCompetition(1, new List<Competition> { season });
            playoffRepo.Update((Playoff)playoff);

            while (!playoff.IsComplete())
            {
                playoff.PlayNextDay(random).ForEach(g =>
                {                    
                                       
                 //   gameRepo.Update(g);
                });                
            }

            playoffRepo.Update((Playoff)playoff);

            session.Flush();
            test.Update(league);
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
