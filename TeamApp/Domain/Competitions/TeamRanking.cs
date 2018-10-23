namespace TeamApp.Domain.Competitions
{
    public class TeamRanking:BaseDataObject
    {
        public virtual int Rank { get; set; }
        public virtual string GroupName { get; set; }
        public virtual SingleYearTeam Team { get; set; }

        public TeamRanking() : base() { }
        public TeamRanking(int rank, string group, SingleYearTeam team)
        {
            Rank = rank;
            GroupName = group;
            Team = team;
        }
    }
}
