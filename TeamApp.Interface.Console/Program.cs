using System;
using static System.Console;
using System.Collections.Generic;
using TeamApp.Domain.Games;
using TeamApp.Domain;

namespace TeamApp.Console
{
    class Program
    {
        static void Other()
        {
            var teamList = new List<Team>();
            int numberOfTeams = 10;
            var rand = new Random();

            for (int i = 0; i < numberOfTeams; i++)
            {
                var team = new Team("Team " + i, "The " + i + "'s", "T" + i, 5, "Me", 1, null, true, new List<Player>());

                for (int j = 0; j < 6; j++)
                {
                    var p = new Player("Player " + j + "_" + team.Name, 20, 1, null, team);
                    team.Players.Add(p);
                }

                teamList.Add(team);
            }

            for (int i = 0; i < numberOfTeams - 1; i++)
            {
                for (int j = i + 1; j < numberOfTeams; j++)
                {
                    var g = new Game()
                    {
                        Home = teamList[i],
                        Away = teamList[j],
                        Rules = new GameRules("My Rules", true, 2, 3, 120, true),
                        OutputPlayByPlay = false
                    };

                    g.Play(rand);
                    WriteLine(g);
                }
            }
        }
        
        static void Main(string[] args)
        {

            var go = new SeasonProgram();
            go.Run();
            
            WriteLine("Press Enter to Close the app");
            ReadLine();

        }
        
    }
}
