using TeamApp.Domain.Games;

namespace TeamApp.Domain.Competitions
{
    public abstract class CompetitionGamePlayer:BaseDataObject,IPlayer
    {
        public virtual string Name { get; set; }
        public virtual int Age { get; set; } = 20;
        public virtual int Offense { get; set; } = 10;
        public virtual int Defense { get; set; } = 10;
        public virtual int Goaltending { get; set; } = 10;
        public virtual int? FirstYear { get; set; }
        public virtual int? LastYear { get; set; }

        public virtual Game Game { get; set; }
        
        public virtual PlayerStats Stats { get; set; }
        public virtual ITeam Team
        {
            get { return CompetitionTeam; }
            set { CompetitionTeam = (CompetitionTeam)value; }
        }
        public virtual IPlayer Parent
        {
            get { return CompetitionParent; }
            set { CompetitionParent = (CompetitionPlayer)value; }
        }
        public virtual CompetitionPlayer CompetitionParent { get; set; }

        public virtual CompetitionTeam CompetitionTeam { get; set; }
    }
}
