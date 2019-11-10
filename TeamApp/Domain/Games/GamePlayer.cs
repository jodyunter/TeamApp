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
        public virtual Game Game { get; set; }
        public virtual IPlayer Parent { get { return ParentPlayer; } set { ParentPlayer = (Player)value; } }
        public virtual PlayerStats Stats { get; set; }
        public virtual ITeam Team { get { return CurrentTeam; } set { CurrentTeam = (Team)value; } }
        public virtual int? FirstYear { get; set; }
        public virtual int? LastYear { get; set; }  
        public virtual Team CurrentTeam { get; set; }
        public virtual Player ParentPlayer { get; set; }

        public GamePlayer()
        {

        }

        public GamePlayer(Game g, Player p, Team team, int? year)
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
