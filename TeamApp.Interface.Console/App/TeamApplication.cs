using NHibernate.Tool.hbm2ddl;
using System.Collections.Generic;
using TeamApp.Data.Relational.Repositories;
using TeamApp.Data.Repositories.Relational;
using TeamApp.Data.Repositories.Relational.NHibernate;
using TeamApp.Domain;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Competitions.Config;
using TeamApp.Domain.Competitions.Seasons;
using TeamApp.Domain.Repositories;
using TeamApp.Domain.Schedules;
using TeamApp.Services;
using TeamApp.Services.Implementation;
using TeamApp.Test.Helpers;

namespace TeamApp.Console.App
{
    public class TeamApplication
    {

        private ILeagueRepository leagueRepository;
        private IStandingsRepository standingsRepository;
        private ITeamRepository teamRepository;
        private ICompetitionRepository competitionRepository;
        private ITeamRankingRepository teamRankingRepository;
        private IScheduleGameRepository scheduleGameRepository;
        private ICompetitionConfigRepository competitionConfigRepository;
        private IGameDataRepository gameDataRepository;
        private ISeasonRepository seasonRepository;
        private ICompetitionTeamRepository competitionTeamRepository;

        public ILeagueService LeagueService { get; set; }
        public IStandingsService StandingsService { get; set; }
        public IGameDataService GameDataService { get; set; }
        public IScheduleGameService ScheduleGameService { get; set; }
        public ICompetitionService CompetitionService { get; set; }
        public IPlayoffService PlayoffService { get; set; }
        public ITeamService TeamService { get; set; }
        private ConsoleHelper consoleHelper = new ConsoleHelper();
        
        public TeamApplication()
        {
            leagueRepository = new LeagueRepository(new RepositoryNHibernate<League>());
            teamRepository = new TeamRepository(new RepositoryNHibernate<Team>());
            competitionRepository = new CompetitionRepository(new RepositoryNHibernate<Competition>());
            standingsRepository = new StandingsRepository(new RepositoryNHibernate<SeasonTeam>(), competitionRepository);
            teamRankingRepository = new TeamRankingRepository(new RepositoryNHibernate<TeamRanking>());
            scheduleGameRepository = new ScheduleGameRepository(new RepositoryNHibernate<ScheduleGame>());
            gameDataRepository = new GameDataRepository(new RepositoryNHibernate<GameData>());
            competitionConfigRepository = new CompetitionConfigRepository(new RepositoryNHibernate<CompetitionConfig>());
            seasonRepository = new SeasonRepository(new RepositoryNHibernate<Season>());
            competitionTeamRepository = new CompetitionTeamRepository(new RepositoryNHibernate<CompetitionTeam>());

            LeagueService = new LeagueService(leagueRepository);
            StandingsService = new StandingsService(standingsRepository, competitionRepository);
            TeamService = new TeamService(teamRepository);
            GameDataService = new GameDataService(gameDataRepository, leagueRepository, scheduleGameRepository, competitionRepository, competitionConfigRepository, TeamService);
            ScheduleGameService = new ScheduleGameService(scheduleGameRepository);
            CompetitionService = new CompetitionService(competitionRepository);
            PlayoffService = new PlayoffService(competitionRepository);
        }

        public void SetupConfig(bool setupDatabase, bool dropFirst, bool setupData)
        {
            if (setupDatabase)
            {
                var session = NHibernateHelper.OpenSession();


                if (dropFirst)
                {
                    var query = session.CreateSQLQuery("exec DropAllTables");
                    query.ExecuteUpdate();
                    //D:\Visual Studio Projects\gitrepos\TeamApp\TeamApp.Test.Database\sqloutput\dropddl.sql

                }

                var configuration = NHibernateHelper.GetConfiguration().BuildConfiguration();
                var schemaExport = new SchemaExport(configuration);                
                schemaExport.Create(false, true);

            }

            if (setupData)
            {
                var gameData = new GameData();
                gameData.CurrentDay = 1;
                gameData.CurrentYear = 1;
                gameDataRepository.Update(gameData);
                
                var league = DataCreator.CreateLeague("nhl");
                var teams = DataCreator.CreateTeams();
                //var seasonConfig = DataCreator.CreateLargeSeasonConfiguration(league, teams, null, 1, 1);
                //var playoffConfig = DataCreator.CreateLargePlayoffConfiguration(league, new List<CompetitionConfig>() { seasonConfig }, 2, null, 1, null);

                //var seasonConfig = DataCreator.CreateSmallSeasonConfiguration(league, teams, null, 1, 1);
                var seasonConfig = DataCreator.CreateMediumSeasonConfig(league, teams, null, 1, 1);
                var playoffConfig = DataCreator.CreateSmallPlayoffConfiguration(league, new List<CompetitionConfig>() { seasonConfig }, 2, null, 1, null);

                //var league = Data2.CreateBasicLeague("NHL");
                //var seasonCompetition = Data2.CreateBasicSeasonConfiguration(league);
                //var playoffCompetition = Data2.CreateBasicPlayoffConfiguration(seasonCompetition);

                leagueRepository.Update(league);
            }



        }

        public void ClearScreen()
        {
            consoleHelper.Clear();
        }

    }
}
