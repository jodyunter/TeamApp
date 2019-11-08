using TeamApp.Domain.Competitions;

namespace TeamApp.Domain.Competitions
{
    public class CompetitionTeam : BaseDataObject, ITeam
    {
        public virtual Competition Competition { get; set; }
        public virtual Team Parent { get; set; }
        public virtual string Name { get; set; }
        public virtual string NickName { get; set; }
        public virtual string ShortName { get; set; }
        public virtual int Skill { get; set; }
        public virtual string Owner { get; set; }
        public virtual int? FirstYear { get; set; }
        public virtual int? LastYear { get { return FirstYear; } set { } }

        public CompetitionTeam() { }
        public CompetitionTeam(Competition competition, Team parent, string name, string nickName, string shortName, int skill, string owner, int? year)
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
