using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Competitions.Seasons;

namespace TeamApp.Console.Views.Season
{
    public class SeasonTeamStatsView
    {

        public static string formatter = "{0,3}. {1,-15}{2,5}{3,5}{4,5}{5,5}{6,5}{7,5}{8,5}{9,5}{10,15}";

        public TeamRanking Ranking;

        public SeasonTeamStatsView(TeamRanking ranking)
        {
            Ranking = ranking;
        }
        public static string GetHeader()
        {
            return string.Format(formatter, "R", "Name", "W", "L", "T", "Pts", "GP", "GF", "GA", "GD", "Div");
        }
        public string GetView()
        {
            var team = Ranking.Team;
            var division = Ranking.Group;
            var stats = ((SeasonTeam)team).Stats;

            return string.Format(formatter, Ranking.Rank, team.Name, stats.Wins, stats.Loses, stats.Ties, stats.Points, stats.Games, stats.GoalsFor,
                stats.GoalsAgainst, stats.GoalDifference, division);
        }
        
    }
    
}
