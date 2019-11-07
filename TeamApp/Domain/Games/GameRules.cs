namespace TeamApp.Domain.Games
{

    public class GameRules:BaseDataObject
    {
        public virtual string Name { get; set; }
        public virtual bool CanTie { get; set; }
        public virtual int MaxOverTimePeriods { get; set; }
        public virtual int MinimumPeriods { get; set; }
        public virtual int HomeRange { get; set; }
        public virtual int AwayRange { get; set; }

        public GameRules():base() { }
        public GameRules(string name, bool canTie, int minimumPeriods, int maxOverTimePeriods, int homeRange, int awayRange):base()
        {
            Name = name;
            CanTie = canTie;
            MaxOverTimePeriods = maxOverTimePeriods;
            MinimumPeriods = minimumPeriods;
            HomeRange = homeRange;
            AwayRange = awayRange;
        }

    }

}
