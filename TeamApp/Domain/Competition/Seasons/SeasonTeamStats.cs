using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Competition.Seasons
{
    public class SeasonTeamStats
    {

        public SeasonTeamStats(SeasonTeam team)
        {
            Team = team;
            Wins = 0;
            Ties = 0;
            Loses = 0;
            GoalsFor = 0;
            GoalsAgainst = 0;
        }
        public SeasonTeamStats(SeasonTeam p, int wins, int loses, int ties, int goalsFor, int goalsAgainst)
        {
            Team = p;
            Wins = wins;
            Loses = loses;
            Ties = ties;
            GoalsFor = goalsFor;
            GoalsAgainst = goalsAgainst;            
        }

        public SeasonTeam Team { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }
        public int Ties { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        
        public int GoalDifference { get { return GoalsFor - GoalsAgainst; } }
        public int Points { get { return Wins * 2 + Ties; } }
        public int Games { get { return Wins + Loses + Ties; } }
    }
}
