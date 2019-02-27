using System.Linq;
using TeamApp.ViewModels.Views.Standings;

namespace TeamApp.Console.Views.Season
{
    public class StandingsTeamView
    {
        public static string formatter = "{0,3}. {1,-15}{2,5}{3,5}{4,5}{5,5}{6,5}{7,5}{8,5}{9,5}{10,15}";
        public StandingsTeamViewModel Model { get; set; }
        public StandingsRankingViewModel Ranking { get; set; }
        public StandingsTeamView(StandingsTeamViewModel model)
        {
            Model = model;
        }
        
        public void SetRankingByLevel(int level)
        {
            Ranking = Model.Rankings.Where(r => r.GroupLevel == level).First();
        }

        public string GetView()
        {

            return string.Format(formatter, Ranking.Rank, Model.TeamName, Model.Wins, Model.Loses, Model.Ties, Model.Points, Model.GamesPlayed, Model.GoalsFor,
                Model.GoalsAgainst, Model.GoalDifference, Ranking.GroupName);
        }
    }
}
