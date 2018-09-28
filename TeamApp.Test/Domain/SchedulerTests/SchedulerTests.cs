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
        [InlineData(0, 0, 3, -1, 3)] //roll forward +1
        public void ShouldGetNextDay(int currentDay, int startDay, int maxDay, int daysToIncrement, int expected)
        {
            var nextDay = Scheduler.GetNextDay(currentDay, startDay, maxDay, daysToIncrement);
            StrictEqual(expected, nextDay);
        }

            
        public static IEnumerable<object[]> TwoDifferentGroupsOfTeams()
        {
            var rules = new GameRules(true, 1, 5, 7, 6);

            yield return new object[] { new List<Team> { CreateTeam("Team 1"), CreateTeam("Team 2"),CreateTeam("Team 3") },
                                       new List<Team> { CreateTeam("Team 4"), CreateTeam("Team 5"),CreateTeam("Team 6") },
                                       3, 1, false, rules };

            yield return new object[] { new List<Team> { CreateTeam("Team 1"), CreateTeam("Team 2"),CreateTeam("Team 3") },
                                       new List<Team> { CreateTeam("Team 4"), CreateTeam("Team 5"),CreateTeam("Team 6") },
                                       6, 1, true, rules };

            yield return new object[] { new List<Team> { CreateTeam("Team 1"), CreateTeam("Team 2"),CreateTeam("Team 3"), CreateTeam("Team 7")},
                                       new List<Team> { CreateTeam("Team 4"), CreateTeam("Team 5"),CreateTeam("Team 6") },
                                       8, 1, true, rules };

            yield return new object[] { new List<Team> { CreateTeam("Team 1"), CreateTeam("Team 2"),CreateTeam("Team 3") },
                                       new List<Team> { CreateTeam("Team 4"), CreateTeam("Team 5"),CreateTeam("Team 6"), CreateTeam("Team 7") },
                                       8, 1, true, rules };
        }

        [Theory]
        [MemberData(nameof(TwoDifferentGroupsOfTeams))]
        public void ShouldCreateScheduleTwoDifferentGroups(List<Team> HomeTeams, List<Team> AwayTeams, int expectedDays, int iterations, bool homeAndAway, GameRules rules)
        {
            var league = new League("My League");
            var days = Scheduler.CreateGames(league, 1, 0, 1,
                HomeTeams, AwayTeams, iterations, homeAndAway, rules);

            var messages = new List<string>();

            days.Days.Values.ToList().ForEach(d =>
            {
                var validator = new ScheduleDayValidator(d);

                if (!validator.IsValid) messages.AddRange(validator.Messages);
                
            });

            StrictEqual(expectedDays, days.Days.Count);

            True(messages.Count == 0);
        }

        public static IEnumerable<object[]> OneGroupOfTeams()
        {
            var rules = new GameRules(true, 1, 5, 7, 6);

            yield return new object[] { new List<Team> { CreateTeam("Team 1"), CreateTeam("Team 2"),CreateTeam("Team 3") },
                                       3, 1, false, rules };
            yield return new object[] { new List<Team> { CreateTeam("Team 1"), CreateTeam("Team 2"),CreateTeam("Team 3"),CreateTeam("Team 4") },
                                       3, 1, false, rules };
            yield return new object[] { new List<Team> { CreateTeam("Team 1"), CreateTeam("Team 2"),CreateTeam("Team 3"),CreateTeam("Team 4"),
                                                        CreateTeam("Team 5"), CreateTeam("Team 6"),CreateTeam("Team 7"),CreateTeam("Team 8")},
                                       7, 1, false, rules };
            yield return new object[] { new List<Team> { CreateTeam("Team 1"), CreateTeam("Team 2"),CreateTeam("Team 3"),CreateTeam("Team 4"),
                                                        CreateTeam("Team 5"), CreateTeam("Team 6"),CreateTeam("Team 7"),CreateTeam("Team 8"), CreateTeam("Team 9")},
                                       9, 1, false, rules };
            yield return new object[] { new List<Team> { CreateTeam("Team 1"), CreateTeam("Team 2"),CreateTeam("Team 3") },
                                       6, 1, true, rules };
            yield return new object[] { new List<Team> { CreateTeam("Team 1"), CreateTeam("Team 2"),CreateTeam("Team 3"),CreateTeam("Team 4") },
                                       6, 1, true, rules };
            yield return new object[] { new List<Team> { CreateTeam("Team 1"), CreateTeam("Team 2"),CreateTeam("Team 3"),CreateTeam("Team 4"),
                                                        CreateTeam("Team 5"), CreateTeam("Team 6"),CreateTeam("Team 7"),CreateTeam("Team 8")},
                                       14, 1, true, rules };
            yield return new object[] { new List<Team> { CreateTeam("Team 1"), CreateTeam("Team 2"),CreateTeam("Team 3"),CreateTeam("Team 4"),
                                                        CreateTeam("Team 5"), CreateTeam("Team 6"),CreateTeam("Team 7"),CreateTeam("Team 8"), CreateTeam("Team 9")},
                                       18, 1, true, rules };
        }

        [Theory]
        [MemberData(nameof(OneGroupOfTeams))]
        public void ShouldCreateScheduleForOneGroupofTeams(List<Team> Teams, int expectedDays, int iterations, bool homeAndAway,GameRules rules)
        {
            var league = new League("My League");
            var days = Scheduler.CreateGames(league, 1, 0, 1,
                Teams, iterations, homeAndAway, rules);

            var messages = new List<string>();

            days.Days.Values.ToList().ForEach(d =>
            {
                var validator = new ScheduleDayValidator(d);

                if (!validator.IsValid) messages.AddRange(validator.Messages);

            });

            StrictEqual(expectedDays, days.Days.Count);

            True(messages.Count == 0);
        }
        //validate game numbers
        //validate no duplicate games
        //validate no bad days
        //validate total games are equal per team

        public static Team CreateTeam(string name)
        {
            return new Team(name, 5, null, 1, null);
        }            
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
