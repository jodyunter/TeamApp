using System;
using System.Collections.Generic;
using TeamApp.Domain.Schedules;
using System.Linq;

namespace TeamApp.Domain.Competition.Playoffs
{
    public class Playoff : ICompetition
    {
        public ICompetitionConfig CompetitionConfig { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int StartingDay { get; set; }
        public List<PlayoffSeries> Series { get; set; }
        public Schedule Schedule { get; set; }
        public Dictionary<string, TeamRanking> Rankings { get; set; }

        public Playoff(ICompetitionConfig competitionConfig, string name, int year, int startingDay, List<PlayoffSeries> series, Schedule schedule, Dictionary<string, TeamRanking> rankings)
        {
            CompetitionConfig = competitionConfig;
            StartingDay = startingDay;
            Name = name;
            Year = year;
            Series = series;
            Schedule = schedule;
            Rankings = rankings;
        }

        public void Setup()
        {            
            //todo series starting days
            Series.ForEach(s => { Scheduler.AddGamesToSchedule(Schedule, s.CreateNeededGamesForSeries().ToList<ScheduleGame>(), StartingDay); });
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

    }
}
