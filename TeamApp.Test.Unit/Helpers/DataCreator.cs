using System;
using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain;
using TeamApp.Domain.Competitions.Seasons.Config;

namespace TeamApp.Test.Helpers
{
    public class DataCreator
    {
        public static League CreateLeague(string name)
        {
            return new League(name, 1, null);
        }

        public static List<Team> CreateTeams()
        {
            return new List<Team>()
            {
                new Team("Toronto", "Maple Leafs", "TML", 1, null, 1, null, true),
                new Team("Montreal", "Canadiens", "MTL", 1, null, 1, null, true),
                new Team("Quebec", "Nordiques", "QCN", 1, null, 1, null, true),
                new Team("Ottawa", "Senators", "OTS", 1, null, 3, null, true),
                new Team("Calgary", "Flames", "CGF", 1, null, 2, null, true),
                new Team("Winnipeg", "Jets", "WPJ", 1, null, 2, null, true),
                new Team("Edmonton", "Oilers", "EDO", 1, null, 2, null, true),
                new Team("Vancouver", "Canucks", "VCC", 1, null, 3, null, true),
                new Team("Detroit", "Red Wings", "DRW", 1, null, 3, null, true)
            };
        }
        public static SeasonCompetitionConfig CreateSeasonConfiguration(League league, List<Team> teamList)
        {
            var seasonConfig = new SeasonCompetitionConfig("Regular Season", league, 1, 1, null, 1, null, null, null, null, null);

            var gameRules = new GameRules("Season Rules", true, 3, 1, 7, 6);

            seasonConfig.GameRules = gameRules;

            var divisionRules = new List<SeasonDivisionRule>()
            {
                new SeasonDivisionRule(seasonConfig, "NHL", null, 1, 1, 1, null),
                new SeasonDivisionRule(seasonConfig, "West", "NHL", 2, 1, 2, null),
                new SeasonDivisionRule(seasonConfig, "East", "NHL", 2, 2, 2, null),
                new SeasonDivisionRule(seasonConfig, "Central", "NHL", 2, 3, 3, null)
            };

            seasonConfig.DivisionRules = divisionRules;

            var scheduleRules = new List<SeasonScheduleRule>() {
                new SeasonScheduleRule(seasonConfig, SeasonScheduleRule.DIVISION_TYPE, "NHL", SeasonScheduleRule.NONE, null, 2, true, 1, 1),
                new SeasonScheduleRule(seasonConfig, SeasonScheduleRule.DIVISION_TYPE, "NHL", SeasonScheduleRule.NONE, null, 1, true, 2, null),
                new SeasonScheduleRule(seasonConfig, SeasonScheduleRule.DIVISION_TYPE, "West", SeasonScheduleRule.NONE, null, 1, true, 2, null),
                new SeasonScheduleRule(seasonConfig, SeasonScheduleRule.DIVISION_TYPE, "East", SeasonScheduleRule.NONE, null, 1, true, 2, null),
                new SeasonScheduleRule(seasonConfig, SeasonScheduleRule.DIVISION_TYPE, "Central", SeasonScheduleRule.NONE, null, 1, true, 3, null),
            };

            seasonConfig.ScheduleRules = scheduleRules;

            var seasonTeamRules = new List<SeasonTeamRule>()
            {
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Toronto").First(), "NHL", 1, 1),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Montreal").First(), "NHL", 1, 1),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Quebec").First(), "NHL", 1, 1),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Toronto").First(), "East", 2, 2),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Montreal").First(), "East", 2, null),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Quebec").First(), "East", 2, null),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Calgary").First(), "West", 2, null),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Winnipeg").First(), "West", 2, 2),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Edmonton").First(), "West", 2, null),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Detroit").First(), "Central", 3, null),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Vancouver").First(), "West", 3, null),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Ottawa").First(), "East", 3, null),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Winnipeg").First(), "Central", 3, null),
                new SeasonTeamRule(seasonConfig, teamList.Where(t => t.Name == "Toronto").First(), "Central", 3, null)
            };

            seasonConfig.TeamRules = seasonTeamRules;

            league.CompetitionConfigs.Add(seasonConfig);

            return seasonConfig;
        }
    }
}
