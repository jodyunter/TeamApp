using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace TeamApp.App
{
    public class TeamApplication
    {
        private IServiceProvider serviceProvider;

        public TeamApplication()
        {

        }

        
        private void SetupServices()
        {
            serviceProvider =  new ServiceCollection().AddSingleton<ILeagueService, LeagueService>());
        }
    }
}
