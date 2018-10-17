using System;
using System.Collections.Generic;
using TeamApp.Domain.Schedules;
using System.Linq;
using TeamApp.Domain.Competition.Playoffs.Config;
using TeamApp.Domain.Competition.Playoffs.Series;

namespace TeamApp.Domain.Competition.Playoffs
{
    public class Playoff : ICompetition
    {
        public ICompetitionConfig CompetitionConfig { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int StartingDay { get; set; }
        public int CurrentRound { get; set; }
        public List<PlayoffSeries> Series { get; set; }
        public Schedule Schedule { get; set; }
        public Dictionary<string, List<TeamRanking>> Rankings { get; set; }
        public List<ISingleYearTeam> Teams { get; set; }

        public Playoff(ICompetitionConfig competitionConfig, string name, int year, int startingDay, int currentRound, List<PlayoffSeries> series, List<ISingleYearTeam> teams, Schedule schedule, Dictionary<string, List<TeamRanking>> rankings)
        {
            CompetitionConfig = competitionConfig;
            StartingDay = startingDay;
            Name = name;
            Year = year;
            Series = series;
            Schedule = schedule;
            Rankings = rankings;
            Teams = teams;
            CurrentRound = currentRound;
        }

        public void BeginRound()
        {
            if (IsRoundComplete(CurrentRound)) CurrentRound++;

            var playoffConfig = (PlayoffCompetitionConfig)CompetitionConfig;

            int roundStartDay = Schedule.Days.Max(m => m.Value.DayNumber) + 1;
            //add any missing teams, and setup the games for each series
            Series.Where(s => s.Round == CurrentRound).ToList().ForEach(s =>
            {                
                //teams that relied on the previous round may still need their team
                if (s.HomeTeam == null)
                {
                    var rule = playoffConfig.SeriesRules.Where(sr => sr.Name.Equals(s.Name)).FirstOrDefault();
                    s.HomeTeam = playoffConfig.GetTeamByRule(this, rule.HomeFromType, rule.HomeFromName, rule.HomeFromValue);
                }

                if (s.AwayTeam == null)
                {
                    var rule = playoffConfig.SeriesRules.Where(sr => sr.Name.Equals(s.Name)).FirstOrDefault();
                    s.AwayTeam = playoffConfig.GetTeamByRule(this, rule.AwayFromType, rule.AwayFromName, rule.AwayFromValue);
                }
                SetupSeriesGames(s);
            });

        }

        public void SetupSeriesGames(PlayoffSeries series)
        {
            var newGames = series.CreateNeededGamesForSeries();

            Scheduler.AddGamesToSchedule(Schedule, newGames.ToList<ScheduleGame>(), series.StartingDay > 0 ? series.StartingDay: StartingDay);
        }

        public void AddSeries(PlayoffSeries series)
        {
            if (Series == null) Series = new List<PlayoffSeries>();

            Series.Add(series);
        }

        public void ProcessGame(ScheduleGame game)
        {
            var gameCompetition = game.Competition;

            if (!(gameCompetition.Name.Equals(Name)) || !(gameCompetition.Year.Equals(Year)) || !(game is PlayoffGame))
            {
                throw new ApplicationException("Trying to process game with the wrong competition.");
            }

            var playoffGame = (PlayoffGame)game;

            playoffGame.Series.ProcessSeriesGame(playoffGame);
            SetupSeriesGames(playoffGame.Series);
            
        }

        public bool IsRoundComplete(int round)
        {
            var complete = true;

            var playoffConfig = (PlayoffCompetitionConfig)CompetitionConfig;

            //get all rules for this orund
            var seriesRulesList = playoffConfig.SeriesRules.Where(sr => sr.Round == round).ToList();

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

        public bool IsComplete()
        {
            var complete = true;
            var playoffConfig = (PlayoffCompetitionConfig)CompetitionConfig;

            for (int i = 0; i < playoffConfig.SeriesRules.Count; i++)
            {
                complete = complete && IsRoundComplete(playoffConfig.SeriesRules[i].Round);
            }

            return complete;
        }
        
    }
}
