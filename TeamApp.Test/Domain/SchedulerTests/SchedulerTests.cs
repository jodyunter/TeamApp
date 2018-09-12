using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Scheduler;
using TeamApp.Domain;
using Xunit;
using static Xunit.Assert;
using System.Linq;

namespace TeamApp.Test.Domain.SchedulerTests
{
    public class SchedulerTests
    {
        [Theory]
        [InlineData(0, 1, 1, 0, 1)]
        [InlineData(4, 1, 4, -1, 3)]
        [InlineData(3, 1, 4, -1, 2)]
        [InlineData(2, 1, 4, -1, 1)]
        [InlineData(1, 1, 4, -1, 4)]
        [InlineData(4, 1, 4, 1, 1)]
        [InlineData(3, 1, 4, 1, 4)]
        [InlineData(2, 1, 4, 1, 3)]
        [InlineData(1, 1, 4, 1, 2)]
        [InlineData(4, 1, 4, -4, 4)]
        [InlineData(3, 1, 4, -4, 3)]
        [InlineData(2, 1, 4, -4, 2)]
        [InlineData(1, 1, 4, -4, 1)]
        [InlineData(4, 1, 4, -5, 3)]
        [InlineData(3, 1, 4, -5, 2)]
        [InlineData(2, 1, 4, -5, 1)]
        [InlineData(1, 1, 4, -5, 4)]
        [InlineData(4, 1, 4, 4, 4)]
        [InlineData(3, 1, 4, 4, 3)]
        [InlineData(2, 1, 4, 4, 2)]
        [InlineData(1, 1, 4, 4, 1)]
        [InlineData(4, 1, 4, 5, 1)]
        [InlineData(3, 1, 4, 5, 4)]
        [InlineData(2, 1, 4, 5, 3)]
        [InlineData(1, 1, 4, 5, 2)]
        [InlineData(4, 1, 6, 24, 4)]
        [InlineData(3, 1, 6, 15, 2)]
        [InlineData(2, 1, 6, -12, 2)]
        [InlineData(1, 1, 6, -15, 4)]
        [InlineData(4, 1, 6, -25, 3)]
        public void ShouldGetNextDay(int currentDay, int startDay, int maxDay, int daysToIncrement, int expected)
        {
            Equals(expected, Scheduler.GetNextDay(currentDay, startDay, maxDay, daysToIncrement));
        }

        //validate game numbers
        //validate no duplicate games
        //validate no bad days
        //validate total games are equal per team
        public static ScheduleDay CreateDay(int dayNumber, params ScheduleGame[] games)
        {
            return new ScheduleDay(dayNumber) { Games = new List<ScheduleGame>(games) };
        }
                        
        public static ScheduleGame CreateGame(string homeTeamName, string awayTeamName)
        {
            return new ScheduleGame() { HomeTeam = new Team() { Name = homeTeamName }, AwayTeam = new Team() { Name = awayTeamName } };
        }

    }
}
