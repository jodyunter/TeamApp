using System;
using System.Collections.Generic;
using System.Text;
using static Xunit.Assert;
using Xunit;
using TeamApp.Domain.Scheduler;
using static TeamApp.Test.Domain.SchedulerTests.SchedulerTests;
using static TeamApp.Domain.Scheduler.ScheduleValidator;
using TeamApp.Domain;

namespace TeamApp.Test.Domain.SchedulerTests
{
    public class ScheduleValidatorTests
    {
        public static IEnumerable<object[]> GetBalancedSchedule()
        {
            yield return new object[] { CreateDay(1, new ScheduleGame[] { CreateGame("Team 1", "Team 2"), CreateGame("Team 3", "Team 4"), CreateGame("Team 5", "Team 6") }), true };
            yield return new object[] { CreateDay(1, new ScheduleGame[] { CreateGame("Team 1", "Team 2"), CreateGame("Team 1", "Team 3"), CreateGame("Team 5", "Team 6") }), false }; //duplicate home team
            yield return new object[] { CreateDay(1, new ScheduleGame[] { CreateGame("Team 1", "Team 2"), CreateGame("Team 3", "Team 2"), CreateGame("Team 5", "Team 6") }), false }; //duplicate away team
            yield return new object[] { CreateDay(1, new ScheduleGame[] { CreateGame("Team 1", "Team 2"), CreateGame("Team 2", "Team 4"), CreateGame("Team 5", "Team 6") }), false }; //duplicate home and away
            yield return new object[] { CreateDay(1, new ScheduleGame[] { CreateGame("Team 1", "Team 2"), CreateGame("Team 3", "Team 5"), CreateGame("Team 5", "Team 6") }), false }; //duplicate away and home
            yield return new object[] { CreateDay(1, new ScheduleGame[] { CreateGame("Team 2", "Team 2"), CreateGame("Team 3", "Team 5"), CreateGame("Team 5", "Team 6") }), false }; //duplicate same team per game

        }

        public static IEnumerable<object[]> GetUnbalancedSchedule()
        {
            yield return null;
        }

        public static IEnumerable<object[]> GetBalancedScheduleWithBadGames()
        {
            yield return null;
        }

        public static IEnumerable<object[]> GetBalancedScheduleWithBadDays()
        {
            yield return null;
        }


        [Theory]
        [MemberData(nameof(GetBalancedSchedule))]        
        public void IsScheduleValid(Schedule schedule, bool expected)
        {
            var counts = new ScheduleValidator(schedule);

            StrictEqual(expected, counts.IsValid);
        }
        
        public Schedule CreateBalancedScheduleNoHomeAndAway()
        {
            var league = new League("My League");
            var schedule = new Schedule();

            schedule.Days = Scheduler.CreateGamesSingleGroup(league, 1, 5, 1,
                new List<Team>()
                    { CreateTeam("Team 1"), CreateTeam("Team 2"), CreateTeam("Team 3"), CreateTeam("Team 4"), CreateTeam("Team 5"), CreateTeam("Team 6") },
                1, false, true, 0);
                    
            

            return schedule;
        }
        
        
    }
}
