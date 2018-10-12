using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Scheduler;
using System.Linq;

namespace TeamApp.Domain.Competition.Playoffs
{
    public class Playoff : ICompetition
    {
        public ICompetitionConfig CompetitionConfig { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public List<PlayoffSeries> Series { get; set; }
        public Schedule Schedule { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Dictionary<string, TeamRanking> Rankings { get; set; }

        public void ProcessGame(ScheduleGame game)
        {
            var gameConfig = game.Competition;

            if (!(gameConfig.Name.Equals(Name)) || !(gameConfig.Year.Equals(Year)) || !(game is PlayoffGame))
            {
                throw new ApplicationException("Trying to process game with the wrong competition.");
            }

            var playoffGame = (PlayoffGame)game;

            

            throw new NotImplementedException();
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
