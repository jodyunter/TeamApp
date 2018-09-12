using System;
using System.Collections.Generic;
using System.Text;
using static Xunit.Assert;
using Xunit;
using TeamApp.Domain.Scheduler;
using static TeamApp.Test.Domain.SchedulerTests.SchedulerTests;
using static TeamApp.Domain.Scheduler.ScheduleValidator;

namespace TeamApp.Test.Domain.SchedulerTests
{
    public class ScheduleDayValidatorTests
    {
        public static IEnumerable<object[]> GetDays()
        {
            yield return new object[] { CreateDay(1, new ScheduleGame[] { CreateGame("Team 1", "Team 2"), CreateGame("Team 3", "Team 4"), CreateGame("Team 5", "Team 6") }), true };
            yield return new object[] { CreateDay(1, new ScheduleGame[] { CreateGame("Team 1", "Team 2"), CreateGame("Team 1", "Team 3"), CreateGame("Team 5", "Team 6") }), false }; //duplicate home team
            yield return new object[] { CreateDay(1, new ScheduleGame[] { CreateGame("Team 1", "Team 2"), CreateGame("Team 3", "Team 2"), CreateGame("Team 5", "Team 6") }), false }; //duplicate away team
            yield return new object[] { CreateDay(1, new ScheduleGame[] { CreateGame("Team 1", "Team 2"), CreateGame("Team 2", "Team 4"), CreateGame("Team 5", "Team 6") }), false }; //duplicate home and away
            yield return new object[] { CreateDay(1, new ScheduleGame[] { CreateGame("Team 1", "Team 2"), CreateGame("Team 3", "Team 5"), CreateGame("Team 5", "Team 6") }), false }; //duplicate away and home
            yield return new object[] { CreateDay(1, new ScheduleGame[] { CreateGame("Team 2", "Team 2"), CreateGame("Team 3", "Team 5"), CreateGame("Team 5", "Team 6") }), false }; //duplicate same team per game

        }
        [Theory]
        [MemberData(nameof(GetDays))]
        public void IsDayValid(ScheduleDay day, bool expected)
        {
            var counts = new ScheduleDayValidator(day);

            StrictEqual(expected, counts.IsValid);


        }
    }
}
