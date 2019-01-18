﻿using System;
using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain.Competitions.Seasons;
using TeamApp.Domain.Schedules;
using Xunit;
using static Xunit.Assert;
using static TeamApp.Test.Domain.SchedulerTests.SchedulerTests;
using TeamApp.Domain;
using TeamApp.Test.Helpers;
using TeamApp.Domain.Competitions.Seasons.Config;
using TeamApp.Domain.Competitions;

namespace TeamApp.Test.Domain.Competitions.Seasons
{
    public class SeasonTests
    {
        [Fact]
        public void ShouldProcessGame()
        {
            var seasonConfig = new SeasonCompetitionConfig("Test", null, null, null, 1, 1, null, null, null, null, null);
            var season = new Season(seasonConfig, seasonConfig.Name, 1, null, null, null, null);
            var teams = new List<Team>() { CreateTeam("Team 1"), CreateTeam("Team 2"), CreateTeam("Team 3"), CreateTeam("Team 4") };
            var rules = new GameRules(null, true, 1, 0, 7, 6);
            var games = new List<ScheduleGame>()
            {
                new ScheduleGame(null, 1, 1, 1, teams[0], teams[1], 1, 1, true, 1, rules, false),
                new ScheduleGame(null, 1, 1, 1, teams[0], teams[2], 3, 1, true, 1, rules, false),
                new ScheduleGame(null, 1, 1, 1, teams[0], teams[3], 1, 4, true, 1, rules, false)  
            };

            var team1 = new SeasonTeam(null, teams[0], "Team 1", null, null, 5, null, 1, null, null);
            var team2 = new SeasonTeam(null, teams[1], "Team 2", null, null, 5, null, 1, null, null);
            var team3 = new SeasonTeam(null, teams[2], "Team 3", null, null, 5, null, 1, null, null);
            var team4 = new SeasonTeam(null, teams[3], "Team 4", null, null, 5, null, 1, null, null);
            
            season.Teams = new List<SingleYearTeam>() { team1, team2, team3, team4 };

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
            
            var seasonCompetition = ((List<SeasonCompetitionConfig>)data[Data1.BASIC_SEASON_COMPETITION_LSIT])[0];

            var season = (Season)seasonCompetition.CreateCompetition(1, null);

            var schedule = Scheduler.CreateGames(season, season.Year, 1, 1, 
               season.GetAllTeamsInDivision(season.GetDivisionByName("NHL")).Select(t => t.Parent).ToList(),
                1, true, season.CompetitionConfig.GameRules);
            
            season.Schedule = schedule;

            var scheduleValidator = new ScheduleValidator(season.Schedule);

            True(scheduleValidator.IsValid);

            while (!season.Schedule.IsComplete())
                ((Competition)season).PlayNextDay(new Random());            

            StrictEqual(42, ((SeasonTeam)season.Teams.Where(t => t.Name.Equals("Boston")).First()).Stats.Games);
        }

        [Fact]
        public void ShouldGetAllTeamsInDivision()
        {
            var data = Data1.CreateBasicSeasonConfiguration();
            
            var seasonCompetition = ((List<SeasonCompetitionConfig>)data[Data1.BASIC_SEASON_COMPETITION_LSIT])[0];

            var season = (Season)seasonCompetition.CreateCompetition(1, null);

            StrictEqual(22, season.GetAllTeamsInDivision(season.Divisions.Where(d => d.Name.Equals("NHL")).First()).Count);
            StrictEqual(10, season.GetAllTeamsInDivision(season.Divisions.Where(d => d.Name.Equals("East")).First()).Count);
            StrictEqual(6, season.GetAllTeamsInDivision(season.Divisions.Where(d => d.Name.Equals("West")).First()).Count);
            StrictEqual(6, season.GetAllTeamsInDivision(season.Divisions.Where(d => d.Name.Equals("Central")).First()).Count);
            StrictEqual(5, season.GetAllTeamsInDivision(season.Divisions.Where(d => d.Name.Equals("NorthEast")).First()).Count);
            StrictEqual(5, season.GetAllTeamsInDivision(season.Divisions.Where(d => d.Name.Equals("Atlantic")).First()).Count);
        }
    }
}