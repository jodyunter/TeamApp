using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TeamApp.Domain.Schedules;
using TeamApp.ViewModels.Views.Games;

namespace TeamApp.Services
{
    public interface IScheduleGameService
    {
        //convert to viewmodel at some point
        IEnumerable<ScheduleGame> GetGamesForDay(int day, int year);
        Task<ScheduleDaySummaryViewModel> GetScheduleDay(int day, int year);
    }
}
