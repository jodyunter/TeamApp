using System;
using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Repositories;
using TeamApp.Domain.Schedules;
using TeamApp.Services.ViewModels.Views;

namespace TeamApp.Services
{
    public class GameDataService
    {

        public GameDataService()
        {
        }

        public GameSummary GetGameSummary()
        {
            return new GameSummary()
            {
                CurrentDay = 125,
                CurrentYear = 5

            };

        }

 
    }
}
