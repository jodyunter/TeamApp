using System;
using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain.Competitions.Config;
using TeamApp.Domain.Schedules;

namespace TeamApp.Domain.Competitions.Seasons
{
    public class Season:Competition
    {
        public virtual IList<SeasonDivision> Divisions { get; set; }

        public Season() : base() { }
        public Season(CompetitionConfig competitionConfig, string name, int year, List<SeasonDivision> divisions, List<CompetitionTeam> teams, Schedule schedule, List<TeamRanking> rankings, bool started, bool finished, int? startDay, int? endDay)
            :base(competitionConfig, name, year, schedule, rankings, teams, started, finished, startDay, endDay)
        {
            Divisions = divisions;
        }

        public override IEnumerable<ScheduleGame> ProcessGame(ScheduleGame game, int currentDay)
        {            
            if (game.Complete)
            {
                var home = (SeasonTeam)Teams.Where(t => t.Parent.Id == game.Home.Id).First();
                var away = (SeasonTeam)Teams.Where(t => t.Parent.Id == game.Away.Id).First();

                if (game.HomeScore == game.AwayScore)
                {
                    home.Stats.Ties++;
                    away.Stats.Ties++;
                }
                else
                {
                    ((SeasonTeam)Teams.Where(t => t.Parent.Id == game.GetWinner().Id).First()).Stats.Wins++;
                    ((SeasonTeam)Teams.Where(t => t.Parent.Id == game.GetLoser().Id).First()).Stats.Loses++;
                }

                home.Stats.GoalsFor += game.HomeScore;
                home.Stats.GoalsAgainst += game.AwayScore;
                away.Stats.GoalsFor += game.AwayScore;
                away.Stats.GoalsAgainst += game.HomeScore;

                game.Processed = true;
            }

            return new List<ScheduleGame>();
        }

        public override void ProcessEndOfCompetitionDetails(int endingDay)
        {
            SortAllTeams();            
            EndDay = endingDay;
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
        //todo must make sure this doesn't create duplicate records
        public virtual void SortTeamByDivision(string divisionName)
        {
            var division = GetDivisionByName(divisionName);

            var listOfTeams = GetAllTeamsInDivision(division);

            listOfTeams.Sort((a, b) => -1 * a.CompareTo(b)); // descending sort

            int rank = 1;            

            listOfTeams.ForEach(team =>
            {
                var ranking = Rankings.Where(r => r.GroupName == division.Name && (r.CompetitionTeam.Id == team.Id) && division.Level == r.GroupLevel).FirstOrDefault();
                if (ranking == null)
                {
                    Rankings.Add(new TeamRanking(rank, division.Name, team, division.Level));
                }
                else
                    ranking.Rank = rank;

                rank++;
            });
        }       

        public override bool AreGamesComplete()
        {
            if (Schedule == null)
            {
                SetupSchedule();
            }
            return Schedule.IsComplete();            
        }

        public override List<TeamRanking> GetFinalRankings()
        {
            var finalGroupName = CompetitionConfig.FinalRankingGroupName;

            var currentFinalRankings = Rankings.Where(r => r.GroupName.Equals(finalGroupName)).ToList();

            if (currentFinalRankings.Count > 0) return currentFinalRankings;
            else
            {
                var finalRankings = new List<TeamRanking>();

                CompetitionConfig.FinalRankingRules.ToList().ForEach(rule =>
                {
                    var teams = rule.GetTeamsForRule(this);

                    var rank = rule.Rank;

                    teams.OrderBy(t => t.Rank).ToList().ForEach(t =>
                    {
                        var ranking = new TeamRanking((int)rank, finalGroupName, t.CompetitionTeam, 0);
                        finalRankings.Add(ranking);
                        rank++;
                    });

                });

                return finalRankings;
            }
        }
    }
}
