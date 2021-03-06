﻿using System.Collections.Generic;
using TeamApp.Domain.Schedules;
using TeamApp.Domain;
using TeamApp.Domain.Games;
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
            var rules = new GameRules(null, true, 1, 5, 10, true);

            yield return new object[] { new List<Team> { CreateTeam("Team 1",1), CreateTeam("Team 2",2),CreateTeam("Team 3",3) },
                                       new List<Team> { CreateTeam("Team 4",4), CreateTeam("Team 5",5),CreateTeam("Team 6",6) },
                                       3, 1, false, rules };

            yield return new object[] { new List<Team> { CreateTeam("Team 1",1), CreateTeam("Team 2",2),CreateTeam("Team 3",3) },
                                       new List<Team> { CreateTeam("Team 4",4), CreateTeam("Team 5",5),CreateTeam("Team 6",6) },
                                       6, 1, true, rules };

            yield return new object[] { new List<Team> { CreateTeam("Team 1",1), CreateTeam("Team 2",2),CreateTeam("Team 3",3), CreateTeam("Team 7", 7) },
                                       new List<Team> { CreateTeam("Team 4",4), CreateTeam("Team 5",5),CreateTeam("Team 6",6) },
                                       8, 1, true, rules };

            yield return new object[] { new List<Team> { CreateTeam("Team 1",1), CreateTeam("Team 2",2),CreateTeam("Team 3",3) },
                                       new List<Team> { CreateTeam("Team 4",4), CreateTeam("Team 5",5),CreateTeam("Team 6",6), CreateTeam("Team 7", 7) },
                                       8, 1, true, rules };
        }

        [Theory]
        [MemberData(nameof(TwoDifferentGroupsOfTeams))]
        public void ShouldCreateScheduleTwoDifferentGroups(List<ITeam> HomeTeams, List<ITeam> AwayTeams, int expectedDays, int iterations, bool homeAndAway, GameRules rules)
        {            
            var days = Scheduler.CreateGames(null, 1, 0, 1,
                HomeTeams, AwayTeams, iterations, homeAndAway, rules, new BaseScheduleGameCreator());

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
            var rules = new GameRules(null, true, 1, 5, 3, true);

            yield return new object[] { new List<Team> { CreateTeam("Team 1",1), CreateTeam("Team 2",2),CreateTeam("Team 3",3) },
                                       3, 1, false, rules };
            yield return new object[] { new List<Team> { CreateTeam("Team 1",1), CreateTeam("Team 2",2),CreateTeam("Team 3",3),CreateTeam("Team 4",4) },
                                       3, 1, false, rules };
            yield return new object[] { new List<Team> { CreateTeam("Team 1",1), CreateTeam("Team 2",2),CreateTeam("Team 3",3),CreateTeam("Team 4",4) ,
                                                        CreateTeam("Team 5",5), CreateTeam("Team 6",6),CreateTeam("Team 7",7),CreateTeam("Team 8",8)},
                                       7, 1, false, rules };
            yield return new object[] { new List<Team> { CreateTeam("Team 1",1), CreateTeam("Team 2",2),CreateTeam("Team 3",3),CreateTeam("Team 4",4) ,
                                                        CreateTeam("Team 5",5), CreateTeam("Team 6",6),CreateTeam("Team 7",7),CreateTeam("Team 8",8), CreateTeam("Team 9", 9)},
                                       9, 1, false, rules };
            yield return new object[] { new List<Team> { CreateTeam("Team 1",1), CreateTeam("Team 2",2),CreateTeam("Team 3",3) },
                                       6, 1, true, rules };
            yield return new object[] { new List<Team> { CreateTeam("Team 1",1), CreateTeam("Team 2",2),CreateTeam("Team 3",3),CreateTeam("Team 4",4) },
                                       6, 1, true, rules };
            yield return new object[] { new List<Team> { CreateTeam("Team 1",1), CreateTeam("Team 2",2),CreateTeam("Team 3",3),CreateTeam("Team 4",4) ,
                                                        CreateTeam("Team 5",5), CreateTeam("Team 6",6),CreateTeam("Team 7",7),CreateTeam("Team 8",8)},
                                       14, 1, true, rules };
            yield return new object[] { new List<Team> { CreateTeam("Team 1",1), CreateTeam("Team 2",2),CreateTeam("Team 3",3),CreateTeam("Team 4",4) ,
                                                        CreateTeam("Team 5",5), CreateTeam("Team 6",6),CreateTeam("Team 7",7),CreateTeam("Team 8",8), CreateTeam("Team 9", 9)},
                                       18, 1, true, rules };
        }

        [Theory]
        [MemberData(nameof(OneGroupOfTeams))]
        public void ShouldCreateScheduleForOneGroupofTeams(List<ITeam> Teams, int expectedDays, int iterations, bool homeAndAway,GameRules rules)
        {            
            var days = Scheduler.CreateGames(null, 1, 0, 1,
                Teams, iterations, homeAndAway, rules, new BaseScheduleGameCreator());

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

        public static Team CreateTeam(string name, int id)
        {
            return new Team(name, null, null, 5, null, 1, null, true, null) { Id = id };
        }            
        public static ScheduleDay CreateDay(int dayNumber, params ScheduleGame[] games)
        {
            return new ScheduleDay(dayNumber) { Games = new List<ScheduleGame>(games) };
        }
                        
        public static ScheduleGame CreateGame(string homeTeamName, int homeId, string awayTeamName, int awayId)
        {
            return new ScheduleGame(null, -1, -1, -1, CreateTeam(homeTeamName, homeId), null, CreateTeam(awayTeamName, awayId), null, 0, 0, false, 1, 0, null,false);
        }

    }
}
