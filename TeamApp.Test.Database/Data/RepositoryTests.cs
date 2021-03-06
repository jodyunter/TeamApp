﻿using NHibernate;
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
using TeamApp.Data.Relational.Repositories;
using TeamApp.Domain.Competitions.Seasons;
using System.Threading;
using TeamApp.Domain.Competitions.Playoffs;
using TeamApp.Data.Repositories.Relational;
using TeamApp.Domain.Competitions.Config.Seasons;
using TeamApp.Domain.Competitions.Config.Playoffs;
using TeamApp.Domain.Competitions.Config;

namespace TeamApp.Test.Data
{
    public class RepositoryTests : IDisposable
    {     

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
            var query = session.CreateSQLQuery("exec DropAllTables");
            query.ExecuteUpdate();
        }


        #region Competition Repo Tests
        [Fact]
        public void ShouldExerciseCompetitionRepositoryNHibernate()
        {
            var league1 = new League("NHL", 1, null);
            var league2 = new League("NHL 2", 1, null);

            var leagueRepo = new LeagueRepository(new RepositoryNHibernate<League>());

            var repo = new CompetitionRepository(new RepositoryNHibernate<Competition>());
            var configRepo = new CompetitionConfigRepository(new RepositoryNHibernate<CompetitionConfig>());
            var cc0 = new SeasonCompetitionConfig("Test B", league1, 1, 1, null, 1, null, null, null, null, null, null);
            var cc1 = new SeasonCompetitionConfig("Test 1", league1, 1, 1, null, 1, null, null, null, null, null, null);
            var c1 = new Season(cc1, "Test 1", 5, null, null, null, null, true, false, 5, 55);
            var cc2 = new PlayoffCompetitionConfig("P3", league1, 2, 25, null, 1, null, null, null, new List<CompetitionConfig> { cc1, cc0 }, null);
            var c8 = new Playoff(cc2, "P3", 5, 5, null, null, null, null, false, false, 5, 12);
            var c2 = new Season(null, "Test 2", 6, null, null, null, null, true, true, 5, 55);
            var c3 = new Season(null, "Test 3", 7, null, null, null, null, true, false, 5, 55);
            var c4 = new Season(cc1, "Test 4", 8, null, null, null, null, true, false, 5, 55);
            var c5 = new Season(null, "Test 5", 9, null, null, null, null, true, false, 5, 55);
            var c6 = new Playoff(null, "P1", 8, 5, null, null, null, null, true, false, 5, 12);
            var c7 = new Playoff(null, "P2", 8, 5, null, null, null, null, false, false, 5, 12);
            var c9 = new Playoff(cc2, "P9", 15, 5, null, null, null, null, false, false, 5, 12);
            var c10 = new Playoff(cc2, "P10", 15, 5, null, null, null, null, false, true, 5, 12);
            var c11 = new Playoff(cc2, "P11", 15, 5, null, null, null, null, true, false, 5, 12);
            var c12 = new Playoff(cc2, "P12", 15, 5, null, null, null, null, true, true, 5, 12);

            configRepo.Update(cc2);
            repo.Update(c1);
            repo.Update(c2);
            repo.Update(c3);
            repo.Update(c4);
            repo.Update(c5);
            repo.Update(c6);
            repo.Update(c7);
            repo.Update(c8);
            repo.Update(c9);
            repo.Update(c10);
            repo.Update(c11);
            repo.Update(c12);

            var c10Id = c10.Id;

            //getall
            StrictEqual(12, repo.GetAll().Count());
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
            Equal("Test 1", parents[0].Name);
            Equal(5, parents[0].Year);
            //GetCompetitionsForCompetitionConfig
            var competitionForConfig = repo.GetCompetitionForCompetitionConfig(cc2, 5);
            Equal("P3", competitionForConfig.Name);
            Equal(5, competitionForConfig.Year);

            var shouldBeNull = repo.GetCompetitionForCompetitionConfig(cc0, 5);
            Null(shouldBeNull);

            //IEnumerable<Competition> GetByLeagueAndYear(int leagueId, int year)
            StrictEqual(2, repo.GetByLeagueAndYear(league1.Id, 5).Count());
            StrictEqual(1, repo.GetByLeagueAndYear(league1.Id, 8).Count());
            StrictEqual(0, repo.GetByLeagueAndYear(league2.Id, 15).Count());

            //IEnumerable<Competition> GetByLeagueAndYear(int leagueId, int year, bool started, bool finished)

            Equal("P9", repo.GetByLeagueAndYear(league1.Id, 15, false, false).First().Name);
            Equal("P10", repo.GetByLeagueAndYear(league1.Id, 15, false, true).First().Name);
            Equal("P11", repo.GetByLeagueAndYear(league1.Id, 15, true, false).First().Name);
            Equal("P12", repo.GetByLeagueAndYear(league1.Id, 15, true, true).First().Name);

            //IEnumerable<CompetitionSimpleViewModel> GetCompetitionsByYear(int year);
            Single(repo.GetByYear(9));
            StrictEqual(2, repo.GetByYear(5).Count());

            //Competition GetCompetition(long id);
            Equal("P10", repo.Get(c10Id).Name);
        }

        #endregion
        #region Competition Config Repo Tests
        [Fact]
        public void ShouldExerciseCompetitionConfigRepositoryNHibernate()
        {
            var repo = new CompetitionConfigRepository(new RepositoryNHibernate<CompetitionConfig>());

            var config1 = new SeasonCompetitionConfig("Season 1", null, 1, 1, 12, 1, null, null, null, null, null, null);
            var config2 = new SeasonCompetitionConfig("Season 2", null, 1, 1, 12, 1, null, null, null, null, null, null);
            var config3 = new SeasonCompetitionConfig("Season 3", null, 1, 3, 12, 1, null, null, null, null, null, null);
            var config4 = new SeasonCompetitionConfig("Season 4", null, 5, 1, 12, 1, null, null, null, null, null, null);
            var config5 = new SeasonCompetitionConfig("Season 5", null, 5, 2, 12, 1, null, null, null, null, null, null);

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
        #region League Repo Tests
        [Fact]
        public void ShouldExterciseLeagueRepository()
        {
            var league1 = new League("League 1", 1, null);
            var league2 = new League("League 2", 1, 12);
            var league3 = new League("League 3", 1, 8);
            var league4 = new League("League 4", 1, 4);
            var league5 = new League("League 5", 1, 2);

            var repo = new LeagueRepository(new RepositoryNHibernate<League>());

            repo.Update(league1);
            repo.Update(league2);
            repo.Update(league3);
            repo.Update(league4);
            repo.Update(league5);

            Equal("League 3", repo.GetByName("League 3").Name);
            StrictEqual(5, repo.GetActiveLeagues(1).Count());
            StrictEqual(1, repo.GetActiveLeagues(13).Count());
            StrictEqual(2, repo.GetActiveLeagues(12).Count());
            StrictEqual(3, repo.GetActiveLeagues(7).Count());
            StrictEqual(4, repo.GetActiveLeagues(3).Count());
            StrictEqual(5, repo.GetActiveLeagues(2).Count());


        }
        #endregion
        #region Schedule Game Repo Tests
        [Fact]
        public void ShouldExerciseScheduleGameRepositoryNHibernate()
        {
            var gameRepo = new ScheduleGameRepository(new RepositoryNHibernate<ScheduleGame>());

            //IEnumerable<ScheduleGame> GetGamesForDay(int day, int year);
            for (int i = 0; i < 7; i++)
            {
                gameRepo.Update(new ScheduleGame(null, i, i % 2, 1, null, null, null, null, 0, 0, false, 1, 0, null, false));
            }

            for (int i = 7; i < 22; i++)
            {
                gameRepo.Update(new ScheduleGame(null, i, i % 2 + 2, 2, null, null, null, null, 0, 0, false, 1, 0, null, false));
            }

            StrictEqual(4, gameRepo.GetGamesForDay(0, 1).Count());
            StrictEqual(3, gameRepo.GetGamesForDay(1, 1).Count());
            StrictEqual(7, gameRepo.GetGamesForDay(2, 2).Count());
            StrictEqual(8, gameRepo.GetGamesForDay(3, 2).Count());

            //IEnumerable<ScheduleGame> GetInCompleteGamesForDay(int day, int year);
            gameRepo.Update(new ScheduleGame(null, 22, 3, 2, null, null, null, null, 0, 0, true, 1, 0, null, false));
            gameRepo.Update(new ScheduleGame(null, 23, 3, 2, null, null, null, null, 0, 0, true, 1, 0, null, false));
            StrictEqual(10, gameRepo.GetGamesForDay(3, 2).Count());
            StrictEqual(8, gameRepo.GetInCompleteGamesForDay(3, 2).Count());

            //IEnumerable<ScheduleGame> GetCompleteAndUnProcessedGamesForDay(int day, int year);
            StrictEqual(2, gameRepo.GetCompleteAndUnProcessedGamesForDay(3, 2).Count());

            //IEnumerable<ScheduleGame> GetInCompleteOrUnProcessedGamesForDay(int day, int year);
            StrictEqual(17, gameRepo.GetInCompleteOrUnProcessedGamesOnOrBeforeDay(3, 2).Count());
        }
        #endregion
        #region Season Repo Tests
        [Fact]
        public void ShouldExerciseSeasonRepositoryNHibernate()
        {

            //we weren't using any of the methods so we removed them
            True(true);
        }
        #endregion
        #region Standings Repo Tests
        [Fact]
        public void ShouldExerciseStandingsRepository()
        {
            var compRepo = new CompetitionRepository(new RepositoryNHibernate<Competition>());

            var repo = new StandingsRepository(new RepositoryNHibernate<SeasonTeam>(), compRepo);


            var season = new Season(null, "Season 1", 1, null, null, null, null, true, false, 1, null);
            var seasonTeams = new List<CompetitionTeam>()
            {
                new SeasonTeam(season, null, "Team 1", null, null, 5, null, 1, null, null, null),
                new SeasonTeam(season, null, "Team 2", null, null, 5, null, 1, null, null, null),
                new SeasonTeam(season, null, "Team 3", null, null, 5, null, 1, null, null, null),
                new SeasonTeam(season, null, "Team 4", null, null, 5, null, 1, null, null, null),
                new SeasonTeam(season, null, "Team 5", null, null, 5, null, 1, null, null, null),
                new SeasonTeam(season, null, "Team 6", null, null, 5, null, 1, null, null, null),
                new SeasonTeam(season, null, "Team 7", null, null, 5, null, 1, null, null, null),
            };
            season.Teams = seasonTeams;
            compRepo.Update(season);
            var teams = repo.GetByCompetition(compRepo.GetByNameAndYear("Season 1", 1).Id);

            StrictEqual(7, teams.Count);
        }
        #endregion
        #region Team Repo Tests
        [Fact]

        public void ShouldExterciseTeamRepositoryNHibernate()
        {
            var repo = new TeamRepository(new RepositoryNHibernate<Team>());

            var newTeamId = (long)repo.Add(new Team("Add Team", "AddNick", "AddShort", 5, "Me", 1, null, true, null));
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

            Equal("Updated Name", newTeam.Name);

            for (int i = 0; i < 10; i++)
            {
                repo.Add(new Team("Team " + i, "AddNick" + i, "AddShort" + i, 5, "Me" + i, 1, i, true, null));
            }

            Equal(11, repo.GetAll().ToList().Count);

            //Team GetByName(string name);        
            Equal("AddNick5", repo.GetByName("Team 5").ToList()[0].NickName);
        }
        #endregion
        #region Team Ranking Repo Tests
        [Fact]
        public void ShouldExerciseTeamRankingRepositoryNHibernate()
        {
            var compRepo = new CompetitionRepository(new RepositoryNHibernate<Competition>());
            var repo = new TeamRankingRepository(new RepositoryNHibernate<TeamRanking>());

            var comp1 = new Season(null, "Season 1", 1, null, null, null, null, false, false, 1, null);
            var comp2 = new Playoff(null, "Playoff 1", 1, 1, null, null, null, null, false, false, 1, null);

            compRepo.Update(comp1);
            compRepo.Update(comp2);

            for (int i = 0; i < 10; i++)
            {
                var ranking = new TeamRanking(1, "Group 1", new CompetitionTeam(comp1, null, "Team " + (i * 10), null, null, 5, null, 1, null), 1);
                repo.Update(ranking);
            }

            for (int i = 0; i < 5; i++)
            {
                var ranking = new TeamRanking(1, "Group 5", new CompetitionTeam(comp2, null, "Team " + (i * 100), null, null, 5, null, 1, null), 1);
                repo.Update(ranking);
            }

            var rankings = repo.GetByCompetition(comp1.Id);
            StrictEqual(10, rankings.Count());
            rankings = repo.GetByCompetition(comp2.Id);
            StrictEqual(5, rankings.Count());
        }

        #endregion
        #region Single Year Team Repo tests
        [Fact]
        public void ShouldExerciseCompetitionTeamRepositoryNHibernate()
        {
            var repo = new CompetitionTeamRepository(new RepositoryNHibernate<CompetitionTeam>());
            var compRepo = new CompetitionRepository(new RepositoryNHibernate<Competition>());
            
            var comp1 = new Season(null, "Season 1", 1, null, null, null, null, false, false, 1, null);
            var comp2 = new Playoff(null, "Playoff 1", 1, 1, null, null, null, null, false, false, 1, null);

            compRepo.Update(comp1);
            compRepo.Update(comp2);

            for (int i = 0; i < 10; i++)
            {
                var syt = new CompetitionTeam(comp1, null, "Team " + i, null, null, 5, null, 1, null);
                repo.Update(syt);
            }

            for (int i = 0; i < 5; i++)
            {
                var syt = new CompetitionTeam(comp2, null, "Team " + (i*100), null, null, 5, null, 1, null);
                repo.Update(syt);
            }

            //can we get them all?
            var teams = repo.GetAll().ToList();
            var test = teams.Where(t => t.Competition.Id == comp1.Id).ToList();
            StrictEqual(15, teams.Count);
            teams = repo.GetByCompetition(comp1).ToList();
            StrictEqual(10, teams.Count());
            teams = repo.GetByCompetition(comp2).ToList();
            StrictEqual(5, teams.Count());
            
        }
        #endregion
        [Fact]
        public void ShouldExportSchema()
        {
            schemaExport.SetOutputFile("../../../sqloutput/ddl.sql");
            schemaExport.Execute(false, true, false);

            dropDatabase = true;

        }


    }
}
