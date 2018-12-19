
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using static Xunit.Assert;
using TeamApp.Data.Repositories.NHibernate;
using TeamApp.Domain;
using TeamApp.Domain.Repositories;
using Xunit;
using System.Linq;
using TeamApp.Domain.Schedules;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Competitions.Playoffs;
using TeamApp.Domain.Competitions.Seasons;
using System.Collections.Generic;
using TeamApp.Test.Helpers;

namespace TeamApp.Test.Data
{
    public class RepositoryTests:IDisposable
    {
        protected ISession session;
        private Configuration configuration;

        protected bool dropDatabase = true;
        protected SchemaExport schemaExport;

        public RepositoryTests()
        {
            session = NHibernateHelper.OpenSession();
            configuration = NHibernateHelper.GetConfiguration().BuildConfiguration();
            schemaExport = new SchemaExport(configuration);
            SetupDatabase();                    
        }

        public void Dispose()
        {
            if (dropDatabase)
            {
                DropDatabase();
            }

            NHibernateHelper.CloseSession();
        }
    
        private void SetupDatabase()
        {
            schemaExport.Create(false, true);

        }

        private void DropDatabase()
        {
            schemaExport.Drop(false, true);
        }



        #region Team Repo Tests
        [Fact]
        
        public void ShouldExterciseTeamRepositoryNHibernate()
        {
            var repo = new TeamRepositoryNHibernate();
            var newTeamId = (long)repo.Add(new Team("Add Team", "AddNick", "AddShort", 5, "Me", 1, null, true));
            var newTeam = repo.Get(newTeamId);
            NotEqual(0L, newTeam.Id);

            newTeam.Name = "Updated Name";
            newTeam.NickName = "UpdatedNick";
            newTeam.ShortName = "UpdatedShort";
            newTeam.Skill = 10;
            newTeam.Owner = "Not Me";
            newTeam.FirstYear = 15;
            newTeam.LastYear = 25;
            newTeam.Active = false;

            repo.Update(newTeam);

            var updatedTeam = repo.Get(newTeam.Id);

            Equals("Updated Name", newTeam.Name);
            
            for (int i = 0; i < 10; i++)
            {
                repo.Add(new Team("Team " + i, "AddNick" + i, "AddShort" + i, 5, "Me" + i, 1, i, true));
            }

            Equals(11, repo.GetAll().ToList().Count);


            Equals(1, repo.GetByStatus(false));
            Equals(10, repo.GetByStatus(true));
            Equals("AddNick5", repo.GetByName("Team 5").NickName);
        }
        #endregion
        #region Competition Repo Tests
        [Fact]
        public void ShouldExerciseCompetitionRepositoryNHibernate()
        {
            AddDataForTests();

            var repo = new CompetitionRepositoryNHibernate();
            Equals(2, repo.GetAll().Count());

            Equals(7, repo.GetByNameAndYear("My Season", 1).Teams.Count());

            var comps = repo.GetByYear(1);
            Equals(2, comps.Count());
        }
        #endregion
        #region Team Ranking Repo Tests
        [Fact]
        public void ShouldExerciseTeamRankingRepositoryNHibernate()
        {
            AddDataForTests();

            var repo = new TeamRankingRepositoryNHibernate();
            var compRepo = new CompetitionRepositoryNHibernate();

            var comp = compRepo.GetByNameAndYear("My Playoff", 1);
            var rankings = repo.GetByCompetition(comp.Id);
            Equals(8, rankings.Count());
        }

        #endregion
        #region Standings Repo Tests
        [Fact]
        public void ShouldExerciseStandingsRepository()
        {
            AddDataForTests();
            var repo = new StandingsRepositoryNHibernate();
            var compRepo = new CompetitionRepositoryNHibernate();
            var teams = repo.GetByCompetition(compRepo.GetByNameAndYear("My Season", 1).Id);
            
            Equals(7, teams.Count);
        }
        #endregion
        [Fact]
        public void ShouldExportSchema()
        {
            schemaExport.SetOutputFile("../../../sqloutput/ddl.sql");
            schemaExport.Execute(false, false, false);
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


        private void PlayAYear()
        {
            //assumes data is added
        }
        private void AddDataForTests()
        {
            var test = new RepositoryNHibernate<League>();
            var seasonRepo = new RepositoryNHibernate<Season>();
            var playoffRepo = new RepositoryNHibernate<Playoff>();
            var gameRepo = new RepositoryNHibernate<ScheduleGame>();

            var league = RepositoryTestData.CreateBasicLeague("NHL");
            var seasonConfig = RepositoryTestData.CreateBasicSeasonConfiguration(league);
            var playoffConfig = RepositoryTestData.CreateBasicPlayoffConfiguration(seasonConfig);

            var season = seasonConfig.CreateCompetition(1, null);

            var random = new Random(55123);

            while (!season.IsComplete())
            {
                season.PlayNextDay(random).ForEach(g =>
                {
                    gameRepo.Update(g);
                });

            }

            ((Season)season).SortAllTeams();
            seasonRepo.Update((Season)season);

            var playoff = playoffConfig.CreateCompetition(1, new List<Competition> { season });

            while (!playoff.IsComplete())
            {
                playoff.PlayNextDay(random).ForEach(g =>
                {
                    gameRepo.Update(g);
                });
            }
            playoffRepo.Update((Playoff)playoff);

            test.Update(league);
            session.Flush();
        }


        //can use this to get some base data going
        [Fact]
        public void ShouldPopulateDatabase()
        {
            AddDataForTests();
            var repo = new StandingsRepositoryNHibernate();

            var data = repo.GetByCompetition(1);

            Equal(7, data.Count);

            dropDatabase = true;

        }

        //team tests

    }
}
