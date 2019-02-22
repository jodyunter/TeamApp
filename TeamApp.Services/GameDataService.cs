using System.Linq;
using TeamApp.Domain.Repositories;
using TeamApp.Services.ViewModels.Views;

namespace TeamApp.Services
{
    public class OldGameDataServiceToRemove
    {
        public IScheduleGameRepository gameRepository;

        public OldGameDataServiceToRemove()
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
