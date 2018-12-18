using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamApp.Data.Repositories.NHibernate;
using TeamApp.Domain.Repositories;
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
