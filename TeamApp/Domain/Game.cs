using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain
{
    public class Game
    {
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public bool Complete { get; set; }
        public int CurrentPeriod { get; set; }

        public GameRules Rules { get; set; }
        public Game() { }
        public Game(Team homeTeam, Team awayTeam, int homeScore, int awayScore, bool complete,  int currentPeriod, GameRules rules)
        {
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            HomeScore = homeScore;
            AwayScore = awayScore;
            Complete = complete;
            Rules = rules;
            CurrentPeriod = currentPeriod;
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

                while (!IsComplete())
                {

                    if (IsCurrentPeriodRegulationPeriod()) PlayRegulationPeriod(r);
                    else PlayOverTimePeriod(r);

                    CurrentPeriod++;
                }

                Complete = true;

                return true;
            }

            return false;
        }

        public void PlayRegulationPeriod(Random r)
        {
            HomeScore += r.Next(Rules.HomeRange);
            AwayScore += r.Next(Rules.AwayRange);
        }

        public void PlayOverTimePeriod(Random r)
        {
            int next = r.Next(11) - 5;

            if (next < 0) AwayScore++;
            else if (next > 0) HomeScore++;

        }

        public bool IsCurrentPeriodRegulationPeriod()
        {
            return CurrentPeriod <= Rules.MinimumPeriods;
        }
        public bool IsComplete()
        {
            bool regulationDone = CurrentPeriod > Rules.MinimumPeriods;  //are we in overtime?
            bool overTimeDone = true;

            if (regulationDone)
            {
                if (HomeScore != AwayScore) overTimeDone = true;
                else
                {
                    if (!Rules.CanTie) overTimeDone = false;
                    else if (!(CurrentPeriod > (Rules.MaxOverTimePeriods + Rules.MinimumPeriods))) overTimeDone = false;
                }

            }

            return regulationDone && overTimeDone;
        }

        public override string ToString()
        {
            var formatter = "{0,10}: {1,3} - {2,3} :{3,-10} {4}";
            var result = "";

            if (Complete) result += " Final";
            else result += " " + CurrentPeriod.DisplayWithSuffix();

            return string.Format(formatter, HomeTeam.Name, HomeScore, AwayScore, AwayTeam.Name, result);
        }
    }

    public static class IntegerExtensions
    {
        public static string DisplayWithSuffix(this int num)
        {
            if (num.ToString().EndsWith("11")) return num.ToString() + "th";
            if (num.ToString().EndsWith("12")) return num.ToString() + "th";
            if (num.ToString().EndsWith("13")) return num.ToString() + "th";
            if (num.ToString().EndsWith("1")) return num.ToString() + "st";
            if (num.ToString().EndsWith("2")) return num.ToString() + "nd";
            if (num.ToString().EndsWith("3")) return num.ToString() + "rd";
            return num.ToString() + "th";
        }
    }

    public class GameRules
    {
        public bool CanTie { get; set; }
        public int MaxOverTimePeriods { get; set; }        
        public int MinimumPeriods { get; set; }
        public int HomeRange { get; set; }
        public int AwayRange { get; set; }
    }
}
