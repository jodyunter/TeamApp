using Microsoft.Extensions.DependencyInjection;
using TeamApp.Data.Repositories.NHibernate;
using TeamApp.Domain.Repositories;

namespace TeamApp.Services
{
    public static class ConfigureLibrary
    {
        public static IServiceCollection InjectServices(this IServiceCollection services)
        {
            services.AddSingleton<ITeamRepository, TeamRepositoryNHibernate>();

            return services;
        }
    }
}
