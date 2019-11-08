using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Competitions
{
    public abstract class CompetitionPlayer : BaseDataObject, IPlayer
    {
        public virtual string Name { get; set; }
        public virtual int Age { get; set; } = 20;
        public virtual int Offense { get; set; } = 10;
        public virtual int Defense { get; set; } = 10;
        public virtual int Goaltending { get; set; } = 10;
        public virtual int? FirstYear { get; set; }
        public virtual int? LastYear { get { return FirstYear; } set { } }        

        public virtual ITeam Team
        {
            get { return CompetitionTeam; }
            set { CompetitionTeam = (CompetitionTeam)value; }
        }

        public virtual CompetitionTeam CompetitionTeam { get; set; }
        public virtual Competition Competition { get; set; }
        public Player Parent { get; set; }
    }
}
