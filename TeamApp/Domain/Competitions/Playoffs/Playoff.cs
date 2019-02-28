using System;
using System.Collections.Generic;
using TeamApp.Domain.Schedules;
using System.Linq;
using TeamApp.Domain.Competitions.Playoffs.Config;
using TeamApp.Domain.Competitions.Playoffs.Series;

namespace TeamApp.Domain.Competitions.Playoffs
{
    public class Playoff : Competition
    {        
        public virtual int CurrentRound { get; set; }
        public virtual IList<PlayoffSeries> Series { get; set; }

        public Playoff() : base() { }

        public Playoff(CompetitionConfig competitionConfig, string name, int year, int currentRound, List<PlayoffSeries> series, List<SingleYearTeam> teams, Schedule schedule, IList<TeamRanking> rankings, bool started, bool finished, int? startDay, int? endDay)
            :base(competitionConfig, name, year, schedule, rankings, teams, started, finished, startDay, endDay)
        {                        
            Series = series;
            Teams = teams;
            CurrentRound = currentRound;
        }

        public override void ProcessEndOfCompetitionDetails(int endingDay)
        {
            //nothing to do for end of series at this point in time
        }

        public virtual void BeginRound()
        {
            Started = true;

            if (IsRoundComplete(CurrentRound)) CurrentRound++;
            //else return;

            var playoffConfig = (PlayoffCompetitionConfig)CompetitionConfig;

            int roundStartDay = Schedule.Days.Max(m => m.Value.DayNumber) + 1;

            //sort all rankings starting at one.  At the end of each round, each group is assigned a ranking based on other criteria.
            //we need to sort based on that and assign the values accordingly.


            var rankingsDictionary = new Dictionary<string, List<TeamRanking>>();

            Rankings.ToList().ForEach(ranking =>
            {
                if (!rankingsDictionary.ContainsKey(ranking.GroupName)) rankingsDictionary.Add(ranking.GroupName, new List<TeamRanking>());

                rankingsDictionary[ranking.GroupName].Add(ranking);
            });

            rankingsDictionary.Keys.ToList().ForEach(key =>
            {
                rankingsDictionary[key].Sort((a, b) => a.Rank.CompareTo(b.Rank));
                int m = 0;

                rankingsDictionary[key].ForEach(value =>
                {
                    m++;
                    value.Rank = m;
                });
            });

            //add any missing teams, and setup the games for each series
            Series.Where(s => s.Round == CurrentRound).ToList().ForEach(s =>
            {
                var activeSeriesList = playoffConfig.GetActiveSeriesRules(Year);
                //teams that relied on the previous round may still need their team
                if (s.HomeTeam == null)
                {
                    var rule = activeSeriesList.Where(sr => sr.Name.Equals(s.Name)).FirstOrDefault();
                    s.HomeTeam = playoffConfig.GetTeamByRule(this, rule.HomeFromType, rule.HomeFromName, rule.HomeFromValue);
                }

                if (s.AwayTeam == null)
                {
                    var rule = activeSeriesList.Where(sr => sr.Name.Equals(s.Name)).FirstOrDefault();
                    s.AwayTeam = playoffConfig.GetTeamByRule(this, rule.AwayFromType, rule.AwayFromName, rule.AwayFromValue);
                }
                SetupSeriesGames(s);
            });

        }

        public virtual void SetupSeriesGames(PlayoffSeries series)
        {
            var newGames = series.CreateNeededGamesForSeries();

            if (StartDay == null) throw new Exception("Start day cannot be null when we create series games.");
            var start = (int)StartDay;
            Scheduler.AddGamesToSchedule(Schedule, newGames.ToList<ScheduleGame>(), series.StartingDay > 0 ? series.StartingDay: start);
        }

        public virtual void AddSeries(PlayoffSeries series)
        {
            if (Series == null) Series = new List<PlayoffSeries>();

            Series.Add(series);
        }

        public override void ProcessGame(ScheduleGame game)
        {
            var gameCompetition = game.Competition;

            if (!(gameCompetition.Name.Equals(Name)) || !(gameCompetition.Year.Equals(Year)) || !(game is PlayoffGame))
            {
                throw new ApplicationException("Trying to process game with the wrong competition.");
            }

            var playoffGame = (PlayoffGame)game;

            playoffGame.Series.ProcessSeriesGame(playoffGame);
            if (playoffGame.Series.IsComplete())
            {
                //process end of series
                ProcessEndOfSeries(playoffGame.Series);
            }

            if (IsRoundComplete(CurrentRound))
                BeginRound();

            SetupSeriesGames(playoffGame.Series);
            
        }

        public virtual void ProcessEndOfSeries(PlayoffSeries series)
        {
            var playoffConfig = (PlayoffCompetitionConfig)CompetitionConfig;

            var seriesRule = playoffConfig.GetActiveSeriesRules(Year).Where(s => s.Name.Equals(series.Name)).First();
            
            ProcessEndOfSeriesTeam(seriesRule.WinnerGroupName, seriesRule.WinnerRankFrom, series.GetWinner());
            ProcessEndOfSeriesTeam(seriesRule.LoserGroupName, seriesRule.LoserRankFrom, series.GetLoser());
        }

        public virtual void ProcessEndOfSeriesTeam(string newGroupName, string rankSourceGroupName, PlayoffTeam team)
        {
            if (newGroupName != null)
            {                
                if (rankSourceGroupName == null) throw new ApplicationException("Can't have a null winner rank from.");

                var rank = Rankings.Where(r => r.GroupName == rankSourceGroupName && r.Team.Name.Equals(team.Name)).First().Rank;                

                Rankings.Add(new TeamRanking(rank, newGroupName, team, 1));
            }
        }
        public virtual bool IsRoundComplete(int round)
        {
            var complete = true;

            var playoffConfig = (PlayoffCompetitionConfig)CompetitionConfig;

            //get all rules for this orund
            var seriesRulesList = playoffConfig.GetActiveSeriesRules(Year).Where(sr => sr.Round == round).ToList();

            //if no rules, then it is complete
            if (seriesRulesList.Count == 0) return true;

            //for each series rule, check to see if the series exists and if it does, is it complete?
            seriesRulesList.ForEach(sr =>
            {
                var series = Series.Where(s => s.Name == sr.Name).FirstOrDefault();
                
                complete = complete && series.IsComplete();
            });

            return complete;
        }

        public override bool AreGamesComplete()
        {
            var complete = true;
            var playoffConfig = (PlayoffCompetitionConfig)CompetitionConfig;

            var activeSeries = playoffConfig.GetActiveSeriesRules(Year).ToList();

            for (int i = 0; i < activeSeries.Count; i++)
            {
                complete = complete && IsRoundComplete(activeSeries[i].Round);
            }

            return complete;
        }
        
    }
}
