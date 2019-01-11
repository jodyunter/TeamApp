using Microsoft.Extensions.DependencyInjection;
using TeamApp.Services;
using TeamApp.Services.Implementation;

namespace TeamApp.Web
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<ITeamService, TeamService>();              
            Services.ServiceExtensions.RegisterServices(services);
            return services;
        }
    }
}
