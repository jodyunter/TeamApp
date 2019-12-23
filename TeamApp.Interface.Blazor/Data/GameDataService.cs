using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamApp.ViewModels.Views;

namespace TeamApp.Interface.Blazor.Data
{
    public class GameDataService
    {
        public Task<GameSummary> GetGameSummary()
        {
            var service = new GameDataService();

            return service.GetGameSummary();
        }
        
    }
}
