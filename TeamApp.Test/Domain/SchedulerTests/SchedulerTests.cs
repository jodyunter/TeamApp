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
        [InlineData(15, 5, 15, 1, 5)] //roll forward +1
        [InlineData(5, 5, 15, -1, 15)] //roll backward -1
        [InlineData(15, 5, 15, 45, 5)] //roll forward +1
        public void ShouldGetNextDay(int currentDay, int startDay, int maxDay, int daysToIncrement, int expected)
        {
            var nextDay = Scheduler.GetNextDay(currentDay, startDay, maxDay, daysToIncrement);
            StrictEqual(expected, nextDay);
        }

        [Fact]
        public void ShouldCreateScheduleTwoDifferentGroups()
        {
            var league = new League("My League");
            var days = Scheduler.CreateGamesTwoDifferentGroups(league, 1, 0, 1,
                new List<Team> { new Team("Team 1", 1, null, 1, null),
                                 new Team("Team 2", 1, null, 1, null),
                                 new Team("Team 3", 1, null, 1, null) },
                new List<Team> { new Team("Team 4", 1, null, 1, null),
                                     new Team("Team 5", 1, null, 1, null),
                                     new Team("Team 6", 1, null, 1, null) },
                1, false, true, 0);

            var messages = new List<string>();

            days.Values.ToList().ForEach(d =>
            {
                var validator = new ScheduleDayValidator(d);

                if (!validator.IsValid) messages.AddRange(validator.Messages);
                
            });

            True(messages.Count == 0);
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
