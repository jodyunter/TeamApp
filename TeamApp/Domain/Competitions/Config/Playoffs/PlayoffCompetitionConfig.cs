using System;
using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain.Games;
using TeamApp.Domain.Competitions.Playoffs;
using TeamApp.Domain.Competitions.Playoffs.Series;

namespace TeamApp.Domain.Competitions.Config.Playoffs
{
    public class PlayoffCompetitionConfig:CompetitionConfig
    {
        public virtual IEnumerable<PlayoffSeriesRule> SeriesRules { get; set; }
        public virtual IEnumerable<PlayoffRankingRule> RankingRules { get; set; }

        public PlayoffCompetitionConfig():base() { }

        public PlayoffCompetitionConfig(string name, League league, int order, int? startingDay, GameRules gameRules, int? firstYear, int? lastYear, List<PlayoffRankingRule> rankingRules, List<PlayoffSeriesRule> seriesRules, List<CompetitionConfig> parents, List<CompetitionConfigFinalRankingRule> finalRankingRules)
            :base(name, league, order, startingDay, gameRules, parents, finalRankingRules, "Final Standings", firstYear, lastYear)            
        {
            RankingRules = rankingRules;
            if (RankingRules != null)
                RankingRules.ToList().ForEach(r => r.PlayoffConfig = this);
            SeriesRules = seriesRules;
            if (SeriesRules != null)
                SeriesRules.ToList().ForEach(sr => sr.PlayoffConfig = this);
        }


        public virtual IEnumerable<PlayoffSeriesRule> GetActiveSeriesRules(int year)
        {
            return SeriesRules.Where(sr => sr.IsActive(year));
        }

        public virtual IEnumerable<PlayoffRankingRule> GetActiveRankingRules(int year)
        {
            return RankingRules.Where(rr => rr.IsActive(year));
        }
        public override Competition CreateCompetitionDetails(int day, int year, IList<Competition> parents)
        {
            var playoff = new Playoff(this, Name, year, 1, null, null, null, null, false, false, day, null);

            ProcessRankingRulesAndAddTeams(playoff, parents);            

            ProcessSeriesRules(playoff);

            if (parents != null) //assume shared schedule
                playoff.Schedule = parents[0].Schedule;

            playoff.BeginRound(day);

            playoff.StartDay = day;

            return playoff;
        }

        //need to test out the time period
        public virtual void ProcessSeriesRules(Playoff playoff)
        {
            playoff.Series = new List<PlayoffSeries>();

            GetActiveSeriesRules(playoff.Year).ToList().ForEach(rule =>
            {
                playoff.Series.Add(SetupSeriesFromRule(playoff, rule));
            });
        }
      
        
        public override SingleYearTeam CreateCompetitionTeam(Competition playoff, Team parent)
        {
            return new PlayoffTeam(playoff, parent, parent.Name, parent.NickName, parent.ShortName,
                        parent.Skill, parent.Owner, playoff.Year);
        }

        public virtual void CreateRankingsFromRule(Playoff playoff, PlayoffRankingRule rule)
        {
            if (!rule.IsActive(playoff.Year)) throw new Exception("Trying to use an inactive rule in CreatRankings From rule: " + rule.FirstYear + " : " + rule.LastYear);

            if (playoff.Rankings == null) playoff.Rankings = new List<TeamRanking>();
            if (playoff.Teams == null) playoff.Teams = new List<SingleYearTeam>();

            var groupToPutTeamIn = rule.GroupName;
            var groupToGetTeamFrom = rule.SourceGroupName;
            int firstRankToGet = rule.SourceFirstRank;
            int? lastRankToGet = rule.SourceLastRank;

            var newRankings = new List<TeamRanking>();

            var groupToGetRankFrom = rule.RankingGroupName;

            var groupOfTeams = playoff.Rankings.Where(rank => rank.GroupName.Equals(groupToGetTeamFrom)).ToList();
            if (lastRankToGet == null) lastRankToGet = groupOfTeams.Max(r => r.Rank);

            var sourceTeamRankings = groupOfTeams.Where(rank => rank.Rank >= firstRankToGet && rank.Rank <= lastRankToGet).ToList();

            sourceTeamRankings.ForEach(sourceRanking =>
            {
                var team = playoff.Teams.Where(t => t.Parent.Id == sourceRanking.Team.Parent.Id).FirstOrDefault();
                if (team == null) team = CreateCompetitionTeam(playoff, sourceRanking.Team.Parent);
                var rank = playoff.Rankings.Where(r => r.GroupName.Equals(groupToGetRankFrom) && r.Team.Parent.Id == team.Parent.Id).First().Rank;

                newRankings.Add(new TeamRanking(rank, groupToPutTeamIn, team, 1));
            });
            
            if (rule.DestinationFirstRank != null)
            {
                var startingRank = rule.DestinationFirstRank;

                newRankings = newRankings.OrderBy(a => a.Rank).ToList();

                int start = (int)startingRank;

                newRankings.ForEach(newRank =>
                {
                    newRank.Rank = start;
                    start++;                    
                });
            }

            newRankings.ForEach(newRank =>
            {
                playoff.Rankings.Add(newRank);
            });

        }
        
        //need to  test out the time period
        public virtual void ProcessRankingRulesAndAddTeams(Playoff playoff, IList<Competition> parents)
        {
            //setup rankings based on each competition to use later on in the series
            if (parents != null)
            {
                parents.ToList().ForEach(comp =>
                {
                    CopyTeamsFromCompetition(playoff, comp);
                    CopyRankingsFromCompetition(playoff, comp);
                });
            }

            ProcessRankingRules(playoff);
       
        }

        public virtual void ProcessRankingRules(Playoff playoff)
        {
            var activeRankingRules = GetActiveRankingRules(playoff.Year);
            var levels = activeRankingRules.Select(a => a.GroupSetupLevel).Distinct().ToList();
            levels.Sort();

            levels.ForEach(level =>
            {
                activeRankingRules.Where(arr => arr.GroupSetupLevel == level).ToList().ForEach(rule =>
                {
                    CreateRankingsFromRule(playoff, rule);
                });

                playoff.SeedRankingsGroups();
            });
        }

        public virtual PlayoffSeries SetupSeriesFromRule(Playoff playoff, PlayoffSeriesRule rule)
        {
            var homeTeam = GetTeamByRule(playoff, rule.HomeFromName, rule.HomeFromValue);
            var awayTeam = GetTeamByRule(playoff, rule.AwayFromName, rule.AwayFromValue);

            var series = SetupSeries(playoff, rule.SeriesType, rule.Name, rule.Round, -1, homeTeam, awayTeam, rule.SeriesNumber, rule.HomeGameProgression);

            return series;
        }

        public virtual PlayoffSeries SetupSeries(Playoff playoff, PlayoffSeriesRule.Type seriesType, string name, int round, int startingDay, PlayoffTeam homeTeam, PlayoffTeam awayTeam,
            int seriesNumber, int[] homeGameProgression)
        {       //if it is not setup, create it
            switch (seriesType)
            {
                case PlayoffSeriesRule.Type.BestOf:
                    return new BestOfSeries(playoff, name, round, startingDay, homeTeam, awayTeam, 0, 0, seriesNumber, new List<PlayoffGame>(), homeGameProgression);
                case PlayoffSeriesRule.Type.TotalGoals:
                    return new TotalGoalsSeries(playoff, name, round, startingDay, homeTeam, awayTeam, 0, 0, seriesNumber, 0, new List<PlayoffGame>(), homeGameProgression);                    
                default:
                    throw new ApplicationException("Bad series type from Playoff Series rule: " + seriesType);
            }
        }

        public virtual PlayoffTeam GetTeamByRule(Playoff playoff, string fromName, int fromValue)
        {
            var rankingsForGroup = playoff.Rankings.Where(r => r.GroupName == fromName).ToList();
            if (rankingsForGroup.Count > 0)
            {
                var ranking = rankingsForGroup.Where(r => r.Rank == fromValue).ToList().First();
                return (PlayoffTeam)ranking.Team;
            }
            return null;
        }

    }
}
