using System;
using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain.Competition.Seasons.Config;
using TeamApp.Domain.Scheduler;

namespace TeamApp.Domain.Competition.Seasons
{
    public class Season:ICompetition
    {
        public ICompetitionRule CompetitionRule { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public List<SeasonDivision> Divisions { get; set; }
        public List<SeasonTeam> Teams { get; set; }
        public Schedule Schedule { get; set; }        
        public Dictionary<string, List<SeasonDivisionRank>> Rankings { get; set; }

        public Season(SeasonCompetition competitionRule, string name, int year)
        {
            CompetitionRule = competitionRule;
            Name = name;
            Year = year;
            Rankings = new Dictionary<string, List<SeasonDivisionRank>>();
        }

        /*
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
        }*/
        
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

        public void SortAllTeams()
        {
            Divisions.ForEach(division =>
            {
                SortTeamByDivision(division.Name);
            });
        }
        public void SortTeamByDivision(string divisionName)
        {
            var division = GetDivisionByName(divisionName);

            var listOfTeams = GetAllTeamsInDivision(division);

            listOfTeams.Sort((a, b) => -1 * a.CompareTo(b)); // descending sort

            int rank = 1;

            Rankings[divisionName] = new List<SeasonDivisionRank>();

            listOfTeams.ForEach(team =>
            {
                Rankings[divisionName].Add(new SeasonDivisionRank(rank, division.Name, team));
                rank++;
            });
        }

    }
}
