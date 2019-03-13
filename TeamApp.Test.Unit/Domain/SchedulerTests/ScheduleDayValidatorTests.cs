using System;
using System.Collections.Generic;
using System.Text;
using static Xunit.Assert;
using Xunit;
using TeamApp.Domain.Schedules;
using static TeamApp.Test.Domain.SchedulerTests.SchedulerTests;
using static TeamApp.Domain.Schedules.ScheduleValidator;

namespace TeamApp.Test.Domain.SchedulerTests
{
    public class ScheduleDayValidatorTests
    {
        public static IEnumerable<object[]> GetDays()
        {
            yield return new object[] { CreateDay(1, new ScheduleGame[] { CreateGame("Team 1",1, "Team 2",2), CreateGame("Team 3", 3, "Team 4",4), CreateGame("Team 5", 5, "Team 6", 6) }), true };
            yield return new object[] { CreateDay(1, new ScheduleGame[] { CreateGame("Team 1", 1, "Team 2", 2), CreateGame("Team 1", 1, "Team 4", 4), CreateGame("Team 5", 5, "Team 6", 6) }), false }; //duplicate home
            yield return new object[] { CreateDay(1, new ScheduleGame[] { CreateGame("Team 1", 1, "Team 2", 2), CreateGame("Team 3", 3, "Team 2", 2), CreateGame("Team 5", 5, "Team 6", 6) }), false }; //dupcliate away
            yield return new object[] { CreateDay(1, new ScheduleGame[] { CreateGame("Team 1", 1, "Team 2", 2), CreateGame("Team 2", 2, "Team 4", 4), CreateGame("Team 5", 5, "Team 6", 6) }), false }; //duplicate home and away
            yield return new object[] { CreateDay(1, new ScheduleGame[] { CreateGame("Team 1", 1, "Team 2", 2), CreateGame("Team 3", 3, "Team 5", 5), CreateGame("Team 5", 5, "Team 6", 6) }), false }; //duplicate away and home
            yield return new object[] { CreateDay(1, new ScheduleGame[] { CreateGame("Team 2", 2, "Team 2", 2), CreateGame("Team 3", 3, "Team 5", 5), CreateGame("Team 5", 5, "Team 6", 6) }), false }; //duplicate same team per game

        }

        [Theory]
        [MemberData(nameof(GetDays))]
        public void IsDayValid(ScheduleDay day, bool expected)
        {
            var counts = new ScheduleDayValidator(day);

            StrictEqual(expected, counts.IsValid);
            
            
        }

        [Fact]
        public void ShouldCountTeamsInDayCorrectly()
        {
            var day = CreateDay(1, new ScheduleGame[] { CreateGame("Team 1", 1, "Team 2", 2), CreateGame("Team 3", 3, "Team 4",4), CreateGame("Team 5", 5, "Team 6",6), CreateGame("Team 6", 6,"Team 5",5), CreateGame("Team 6", 6, "Team 2", 2) });

            var counts = new ScheduleDayValidator(day);

            False(counts.IsValid);

            StrictEqual(1, counts.GetHomeTeamCounts("Team 1"));
            StrictEqual(0, counts.GetHomeTeamCounts("Team 2"));
            StrictEqual(1, counts.GetHomeTeamCounts("Team 3"));
            StrictEqual(0, counts.GetHomeTeamCounts("Team 4"));
            StrictEqual(1, counts.GetHomeTeamCounts("Team 5"));
            StrictEqual(2, counts.GetHomeTeamCounts("Team 6"));

            StrictEqual(0, counts.GetAwayTeamCounts("Team 1"));
            StrictEqual(2, counts.GetAwayTeamCounts("Team 2"));
            StrictEqual(0, counts.GetAwayTeamCounts("Team 3"));
            StrictEqual(1, counts.GetAwayTeamCounts("Team 4"));
            StrictEqual(1, counts.GetAwayTeamCounts("Team 5"));
            StrictEqual(1, counts.GetAwayTeamCounts("Team 6"));

            StrictEqual(3, counts.Messages.Count);
        }
        
    }
}
