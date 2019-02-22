using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using static Xunit.Assert;
using TeamApp.Data.Repositories.Relational.NHibernate;
using TeamApp.Domain;
using Xunit;
using System.Linq;
using TeamApp.Domain.Schedules;
using TeamApp.Domain.Competitions;
using System.Collections.Generic;
using TeamApp.Test.Helpers;
using TeamApp.Data.Relational.Repositories;
using TeamApp.Domain.Competitions.Seasons;
using System.Threading;
using TeamApp.Domain.Competitions.Playoffs;
using TeamApp.Domain.Competitions.Seasons.Config;
using TeamApp.Data.Repositories.Relational;
using TeamApp.Domain.Competitions.Playoffs.Config;

namespace TeamApp.Test.Data
{
    public class RepositoryTests : IDisposable
    {
        private string user = "repo user";

        protected ISession session;
        private Configuration configuration;

        protected bool dropDatabase = true;
        protected bool dropFirst = true;
        protected SchemaExport schemaExport;

        public RepositoryTests()
        {
            var user = new User("Jody_Program_User");
            Thread.CurrentPrincipal = user;

            session = NHibernateHelper.OpenSession();
            configuration = NHibernateHelper.GetConfiguration().BuildConfiguration();
            schemaExport = new SchemaExport(configuration);
            if (dropFirst)
            {
                DropDatabase();
            }
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
            var repo = new TeamRepository(new RepositoryNHibernate<Team>());

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
            var repo = new CompetitionRepository(new RepositoryNHibernate<Competition>());
            var configRepo = new CompetitionConfigRepository(new RepositoryNHibernate<CompetitionConfig>());

            var cc1 = new SeasonCompetitionConfig("Test 1", null, 1, 1, null, 1, null, null, null, null, null);
            var c1 = new Season(cc1, "Test 1", 5, null, null, null, null, true, false, 5, 55);
            var cc2 = new PlayoffCompetitionConfig("P3", null, 2, 25, null, 1, null, null, null, new List<CompetitionConfig> { cc1 });
            var c8 = new Playoff(cc2, "P3", 5, 5, null, null, null, null, false, false, 5, 12);
            var c2 = new Season(null, "Test 2", 6, null, null, null, null, true, true, 5, 55);
            var c3 = new Season(null, "Test 3", 7, null, null, null, null, true, false, 5, 55);
            var c4 = new Season(null, "Test 4", 8, null, null, null, null, true, false, 5, 55);
            var c5 = new Season(null, "Test 5", 9, null, null, null, null, true, false, 5, 55);
            var c6 = new Playoff(null, "P1", 8, 5, null, null, null, null, true, false, 5, 12);
            var c7 = new Playoff(null, "P2", 8, 5, null, null, null, null, false, false, 5, 12);

            repo.Update(c1);
            repo.Update(c2);
            repo.Update(c3);
            repo.Update(c4);
            repo.Update(c5);
            repo.Update(c6);
            repo.Update(c7);
            repo.Update(c8);
            

            //getall
            StrictEqual(8, repo.GetAll().Count());
            //GetByNameAndYear
            Equal("P3", repo.GetByNameAndYear("P3", 5).Name);
            //GetByYear
            StrictEqual(3, repo.GetByYear(8).Count());
            //GetStartedAndUnfinishedCompetitionsByYear
            StrictEqual(2, repo.GetStartedAndUnfinishedCompetitionsByYear(8).Count());
            StrictEqual(0, repo.GetStartedAndUnfinishedCompetitionsByYear(6).Count());
            //IsCompetitionCompleteForYear
            False(repo.IsCompetitionCompleteForYear(5, cc1));  
            False(repo.IsCompetitionCompleteForYear(12, cc1)); //hasn't even been created yet!
            //GetParentCompetitionsForCompetitionConfig
            var parents = repo.GetParentCompetitionsForCompetitionConfig(cc2, 5).ToList();
            StrictEqual(1, parents.Count());
            Equal("P3", parents[0].Name);
            Equal(5, parents[0].Year);

        }
        #endregion
        #region Competition Config Repo Tests
        [Fact]
        public void ShouldExerciseCompetitionConfigRepositoryNHibernate()
        {
            var repo = new CompetitionConfigRepository(new RepositoryNHibernate<CompetitionConfig>());
            
            var config1 = new SeasonCompetitionConfig("Season 1", null, 1, 1, 12, 1, null, null, null, null, null);
            var config2 = new SeasonCompetitionConfig("Season 2", null, 1, 1, 12, 1, null, null, null, null, null);
            var config3 = new SeasonCompetitionConfig("Season 3", null, 1, 3, 12, 1, null, null, null, null, null);
            var config4 = new SeasonCompetitionConfig("Season 4", null, 5, 1, 12, 1, null, null, null, null, null);
            var config5 = new SeasonCompetitionConfig("Season 5", null, 5, 2, 12, 1, null, null, null, null, null);
            
            repo.Update(config1);
            repo.Update(config2);
            repo.Update(config3);
            repo.Update(config4);
            repo.Update(config5);

            //GetConfigByStartingDayAndYear
            StrictEqual(3, repo.GetConfigByStartingDayAndYear(1, 6).Count());
            StrictEqual(2, repo.GetConfigByStartingDayAndYear(1, 2).Count());
            //GetConfigByYear
            StrictEqual(5, repo.GetConfigByYear(8).Count());
            StrictEqual(4, repo.GetConfigByYear(2).Count());
        }
        #endregion
        #region Team Ranking Repo Tests
        [Fact]
        public void ShouldExerciseTeamRankingRepositoryNHibernate()
        {
            SetupConfigForTests("NHL");
            PlayAnotherYear(1, "NHL", new Random(55123));

            var repo = new TeamRankingRepository(new RepositoryNHibernate<TeamRanking>());
            var compRepo = new CompetitionRepository(new RepositoryNHibernate<Competition>());

            var comp = compRepo.GetByNameAndYear("My Playoff", 1);
            var rankings = repo.GetByCompetition(comp.Id);
            StrictEqual(8, rankings.Count());
        }

        #endregion
        #region Standings Repo Tests
        [Fact]
        public void ShouldExerciseStandingsRepository()
        {
            SetupConfigForTests("NHL");
            PlayAnotherYear(1, "NHL", new Random(55123));
            var compRepo = new CompetitionRepository(new RepositoryNHibernate<Competition>());
            var repo = new StandingsRepository(new RepositoryNHibernate<SeasonTeam>(), compRepo);
            var teams = repo.GetByCompetition(compRepo.GetByNameAndYear("My Season", 1).Id);

            StrictEqual(7, teams.Count);
        }
        #endregion
        #region League Repo Tests
        [Fact]
        public void ShouldExterciseLeagueRepository()
        {
            SetupConfigForTests("Other League");
            PlayAnotherYear(1, "Other League", new Random(55123));

            SetupConfigForTests("NHL");
            SetupConfigForTests("Dude League");

            var repo = new LeagueRepository(new RepositoryNHibernate<League>());

            StrictEqual(3, repo.GetAll().Count());


        }
        #endregion
        #region Season Repo Tests
        [Fact]
        public void ShouldExerciseSeasonRepositoryNHibernate()
        {
            SetupConfigForTests("NHL");
            PlayAnotherYear(1, "NHL", new Random());

            var leagueRepo = new LeagueRepository(new RepositoryNHibernate<League>());
            var seasonRepo = new SeasonRepository(new RepositoryNHibernate<Season>());

            var league = leagueRepo.GetByName("NHL");

            var parentConfig = league.CompetitionConfigs.Where(s => s.Name.Equals("My Season")).FirstOrDefault();

            var seasonConfig = RepositoryTestData.CreateBasicSeasonConfiguration(league);
            seasonConfig.Parents.Add(parentConfig);

            leagueRepo.Update(league);

            PlayAnotherYear(2, "NHL", new Random());

            var seasons1 = seasonRepo.GetByLeagueAndYear(league.Id, 1).Count();
            var seasons2 = seasonRepo.GetByLeagueAndYear(league.Id, 2).Count();

            leagueRepo.Flush();

            StrictEqual(1, seasons1);
            StrictEqual(2, seasons2);

            var seasonA = seasonRepo.GetBySeasonCompetitionConfigAndYear(parentConfig.Id, 2);
            var seasonB = seasonRepo.GetBySeasonCompetitionConfigAndYear(seasonConfig.Id, 2);

            StrictEqual(2, seasonA.Year);
            StrictEqual(2, seasonB.Year);
            NotStrictEqual(seasonA.Id, seasonB.Id);
        }
        #endregion
        [Fact]
        public void ShouldExportSchema()
        {
            schemaExport.SetOutputFile("../../../sqloutput/ddl.sql");
            schemaExport.Execute(false, true, false);

            dropDatabase = true;

        }

        private void SetupConfigForTests(string leagueName)
        {
            var test = new LeagueRepository(new RepositoryNHibernate<League>());

            var league = RepositoryTestData.CreateBasicLeague(leagueName);
            var seasonConfig = RepositoryTestData.CreateBasicSeasonConfiguration(league);
            var playoffConfig = RepositoryTestData.CreateBasicPlayoffConfiguration(seasonConfig);

            test.Update(league);
            session.Flush();
        }
        private void PlayAnotherYear(int nextYear, string leagueName, Random random)
        {
            var leagueRepo = new LeagueRepository(new RepositoryNHibernate<League>());
            var compRepo = new CompetitionRepository(new RepositoryNHibernate<Competition>());
            var gameRepo = new ScheduleGameRepository(new RepositoryNHibernate<ScheduleGame>());

            var league = leagueRepo.GetByName(leagueName);

            league.CompetitionConfigs.OrderBy(m => m.Ordering).ToList().ForEach(c =>
            {
                var parentCompList = new List<Competition>();

                c.Parents.ToList().ForEach(p =>
                {
                    parentCompList.Add(compRepo.GetByNameAndYear(p.Name, nextYear));
                });

                var competition = c.CreateCompetition(1, nextYear, parentCompList);

                while (!competition.AreGamesComplete())
                {
                    competition.PlayNextDay(random).ForEach(g =>
                    {
                        gameRepo.Update(g);
                    });
                }

                competition.ProcessEndOfCompetition(0);

                compRepo.Update(competition);

            });

            session.Flush();

        }

        private void PlayAYear()
        {
            //assumes data is added
        }


        //can use this to get some base data going
        [Fact]
        public void ShouldPopulateDatabase()
        {
            SetupConfigForTests("NHL");
            PlayAnotherYear(1, "NHL", new Random());
            PlayAnotherYear(2, "NHL", new Random());
            PlayAnotherYear(3, "NHL", new Random());
            PlayAnotherYear(4, "NHL", new Random());
            PlayAnotherYear(5, "NHL", new Random());
            PlayAnotherYear(6, "NHL", new Random());
            PlayAnotherYear(7, "NHL", new Random());
            PlayAnotherYear(8, "NHL", new Random());
            PlayAnotherYear(9, "NHL", new Random());
            PlayAnotherYear(10, "NHL", new Random());


            dropDatabase = true;

        }

        //team tests

    }
}
