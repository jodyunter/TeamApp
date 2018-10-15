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

            var seasonService = new SeasonService();
            var seasonCompetition = ((List<SeasonCompetitionConfig>)data[Data1.BASIC_SEASON_COMPETITION_LSIT])[0];

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

            var nhlRankings = season.Rankings.Where(m => m.Key == "NHL").First().Value;

            var team1Parent = nhlRankings.Where(rank => rank.Rank == 1).First().Team;
            var team2Parent = nhlRankings.Where(rank => rank.Rank == 2).First().Team;

            var team3Parent = nhlRankings.Where(rank => rank.Rank == 3).First().Team;
            var team4Parent = nhlRankings.Where(rank => rank.Rank == 4).First().Team;

            var playoffConfig = new PlayoffCompetitionConfig("My Playoff", null, 2, new Domain.GameRules("My Rules", false, 3, 1, 7, 6), 1, null, null, null);
            var playoff = new Playoff(playoffConfig, "My Playoff", 1, 82, 1, null, season.Schedule, null);
            playoff.CompetitionConfig = playoffConfig;

            var team1 = new PlayoffTeam(team1Parent.Name, team1Parent.Skill, null, team1Parent.Parent, null, 1);
            var team2 = new PlayoffTeam(team2Parent.Name, team2Parent.Skill, null, team2Parent.Parent, null, 1);

            var team3 = new PlayoffTeam(team3Parent.Name, team3Parent.Skill, null, team3Parent.Parent, null, 1);
            var team4 = new PlayoffTeam(team4Parent.Name, team4Parent.Skill, null, team4Parent.Parent, null, 1);


            var series1 = new BestOfSeries(playoff, "Series 1", 1, -1, team1, team2, 0, 0, 4, new List<PlayoffGame>(), new int[] { 0, 0, 1, 1, 0, 1, 0 });
            var series2 = new BestOfSeries(playoff, "Series 2", 1, -1, team3, team4, 0, 0, 4, new List<PlayoffGame>(), new int[] { 0, 0, 1, 1, 0, 1, 0 });
            playoff.AddSeries(series1);
            playoff.AddSeries(series2);

            playoff.Setup();

            while (!playoff.IsComplete())
            {
                playoff.PlayNextDay(new Random()).ForEach(g =>
                {                    
                    WriteLine(g.Day + ": " + g + " " + ((PlayoffGame)g).Series.Name);
                });

                
                
            }

            WriteLine("Press Enter to continue");
            ReadLine();

        }
    }
}
