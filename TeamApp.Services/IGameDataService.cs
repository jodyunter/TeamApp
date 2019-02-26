using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain;

namespace TeamApp.Services
{
    public interface IGameDataService
    {
        bool IsYearComplete(int year);   
        bool IncrementYear();
        void PlayDay(Random random);
        void ProcessDay();
        bool IncrementDay();
        void SetupComeptitionsForDay(int day, int year);
        GameData GetCurrentData();
        void SaveCurrentData(GameData data);
    }
}
