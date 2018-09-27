using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competition.Seasons;
using TeamApp.Domain.Scheduler;
using Xunit;
using static Xunit.Assert;
using static TeamApp.Test.Domain.SchedulerTests.SchedulerTests;

namespace TeamApp.Test.Domain.Competition.Seasons
{
    public class SeasonTests
    {
        [Fact]
        public void ShouldProcessGame()
        {
            var season = new Season(null, "Test", 1);
            var team1 = new SeasonTeam("Team 1", 5, CreateTeam("Team 1"), null, null, null, null, 1);
            var team2 = new SeasonTeam("Team 2", 5, CreateTeam("Team 1"), null, null, null, null, 1);
            var team3 = new SeasonTeam("Team 3", 5, CreateTeam("Team 1"), null, null, null, null, 1);
            var team4 = new SeasonTeam("Team 4", 5, CreateTeam("Team 1"), null, null, null, null, 1);

            season.Teams = new List<SeasonTeam>() { team1, team2, team3, team4 };

            var g = new ScheduleGame(null, 1, 1, 1, team1.Parent, team2.Parent, 15, 15, false, true, 0);

            season.ProcessGame(g);

            StrictEqual(1, team1.Stats.Games);
            StrictEqual(1, team1.Stats.Points);
            StrictEqual(1, team1.Stats.Ties);
            StrictEqual(15, team1.Stats.GoalsFor);
            StrictEqual(15, team1.Stats.GoalsAgainst);

        }
    }
}
