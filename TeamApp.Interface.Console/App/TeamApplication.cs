using TeamApp.Data.Relational.Repositories;
using TeamApp.Data.Repositories.Relational.NHibernate;
using TeamApp.Domain;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Competitions.Seasons;
using TeamApp.Domain.Repositories;
using TeamApp.Domain.Schedules;
using TeamApp.Services;
using TeamApp.Services.Implementation;

namespace TeamApp.Console.App
{
    public class TeamApplication
    {
        
        public ILeagueRepository LeagueRepository { get; set; }    
        public IStandingsRepository StandingsRepository { get; set; }
        public ITeamRepository TeamRepository { get; set; }
        public ICompetitionRepository CompetitionRepository { get; set; }
        public ITeamRankingRepository TeamRankingRepository { get; set; }
        public IScheduleGameRepository ScheduleGameRepository { get; set; }
        public ILeagueService LeagueService { get; set; }
        public IStandingsService StandingsService { get; set; }
        public TeamApplication()
        {
            LeagueRepository = new LeagueRepository(new RepositoryNHibernate<League>());
            TeamRepository = new TeamRepository(new RepositoryNHibernate<Team>());
            CompetitionRepository = new CompetitionRepository(new RepositoryNHibernate<Competition>());
            StandingsRepository = new StandingsRepository(new RepositoryNHibernate<SeasonTeam>(), CompetitionRepository);
            TeamRankingRepository = new TeamRankingRepository(new RepositoryNHibernate<TeamRanking>());
            ScheduleGameRepository = new ScheduleGameRepository(new RepositoryNHibernate<ScheduleGame>());
            LeagueService = new LeagueService(LeagueRepository, CompetitionRepository, ScheduleGameRepository);
            StandingsService = new StandingsService(StandingsRepository, TeamRankingRepository);
        }

            
    }
}
