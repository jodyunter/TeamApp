using System;
using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain.Competitions.Playoffs.Series;
using TeamApp.Domain.Schedules;

namespace TeamApp.Domain.Competitions.Playoffs.Config
{
    public class PlayoffCompetitionConfig:CompetitionConfig
    {
        public virtual IList<PlayoffSeriesRule> SeriesRules { get; set; }
        public virtual IList<PlayoffRankingRule> Rankings { get; set; }

        public PlayoffCompetitionConfig():base() { }

        public PlayoffCompetitionConfig(string name, League league, int order, GameRules gameRules, int? firstYear, int? lastYear, List<PlayoffRankingRule> rankings, List<PlayoffSeriesRule> seriesRules, List<CompetitionConfig> parents)
            :base(name, league, order, gameRules, parents, firstYear, lastYear)
        {
            Rankings = rankings;
            if (Rankings != null)
                Rankings.ToList().ForEach(r => r.PlayoffConfig = this);
            SeriesRules = seriesRules;
            if (SeriesRules != null)
                SeriesRules.ToList().ForEach(sr => sr.PlayoffConfig = this);
        }

        public override Competition CreateCompetition(int year, List<Competition> parents)
        {
            var playoff = new Playoff(this, Name, year, -1, 1, null, null, null, null);

            ProcessRankingRulesAndAddTeams(playoff, parents);
            ProcessSeries(playoff);

            if (parents != null) //assume shared schedule
                playoff.Schedule = parents[0].Schedule;

            playoff.BeginRound();

            return playoff;
        }

        public virtual void ProcessSeries(Playoff playoff)
        {
            playoff.Series = new List<PlayoffSeries>();

            SeriesRules.ToList().ForEach(rule =>
            {
                playoff.Series.Add(SetupSeriesFromRule(playoff, rule));
            });
        }

        public virtual void ProcessRankingRulesAndAddTeams(Playoff playoff, List<Competition> parents)
        {
            playoff.Teams = new List<SingleYearTeam>();
            playoff.Rankings = new List<TeamRanking>();

            Rankings.ToList().ForEach(rule =>
            {
                //get the competition
                var sourceCompetition = parents.Where(p => p.Name.Equals(rule.SourceCompetition.Name)).FirstOrDefault(); //this is the source competition

                if (sourceCompetition == null) throw new ApplicationException("Playoff Ranking Rule has bad source competition: " + rule.SourceCompetition.Name);

                //get the group with the rankings
                var sourceGroup = sourceCompetition.Rankings.Where(r => r.GroupName == rule.SourceGroupName).ToList();                

                if (sourceGroup == null) throw new ApplicationException("Playoff Ranking Rule has bad source group name: " + rule.SourceGroupName);

                int firstRank = rule.StartingRank;

                int nextRank = firstRank;

                for (int i = rule.SourceFirstRank; i <= rule.SourceLastRank; i++)
                {
                    var sourceRanking = sourceGroup.Where(r => r.Rank == i).FirstOrDefault();

                    if (sourceRanking == null) throw new ApplicationException("Playoff Source Rank did not exist: " + rule.SourceCompetition.Name + " " + rule.SourceGroupName + " rank: " + i);

                    var sourceTeam = sourceRanking.Team;

                    var newTeam = new PlayoffTeam(playoff, sourceTeam.Parent, sourceTeam.Name, sourceTeam.NickName, sourceTeam.ShortName, sourceTeam.Skill, sourceTeam.Owner, playoff.Year);                    

                    var playoffRanking = new TeamRanking(nextRank, rule.GroupName, newTeam);

                    playoff.Rankings.Add(playoffRanking);

                    playoff.Teams.Add(newTeam);

                    nextRank++;
                }
                
            });
        }

        public virtual PlayoffSeries SetupSeriesFromRule(Playoff playoff, PlayoffSeriesRule rule)
        {
            var homeTeam = GetTeamByRule(playoff, rule.HomeFromType, rule.HomeFromName, rule.HomeFromValue);
            var awayTeam = GetTeamByRule(playoff, rule.AwayFromType, rule.AwayFromName, rule.AwayFromValue);

            var series = SetupSeries(playoff, rule.SeriesType, rule.Name, rule.Round, -1, homeTeam, awayTeam, rule.SeriesNumber, rule.HomeGameProgression);

            return series;
        }

        public virtual PlayoffSeries SetupSeries(Playoff playoff, int seriesType, string name, int round, int startingDay, PlayoffTeam homeTeam, PlayoffTeam awayTeam,
            int seriesNumber, int[] homeGameProgression)
        {       //if it is not setup, create it
            switch (seriesType)
            {
                case PlayoffSeriesRule.BEST_OF_SERIES:
                    return new BestOfSeries(playoff, name, round, startingDay, homeTeam, awayTeam, 0, 0, seriesNumber, new List<PlayoffGame>(), homeGameProgression);
                case PlayoffSeriesRule.TOTAL_GOALS:
                    return new TotalGoalsSeries(playoff, name, round, startingDay, homeTeam, awayTeam, 0, 0, seriesNumber, 0, new List<PlayoffGame>(), homeGameProgression);                    
                default:
                    throw new ApplicationException("Bad series type from Playoff Series rule: " + seriesType);
            }
        }

        public virtual PlayoffTeam GetTeamByRule(Playoff playoff, int fromType, string fromName, int fromValue)
        {
            switch (fromType)
            {                
                case PlayoffSeriesRule.FROM_RANKING:
                    var rankingsForGroup = playoff.Rankings.Where(r => r.GroupName == fromName).ToList();
                    if (rankingsForGroup.Count > 0)
                    {
                        var ranking = rankingsForGroup.Where(r => r.Rank == fromValue).ToList().First();
                        return new PlayoffTeam(playoff, ranking.Team.Parent, ranking.Team.Name, ranking.Team.NickName, ranking.Team.ShortName, ranking.Team.Skill, ranking.Team.Owner, playoff.Year);
                    }
                    return null;
                case PlayoffSeriesRule.FROM_SERIES:
                    var series = playoff.Series.Where(s => s.Name.Equals(fromName)).FirstOrDefault();
                    switch (fromValue)
                    {
                        case PlayoffSeriesRule.GET_WINNER:
                            return series == null ? null : series.GetWinner();
                        case PlayoffSeriesRule.GET_LOSER:
                            return series == null ? null : series.GetLoser();
                        default:
                            throw new ApplicationException("Bad From value in Playoff series rule: " + fromValue);

                    }
                default:
                    throw new ApplicationException("Bad From Team Type in Playoff Series Rule: " + fromType);
            }
        }

    }
}
