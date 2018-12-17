namespace TeamApp.Domain.Competitions
{
    public class TeamRanking:BaseDataObject
    {
        public virtual int Rank { get; set; }
        public virtual string GroupName { get; set; }
        public virtual SingleYearTeam Team { get; set; }
        public virtual int GroupLevel { get; set; }

        public TeamRanking() : base() { }
        public TeamRanking(int rank, string group, SingleYearTeam team, int groupLevel)
        {
            Rank = rank;
            GroupName = group;
            Team = team;
            GroupLevel = groupLevel;
        }
    }
}
