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

        public GameRules():base() { }
        //get rid of these game rules at some point
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
