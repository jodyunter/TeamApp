using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain
{
    public class Game:BaseDataObject
    {
        public virtual Team HomeTeam { get; set; }
        public virtual Team AwayTeam { get; set; }
        public virtual int HomeScore { get; set; }
        public virtual int AwayScore { get; set; }
        public virtual bool Complete { get; set; }
        public virtual int CurrentPeriod { get; set; }

        public virtual GameRules Rules { get; set; }
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

        public virtual Team GetWinner()
        {
            if (HomeScore > AwayScore) return HomeTeam;
            else if (AwayScore > HomeScore) return AwayTeam;
            else return null;
        }

        public virtual Team GetLoser()
        {
            if (HomeScore > AwayScore) return AwayTeam;
            else if (AwayScore > HomeScore) return HomeTeam;
            else return null;
        }

        public virtual bool Play(Random r)
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

        public virtual void PlayRegulationPeriod(Random r)
        {
            HomeScore += r.Next(Rules.HomeRange);
            AwayScore += r.Next(Rules.AwayRange);
        }

        public virtual void PlayOverTimePeriod(Random r)
        {
            int next = r.Next(11) - 5;

            if (next < 0) AwayScore++;
            else if (next > 0) HomeScore++;

        }

        public virtual bool IsCurrentPeriodRegulationPeriod()
        {
            return CurrentPeriod <= Rules.MinimumPeriods;
        }
        public virtual bool IsComplete()
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
            var formatter = "{0,15}: {1,3} - {2,3} :{3,-15} {4}";
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
}
