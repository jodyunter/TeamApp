using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Competition
{
    public class Game
    {
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public bool Complete { get; set; }
        public bool CanTie { get; set; }
        public int MaxOverTimePeriods { get; set; }        

        public Game() { }
        public Game(Team homeTeam, Team awayTeam, int homeScore, int awayScore, bool complete, bool canTie, int maxOverTimePeriods)
        {
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            HomeScore = homeScore;
            AwayScore = awayScore;
            Complete = complete;
            CanTie = canTie;
            MaxOverTimePeriods = maxOverTimePeriods;
        }

        public Team GetWinner()
        {
            if (HomeScore > AwayScore) return HomeTeam;
            else if (AwayScore > HomeScore) return AwayTeam;
            else return null;
        }

        public Team GetLoser()
        {
            if (HomeScore > AwayScore) return AwayTeam;
            else if (AwayScore > HomeScore) return HomeTeam;
            else return null;
        }

        public bool Play(Random r)
        {
            if (!Complete)
            {
                int HomeScore = r.Next(7);
                int AwayScore = r.Next(6);
                int currentPeriod = 1;
                int regularPeriods = 1;

                while (HomeScore == AwayScore && (!CanTie || currentPeriod <= regularPeriods + MaxOverTimePeriods))
                {
                    int next = r.Next(11) - 5;

                    if (next < 0) AwayScore++;
                    else if (next > 0) HomeScore++;

                    currentPeriod++;
                }

                Complete = true;

                return true;
            }

            return false;
        }
    }
}
