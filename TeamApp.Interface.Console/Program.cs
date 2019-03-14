using System;
using static System.Console;
using TeamApp.Console.App;
using System.Threading;
using System.Linq;
using TeamApp.Console.Views.Season;
using TeamApp.Domain.Competitions;
using System.Collections.Generic;

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

            //track this so we can repeat a year if needed
            var seed = 156;// DateTime.Now.Millisecond;
            var random = new Random(seed);
            WriteLine("Seed: " + seed);

            while (!stop)
            {
                teamApp.ClearScreen();
                WriteLine("Seed: " + seed);
                var leagueView = teamApp.LeagueService.GetByName("NHL");

                WriteLine("League: " + leagueView.Name + " loaded.");

                var currentData = teamApp.GameDataService.GetCurrentData();
                teamApp.GameDataService.SetupComeptitionsForDay(currentData.CurrentDay, currentData.CurrentYear);
                teamApp.GameDataService.ProcessDay();
                teamApp.GameDataService.PlayDay(random);
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
                    WriteLine("Day: " + currentData.CurrentDay);
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

                            WriteLine(view.GetView(StandingsView.CONFERENCE));
                        }
                        else if (m.Type == "Playoff")
                        {
                            var playoffs = teamApp.PlayoffService.GetPlayoffSummary(m.Id);

                            var format = "{0,2} {1,5}{2,12}: {3,2}{4,3}{5,2} :{6,-12}";
                            playoffs.Series.ToList().ForEach(series =>
                            {
                                var output = string.Format(format, series.Round, series.Name, series.HomeTeamName, series.HomeWins, "-", series.AwayWins, series.AwayTeamName);
                                WriteLine(output);
                            });
                        }
                        else WriteLine("No type defined");

                    });
                }
                else
                {
                    teamApp.CompetitionService.GetCompetitionsByYear(currentData.CurrentYear).ToList().ForEach(m =>
                    {
                        if (
                        m.Type == "Season")
                        {
                            var standings = teamApp.StandingsService.GetStandings(m.Id);
                            var view = new StandingsView(standings);

                            WriteLine(view.GetView(StandingsView.LEAGUE));
                        }
                        else if (m.Type == "Playoff")
                        {
                            var playoffs = teamApp.PlayoffService.GetPlayoffSummary(m.Id);

                            var format = "{0,2} {1,5}{2,12}: {3,2}{4,3}{5,2} :{6,-12}";
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
            
            WriteLine("Press Enter to Close the app");
            ReadLine();

        }
    }
}
