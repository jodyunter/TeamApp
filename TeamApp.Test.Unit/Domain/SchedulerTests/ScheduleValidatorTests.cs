using System.Collections.Generic;
using static Xunit.Assert;
using Xunit;
using TeamApp.Domain.Schedules;
using static TeamApp.Test.Domain.SchedulerTests.SchedulerTests;
using TeamApp.Domain;

namespace TeamApp.Test.Domain.SchedulerTests
{
    public class ScheduleValidatorTests
    {

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

        public static IEnumerable<object[]> GetBalancedSchedule()
        {
            yield return new object[] {1, CreateBalancedScheduleNoHomeAndAway(), true, false, true };
            yield return new object[] {2, CreateBalancedScheduleNoHomeAndAway(), false, false, false };
            yield return new object[] {3, CreateBalancedScheduleWithHomeAndAway(), false, false, true };

        }

        [Theory]
        [MemberData(nameof(GetBalancedSchedule))]        
        public void IsScheduleValid(int testNo, Schedule schedule, bool isUnevenHomeAndAwayOkay, bool isUnevenScheduleOkay, bool expected)
        {
            var number = testNo;

            var counts = new ScheduleValidator(schedule);
            counts.IsUnevenHomeAwayOkay = isUnevenHomeAndAwayOkay;
            counts.IsUnevenScheduleOkay = isUnevenScheduleOkay;

            bool result = counts.IsValid;
            StrictEqual(expected, result);
        }
        

        public static Schedule CreateBalancedScheduleNoHomeAndAway()
        {         
            var schedule = new Schedule();
            var rules = new GameRules(null, true, 1, 0, 7, 6);

            schedule = Scheduler.CreateGames(null, 1, 5, 1,
                new List<Team>()
                    { CreateTeam("Team 1"), CreateTeam("Team 2"), CreateTeam("Team 3"), CreateTeam("Team 4"), CreateTeam("Team 5"), CreateTeam("Team 6") },
                2, false, rules);

            return schedule;
        }

        public static Schedule CreateBalancedScheduleWithHomeAndAway()
        {            
            var schedule = new Schedule();
            var rules = new GameRules(null, true, 1, 0, 7, 6);

            schedule = Scheduler.CreateGames(null, 1, 5, 1,
                new List<Team>()
                    { CreateTeam("Team 1"), CreateTeam("Team 2"), CreateTeam("Team 3"), CreateTeam("Team 4"), CreateTeam("Team 5"), CreateTeam("Team 6") },
                2, true, rules);

            return schedule;
        }

        
    }
}
