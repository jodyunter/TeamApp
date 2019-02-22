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
        [Fact]
        public void shouldTestRankingRules()
        {
            var data = Data1.CreateBasicSeasonConfiguration();
            var seasonCompetition = ((List<SeasonCompetitionConfig>)data[Data1.BASIC_SEASON_COMPETITION_LSIT])[0];
            var season = (Season)seasonCompetition.CreateCompetition(1, 1, null);            
            Random r = new Random(12345);            
            while (!season.Schedule.IsComplete())
                season.PlayNextDay(r);

            season.SortAllTeams();

            var gameRules = new GameRules("Playoff Game Rules", false, 3, 1, 7, 6);
            var playoffConfig = new PlayoffCompetitionConfig("My Playoff", null, 2, gameRules, 1, null, null, null, new List<CompetitionConfig>() { seasonCompetition  });

            var rankingRules = new List<PlayoffRankingRule>();           
            rankingRules.Add(new PlayoffRankingRule(playoffConfig, "East", 3, seasonCompetition, "East", 5, 8,1, 12));
            rankingRules.Add(new PlayoffRankingRule(playoffConfig, "West", 15, seasonCompetition, "West", 3, 3,1, null));
            //test out the active rule
            //playoff is for year 5, this rule ends year 4
            rankingRules.Add(new PlayoffRankingRule(playoffConfig, "Other", 25, seasonCompetition, "Other", 3, 3, 1, 4));

            playoffConfig.RankingRules = rankingRules;

            var playoff = new Playoff(playoffConfig, "My Playoff", 5, 1, null, new List<SingleYearTeam>(), null, null, true, false, 15, null);

            playoffConfig.ProcessRankingRulesAndAddTeams(playoff, new List<Competition> { season });

            StrictEqual(5, playoff.Teams.Count);
            StrictEqual(5, playoff.Rankings.Count);

            StrictEqual(4, playoff.Rankings.Where(ra => ra.GroupName.Equals("East")).ToList().Count);
            False(playoff.Rankings.Where(ra => ra.GroupName.Equals("East")).ToList().Select(ra => ra.Rank).ToList().Except(new int[] { 3, 4, 5, 6 }).Any());
                        
            StrictEqual(1, playoff.Rankings.Where(ra => ra.GroupName.Equals("West")).ToList().Count);
            True(playoff.Rankings.Where(ra => ra.GroupName.Equals("West")).ToList()[0].Rank == 15);

            var teamName = playoff.Rankings.Where(ra => ra.GroupName.Equals("West")).ToList()[0].Team.Name;

            True(season.Rankings.Where(ra => ra.GroupName.Equals("West") && ra.Team.Name.Equals(teamName)).First().Rank == 3);
            Null(playoff.Rankings.Where(ra => ra.GroupName.Equals("Other")).FirstOrDefault());
        }

    }
}
