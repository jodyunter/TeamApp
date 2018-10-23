namespace TeamApp.Domain.Competitions
{
    public class TeamRanking
    {
        public int Rank { get; set; }
        public string Group { get; set; }
        public SingleYearTeam Team { get; set; }

        public TeamRanking(int rank, string group, SingleYearTeam team)
        {
            Rank = rank;
            Group = group;
            Team = team;
        }
    }
}
