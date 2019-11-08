using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Games
{
    //this class is NOT stored in the database
    public class GamePlayer:BaseDataObject,IPlayer
    {
        public virtual string Name { get; set; }
        public virtual int Age { get; set; } = 20;
        public virtual int Offense { get; set; } = 10;
        public virtual int Defense { get; set; } = 10;
        public virtual int Goaltending { get; set; } = 10;
        public virtual int? FirstYear { get; set; }
        public virtual int? LastYear { get; set; }

        public virtual NewGame Game { get; set; }
        public virtual IPlayer Parent { get; set; }
        public virtual PlayerStats Stats { get; set; }
        public virtual ITeam Team { get; set; }        

        public GamePlayer()
        {

        }

        public GamePlayer(NewGame g, IPlayer p, ITeam team, int? year)
        {
            Stats = new PlayerStats();
            Name = p.Name;
            Age = p.Age;
            Offense = p.Offense;
            Defense = p.Defense;
            Goaltending = p.Goaltending;
            p.FirstYear = year;
            p.LastYear = year;
            Game = g;
            Parent = p;
            Team = team;
        }
    }
}
