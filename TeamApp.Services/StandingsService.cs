using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.ViewModels.Views;

namespace TeamApp.Services
{
    public class StandingsService
    {
        public StandingsViewModel GetStandings(int league, int year, int competitionId)
        {
            //command to get the standings from the database/repository
            var teams = new List<StandingsTeamViewModel>();

            for (int i = 0; i < 20; i++)
            {
                teams.Add(new StandingsTeamViewModel()
                {
                    TeamName = "Team " + i,
                    Division = "League",
                    Rank = i + 1,
                    Wins = 0,
                    Loses = 0,
                    Ties = 0,
                    GoalDifference = 0,
                    GoalsFor = 0,
                    GoalsAgainst = 0,
                    GamesPlayed = 0,
                    Points = 0
                });
            }
            var standingsView = new StandingsViewModel()
            {
                StandingsName = "League",
                Teams = teams
            };

            return standingsView;
            
        }
    }
}
