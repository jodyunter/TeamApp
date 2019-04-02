﻿using System;
using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain.Competitions.Playoffs;
using TeamApp.Domain.Competitions.Playoffs.Series;

namespace TeamApp.Domain.Competitions.Config.Playoffs
{
    public class PlayoffCompetitionConfig:CompetitionConfig
    {
        public virtual IEnumerable<PlayoffSeriesRule> SeriesRules { get; set; }
        public virtual IEnumerable<PlayoffRankingRule> RankingRules { get; set; }

        public PlayoffCompetitionConfig():base() { }

        public PlayoffCompetitionConfig(string name, League league, int order, int? startingDay, GameRules gameRules, int? firstYear, int? lastYear, List<PlayoffRankingRule> rankingRules, List<PlayoffSeriesRule> seriesRules, List<CompetitionConfig> parents)
            :base(name, league, order, startingDay, gameRules, parents, firstYear, lastYear)
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

        //todo put this in the parent?
        public virtual void CopyTeamsFromCompetition(Playoff playoff, Competition competition)
        {
            if (playoff.Teams == null) playoff.Teams = new List<SingleYearTeam>();

            competition.Teams.ToList().ForEach(sourceTeam =>
            {
                //does the team already exist?
                var team = playoff.Teams.Where(t => t.Parent.Id == sourceTeam.Parent.Id).FirstOrDefault();                                        
                if (team == null) team = CreateCompetitionTeam(playoff, sourceTeam);
                playoff.Teams.Add(team);
            });
        }
        //put this is in the parent?
        //what if we have two parent competitions, and therefore end up copying this twice?
        public virtual void CopyRankingsFromCompetition(Playoff playoff, Competition competition)
        {
            if (playoff.Rankings == null) playoff.Rankings = new List<TeamRanking>();

            competition.Rankings.ToList().ForEach(sourceRanking =>
            {
                var team = playoff.Teams.Where(t => t.Parent.Id == sourceRanking.Team.Parent.Id).First(); //if null we messed up
                playoff.Rankings.Add(new TeamRanking(sourceRanking.Rank, sourceRanking.GroupName, team, sourceRanking.GroupLevel));
            });
            
        }

        //todo have this as an implementation of an abstracat method
        private PlayoffTeam CreateCompetitionTeam(Playoff playoff, SingleYearTeam sourceTeam)
        {
            return new PlayoffTeam(playoff, sourceTeam.Parent, sourceTeam.Name, sourceTeam.NickName, sourceTeam.ShortName,
                        sourceTeam.Skill, sourceTeam.Owner, playoff.Year);
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
                if (team == null) team = CreateCompetitionTeam(playoff, sourceRanking.Team);
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
                        return (PlayoffTeam)ranking.Team;                        
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