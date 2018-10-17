using System;
using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain.Competition.Playoffs.Series;

namespace TeamApp.Domain.Competition.Playoffs.Config
{
    public class PlayoffCompetitionConfig:ICompetitionConfig
    {
        public string Name { get; set; }
        public League League { get; set; }
        public int Order { get; set; }
        public GameRules GameRules { get; set; }
        public int? FirstYear { get; set; }
        public int? LastYear { get; set; }
        public List<PlayoffSeriesRule> SeriesRules { get; set; }
        public List<PlayoffRankingRule> Rankings { get; set; }
        public Dictionary<string, ICompetitionConfig> Parents { get; set; }      

        public PlayoffCompetitionConfig(string name, League league, int order, GameRules gameRules, int? firstYear, int? lastYear, List<PlayoffRankingRule> rankings, List<PlayoffSeriesRule> seriesRules, Dictionary<string, ICompetitionConfig> parents)
        {
            Name = name;
            League = league;
            Order = order;
            GameRules = gameRules;
            FirstYear = firstYear;
            LastYear = lastYear;
            Rankings = rankings;
            SeriesRules = seriesRules;
            Parents = parents;
        }

        public ICompetition CreateCompetition(int year, List<ICompetition> parents)
        {
            var playoff = new Playoff(this, Name, year, -1, 1, null, null, null);

            ProcessRankingRulesAndAddTeams(playoff, parents);
            
            throw new NotImplementedException();
        }

        public void ProcessRankingRulesAndAddTeams(Playoff playoff, List<ICompetition> parents)
        {
            Rankings.ForEach(rule =>
            {
                //get the competition
                var source = parents.Where(p => p.Name.Equals(rule.SourceCompetition.Name)).FirstOrDefault(); //this is the source competition

                if (source == null) throw new ApplicationException("Playoff Ranking Rule has bad source competition: " + rule.SourceCompetition.Name);

                var group = source.Rankings[rule.SourceGroupName];

                if (group == null) throw new ApplicationException("Playoff Ranking Rule has bad source group name: " + rule.SourceGroupName);

                int firstRank = rule.StartingRank;

                int nextRank = firstRank;

                for (int i = rule.SourceFirstRank; i <= rule.SourceLastRank; i++)
                {
                    var sourceRanking = group.Where(r => r.Rank == i).FirstOrDefault();

                    if (sourceRanking == null) throw new ApplicationException("Playoff Source Rank did not exist: " + rule.SourceCompetition.Name + " " + rule.SourceGroupName + " rank: " + i);

                    var sourceTeam = sourceRanking.Team;

                    var newTeam = new PlayoffTeam(sourceTeam.Name, sourceTeam.Skill, playoff, sourceTeam.Parent, sourceTeam.Owner, playoff.Year);

                    var playoffRanking = new TeamRanking(nextRank, rule.GroupName, newTeam);

                    playoff.Teams.Add(newTeam);

                    nextRank++;
                }
                
            });
        }

        public PlayoffSeries SetupSeriesFromRule(Playoff playoff, PlayoffSeriesRule rule)
        {
            var homeTeam = GetTeamByRule(playoff, rule.HomeFromType, rule.HomeFromName, rule.HomeFromValue);
            var awayTeam = GetTeamByRule(playoff, rule.AwayFromType, rule.AwayFromName, rule.AwayFromValue);

            var series = SetupSeries(playoff, rule.SeriesType, rule.Name, rule.Round, -1, homeTeam, awayTeam, rule.SeriesNumber, rule.HomeGameProgression);

            return series;
        }

        public PlayoffSeries SetupSeries(Playoff playoff, int seriesType, string name, int round, int startingDay, PlayoffTeam homeTeam, PlayoffTeam awayTeam,
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

        public PlayoffTeam GetTeamByRule(Playoff playoff, int fromType, string fromName, int fromValue)
        {
            switch (fromType)
            {
                case PlayoffSeriesRule.FROM_RANKING:
                    var ranking = playoff.Rankings[fromName].Where(r => r.Rank == fromValue).ToList().First();
                    return new PlayoffTeam(ranking.Team.Name, ranking.Team.Skill, playoff, ranking.Team.Parent, ranking.Team.Owner, playoff.Year);
                case PlayoffSeriesRule.FROM_SERIES:
                    var series = playoff.Series.Where(s => s.Name.Equals(fromName)).FirstOrDefault();
                    switch (fromValue)
                    {
                        case PlayoffSeriesRule.GET_WINNER:
                            return series.GetWinner();
                        case PlayoffSeriesRule.GET_LOSER:
                            return series.GetLoser();
                        default:
                            throw new ApplicationException("Bad From value in Playoff series rule: " + fromValue);

                    }
                default:
                    throw new ApplicationException("Bad From Team Type in Playoff Series Rule: " + fromType);
            }
        }

    }
}
