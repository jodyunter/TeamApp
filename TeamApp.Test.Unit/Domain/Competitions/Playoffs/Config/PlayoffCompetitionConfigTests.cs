﻿using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Competitions.Seasons;
using TeamApp.Domain;
using Xunit;
using static Xunit.Assert;
using TeamApp.Domain.Competitions.Playoffs;
using TeamApp.Domain.Competitions.Config.Playoffs;

namespace TeamApp.Test.Domain.Competitions.Playoffs.Config
{
    public class PlayoffCompetitionConfigTests
    {
        private static Team CreateTeamForTests(long id, string name, string nickName, string shortName, int skill, string owner, int? start, int? end, bool active)
        {
            var team = new Team(name, nickName, shortName, skill, owner, start, end, active, null);

            team.Id = id;

            return team;
        }
        private List<Team> teams = new List<Team>()
        {
            CreateTeamForTests(1, "Team 1", "T1", "T1", 5, "Me", 1, null, true),
            CreateTeamForTests(2, "Team 2", "T1", "T1", 5, "Me", 1, null, true),
            CreateTeamForTests(3, "Team 3", "T1", "T1", 5, "Me", 1, null, true),
            CreateTeamForTests(4, "Team 4", "T1", "T1", 5, "Me", 1, null, true),
            CreateTeamForTests(5, "Team 5", "T1", "T1", 5, "Me", 1, null, true),
            CreateTeamForTests(6, "Team 6", "T1", "T1", 5, "Me", 1, null, true),
            CreateTeamForTests(7, "Team 7", "T1", "T1", 5, "Me", 1, null, true),
            CreateTeamForTests(8, "Team 8", "T1", "T1", 5, "Me", 1, null, true),
            CreateTeamForTests(9, "Team 9", "T1", "T1", 5, "Me", 1, null, true),
            CreateTeamForTests(10, "Team 10", "T1", "T1", 5, "Me", 1, null, true),
            CreateTeamForTests(11, "Team 11", "T1", "T1", 5, "Me", 1, null, true),
            CreateTeamForTests(12, "Team 12", "T1", "T1", 5, "Me", 1, null, true),
        };

        private void CreateSeasonDivisions(Season season)
        {
            var ordered = teams.OrderBy(t => t.Name).ToList();

            var nhl = new SeasonDivision(season, null, 1, "NHL", 1, 1, null);
            var east = new SeasonDivision(season, nhl, 1, "East", 2, 1, null);
            var west = new SeasonDivision(season, nhl, 1, "West", 2, 2, null);
            var central = new SeasonDivision(season, nhl, 1, "Central", 2, 3, null);

            season.Divisions = new List<SeasonDivision>() { nhl, east, west, central };
            
        }
        private void CreateSeasonTeams(Season season)
        {
            season.Teams = new List<CompetitionTeam>() {
                new SeasonTeam(season, teams[0], 1, new SeasonTeamStats(), season.Divisions[1]),
                new SeasonTeam(season, teams[1], 1, new SeasonTeamStats(), season.Divisions[1]),
                new SeasonTeam(season, teams[2], 1, new SeasonTeamStats(), season.Divisions[1]),
                new SeasonTeam(season, teams[3], 1, new SeasonTeamStats(), season.Divisions[1]),
                new SeasonTeam(season, teams[4], 1, new SeasonTeamStats(), season.Divisions[2]),
                new SeasonTeam(season, teams[5], 1, new SeasonTeamStats(), season.Divisions[2]),
                new SeasonTeam(season, teams[6], 1, new SeasonTeamStats(), season.Divisions[2]),
                new SeasonTeam(season, teams[7], 1, new SeasonTeamStats(), season.Divisions[2]),
                new SeasonTeam(season, teams[8], 1, new SeasonTeamStats(), season.Divisions[3]),
                new SeasonTeam(season, teams[9], 1, new SeasonTeamStats(), season.Divisions[3]),
                new SeasonTeam(season, teams[10], 1, new SeasonTeamStats(), season.Divisions[3]),
                new SeasonTeam(season, teams[11], 1, new SeasonTeamStats(), season.Divisions[3])
            };
        }

        private void CreateSeasonRankings(Season season)
        {
            var nhl = new int[] { 5, 4, 12, 11, 10, 1, 3, 8, 7, 2, 6, 9 };
            //t6, t10,t7,t2,t1,t11,t9,t12,t5,t4,t3
            var east = new int[] { 2, 1, 4, 3 };
            //t2,t1,t4,t3
            var west = new int[] { 4, 1, 3, 2 };
            //t6,t7,t8,t5
            var central = new int[] { 3, 1, 2, 4 };
            //t10,t11,t9,t12

            int nhlc = 0;
            int eastc = 0;
            int westc = 0;
            int centralc = 0;

            season.Rankings = new List<TeamRanking>();

            season.Teams.ToList().ForEach(team =>
            {
                season.Rankings.Add(new TeamRanking(nhl[nhlc++], "NHL", team, 1));

                int rank = -1;
                string div = "";
                switch (((SeasonTeam)team).Division.Name)
                {
                    case "East":
                        rank = east[eastc++];
                        div = "East";
                        break;
                    case "West":
                        rank = west[westc++];
                        div = "West";
                        break;
                    case "Central":
                        div = "Central";
                        rank = central[centralc++];
                        break;
                }

                season.Rankings.Add(new TeamRanking(rank, div, team, 1));
            });
        }

        private void CreateRankingRules(PlayoffCompetitionConfig config)
        {
            config.RankingRules = new List<PlayoffRankingRule>()
            {
                new PlayoffRankingRule(config, "Top Seeds", "East", "NHL", 1, 1, null, 1, 1, null),
                new PlayoffRankingRule(config, "Top Seeds", "West", "NHL", 1, 1, null, 1, 1, null),
                new PlayoffRankingRule(config, "Top Seeds", "Central", "NHL", 1, 1, null, 1, 1, null),
                new PlayoffRankingRule(config, "RemainingTeams", "East", "NHL", 2, null, null, 1, 1, null),
                new PlayoffRankingRule(config, "RemainingTeams", "West", "NHL", 2, null, null, 1, 1, null),
                new PlayoffRankingRule(config, "RemainingTeams", "Central", "NHL", 2, null, null, 1, 1, null),
                new PlayoffRankingRule(config, "Combined", "Top Seeds", "NHL", 1, 2, 5, 2, 1, null),
                new PlayoffRankingRule(config, "Combined", "RemainingTeams", "NHL", 4, 8, 15, 2, 1, null)
            };
        }

        private void CreatePlayoffTeams(Playoff playoff)
        {
            playoff.Teams = new List<CompetitionTeam>()
            {
                new PlayoffTeam(playoff, teams[0], 1),
                new PlayoffTeam(playoff, teams[1], 1),
                new PlayoffTeam(playoff, teams[2], 1),
                new PlayoffTeam(playoff, teams[3], 1),
                new PlayoffTeam(playoff, teams[4], 1),
                new PlayoffTeam(playoff, teams[5], 1),
                new PlayoffTeam(playoff, teams[6], 1),
                new PlayoffTeam(playoff, teams[7], 1),
                new PlayoffTeam(playoff, teams[8], 1),
                new PlayoffTeam(playoff, teams[9], 1),
                new PlayoffTeam(playoff, teams[10], 1),
                new PlayoffTeam(playoff, teams[11], 1)
            };
        }

        private void CreatePlayoffRankings(Playoff playoffs)
        {
            playoffs.Rankings = new List<TeamRanking>()
            {
                new TeamRanking(1, "Top Seeds", (PlayoffTeam)playoffs.Teams[0], 1),
                new TeamRanking(2, "Top Seeds", (PlayoffTeam)playoffs.Teams[1], 1),
                new TeamRanking(3, "Top Seeds", (PlayoffTeam)playoffs.Teams[2], 1),
                new TeamRanking(6, "NHL", (PlayoffTeam)playoffs.Teams[5], 1),
            };
        }
        
        [Fact]
        public void ShouldCopyTeamsFromSeason()
        {
            var season = new Season(null, "My Season", 1, null, null, null, null, true, false, 1, null);

            CreateSeasonDivisions(season);
            CreateSeasonTeams(season);
            CreateSeasonRankings(season);

            var playoffConfig = new PlayoffCompetitionConfig();
            var playoff = new Playoff() { Year = 15 };
            playoffConfig.CopyTeamsFromCompetition(playoff, season);

            StrictEqual(12, playoff.Teams.Count());
        }

        [Fact]
        public void ShouldCopyTeamsFromPlayoff()
        {
            var oldPlayoff = new Playoff();
            CreatePlayoffTeams(oldPlayoff);

            var playoffConfig = new PlayoffCompetitionConfig();
            var newPlayoff = new Playoff() { Year = 15 };
            playoffConfig.CopyTeamsFromCompetition(newPlayoff, oldPlayoff);

            StrictEqual(12, newPlayoff.Teams.Count());

        }
        [Fact]
        public void ShouldCreateTeamRankingsFromSeason()
        {
            var season = new Season(null, "My Season", 1, null, null, null, null, true, false, 1, null);

            CreateSeasonDivisions(season);
            CreateSeasonTeams(season);            
            CreateSeasonRankings(season);

            var playoffConfig = new PlayoffCompetitionConfig();
            var playoff = new Playoff() { Year = 15 };
            playoffConfig.CopyTeamsFromCompetition(playoff, season);
            playoffConfig.CopyRankingsFromCompetition(playoff, season);
            var newRankings = playoff.Rankings;

            StrictEqual(12, newRankings.Where(r => r.GroupName.Equals("NHL")).Count());
            StrictEqual(4, newRankings.Where(r => r.GroupName.Equals("East")).Count());
            StrictEqual(4, newRankings.Where(r => r.GroupName.Equals("West")).Count());
            StrictEqual(4, newRankings.Where(r => r.GroupName.Equals("Central")).Count());

            Single(newRankings.Where(r => r.GroupName.Equals("NHL") && r.Rank == 5 && r.CompetitionTeam.Name.Equals("Team 1")));
            Single(newRankings.Where(r => r.GroupName.Equals("East") && r.Rank == 2 && r.CompetitionTeam.Name.Equals("Team 1")));

            Single(newRankings.Where(r => r.GroupName.Equals("NHL") && r.Rank == 10 && r.CompetitionTeam.Name.Equals("Team 5")));
            Single(newRankings.Where(r => r.GroupName.Equals("West") && r.Rank == 4 && r.CompetitionTeam.Name.Equals("Team 5")));
        }

        [Fact]
        public void ShouldCreateTeamRankingsFromPlayoff()
        {
            var oldPlayoff = new Playoff();
            CreatePlayoffTeams(oldPlayoff);
            CreatePlayoffRankings(oldPlayoff);

            var playoffConfig = new PlayoffCompetitionConfig();
            var newPlayoff = new Playoff() { Year = 15 };
            playoffConfig.CopyTeamsFromCompetition(newPlayoff, oldPlayoff);
            playoffConfig.CopyRankingsFromCompetition(newPlayoff, oldPlayoff);

            StrictEqual(4, newPlayoff.Rankings.Count());
            Single(newPlayoff.Rankings.Where(r => r.GroupName.Equals("NHL") && r.Rank == 6 && r.CompetitionTeam.Name.Equals("Team 6")));
        }
        [Fact]
        public void ShouldCreateTeamRankingsFromAllRules()
        {
            var season = new Season(null, "My Season", 1, null, null, null, null, true, false, 1, null);
            var playoffConfig = new PlayoffCompetitionConfig();
            var playoff = new Playoff() { Year = 15 };

            CreateSeasonDivisions(season);
            CreateSeasonTeams(season);            
            CreateSeasonRankings(season);
            CreateRankingRules(playoffConfig);

            playoffConfig.CopyTeamsFromCompetition(playoff, season);
            playoffConfig.CopyRankingsFromCompetition(playoff, season);        
            playoffConfig.ProcessRankingRules(playoff);

            var topSeeds = playoff.Rankings.Where(r => r.GroupName.Equals("Top Seeds"));
            var restOfTeams = playoff.Rankings.Where(r => r.GroupName.Equals("RemainingTeams"));
            var combined = playoff.Rankings.Where(r => r.GroupName.Equals("Combined"));

            StrictEqual(3, topSeeds.Count());
            StrictEqual(9, restOfTeams.Count());
            StrictEqual(7, combined.Count());

            var seedName = topSeeds.Select(r => r.CompetitionTeam.Name).ToList();
            var restNames = restOfTeams.Select(r => r.CompetitionTeam.Name).ToList();            

            StrictEqual(0, seedName.Where(r => restNames.Contains(r)).ToList().Count());
            StrictEqual(9, restNames.Count);
                        
            Equal("Team 6", topSeeds.Where(r => r.Rank == 1).First().CompetitionTeam.Name);
            Equal("Team 10", topSeeds.Where(r => r.Rank == 2).First().CompetitionTeam.Name);
            Equal("Team 2", topSeeds.Where(r => r.Rank == 3).First().CompetitionTeam.Name);

            Equal("Team 7", restOfTeams.Where(r => r.Rank == 1).First().CompetitionTeam.Name);
            Equal("Team 1", restOfTeams.Where(r => r.Rank == 2).First().CompetitionTeam.Name);
            Equal("Team 11", restOfTeams.Where(r => r.Rank == 3).First().CompetitionTeam.Name);
            Equal("Team 9", restOfTeams.Where(r => r.Rank == 4).First().CompetitionTeam.Name);
            Equal("Team 8", restOfTeams.Where(r => r.Rank == 5).First().CompetitionTeam.Name);
            Equal("Team 12", restOfTeams.Where(r => r.Rank == 6).First().CompetitionTeam.Name);
            Equal("Team 5", restOfTeams.Where(r => r.Rank == 7).First().CompetitionTeam.Name);
            Equal("Team 4", restOfTeams.Where(r => r.Rank == 8).First().CompetitionTeam.Name);
            Equal("Team 3", restOfTeams.Where(r => r.Rank == 9).First().CompetitionTeam.Name);

            Equal("Team 6", combined.Where(r => r.Rank == 1).First().CompetitionTeam.Name);
            Equal("Team 10", combined.Where(r => r.Rank == 2).First().CompetitionTeam.Name);
            Equal("Team 9", combined.Where(r => r.Rank == 3).First().CompetitionTeam.Name);
            Equal("Team 8", combined.Where(r => r.Rank == 4).First().CompetitionTeam.Name);
            Equal("Team 12", combined.Where(r => r.Rank == 5).First().CompetitionTeam.Name);
            Equal("Team 5", combined.Where(r => r.Rank == 6).First().CompetitionTeam.Name);
            Equal("Team 4", combined.Where(r => r.Rank == 7).First().CompetitionTeam.Name);            
        }
        //this only tests a single level group, to test mulitple elvels need to use the higher method
        [Fact]
        public void ShouldCreateTeamRankingsFromRule()
        {
            var season = new Season(null, "My Season", 1, null, null, null, null, true, false, 1, null);
            var playoffConfig = new PlayoffCompetitionConfig();
            var playoff = new Playoff() { Year = 15 };

            CreateSeasonDivisions(season);
            CreateSeasonTeams(season);            
            CreateSeasonRankings(season);
            CreateRankingRules(playoffConfig);

            playoffConfig.CopyTeamsFromCompetition(playoff, season);
            playoffConfig.CopyRankingsFromCompetition(playoff, season);

            playoffConfig.RankingRules.OrderBy(rr => rr.GroupSetupLevel).ToList().ForEach(rule =>
            {
                playoffConfig.CreateRankingsFromRule(playoff, rule);
            });

            var topSeeds = playoff.Rankings.Where(r => r.GroupName.Equals("Top Seeds"));
            var restOfTeams = playoff.Rankings.Where(r => r.GroupName.Equals("RemainingTeams"));            

            StrictEqual(3, topSeeds.Count());
            StrictEqual(9, restOfTeams.Count());            

            var seedName = topSeeds.Select(r => r.CompetitionTeam.Name).ToList();
            var restNames = restOfTeams.Select(r => r.CompetitionTeam.Name).ToList();

            playoff.SeedRankingsGroups();

            StrictEqual(0, seedName.Where(r => restNames.Contains(r)).ToList().Count());
            StrictEqual(9, restNames.Count);
                        
            Equal("Team 6", topSeeds.Where(r => r.Rank == 1).First().CompetitionTeam.Name);
            Equal("Team 10", topSeeds.Where(r => r.Rank == 2).First().CompetitionTeam.Name);
            Equal("Team 2", topSeeds.Where(r => r.Rank == 3).First().CompetitionTeam.Name);


            Equal("Team 7", restOfTeams.Where(r => r.Rank == 1).First().CompetitionTeam.Name);
            Equal("Team 1", restOfTeams.Where(r => r.Rank == 2).First().CompetitionTeam.Name);
            Equal("Team 11", restOfTeams.Where(r => r.Rank == 3).First().CompetitionTeam.Name);
            Equal("Team 9", restOfTeams.Where(r => r.Rank == 4).First().CompetitionTeam.Name);
            Equal("Team 8", restOfTeams.Where(r => r.Rank == 5).First().CompetitionTeam.Name);
            Equal("Team 12", restOfTeams.Where(r => r.Rank == 6).First().CompetitionTeam.Name);
            Equal("Team 5", restOfTeams.Where(r => r.Rank == 7).First().CompetitionTeam.Name);
            Equal("Team 4", restOfTeams.Where(r => r.Rank == 8).First().CompetitionTeam.Name);
            Equal("Team 3", restOfTeams.Where(r => r.Rank == 9).First().CompetitionTeam.Name);

        }

        [Fact]
        public void ShouldTestCreateCompetitionTeam()
        {
            True(false);
        }

        [Fact]
        public void ShouldGetFinalRankings()
        {
            True(false);
        }

    }
}
