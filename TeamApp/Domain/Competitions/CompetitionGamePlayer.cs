using TeamApp.Domain.Games;

namespace TeamApp.Domain.Competitions
{
    public class CompetitionGamePlayer:GamePlayer,IPlayer
    {

        public virtual CompetitionPlayer CompetitionParent { get; set; }

        public virtual CompetitionTeam CompetitionTeam { get; set; }

        public CompetitionGamePlayer()
        {

        }

        public CompetitionGamePlayer(Game g, Player p, Team team, int? year, CompetitionPlayer competitionParent, CompetitionTeam competitionTeam)
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
            CompetitionParent = competitionParent;
            CompetitionTeam = competitionTeam;
        }
    }
}
