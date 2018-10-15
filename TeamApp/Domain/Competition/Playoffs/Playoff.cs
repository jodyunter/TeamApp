﻿using System;
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
        public List<TeamRanking> Rankings { get; set; }

        public Playoff(ICompetitionConfig competitionConfig, string name, int year, int startingDay, int currentRound, List<PlayoffSeries> series, Schedule schedule, List<TeamRanking> rankings)
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

                playoffConfig.SeriesRules.Where(sr => sr.Round == CurrentRound).ToList().ForEach(sr => { Series.Add(CreateSeriesFromRule(sr)); });

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
            return Series.Where(s => s.Round == roundNumber).Count() > 0;
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

            Series.Where(s => s.Round == round).ToList().ForEach(series =>
            {
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

        public PlayoffSeries CreateSeriesFromRule(PlayoffSeriesRule rule)
        {
            var homeTeam = GetTeamByRule(rule.HomeFromType, rule.HomeFromName, rule.HomeFromValue);
            var awayTeam = GetTeamByRule(rule.AwayFromType, rule.AwayFromName, rule.AwayFromValue);

            var series = CreateSeries(rule.SeriesType, rule.Name, rule.Round, -1, homeTeam, awayTeam, rule.SeriesNumber, rule.HomeGameProgression);

            return series;
        }        
        
        public PlayoffSeries CreateSeries(int seriesType, string name, int round, int startingDay, PlayoffTeam homeTeam, PlayoffTeam awayTeam,
            int seriesNumber, int[] homeGameProgression)
        {
            switch(seriesType)
            {
                case PlayoffSeriesRule.BEST_OF_SERIES:
                    return new BestOfSeries(this, name, round, startingDay, homeTeam, awayTeam, 0, 0, seriesNumber, new List<PlayoffGame>(), homeGameProgression);
                case PlayoffSeriesRule.TOTAL_GOALS:
                    return new TotalGoalsSeries(this, name, round, startingDay, homeTeam, awayTeam, 0, 0, seriesNumber, 0, new List<PlayoffGame>(), homeGameProgression);                    
                default:
                    throw new ApplicationException("Bad series type from Playoff Series rule: " + seriesType);
            }
        }
        public PlayoffTeam GetTeamByRule(int fromType, string fromName, int fromValue)
        {
            switch (fromType)
            {
                case PlayoffSeriesRule.FROM_RANKING:
                    var ranking = Rankings.Where(r => r.Group == fromName && r.Rank == fromValue).ToList().First();
                    return new PlayoffTeam(ranking.Team.Name, ranking.Team.Skill, this, ranking.Team.Parent, ranking.Team.Owner, Year);                    
                case PlayoffSeriesRule.FROM_SERIES:
                    var series = Series.Where(s => s.Name.Equals(fromName)).FirstOrDefault();
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
