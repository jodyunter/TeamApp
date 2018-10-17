using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamApp.Domain.Competition.Playoffs.Config
{
    public class PlayoffCompetitionConfig:ICompetitionConfig
    {
        public string Name { get; set; }
        public League League { get; set; }
        public int Order { get; set; }
        public GameRules GameRules { get; set; }
        public int? FirstYear { get; set; }
        public int? LastYear { get; set; }
        public List<PlayoffSeriesRule> SeriesRules { get; set; }
        public List<PlayoffRankingRule> Rankings { get; set; }
        public Dictionary<string, ICompetitionConfig> Parents { get; set; }      

        public PlayoffCompetitionConfig(string name, League league, int order, GameRules gameRules, int? firstYear, int? lastYear, List<PlayoffRankingRule> rankings, List<PlayoffSeriesRule> seriesRules, Dictionary<string, ICompetitionConfig> parents)
        {
            Name = name;
            League = league;
            Order = order;
            GameRules = gameRules;
            FirstYear = firstYear;
            LastYear = lastYear;
            Rankings = rankings;
            SeriesRules = seriesRules;
            Parents = parents;
        }

        public ICompetition CreateCompetition(int year, List<ICompetition> parents)
        {
            var playoff = new Playoff(this, Name, year, -1, 1, null, null, null);

            ProcessRankingRulesAndAddTeams(playoff, parents);
            
            throw new NotImplementedException();
        }

        public void ProcessRankingRulesAndAddTeams(Playoff playoff, List<ICompetition> parents)
        {
            Rankings.ForEach(rule =>
            {
                //get the competition
                var source = parents.Where(p => p.Name.Equals(rule.SourceCompetition.Name)).FirstOrDefault(); //this is the source competition

                if (source == null) throw new ApplicationException("Playoff Ranking Rule has bad source competition: " + rule.SourceCompetition.Name);

                var group = source.Rankings[rule.SourceGroupName];

                if (group == null) throw new ApplicationException("Playoff Ranking Rule has bad source group name: " + rule.SourceGroupName);

                int firstRank = rule.StartingRank;

                int nextRank = firstRank;

                for (int i = rule.SourceFirstRank; i <= rule.SourceLastRank; i++)
                {
                    var sourceRanking = group.Where(r => r.Rank == i).FirstOrDefault();

                    if (sourceRanking == null) throw new ApplicationException("Playoff Source Rank did not exist: " + rule.SourceCompetition.Name + " " + rule.SourceGroupName + " rank: " + i);

                    var sourceTeam = sourceRanking.Team;

                    var newTeam = new PlayoffTeam(sourceTeam.Name, sourceTeam.Skill, playoff, sourceTeam.Parent, sourceTeam.Owner, playoff.Year);

                    var playoffRanking = new TeamRanking(nextRank, rule.GroupName, newTeam);

                    playoff.Teams.Add(newTeam);

                    nextRank++;
                }
                
            });
        }
        
    }
}
