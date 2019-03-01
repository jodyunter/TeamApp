using System;
using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Competitions.Playoffs.Config;
using TeamApp.Domain.Competitions.Seasons;
using TeamApp.Domain.Competitions.Seasons.Config;
using TeamApp.Test.Helpers;
using TeamApp.Domain;
using Xunit;
using static Xunit.Assert;
using TeamApp.Domain.Competitions.Playoffs;

namespace TeamApp.Test.Domain.Competitions.Playoffs.Config
{
    public class PlayoffConfigTests
    {
        private List<Team> teams = new List<Team>()
        {
            new Team("Team 1", "T1", "T1", 5, "Me", 1, null, true),
            new Team("Team 2", "T1", "T1", 5, "Me", 1, null, true),
            new Team("Team 3", "T1", "T1", 5, "Me", 1, null, true),
            new Team("Team 4", "T1", "T1", 5, "Me", 1, null, true),
            new Team("Team 5", "T1", "T1", 5, "Me", 1, null, true),
            new Team("Team 6", "T1", "T1", 5, "Me", 1, null, true),
            new Team("Team 7", "T1", "T1", 5, "Me", 1, null, true),
            new Team("Team 8", "T1", "T1", 5, "Me", 1, null, true),
            new Team("Team 9", "T1", "T1", 5, "Me", 1, null, true),
            new Team("Team 10", "T1", "T1", 5, "Me", 1, null, true),
            new Team("Team 11", "T1", "T1", 5, "Me", 1, null, true),
            new Team("Team 12", "T1", "T1", 5, "Me", 1, null, true),
        };

        private void CreateSeasonDivisions(Season season)
        {
            var nhl = new SeasonDivision(season, null, 1, "NHL", 1, 1, null);
            var east = new SeasonDivision(season, nhl, 1, "East", 2, 1, null);
            var west = new SeasonDivision(season, nhl, 1, "West", 2, 2, null);
            var central = new SeasonDivision(season, nhl, 1, "Central", 2, 3, null);

            season.Divisions = new List<SeasonDivision>() { nhl, east, west, central };
            
        }
        private void CreateSeasonTeams(Season season)
        {
            season.Teams = new List<SingleYearTeam>() {
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
            var east = new int[] { 1, 2, 4, 3 };
            var west = new int[] { 4, 1, 2, 3 };
            var central = new int[] { 3, 4, 2, 1 };

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
                new PlayoffRankingRule(config, "Top Seeds", "East", "NHL", 1, 1, 1, null),
                new PlayoffRankingRule(config, "Top Seeds", "West", "NHL", 1, 1, 1, null),
                new PlayoffRankingRule(config, "Top Seeds", "Central", "NHL", 1, 1, 1, null),
                new PlayoffRankingRule(config, "RemainingTeams", "East", "NHL", 2, null, 1, null),
                new PlayoffRankingRule(config, "RemainingTeams", "West", "NHL", 2, null, 1, null),
                new PlayoffRankingRule(config, "RemainingTeams", "Central", "NHL", 2, null, 1, null),
            };
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
            playoffConfig.CopyRankingsFromCompetition(playoff, season);
            var newRankings = playoff.Rankings;

            StrictEqual(12, newRankings.Where(r => r.GroupName.Equals("NHL")).Count());
            StrictEqual(4, newRankings.Where(r => r.GroupName.Equals("East")).Count());
            StrictEqual(4, newRankings.Where(r => r.GroupName.Equals("West")).Count());
            StrictEqual(4, newRankings.Where(r => r.GroupName.Equals("Central")).Count());
        }

        [Fact]
        public void ShouldCreateTeamRankingsFromPlayoff()
        {
            True(false);
        }
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
                        
            playoffConfig.CopyRankingsFromCompetition(playoff, season);

            playoffConfig.RankingRules.ToList().ForEach(rule =>
            {
                playoffConfig.CreateRankingsFromRule(playoff, rule);
            });

            var topSeeds = playoff.Rankings.Where(r => r.GroupName.Equals("Top Seeds"));
            var restOfTeams = playoff.Rankings.Where(r => r.GroupName.Equals("RemainingTeams"));
            StrictEqual(3, topSeeds.Count());
            StrictEqual(9, restOfTeams.Count());

            var seedName = topSeeds.Select(r => r.Team.Name).ToList();
            var restNames = restOfTeams.Select(r => r.Team.Name).ToList();

            StrictEqual(0, seedName.Where(r => restNames.Contains(r)).ToList().Count());

        }
     
    }
}
