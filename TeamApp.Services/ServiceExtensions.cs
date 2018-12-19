using Microsoft.Extensions.DependencyInjection;
using TeamApp.Data.Repositories.NHibernate;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Repositories;

namespace TeamApp.Services
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<ITeamRepository, TeamRepositoryNHibernate>();
            services.AddSingleton<IStandingsRepository, StandingsRepositoryNHibernate>();
            services.AddSingleton<ITeamRankingRepository, TeamRankingRepositoryNHibernate>();
            services.AddSingleton<ICompetitionRepository, CompetitionRepositoryNHibernate>();            
            return services;
        }
    }
}
