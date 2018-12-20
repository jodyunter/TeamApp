using Microsoft.Extensions.DependencyInjection;
using TeamApp.Data.Repositories;
using TeamApp.Data.Repositories.NHibernate;
using TeamApp.Domain;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Repositories;

namespace TeamApp.Services
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<ITeamRepository, TeamRepository>();
            services.AddSingleton<IStandingsRepository, StandingsRepositoryNHibernate>();
            services.AddSingleton<ITeamRankingRepository, TeamRankingRepositoryNHibernate>();
            services.AddSingleton<ICompetitionRepository, CompetitionRepositoryNHibernate>();
            services.AddSingleton<ILeagueRepository, LeagueRepository>();
            services.AddSingleton(typeof(IRepository<League>), typeof(RepositoryNHibernate<League>));
            services.AddSingleton(typeof(IRepository<Team>), typeof(RepositoryNHibernate<Team>));
            return services;
        }
    }
}
