using System;
using System.Collections.Generic;
using TeamApp.Domain.Competition.Seasons.Config;
using TeamApp.Domain.Scheduler;
using TeamApp.Services;
using TeamApp.Test.Helpers;
using static System.Console;
using System.Linq;
using TeamApp.Console.Views.Season;

namespace TeamApp.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = Data1.CreateBasicSeasonConfiguration();

            var seasonService = new SeasonService();
            var seasonCompetition = ((List<SeasonCompetition>)data[Data1.BASIC_SEASON_COMPETITION_LSIT])[0];

            var season = seasonService.CreateNewSeason(seasonCompetition, "Season 1", 1);

            /*var schedule = Scheduler.CreateGames(season.Parent.League, season.Year, 1, 1,
               season.GetAllTeamsInDivision(season.GetDivisionByName("NHL")).Select(t => t.Parent).ToList(),
                1, true, season.Parent.GameRules);

            season.Schedule = schedule; */

            var scheduleValidator = new ScheduleValidator(season.Schedule);


            //Random r = new Random(12345);
            Random r = new Random();

            while (!season.Schedule.IsComplete())
                season.PlayNextDay(r);

            WriteLine(SeasonTeamStatsView.GetHeader());

            season.SortAllTeams();

            season.Divisions.OrderBy(d => d.Level).ThenBy(d => d.Order).ToList().ForEach(div =>
            {
                WriteLine(div.Name);
                WriteLine(SeasonTeamStatsView.GetHeader());

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

            WriteLine("Press Enter to continue");
            ReadLine();

        }
    }
}
