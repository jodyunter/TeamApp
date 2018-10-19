using System;
using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain.Competition;
using TeamApp.Domain.Competition.Playoffs.Config;
using TeamApp.Domain.Competition.Seasons;
using TeamApp.Domain.Competition.Seasons.Config;
using TeamApp.Test.Helpers;
using TeamApp.Domain;
using Xunit;
using static Xunit.Assert;
using TeamApp.Domain.Competition.Playoffs;

namespace TeamApp.Test.Domain.Competition.Playoffs.Config
{
    public class PlayoffConfigTests
    {
        [Fact]
        public void shouldTestRankingRules()
        {
            var data = Data1.CreateBasicSeasonConfiguration();
            var seasonCompetition = ((List<SeasonCompetitionConfig>)data[Data1.BASIC_SEASON_COMPETITION_LSIT])[0];
            var season = (Season)seasonCompetition.CreateCompetition(1, null);            
            Random r = new Random(12345);            
            while (!season.Schedule.IsComplete())
                season.PlayNextDay(r);

            season.SortAllTeams();

            var gameRules = new GameRules("Playoff Game Rules", false, 3, 1, 7, 6);
            var playoffConfig = new PlayoffCompetitionConfig("My Playoff", null, 2, gameRules, 1, null, null, null, new List<CompetitionConfig>() { seasonCompetition  });

            var rankingRules = new List<PlayoffRankingRule>();           
            rankingRules.Add(new PlayoffRankingRule(playoffConfig, "East", 3, seasonCompetition, "East", 5, 8));
            rankingRules.Add(new PlayoffRankingRule(playoffConfig, "West", 15, seasonCompetition, "West", 3, 3));
        
            playoffConfig.Rankings = rankingRules;

            var playoff = new Playoff(playoffConfig, "My Playoff", 1, 15, 1, null, new List<ISingleYearTeam>(), null, null);

            playoffConfig.ProcessRankingRulesAndAddTeams(playoff, new List<ICompetition> { season });

            StrictEqual(5, playoff.Teams.Count);
            StrictEqual(2, playoff.Rankings.Count);

            StrictEqual(4, playoff.Rankings["East"].Count);
            False(playoff.Rankings["East"].Select(ra => ra.Rank).ToList().Except(new int[] { 3, 4, 5, 6 }).Any());
                        
            StrictEqual(1, playoff.Rankings["West"].Count);
            True(playoff.Rankings["West"][0].Rank == 15);
            
            True(season.Rankings["West"].Where(team => team.Team.Name.Equals(playoff.Rankings["West"][0].Team.Name)).First().Rank == 3);
        }

    }
}
