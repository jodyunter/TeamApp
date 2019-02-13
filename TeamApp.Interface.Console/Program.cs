using System;
using TeamApp.Test.Helpers;
using static System.Console;
using System.Linq;
using TeamApp.Data.Repositories.Relational.NHibernate;
using NHibernate.Tool.hbm2ddl;
using TeamApp.Console.App;

namespace TeamApp.Console
{
    class Program
    {
        static void SetupConfig(TeamApplication teamApp, bool setupDatabase, bool dropFirst, bool setupData, string user)
        {
            if (setupDatabase)
            {
                var session = NHibernateHelper.OpenSession();
                var configuration = NHibernateHelper.GetConfiguration().BuildConfiguration();
                var schemaExport = new SchemaExport(configuration);

                if (dropFirst)
                    schemaExport.Drop(false, true);

                schemaExport.Create(false, true);

            }

            if (setupData)
            {

                var league = Data2.CreateBasicLeague("NHL");
                var seasonCompetition = Data2.CreateBasicSeasonConfiguration(league);
                var playoffConfig = Data2.CreateBasicPlayoffConfiguration(seasonCompetition);

                teamApp.LeagueRepository.Update(league, user);
            }


            
        }
        static void Main(string[] args)
        {            
            
            string user = "Jody Program";

            var teamApp = new TeamApplication();
            //SetupConfig(teamApp, true, true, true);

            var league = teamApp.LeagueRepository.Where(l => l.Name.Equals("NHL")).FirstOrDefault();

            WriteLine("Loaded league: " + league.Name);

            for (int i = 0; i < 1; i++)
            {
                teamApp.LeagueService.PlayAnotherYear("NHL", new Random(), user);
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
            WriteLine("Press Enter to continue");
            ReadLine();

        }
    }
}
