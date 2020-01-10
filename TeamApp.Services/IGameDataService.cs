using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeamApp.Domain;
using TeamApp.ViewModels.Views;

namespace TeamApp.Services
{
    public interface IGameDataService
    {
        bool IsYearComplete(int year);   
        bool IncrementYear();
        void PlayDay(Random random);
        void ProcessDay();
        void PlayAndProcessDay();
        bool IncrementDay();
        void SetupComeptitionsForDay(int day, int year);
        void RandomlyChangeSkillLevels(Random random);
        GameData GetCurrentData();//need to change to a view model!
        Task<GameSummary> GetGameSummary();
        void SaveCurrentData(GameData data);
        void StartNextCompetition();

        void StartNextYear();
    }
}
