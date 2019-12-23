using Microsoft.Extensions.DependencyInjection;
using TeamApp.Data.Relational.Repositories;
using TeamApp.Data.Repositories.Relational;
using TeamApp.Data.Repositories.Relational.NHibernate;
using TeamApp.Domain;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Competitions.Config;
using TeamApp.Domain.Competitions.Seasons;
using TeamApp.Domain.Repositories;
using TeamApp.Domain.Schedules;
using TeamApp.Services.Implementation;

namespace TeamApp.Services
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            //these should all be moved to the services and references removed
            services.AddSingleton<IGameDataService, GameDataService>();
            services.AddSingleton<ITeamService, TeamService>();
            services.AddSingleton<ICompetitionService, CompetitionService>();
            services.AddSingleton<IStandingsService, StandingsService>();
            services.AddSingleton<IScheduleGameService, ScheduleGameService>();

            services.AddSingleton<IGameDataRepository, GameDataRepository>();
            services.AddSingleton<ILeagueRepository, LeagueRepository>();
            services.AddSingleton<IScheduleGameRepository, ScheduleGameRepository>();
            services.AddSingleton<ICompetitionRepository, CompetitionRepository>();
            services.AddSingleton<ICompetitionConfigRepository, CompetitionConfigRepository>();
            services.AddSingleton<ITeamRepository, TeamRepository>();
            services.AddSingleton<IStandingsRepository, StandingsRepository>();

            services.AddSingleton(typeof(IRelationalRepository<GameData>), typeof(RepositoryNHibernate<GameData>));
            services.AddSingleton(typeof(IRelationalRepository<League>), typeof(RepositoryNHibernate<League>));
            services.AddSingleton(typeof(IRelationalRepository<ScheduleGame>), typeof(RepositoryNHibernate<ScheduleGame>));
            services.AddSingleton(typeof(IRelationalRepository<Competition>), typeof(RepositoryNHibernate<Competition>));
            services.AddSingleton(typeof(IRelationalRepository<CompetitionConfig>), typeof(RepositoryNHibernate<CompetitionConfig>));
            services.AddSingleton(typeof(IRelationalRepository<Team>), typeof(RepositoryNHibernate<Team>));
            services.AddSingleton(typeof(IRelationalRepository<SeasonTeam>), typeof(RepositoryNHibernate<SeasonTeam>));
            /* old
            services.AddSingleton<ITeamRepository, TeamRepository>();
            services.AddSingleton<IStandingsRepository, StandingsRepository>();
            services.AddSingleton<ITeamRankingRepository, TeamRankingRepository>();
            services.AddSingleton<ICompetitionRepository, CompetitionRepository>();
            services.AddSingleton<ILeagueRepository, LeagueRepository>();
            services.AddSingleton<IScheduleGameRepository, ScheduleGameRepository>();
            services.AddSingleton<ICompetitionConfigRepository, CompetitionConfigRepository>();
            services.AddSingleton<IGameDataRepository, GameDataRepository>();
            services.AddSingleton<ICompetitionTeamRepository, CompetitionTeamRepository>();

            services.AddSingleton(typeof(IRelationalRepository<League>), typeof(RepositoryNHibernate<League>));
            services.AddSingleton(typeof(IRelationalRepository<Team>), typeof(RepositoryNHibernate<Team>));
            services.AddSingleton(typeof(IRelationalRepository<ScheduleGame>), typeof(RepositoryNHibernate<ScheduleGame>));
            services.AddSingleton(typeof(IRelationalRepository<SeasonTeam>), typeof(RepositoryNHibernate<SeasonTeam>));
            services.AddSingleton(typeof(IRelationalRepository<Competition>), typeof(RepositoryNHibernate<Competition>));
            services.AddSingleton(typeof(IRelationalRepository<TeamRanking>), typeof(RepositoryNHibernate<TeamRanking>));
            services.AddSingleton(typeof(IRelationalRepository<CompetitionConfig>), typeof(RepositoryNHibernate<CompetitionConfig>));
            */

            return services;
        }
    }
}
