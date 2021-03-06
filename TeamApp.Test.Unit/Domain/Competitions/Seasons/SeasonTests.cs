﻿using System.Collections.Generic;
using TeamApp.Domain;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Competitions.Config.Seasons;
using TeamApp.Domain.Competitions.Seasons;
using TeamApp.Domain.Schedules;
using TeamApp.Domain.Games;
using Xunit;
using static TeamApp.Test.Domain.SchedulerTests.SchedulerTests;
using static Xunit.Assert;

namespace TeamApp.Test.Domain.Competitions.Seasons
{
    public class SeasonTests
    {
        [Fact]
        public void ShouldProcessGame()
        {
            var seasonConfig = new SeasonCompetitionConfig("Test", null, 1, null, null, 1, null, null, null, null, null, null);
            var season = new Season(seasonConfig, seasonConfig.Name, 1, null, null, null, null, true, false, 1, null);
            var teams = new List<Team>() { CreateTeam("Team 1", 1), CreateTeam("Team 2", 2), CreateTeam("Team 3", 3), CreateTeam("Team 4", 4) };
            var rules = new GameRules(null, true, 1, 3, 10, true);            
            var games = new List<ScheduleGame>()
            {
                new ScheduleGame(null, 1, 1, 1, teams[0], null, teams[1],null, 1, 1, true, 1, 0, rules, false),
                new ScheduleGame(null, 1, 1, 1, teams[0], null,teams[2],null, 3, 1, true, 1, 0, rules, false),
                new ScheduleGame(null, 1, 1, 1, teams[0], null,teams[3],null, 1, 4, true, 1, 0, rules, false)
            };

            var team1 = new SeasonTeam(null, teams[0], "Team 1", null, null, 5, null, 1, null, null, null);
            var team2 = new SeasonTeam(null, teams[1], "Team 2", null, null, 5, null, 1, null, null, null);
            var team3 = new SeasonTeam(null, teams[2], "Team 3", null, null, 5, null, 1, null, null, null);
            var team4 = new SeasonTeam(null, teams[3], "Team 4", null, null, 5, null, 1, null, null, null);

            season.Teams = new List<CompetitionTeam>() { team1, team2, team3, team4 };

            games.ForEach(g => { season.ProcessGame(g, 1); });

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
        public void ShouldGetAllTeamsInDivision()
        {
            var season = new Season();
            var nhl = new SeasonDivision() { Season = season, Name = "NHL", Level = 1 };
            var eastern = new SeasonDivision() { Season = season, Name = "Eastern", ParentDivision = nhl, Level = 2 };
            var western = new SeasonDivision() { Season = season, Name = "Western", ParentDivision = nhl, Level = 2 };
            var central = new SeasonDivision() { Season = season, Name = "Central", ParentDivision = nhl, Level = 2 };
            var east = new SeasonDivision() { Season = season, Name = "East", ParentDivision = eastern, Level = 3 };
            var atlantic = new SeasonDivision() { Season = season, Name = "Atlantic", ParentDivision = eastern, Level = 3 };
            var west = new SeasonDivision() { Season = season, Name = "West", ParentDivision = western, Level = 3 };
            var northwest = new SeasonDivision() { Season = season, Name = "NorthWest", ParentDivision = west, Level = 4 };
            var southwest = new SeasonDivision() { Season = season, Name = "Northeast", ParentDivision = west, Level = 4 };

            season.Divisions = new List<SeasonDivision>() { nhl, eastern, western, central, east, atlantic, west, northwest, southwest };
            var teamList = new List<SeasonTeam>()
            {
                CreateSeasonTeam(season, 1, "Team 1", nhl),
                CreateSeasonTeam(season, 2, "Team 2", eastern),
                CreateSeasonTeam(season, 3, "Team 3", east),
                CreateSeasonTeam(season, 4, "Team 4", east),
                CreateSeasonTeam(season, 5, "Team 5", east),
                CreateSeasonTeam(season, 6, "Team 6", northwest),
                CreateSeasonTeam(season, 7, "Team 7", northwest),
                CreateSeasonTeam(season, 8, "Team 8", central),
                CreateSeasonTeam(season, 9, "Team 9", central),
                CreateSeasonTeam(season, 10, "Team 10", atlantic),
                CreateSeasonTeam(season, 11, "Team 11", atlantic),
                CreateSeasonTeam(season, 12, "Team 12", atlantic),
                CreateSeasonTeam(season, 13, "Team 13", atlantic),
                CreateSeasonTeam(season, 14, "Team 14", northwest),
                CreateSeasonTeam(season, 15, "Team 15", southwest),
                CreateSeasonTeam(season, 16, "Team 16", southwest)
            };

            StrictEqual(16, season.GetAllTeamsInDivision(nhl).Count);
            StrictEqual(8, season.GetAllTeamsInDivision(eastern).Count);
            StrictEqual(5, season.GetAllTeamsInDivision(western).Count);
            StrictEqual(2, season.GetAllTeamsInDivision(central).Count);
            StrictEqual(4, season.GetAllTeamsInDivision(atlantic).Count);
            StrictEqual(3, season.GetAllTeamsInDivision(east).Count);
            StrictEqual(5, season.GetAllTeamsInDivision(west).Count);
            StrictEqual(3, season.GetAllTeamsInDivision(northwest).Count);
            StrictEqual(2, season.GetAllTeamsInDivision(southwest).Count);
        }

        [Fact]
        public void ShouldProcessEndOfCompetitionDetails()
        {
            True(false);
        }

        [Fact]
        public void ShouldGetDivisionByName()
        {
            True(false);
        }
        [Fact]
        public void ShouldSortAllTeams()
        {
            True(false);
        }
        [Fact]
        public void ShouldTeamsByDivision()
        {
            True(false);
        }
        [Fact]
        public void ShouldTestAreGamesComplete()
        {
            True(false);
        }
        [Fact]
        public void ShouldGetFinalRanking()
        {
            True(false);
        }
        private SeasonTeam CreateSeasonTeam(Competition competition, int id, string name, SeasonDivision division)
        {
            var team = new SeasonTeam(competition, new Team() { Id = id, Name = name }, 1, null, division);
            if (division.Teams == null) division.Teams = new List<SeasonTeam>();
            division.Teams.Add(team);

            return team;
        }
    }
}