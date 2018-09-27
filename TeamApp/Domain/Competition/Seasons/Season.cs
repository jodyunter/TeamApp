using System;
using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain.Competition.Seasons.Config;
using TeamApp.Domain.Scheduler;

namespace TeamApp.Domain.Competition.Seasons
{
    public class Season
    {
        public SeasonCompetition Parent { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public List<SeasonDivision> Divisions { get; set; }
        public List<SeasonTeam> Teams { get; set; }

        public Season(SeasonCompetition parent, string name, int year)
        {
            Parent = parent;
            Name = name;
            Year = year;
        }
        
        public void ProcessGame(ScheduleGame game)
        {
            if (game.Complete)
            {
                var home = Teams.Where(t => t.Name.Equals(game.HomeTeam.Name)).First();
                var away = Teams.Where(t => t.Name.Equals(game.AwayTeam.Name)).First();

                if (game.HomeScore == game.AwayScore)
                {
                    home.Stats.Ties++;
                    away.Stats.Ties++;
                }
                else
                {
                    Teams.Where(t => t.Name.Equals(game.GetWinner().Name)).First().Stats.Wins++;
                    Teams.Where(t => t.Name.Equals(game.GetLoser().Name)).First().Stats.Loses++;
                }

                home.Stats.GoalsFor += game.HomeScore;
                home.Stats.GoalsAgainst += game.AwayScore;
                away.Stats.GoalsFor += game.AwayScore;
                away.Stats.GoalsAgainst += game.HomeScore;
            }
        }
    }
}
