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
        public Schedule Schedule { get; set; }        

        public Season(SeasonCompetition parent, string name, int year)
        {
            Parent = parent;
            Name = name;
            Year = year;
        }

        public void Playgame(ScheduleGame game, Random random)
        {
            game.Play(random);
            ProcessGame(game);
        }

        public void PlayGames(List<ScheduleGame> games, Random random)
        {
            games.ForEach(g => { g.Play(random); ProcessGame(g); });
        }

        public void PlayDay(ScheduleDay day, Random random)
        {
            PlayGames(day.Games, random);
        }

        public void PlayNextDay(Random random)
        {
            var day = Schedule.GetNextInCompleteDay();

            if (day != null)
            {
                PlayGames(day.Games, random);
            }
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

        public SeasonDivision GetDivisionByName(string divisionName)
        {
            return Divisions.Where(d => d.Name.Equals(divisionName)).First();
        }
        public List<SeasonTeam> GetAllTeamsInDivision(SeasonDivision division)
        {
            var result = new List<SeasonTeam>();

            if (division.Teams != null && division.Teams.Count > 0) result.AddRange(division.Teams);

            Divisions.Where(d => d.ParentDivision != null && d.ParentDivision.Name.Equals(division.Name)).ToList().ForEach(div =>
            {
                result.AddRange(GetAllTeamsInDivision(div));
            });

            return result;
        }

    }
}
