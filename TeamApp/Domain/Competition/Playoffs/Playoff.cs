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

        public Playoff(ICompetitionConfig competitionConfig, string name, int year, int startingDay, int currentRound, List<PlayoffSeries> series, Schedule schedule, Dictionary<string, List<TeamRanking>> rankings)
        {
            CompetitionConfig = competitionConfig;
            StartingDay = startingDay;
            Name = name;
            Year = year;
            Series = series;
            Schedule = schedule;
            Rankings = rankings;
            CurrentRound = currentRound;
        }

        public void SetupRound(int roundNumber)
        {
            if (!IsRoundSetup(roundNumber))
            {
                var playoffConfig = (PlayoffCompetitionConfig)CompetitionConfig;

                playoffConfig.SeriesRules.Where(sr => sr.Round == CurrentRound).ToList().ForEach(sr =>
                {
                    Series.Add(((PlayoffCompetitionConfig)CompetitionConfig).SetupSeriesFromRule(this, sr));
                });

                Series.Where(s => s.Round == roundNumber).ToList().ForEach(s =>
                {
                    SetupSeriesGames(s);
                });
            }
            else
                throw new ApplicationException("Round " + roundNumber + " is already setup");
        }

        public bool IsRoundSetup(int roundNumber)
        {
            return Series.Where(s => s.Round == roundNumber && s.HomeTeam != null && s.AwayTeam != null).Count() > 0;
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

                if (series == null) complete = false;
                else
                    complete = complete && series.IsComplete();
            });

            return complete;
        }

        public bool IsComplete()
        {
            var complete = true;

            Series.Select(s => s.Round).Distinct().ToList().ForEach(r =>
            {
                complete = complete && IsRoundComplete(r);
            });

            return complete;
        }
        
    }
}
