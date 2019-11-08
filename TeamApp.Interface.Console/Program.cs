using System;
using static System.Console;
using TeamApp.Console.App;
using System.Threading;
using System.Linq;
using TeamApp.Console.Views.Season;
using TeamApp.Domain.Competitions;
using System.Collections.Generic;
using TeamApp.Domain.Games;
using TeamApp.Domain;

namespace TeamApp.Console
{
    class Program
    {

        
        static void Main(string[] args)
        {

            var teamList = new List<Team>();

            for (int i = 0; i < 10; i++)
            {
                var team = new Team("Team " + i, "The " + i + "'s", "T" + i, 5, "Me", 1, null, true, new List<Player>());

                for (int j = 0; j < 6; j++)
                {
                    var p = new Player("Player " + j + "_" + team.Name, 20, 1, null, team);
                    team.Players.Add(p);
                }

                teamList.Add(team);
            }

            var g = new NewGame() {
                Home = teamList[1],
                Away = teamList[2],
                Rules = new GameRules("My Rules", false, 2, 1, 10, true)
            };

            var rand = new Random(1123213);
            
            g.Play(rand);

            WriteLine("Press Enter to Close the app");
            ReadLine();

        }
        
    }
}
