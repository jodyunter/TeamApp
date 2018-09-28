using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competition.Seasons;

namespace TeamApp.Console.Views.Season
{
    public class SeasonTeamStatsView
    {

        public static string formatter = "{0,3}. {1,-15}{2,5}{3,5}{4,5}{5,5}{6,5}{7,5}{8,5}{9,5}{10,15}";

        public SeasonTeamStats Stats { get; set; }
        public string TeamName { get; set; }
        public string DivisionName { get; set; }

        public SeasonTeamStatsView(SeasonTeamStats stats, string teamName, string divisionName)
        {
            Stats = stats;
            TeamName = teamName;
            DivisionName = divisionName;
        }
        public static string GetHeader()
        {
            return string.Format(formatter, "R", "Name", "W", "L", "T", "Pts", "GP", "GF", "GA", "GD", "Div");
        }
        public string GetView()
        {
            return string.Format(formatter, "-", TeamName, Stats.Wins, Stats.Loses, Stats.Ties, Stats.Points, Stats.Games, Stats.GoalsFor,
                Stats.GoalsAgainst, Stats.GoalDifference, DivisionName);
        }
    }
}
