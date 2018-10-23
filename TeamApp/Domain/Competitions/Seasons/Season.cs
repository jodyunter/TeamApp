using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain.Schedules;

namespace TeamApp.Domain.Competitions.Seasons
{
    public class Season:Competition
    {
        public virtual IList<SeasonDivision> Divisions { get; set; }

        public Season() : base() { }
        public Season(CompetitionConfig competitionConfig, string name, int year, List<SeasonDivision> divisions, List<SingleYearTeam> teams, Schedule schedule, List<TeamRanking> rankings)
            :base(competitionConfig, name, year, schedule, rankings, teams)
        {
            Divisions = divisions;
        }

        public override void ProcessGame(ScheduleGame game)
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

        public virtual SeasonDivision GetDivisionByName(string divisionName)
        {
            return Divisions.Where(d => d.Name.Equals(divisionName)).First();
        }

        public virtual List<SeasonTeam> GetAllTeamsInDivision(SeasonDivision division)
        {
            var result = new List<SeasonTeam>();

            if (division.Teams != null && division.Teams.Count > 0) result.AddRange(division.Teams);

            Divisions.Where(d => d.ParentDivision != null && d.ParentDivision.Name.Equals(division.Name)).ToList().ForEach(div =>
            {
                result.AddRange(GetAllTeamsInDivision(div));
            });

            return result;
        }

        public virtual void SortAllTeams()
        {
            Divisions.ToList().ForEach(division =>
            {
                SortTeamByDivision(division.Name);
            });
        }
        public virtual void SortTeamByDivision(string divisionName)
        {
            var division = GetDivisionByName(divisionName);

            var listOfTeams = GetAllTeamsInDivision(division);

            listOfTeams.Sort((a, b) => -1 * a.CompareTo(b)); // descending sort

            int rank = 1;            

            listOfTeams.ForEach(team =>
            {
                Rankings.Add(new TeamRanking(rank, division.Name, team));
                rank++;
            });
        }

        public override bool IsComplete()
        {
            return Schedule.IsComplete();
        }
    }
}
