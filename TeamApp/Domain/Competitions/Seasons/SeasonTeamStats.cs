using System;

namespace TeamApp.Domain.Competitions.Seasons
{
    public class SeasonTeamStats:IComparable<SeasonTeamStats>
    {

        public SeasonTeamStats(SeasonTeam team)
        {
            Team = team;
            Wins = 0;
            Ties = 0;
            Loses = 0;
            GoalsFor = 0;
            GoalsAgainst = 0;
            PointsPerWin = 2;
            PointsPerTie = 1;
        }
        public SeasonTeamStats(SeasonTeam p, int wins, int loses, int ties, int goalsFor, int goalsAgainst, int pointsPerWin, int pointsPerTie)
        {
            Team = p;
            Wins = wins;
            Loses = loses;
            Ties = ties;
            GoalsFor = goalsFor;
            GoalsAgainst = goalsAgainst;
            PointsPerWin = pointsPerWin;
            PointsPerTie = pointsPerTie;
        }

        public SeasonTeam Team { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }
        public int Ties { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        
        public int GoalDifference { get { return GoalsFor - GoalsAgainst; } }
        public int Points { get { return Wins * PointsPerWin + Ties * PointsPerTie; } }
        public int Games { get { return Wins + Loses + Ties; } }

        public int PointsPerWin { get; set; }
        public int PointsPerTie { get; set; }

        public int CompareTo(SeasonTeamStats other)
        {
            if (this.Points == other.Points)
            {
                if (this.Games == other.Games)
                {
                    if (this.Wins == other.Wins)
                    {
                        if (this.GoalDifference == other.GoalDifference)
                        {
                            if (this.GoalsFor == other.GoalsFor)
                            {
                                return 0;
                            }
                            else
                                return this.GoalsFor - other.GoalsFor;
                        }
                        else
                            return this.GoalDifference - other.GoalDifference;
                    }
                    else
                        return this.Wins - other.Wins;
                }
                else
                {
                    return (this.Games - other.Games) * -1; // we want less games to be better
                }
            }
            else
                return this.Points - other.Points;
        }
    }
}
