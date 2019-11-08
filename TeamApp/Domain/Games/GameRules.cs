namespace TeamApp.Domain.Games
{

    public class GameRules:BaseDataObject
    {
        public virtual string Name { get; set; }
        public virtual bool CanTie { get; set; }
        public virtual int MaxOverTimePeriods { get; set; }
        public virtual int MinimumPeriods { get; set; }
        public virtual int TimePerPeriod { get; set; }
        public virtual bool IsGoldenGoal { get; set; }
        //these should change
        public virtual int HomeRange { get; set; }
        public virtual int AwayRange { get; set; }

        public GameRules():base() { }
        //get rid of these game rules at some point
        public GameRules(string name, bool canTie, int minimumPeriods, int maxOverTimePeriods, int homeRange, int awayRange):base()
        {
            Name = name;
            CanTie = canTie;
            MaxOverTimePeriods = maxOverTimePeriods;
            MinimumPeriods = minimumPeriods;
            HomeRange = homeRange;
            AwayRange = awayRange;
        }

        public GameRules(string name, bool canTie, int maxOverTimePeriods, int minimumPeriods, int timePerPeriod, bool isGoldenGoal)
        {
            Name = name;
            CanTie = canTie;
            MaxOverTimePeriods = maxOverTimePeriods;
            MinimumPeriods = minimumPeriods;
            TimePerPeriod = timePerPeriod;
            IsGoldenGoal = isGoldenGoal;
        }
    }

}
