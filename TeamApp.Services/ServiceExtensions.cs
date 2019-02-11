using Microsoft.Extensions.DependencyInjection;
using TeamApp.Data.Relational.Repositories;
using TeamApp.Data.Repositories.Relational.NHibernate;
using TeamApp.Domain;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Competitions.Seasons;
using TeamApp.Domain.Repositories;
using TeamApp.Domain.Schedules;

namespace TeamApp.Services
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<ITeamRepository, TeamRepository>();
            services.AddSingleton<IStandingsRepository, StandingsRepository>();
            services.AddSingleton<ITeamRankingRepository, TeamRankingRepository>();
            services.AddSingleton<ICompetitionRepository, CompetitionRepository>();
            services.AddSingleton<ILeagueRepository, LeagueRepository>();
            services.AddSingleton<IScheduleGameRepository, ScheduleGameRepository>();
            services.AddSingleton(typeof(IRepository<League>), typeof(RepositoryNHibernate<League>));
            services.AddSingleton(typeof(IRepository<Team>), typeof(RepositoryNHibernate<Team>));
            services.AddSingleton(typeof(IRepository<ScheduleGame>), typeof(RepositoryNHibernate<ScheduleGame>));
            services.AddSingleton(typeof(IRepository<SeasonTeam>), typeof(RepositoryNHibernate<SeasonTeam>));
            services.AddSingleton(typeof(IRepository<Competition>), typeof(RepositoryNHibernate<Competition>));
            services.AddSingleton(typeof(IRepository<TeamRanking>), typeof(RepositoryNHibernate<TeamRanking>)); 

            return services;
        }
    }
}
