using System;
using System.Collections.Generic;
using TeamApp.Domain.Competitions.Seasons.Config;
using TeamApp.Domain.Schedules;
using TeamApp.Test.Helpers;
using static System.Console;
using System.Linq;
using TeamApp.Console.Views.Season;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Competitions.Seasons;
using TeamApp.Domain.Competitions.Playoffs;
using TeamApp.Domain.Competitions.Playoffs.Series;
using TeamApp.Domain.Competitions.Playoffs.Config;
using TeamApp.Data.NHibernate.Repositories;
using TeamApp.Domain.Repositories;
using TeamApp.Domain;

namespace TeamApp.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var league = Data2.CreateBasicLeague("NHL");
            var seasonCompetition = Data2.CreateBasicSeasonConfiguration(league);
            var playoffConfig = Data2.CreateBasicPlayoffConfiguration(seasonCompetition);

            var season = (Season)seasonCompetition.CreateCompetition(1, null);
            
            WriteLine("Validating Schedule based on config.");
            var seasonScheduleConfigValidator = new SeasonConfigScheduleValidator(seasonCompetition);
            WriteLine("Printing Values for Schedule based on config.");
 

            seasonScheduleConfigValidator.GameCounts.Keys.Where(k => !k.Contains(":")).ToList().ForEach(key =>
            {
                WriteLine(key + " : " + seasonScheduleConfigValidator.GameCounts[key]);
            });
            ReadLine();            

            var scheduleValidator = new ScheduleValidator(season.Schedule);

            if (!scheduleValidator.IsValid)
            {
                scheduleValidator.ErrorMessages.ForEach(s =>
                {
                    WriteLine(s);
                });
            }
            //Random r = new Random(12345);
            Random r = new Random();

            while (!season.Schedule.IsComplete())
                season.PlayNextDay(r);
            
            season.SortAllTeams();

            season.Divisions.Where(d => d.Level < 4).OrderBy(d => d.Level).ThenBy(d => d.Ordering).ToList().ForEach(div =>
            {
                WriteLine(div.Name);
                WriteLine(SeasonTeamStatsView.GetHeader());
                season.Rankings.Where(t => t.GroupName.Equals(div.Name)).OrderBy(d => d.Rank).ToList().ForEach(ranking =>
                {
                    WriteLine(new SeasonTeamStatsView(ranking).GetView());
                });

                WriteLine("\n");
            });

            var playoff = (Playoff)playoffConfig.CreateCompetition(1, new List<Competition> { season });
            playoff.Schedule = season.Schedule;

            while (!playoff.IsComplete())
            {
                playoff.BeginRound();
                while (!playoff.IsRoundComplete(playoff.CurrentRound))
                {
                    var games = playoff.PlayNextDay(r);                    
                }

                playoff.Series.Where(s => s.Round == playoff.CurrentRound).ToList().ForEach(st =>
                {
                    var homeValue = 0;
                    var awayValue = 0;

                    if (st is BestOfSeries)
                    {
                        homeValue = ((BestOfSeries)st).HomeWins;
                        awayValue = ((BestOfSeries)st).AwayWins;
                    }
                    else if (st is TotalGoalsSeries)
                    {
                        homeValue = ((TotalGoalsSeries)st).HomeScore;
                        awayValue = ((TotalGoalsSeries)st).AwayScore;
                    }

                    var formatter = "{0,3}. {1,10}{2,15}{3,5} - {4,5}{5,15}";
                    var result = string.Format(formatter, st.Round, st.Name, st.HomeTeam.Name, homeValue, awayValue, st.AwayTeam.Name);
                    WriteLine(result);
                });
            }
            
            WriteLine("Press Enter to continue");
            ReadLine();

        }
    }
}
