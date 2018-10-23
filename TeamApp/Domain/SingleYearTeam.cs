using TeamApp.Domain.Competitions;

namespace TeamApp.Domain
{
    public class SingleYearTeam : ITeam
    {
        public virtual Competition Competition { get; set; }
        public virtual Team Parent { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string ShortName { get; set; }
        public int Skill { get; set; }
        public string Owner { get; set; }
        public int? FirstYear { get; set; }
        public int? LastYear { get { return FirstYear; } set { } }

        public SingleYearTeam() { }
        public SingleYearTeam(Competition competition, Team parent, string name, string nickName, string shortName, int skill, string owner, int? year)
        {
            Competition = competition;
            Parent = parent;
            Name = name;
            NickName = nickName;
            ShortName = shortName;
            Skill = skill;
            Owner = owner;
            FirstYear = year;
            LastYear = year;
        }
    }
}
