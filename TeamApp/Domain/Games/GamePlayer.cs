using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Games
{
    //this class is NOT stored in the database
    public abstract class GamePlayer:BaseDataObject,IPlayer
    {
        public virtual string Name { get; set; }
        public virtual int Age { get; set; } = 20;
        public virtual int Offense { get; set; } = 10;
        public virtual int Defense { get; set; } = 10;
        public virtual int Goaltending { get; set; } = 10;
        public virtual int? FirstYear { get; set; }
        public virtual int? LastYear { get; set; }

        public virtual Game Game { get; set; }
        public virtual IPlayer Parent { get; set; }
        public virtual PlayerStats Stats { get; set; }
        public virtual ITeam Team { get; set; }        
    }
}
