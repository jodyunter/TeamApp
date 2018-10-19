using System;
using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain.Competition.Seasons.Config;
using TeamApp.Domain.Schedules;

namespace TeamApp.Domain.Competition.Seasons
{
    public class Season:ICompetition
    {
        public CompetitionConfig CompetitionConfig { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public List<SeasonDivision> Divisions { get; set; }
        public List<ISingleYearTeam> Teams { get; set; }
        public Schedule Schedule { get; set; }        
        public Dictionary<string, List<TeamRanking>> Rankings { get; set; }

 
        public Season(SeasonCompetitionConfig competitionRule,int year)
        {
            CompetitionConfig = competitionRule;
            Name = competitionRule.Name;
            Year = year;
            Rankings = new Dictionary<string, List<TeamRanking>>();
        }

        public void ProcessGame(ScheduleGame game)
        {
            if (game.Complete)
            {
                var home = (SeasonTeam)Teams.Where(t => t.Name.Equals(game.HomeTeam.Name)).First();
                var away = (SeasonTeam)Teams.Where(t => t.Name.Equals(game.AwayTeam.Name)).First();

                if (game.HomeScore == game.AwayScore)
                {
                    home.Stats.Ties++;
                    away.Stats.Ties++;
                }
                else
                {
                    ((SeasonTeam)Teams.Where(t => t.Name.Equals(game.GetWinner().Name)).First()).Stats.Wins++;
                    ((SeasonTeam)Teams.Where(t => t.Name.Equals(game.GetLoser().Name)).First()).Stats.Loses++;
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

            Rankings[divisionName] = new List<TeamRanking>();

            listOfTeams.ForEach(team =>
            {
                Rankings[divisionName].Add(new TeamRanking(rank, division.Name, team));
                rank++;
            });
        }

        public bool IsComplete()
        {
            return Schedule.IsComplete();
        }
    }
}
