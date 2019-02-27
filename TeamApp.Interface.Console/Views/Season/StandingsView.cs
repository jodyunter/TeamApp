using System.Collections.Generic;
using System.Linq;
using TeamApp.ViewModels.Views.Standings;

namespace TeamApp.Console.Views.Season
{
    public class StandingsView
    {
        public static string formatter = "{0,3}. {1,-15}{2,5}{3,5}{4,5}{5,5}{6,5}{7,5}{8,5}{9,5}{10,15}";        
        public StandingsViewModel Model { get; set; }
        public StandingsView(StandingsViewModel model)
        {
            Model = model;
        }
        public static string GetHeader()
        {
            return string.Format(formatter, "R", "Name", "W", "L", "T", "Pts", "GP", "GF", "GA", "GD", "Div");
        }
        public string GetView(int groupLevel)
        {
            var groupList = new List<StandingsTeamView>();

            Model.Teams.ToList().ForEach(team =>
            {
                var standingsTeamView = new StandingsTeamView(team);
                standingsTeamView.SetRankingByLevel(groupLevel);                
                groupList.Add(standingsTeamView);
            });

            var orderedTeams = groupList.OrderBy(s => s.Ranking.GroupName).ThenBy(s => s.Ranking.Rank).ToList();

            var initialGroupName = orderedTeams[0].Ranking.GroupName;

            var result = initialGroupName + "\n" + GetHeader();

            groupList.ForEach(item =>
            {
                if (!item.Ranking.GroupName.Equals(initialGroupName))
                {
                    result += "\n" + item.Ranking.GroupName + "\n" + GetHeader();
                    initialGroupName = item.Ranking.GroupName;
                }

                result += item.GetView();
            });

            return result;
        }
    }
}
