using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Schedules;

namespace TeamApp.Services
{
    public interface IScheduleGameService
    {
        //convert to viewmodel at some point
        IEnumerable<ScheduleGame> GetGamesForDay(int day, int year);
    }
}
