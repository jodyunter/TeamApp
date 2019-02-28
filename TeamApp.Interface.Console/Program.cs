﻿using System;
using static System.Console;
using TeamApp.Console.App;
using System.Threading;
using System.Linq;
using TeamApp.Console.Views.Season;


namespace TeamApp.Console
{
    class Program
    {

        static void Main(string[] args)
        {            
                        
            var user = new User("Jody_Program_User");
            Thread.CurrentPrincipal = user;

            var teamApp = new TeamApplication();
            teamApp.SetupConfig(true, true, true);
            var stop = false;

            while (!stop)
            {
                teamApp.ClearScreen();                
                var leagueView = teamApp.LeagueService.GetByName("NHL");

                WriteLine("League: " + leagueView.Name + " loaded.");

                var currentData = teamApp.GameDataService.GetCurrentData();
                teamApp.GameDataService.SetupComeptitionsForDay(currentData.CurrentDay, currentData.CurrentYear);
                teamApp.GameDataService.ProcessDay();
                teamApp.GameDataService.PlayDay(new Random());
                teamApp.GameDataService.ProcessDay();

                WriteLine("Year: " + currentData.CurrentYear);
                WriteLine("Day: " + currentData.CurrentDay);
                teamApp.ScheduleGameService.GetGamesForDay(currentData.CurrentDay, currentData.CurrentYear).ToList().ForEach(game =>
                {
                    WriteLine(game.ToString());
                });

                if (!teamApp.GameDataService.IncrementDay())
                {
                    WriteLine("Could not increment day.");
                }
                else
                {
                    WriteLine("Game: " + currentData.CurrentDay);
                    teamApp.ScheduleGameService.GetGamesForDay(currentData.CurrentDay, currentData.CurrentYear).ToList().ForEach(game =>
                    {
                        WriteLine(game.ToString());
                    });
                }

                var activeComps = teamApp.CompetitionService.GetActiveCompetitions(currentData.CurrentYear).ToList();
                if (activeComps.Count > 0)
                {
                    activeComps.ToList().ForEach(m =>
                    {
                        if (m.Type == "Season")
                        {
                            var standings = teamApp.StandingsService.GetStandings(m.Id);
                            var view = new StandingsView(standings);

                            WriteLine(view.GetView(StandingsView.LEAGUE));
                        }
                        else if (m.Type == "Playoff")
                        {
                            var playoffs = teamApp.PlayoffService.GetPlayoffSummary(m.Id);

                            playoffs.Series.ToList().ForEach(series =>
                            {
                                WriteLine(series.Name + " " + series.HomeTeamName + ": " + series.HomeWins + " - " + series.AwayWins + " :" + series.AwayTeamName);
                            });                            
                        }
                        else WriteLine("No type defined");

                    });
                }
                else
                {
                    teamApp.CompetitionService.GetCompetitionsByYear(currentData.CurrentYear).ToList().ForEach(m =>
                    {
                        if (m.Type == "Season")
                        {
                            var standings = teamApp.StandingsService.GetStandings(m.Id);
                            var view = new StandingsView(standings);

                            WriteLine(view.GetView(StandingsView.LEAGUE));
                        }
                        else if (m.Type == "Playoff")
                        {
                            var playoffs = teamApp.PlayoffService.GetPlayoffSummary(m.Id);

                            var format = "{0,2} {1,5}{2,12}: {3,2}{4,3}{5,2} :{-6,12}";
                            playoffs.Series.ToList().ForEach(series =>
                            {
                                var output = string.Format(format, series.Round, series.Name, series.HomeTeamName, series.HomeWins, "-", series.AwayWins, series.AwayTeamName);
                                WriteLine(output);
                            });
                        }
                        else WriteLine("No type defined");
                    });

                    teamApp.GameDataService.IncrementYear();
                    
                }
                WriteLine("Press Enter to continue or type 'quit'");
                var input = ReadLine();
                if (input.Equals("quit"))
                {
                    stop = true;
                }
            }
            
            /*
            var app = new Application();
            app.loadLeague("NHL");
            WriteLine(app.League.Name);
            */

            /*
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

            int currentRound = playoff.CurrentRound;

            while (!playoff.IsComplete())
            {                
                while (!playoff.IsRoundComplete(currentRound))
                {
                    var games = playoff.PlayNextDay(r);                    
                }

                playoff.Series.Where(s => s.Round == currentRound).ToList().ForEach(st =>
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

                currentRound = playoff.CurrentRound;
            }
            */
            WriteLine("Press Enter to Close the app");
            ReadLine();

        }
    }
}
