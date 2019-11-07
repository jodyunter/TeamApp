using System;

namespace TeamApp.Domain.Games
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

        public virtual bool Play(Random r, int homeSkill, int awaySkill)
        {
            if (!Complete)
            {

                while (!IsComplete())
                {

                    if (IsCurrentPeriodRegulationPeriod()) PlayRegulationPeriod(r, homeSkill, awaySkill);
                    else PlayOverTimePeriod(r);

                    CurrentPeriod++;
                }

                Complete = true;

                return true;
            }

            return false;
        }

        public virtual bool Play(Random r)
        {
            return Play(r, HomeTeam.Skill, AwayTeam.Skill);
        }

        public virtual void PlayRegulationPeriod(Random r, int homeSkill, int awaySkill)
        {
            HomeScore += r.Next(Rules.HomeRange + homeSkill);
            AwayScore += r.Next(Rules.AwayRange + awaySkill);
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
            var formatter = "{0,15}: {1,2}{5,2}{2,2} :{3,-15} {4}";
            var result = "";

            if (Complete) result += " Final";
            else result += " " + CurrentPeriod.DisplayWithSuffix();

            return string.Format(formatter, HomeTeam.Name, HomeScore, AwayScore, AwayTeam.Name, result, "-");
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
