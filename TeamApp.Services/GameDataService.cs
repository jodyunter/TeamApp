using System.Linq;
using TeamApp.Domain.Repositories;
using TeamApp.Services.ViewModels.Views;

namespace TeamApp.Services
{
    public class GameDataService
    {
        public IScheduleGameRepository gameRepository;

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

        public void ChangeDay(int newDay)
        {
            var model = new GameSummary();

            model = GetGameSummary();

            if (newDay < model.CurrentDay)
            {
                model.AddErrorMessage("Cannot set the current day to a day in the past");
            }
            else
            {
                var incompleteGames = gameRepository.GetInCompleteGamesBetweenDays(model.CurrentDay, newDay).Count();
                if (incompleteGames > 0)
                {
                    model.AddErrorMessage("There are in complete games bewteen the current day and the new day.  Please complete before continuing.");
                }
            }
        }

 
    }
}
