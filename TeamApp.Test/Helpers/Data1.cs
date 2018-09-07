using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain;
using TeamApp.Domain.Competition.Season.Config;

namespace TeamApp.Test.Helpers
{
    public class Data1
    {
        public static string BASIC_TEAM_MAP = "BASIC_TEAM_MAP";
        public static string BASIC_DIVISION_MAP = "BASIC_DIVISION_MAP";
        public static string BASIC_SEASON_RULE_LIST = "BASIC_SEASON_RULE_LIST";
        public static string BASIC_SEASON_COMPETITION_LSIT = "BASIC_SEASON_COMPETITION_LIST";

        public static Dictionary<string, object> CreateBasicSeasonConfiguration()
        {

            var objects = new Dictionary<string, object>();

            var team1 = new Team("Team 1", 5, null, 1, null);
            var team2 = new Team("Team 2", 5, null, 1, null);
            var team3 = new Team("Team 3", 5, null, 1, null);
            var team4 = new Team("Team 4", 5, null, 1, null);
            var team5 = new Team("Team 5", 5, null, 1, null);
            var team6 = new Team("Team 6", 5, null, 1, null);
            var team7 = new Team("Team 7", 5, null, 1, null);
            var team8 = new Team("Team 8", 5, null, 1, null);
            var team9 = new Team("Team 9", 5, null, 1, null);
            var team10 = new Team("Team 10", 5, null, 1, null);
            var team11 = new Team("Team 11", 5, null, 1, null);
            var team12 = new Team("Team 12", 5, null, 1, null);


            var league1 = new Division("League 1", 1, null, null, new List<Division>());
            var division1 = new Division("Division 1", 1, null, league1, null);
            var division2 = new Division("Division 2", 1, null, league1, null);

            var teamMap = new Dictionary<string, Team>()
            {
                { team1.Name, team1 },
                { team2.Name, team2 },
                { team3.Name, team3 },
                { team4.Name, team4 },
                { team5.Name, team5 },
                { team6.Name, team6 },
                { team7.Name, team7 },
                { team8.Name, team8 },
                { team9.Name, team9 },
                { team10.Name, team10 },
                { team11.Name, team11 },
                { team12.Name, team12 },
            };

            var divisionMap = new Dictionary<string, Division>()
            {
                {league1.Name, league1 },
                {division1.Name, division1 },
                {division2.Name, division2 }
            };



            var seasonRuleList = new List<SeasonRule>()
            {
                new SeasonRule(team1, division1, 1, null, SeasonRule.DIVISION),
                new SeasonRule(team2, division1, 1, null, SeasonRule.DIVISION),
                new SeasonRule(team3, division1, 1, null, SeasonRule.DIVISION),
                new SeasonRule(team4, division1, 1, null, SeasonRule.DIVISION),
                new SeasonRule(team5, division1, 1, null, SeasonRule.DIVISION),
                new SeasonRule(team6, division1, 1, null, SeasonRule.DIVISION),
                new SeasonRule(team7, division2, 1, null, SeasonRule.DIVISION),
                new SeasonRule(team8, division2, 1, null, SeasonRule.DIVISION),
                new SeasonRule(team9, division2, 1, null, SeasonRule.DIVISION),
                new SeasonRule(team10, division2, 1, null, SeasonRule.DIVISION),
                new SeasonRule(team11, division2, 1, null, SeasonRule.DIVISION),
                new SeasonRule(team12, division2, 1, null, SeasonRule.DIVISION),
            };

            var seasonCompetitionList = new List<SeasonCompetition>()
            {
                new SeasonCompetition("My Season", new League {Name = "My Leauge"}, 1, null, 1, 1, seasonRuleList)
            };

            objects.Add(BASIC_DIVISION_MAP, divisionMap);
            objects.Add(BASIC_TEAM_MAP, teamMap);
            objects.Add(BASIC_SEASON_RULE_LIST, seasonRuleList);
            objects.Add(BASIC_SEASON_COMPETITION_LSIT, seasonCompetitionList);

            return objects;

        }

        public static Dictionary<string, Team> CreateBasicTeamMap(int teams)
        {
            var teamMap = new Dictionary<string, Team>();

            for (int i = 0; i < teams; i++)
            {
                var name = "Team " + i.ToString();

                teamMap.Add(name, new Team(name, 5, null, 1, null));
            }

            return teamMap;
        }

    }
}
