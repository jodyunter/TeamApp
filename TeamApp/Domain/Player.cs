using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain
{
    public class Player : BaseDataObject, IPlayer
    {
        public virtual string Name { get; set; }
        public virtual int Age { get; set; } = 20;
        public virtual ITeam Team { get { return CurrentTeam; } set { CurrentTeam = (Team)value; } }
        public virtual Team CurrentTeam { get; set; }
        public virtual int Offense { get; set; } = 10;
        public virtual int Defense { get; set; } = 10;
        public virtual int Goaltending { get; set; } = 10;
        public virtual int? FirstYear { get; set; }
        public virtual int? LastYear { get; set; }
    

        public Player() { }

        public Player(string name, int age, int? firstYear, int? lastYear, Team currentTeam)
        {
            Name = name;
            Age = age;
            FirstYear = firstYear;
            LastYear = lastYear;
            Team = currentTeam;
        }

        public override bool Equals(object obj)
        {
            return obj is Player player &&
                   Name == player.Name &&
                   Age == player.Age &&
                   EqualityComparer<int?>.Default.Equals(FirstYear, player.FirstYear) &&
                   EqualityComparer<int?>.Default.Equals(LastYear, player.LastYear) &&
                   EqualityComparer<Team>.Default.Equals(CurrentTeam, player.CurrentTeam);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Age, FirstYear, LastYear, CurrentTeam);
        }
    }
}
