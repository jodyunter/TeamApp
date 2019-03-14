using System;

namespace TeamApp.Domain.Competitions.Seasons
{
    public class SeasonTeamStats : BaseDataObject, IComparable<SeasonTeamStats>
    {
        public SeasonTeamStats()
        {
            Wins = 0;
            Ties = 0;
            Loses = 0;
            GoalsFor = 0;
            GoalsAgainst = 0;
            PointsPerWin = 2;
            PointsPerTie = 1;
        }

        public SeasonTeamStats(int wins, int loses, int ties, int goalsFor, int goalsAgainst, int pointsPerWin, int pointsPerTie)
        {
            Wins = wins;
            Loses = loses;
            Ties = ties;
            GoalsFor = goalsFor;
            GoalsAgainst = goalsAgainst;
            PointsPerWin = pointsPerWin;
            PointsPerTie = pointsPerTie;
        }

        public virtual int Wins { get; set; }
        public virtual int Loses { get; set; }
        public virtual int Ties { get; set; }
        public virtual int GoalsFor { get; set; }
        public virtual int GoalsAgainst { get; set; }

        public virtual int GoalDifference { get { return GoalsFor - GoalsAgainst; } }
        public virtual int Points { get { return Wins * PointsPerWin + Ties * PointsPerTie; } }
        public virtual int Games { get { return Wins + Loses + Ties; } }

        public virtual int PointsPerWin { get; set; }
        public virtual int PointsPerTie { get; set; }

        public virtual int CompareTo(SeasonTeamStats other)
        {
            if (Points == other.Points)
            {
                if (Games == other.Games)
                {
                    if (Wins == other.Wins)
                    {
                        if (GoalDifference == other.GoalDifference)
                        {
                            if (GoalsFor == other.GoalsFor)
                            {
                                return 0;
                            }
                            else
                                return GoalsFor - other.GoalsFor;
                        }
                        else
                            return GoalDifference - other.GoalDifference;
                    }
                    else
                        return Wins - other.Wins;
                }
                else
                {
                    return (Games - other.Games) * -1; // we want less games to be better
                }
            }
            else
                return Points - other.Points;
        }
    }
}