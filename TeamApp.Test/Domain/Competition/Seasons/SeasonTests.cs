﻿using System;
using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain.Competition.Seasons;
using TeamApp.Domain.Scheduler;
using Xunit;
using static Xunit.Assert;
using static TeamApp.Test.Domain.SchedulerTests.SchedulerTests;
using TeamApp.Domain;
using TeamApp.Test.Helpers;
using TeamApp.Services;
using TeamApp.Domain.Competition.Seasons.Config;

namespace TeamApp.Test.Domain.Competition.Seasons
{
    public class SeasonTests
    {
        [Fact]
        public void ShouldProcessGame()
        {
            var season = new Season(null, "Test", 1);
            var teams = new List<Team>() { CreateTeam("Team 1"), CreateTeam("Team 2"), CreateTeam("Team 3"), CreateTeam("Team 4") };
            var rules = new GameRules(null, true, 1, 0, 7, 6);
            var games = new List<ScheduleGame>()
            {
                new ScheduleGame(null, 1, 1, 1, teams[0], teams[1], 1, 1, true, 1, rules),
                new ScheduleGame(null, 1, 1, 1, teams[0], teams[2], 3, 1, true, 1, rules),
                new ScheduleGame(null, 1, 1, 1, teams[0], teams[3], 1, 4, true, 1, rules)  
            };

            var team1 = new SeasonTeam("Team 1", 5, teams[0], null, null, null, null, 1);
            var team2 = new SeasonTeam("Team 2", 5, teams[1], null, null, null, null, 1);
            var team3 = new SeasonTeam("Team 3", 5, teams[2], null, null, null, null, 1);
            var team4 = new SeasonTeam("Team 4", 5, teams[3], null, null, null, null, 1);

            season.Teams = new List<SeasonTeam>() { team1, team2, team3, team4 };

            games.ForEach(g => { season.ProcessGame(g); });            

            StrictEqual(3, team1.Stats.Games);
            StrictEqual(3, team1.Stats.Points);
            StrictEqual(1, team1.Stats.Wins);
            StrictEqual(1, team1.Stats.Loses);
            StrictEqual(1, team1.Stats.Ties);
            StrictEqual(5, team1.Stats.GoalsFor);
            StrictEqual(6, team1.Stats.GoalsAgainst);

            StrictEqual(1, team2.Stats.Games);
            StrictEqual(1, team2.Stats.Points);
            StrictEqual(0, team2.Stats.Wins);
            StrictEqual(0, team2.Stats.Loses);
            StrictEqual(1, team2.Stats.Ties);
            StrictEqual(1, team2.Stats.GoalsFor);
            StrictEqual(1, team2.Stats.GoalsAgainst);

            StrictEqual(1, team3.Stats.Games);
            StrictEqual(0, team3.Stats.Points);
            StrictEqual(0, team3.Stats.Wins);
            StrictEqual(1, team3.Stats.Loses);
            StrictEqual(0, team3.Stats.Ties);
            StrictEqual(1, team3.Stats.GoalsFor);
            StrictEqual(3, team3.Stats.GoalsAgainst);

            StrictEqual(1, team4.Stats.Games);
            StrictEqual(2, team4.Stats.Points);
            StrictEqual(1, team4.Stats.Wins);
            StrictEqual(0, team4.Stats.Loses);
            StrictEqual(0, team4.Stats.Ties);
            StrictEqual(4, team4.Stats.GoalsFor);
            StrictEqual(1, team4.Stats.GoalsAgainst);
        }


        [Fact]
        public void ShouldPlaySome()
        {
            var data = Data1.CreateBasicSeasonConfiguration();

            var seasonService = new SeasonService();
            var seasonCompetition = ((List<SeasonCompetition>)data[Data1.BASIC_SEASON_COMPETITION_LSIT])[0];

            var season = seasonService.CreateNewSeason(seasonCompetition, "Season 1", 1);

            var schedule = Scheduler.CreateGames(season.CompetitionConfig.League, season.Year, 1, 1, 
               season.GetAllTeamsInDivision(season.GetDivisionByName("NHL")).Select(t => t.Parent).ToList(),
                1, true, season.CompetitionConfig.GameRules);
            
            season.Schedule = schedule;

            var scheduleValidator = new ScheduleValidator(season.Schedule);

            True(scheduleValidator.IsValid);

            while (!season.Schedule.IsComplete())
                season.PlayNextDay(new Random());

            StrictEqual(38, season.Teams.Where(t => t.Name.Equals("Boston")).First().Stats.Games);
        }

        [Fact]
        public void ShouldGetAllTeamsInDivision()
        {
            var data = Data1.CreateBasicSeasonConfiguration();

            var seasonService = new SeasonService();
            var seasonCompetition = ((List<SeasonCompetition>)data[Data1.BASIC_SEASON_COMPETITION_LSIT])[0];

            var season = seasonService.CreateNewSeason(seasonCompetition, "Season 1", 1);

            StrictEqual(20, season.GetAllTeamsInDivision(season.Divisions.Where(d => d.Name.Equals("NHL")).First()).Count);
            StrictEqual(8, season.GetAllTeamsInDivision(season.Divisions.Where(d => d.Name.Equals("East")).First()).Count);
            StrictEqual(6, season.GetAllTeamsInDivision(season.Divisions.Where(d => d.Name.Equals("West")).First()).Count);
            StrictEqual(6, season.GetAllTeamsInDivision(season.Divisions.Where(d => d.Name.Equals("Central")).First()).Count);
            StrictEqual(4, season.GetAllTeamsInDivision(season.Divisions.Where(d => d.Name.Equals("NorthEast")).First()).Count);
            StrictEqual(4, season.GetAllTeamsInDivision(season.Divisions.Where(d => d.Name.Equals("Atlantic")).First()).Count);
        }
    }
}
