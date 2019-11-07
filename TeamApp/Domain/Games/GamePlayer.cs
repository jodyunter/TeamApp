using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Games
{
    public class GamePlayer:Player
    {
        public virtual Game Game { get; set; }
        public virtual Player Parent { get; set; }
        public virtual PlayerStats Stats { get; set; }        
        public virtual Team Team { get { return CurrentTeam; } set { CurrentTeam = value; } }
    }
}
