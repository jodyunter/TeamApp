﻿using NHibernate;
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
using System.Collections.Generic;
using TeamApp.Test.Helpers;
using TeamApp.Data.Repositories;
using TeamApp.Domain.Competitions.Seasons;

namespace TeamApp.Test.Data
{
    public class RepositoryTests:IDisposable
    {
        protected ISession session;
        private Configuration configuration;

        protected bool dropDatabase = true;
        protected bool dropFirst = false;
        protected SchemaExport schemaExport;

        public RepositoryTests()
        {
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
            SetupConfigForTests("NHL");
            PlayAnotherYear(1, "NHL", new Random());
            PlayAnotherYear(2, "NHL", new Random());
            PlayAnotherYear(3, "NHL", new Random());
            PlayAnotherYear(4, "NHL", new Random());
            PlayAnotherYear(5, "NHL", new Random());

            var repo = new CompetitionRepository(new RepositoryNHibernate<Competition>());
            Equals(2, repo.GetAll().Count());

            Equals(7, repo.GetByNameAndYear("My Season", 5).Teams.Count());

            var comps = repo.GetByYear(1);
            Equals(2, comps.Count());
            
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
            Equals(8, rankings.Count());
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
            
            Equals(7, teams.Count);
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

            Equals(3, repo.GetAll().Count());


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

            var league = leagueRepo.Where(m => m.Name.Equals(leagueName)).First();            

            league.CompetitionConfigs.OrderBy(m => m.Ordering).ToList().ForEach(c =>
            {
                var parentCompList = new List<Competition>();

                c.Parents.ToList().ForEach(p =>
                {
                    parentCompList.Add(compRepo.GetByNameAndYear(p.Name, nextYear));
                });

                var competition = c.CreateCompetition(nextYear, parentCompList);

                while(!competition.IsComplete())
                {
                    competition.PlayNextDay(random).ForEach(g =>
                    {
                        gameRepo.Update(g);
                    });
                }

                competition.ProcessEndOfSeason();

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