using System;
using System.Collections.Generic;
using TeamApp.Domain.Competition.Seasons.Config;
using TeamApp.Domain.Schedules;
using TeamApp.Services;
using TeamApp.Test.Helpers;
using static System.Console;
using System.Linq;
using TeamApp.Console.Views.Season;
using TeamApp.Domain.Competition;
using TeamApp.Domain.Competition.Seasons;
using TeamApp.Domain.Competition.Playoffs;
using TeamApp.Domain.Competition.Playoffs.Series;
using TeamApp.Domain.Competition.Playoffs.Config;

namespace TeamApp.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = Data1.CreateBasicSeasonConfiguration();
            
            var seasonCompetition = ((List<SeasonCompetitionConfig>)data[Data1.BASIC_SEASON_COMPETITION_LSIT])[0];

            var season = (Season)seasonCompetition.CreateCompetition(1, null);        

            /*var schedule = Scheduler.CreateGames(season.Parent.League, season.Year, 1, 1,
               season.GetAllTeamsInDivision(season.GetDivisionByName("NHL")).Select(t => t.Parent).ToList(),
                1, true, season.Parent.GameRules);

            season.Schedule = schedule; */

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

            WriteLine(SeasonTeamStatsView.GetHeader());

            season.SortAllTeams();

            season.Divisions.OrderBy(d => d.Level).ThenBy(d => d.Order).ToList().ForEach(div =>
            {
                WriteLine(div.Name);                
                season.Rankings[div.Name].OrderBy(d => d.Rank).ToList().ForEach(ranking =>
                {
                    WriteLine(new SeasonTeamStatsView(ranking).GetView());
                });

                WriteLine("\n");
            });

            var divName = "NHL";
            var teamName = "Calgary";

            var homGames = season.Schedule.GetHomeGamesVsTeams(teamName, season.GetAllTeamsInDivision(season.GetDivisionByName(divName)).Select(t => t.Name).ToList());
            var awayGames = season.Schedule.GetHomeGamesVsTeams(teamName, season.GetAllTeamsInDivision(season.GetDivisionByName(divName)).Select(t => t.Name).ToList());
            foreach (KeyValuePair<string, int> d in homGames)
            {
                WriteLine(d.Key + ": " + d.Value + " - " + awayGames[d.Key]);                
            }


            var playoffConfig = Data1.CreateBasicPlayoffConfiguration(seasonCompetition);

            var playoff = (Playoff)playoffConfig.CreateCompetition(1, new List<ICompetition> { season });
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
                    var series = (BestOfSeries)st;
                    WriteLine(series.HomeTeam.Name + " " + series.HomeWins + " - " + series.AwayWins + " " + series.AwayTeam.Name);
                });
            }
            
            WriteLine("Press Enter to continue");
            ReadLine();

        }
    }
}
