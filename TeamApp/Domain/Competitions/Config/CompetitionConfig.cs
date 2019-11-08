using System.Linq;
using System.Collections.Generic;
using TeamApp.Domain.Games;

namespace TeamApp.Domain.Competitions.Config
{
    public abstract class CompetitionConfig:BaseDataObject, ITimePeriod
    {
        public virtual string Name { get; set; }
        public virtual League League { get; set; }
        public virtual int Ordering { get; set; }
        public virtual GameRules GameRules { get; set; }
        //how do we setup generic rules?
        public virtual IList<CompetitionConfig> Parents { get; set; } //this would be the list of competitions where they could get thier teams from
        public virtual IList<CompetitionConfigFinalRankingRule> FinalRankingRules { get; set; }
        public virtual int? FirstYear { get; set; }
        public virtual int? LastYear { get; set; }
        public virtual int? CompetitionStartingDay { get; set; }
        public virtual string FinalRankingGroupName { get; set; }
        public abstract SingleYearTeam CreateCompetitionTeam(Competition competition, Team parent);
        public abstract Competition CreateCompetitionDetails(int day, int year, IList<Competition> parents);

        protected CompetitionConfig() { }
        protected CompetitionConfig(string name, League league, int order, int? competitionStartingDay, GameRules gameRules, List<CompetitionConfig> parents, List<CompetitionConfigFinalRankingRule> finalRankingRules, string finalRankingGroupName, int? firstYear, int? lastYear)
        {
            Name = name;
            League = league;
            Ordering = order;
            GameRules = gameRules;
            Parents = parents;
            FirstYear = firstYear;
            LastYear = lastYear;
            CompetitionStartingDay = competitionStartingDay;
            FinalRankingGroupName = finalRankingGroupName;
            if (parents == null)
                Parents = new List<CompetitionConfig>();
            else
                Parents = parents;

            if (finalRankingRules == null)
                FinalRankingRules = new List<CompetitionConfigFinalRankingRule>();
            else
                FinalRankingRules = finalRankingRules;
        }
                
        public virtual Competition CreateCompetition(int day, int year, IList<Competition> parents)
        {
            bool areAllParentsDone = true; ;

            if (!(parents == null || parents.Count() == 0))
            {
                parents.ToList().ForEach(competition =>
                {
                    areAllParentsDone = areAllParentsDone && competition.Finished;
                });
            }

            if (areAllParentsDone)
                return CreateCompetitionDetails(day, year, parents);
            
            //if the starting day is null then it starts after it's parents are done.
            if (!areAllParentsDone && CompetitionStartingDay == null)
            {
                return null;
            }

            throw new System.Exception("Not all parents are done!");
                    
        }

        //we should remove these.
        //rules should be in place to setup all the rankings we need
        public virtual void CopyTeamsFromCompetition(Competition destinationCompetition, Competition sourceCompetition)
        {
            if (destinationCompetition.Teams == null) destinationCompetition.Teams = new List<SingleYearTeam>();

            sourceCompetition.Teams.ToList().ForEach(sourceTeam =>
            {
                //does the team already exist?
                var team = destinationCompetition.Teams.Where(t => t.Parent.Id == sourceTeam.Parent.Id).FirstOrDefault();
                if (team == null) team = CreateCompetitionTeam(destinationCompetition, sourceTeam.Parent);
                destinationCompetition.Teams.Add(team);
            });
        }
        
        //what if we have two parent competitions, and therefore end up copying this twice?
        //when we copy the rankings, maybe we should only copy the final rankings to help break ties
        public virtual void CopyRankingsFromCompetition(Competition destinationCompetition, Competition sourceCompetition)
        {
            if (destinationCompetition.Rankings == null) destinationCompetition.Rankings = new List<TeamRanking>();

            sourceCompetition.Rankings.ToList().ForEach(sourceRanking =>
            {
                var team = destinationCompetition.Teams.Where(t => t.Parent.Id == sourceRanking.SingleYearTeam.Parent.Id).First(); //if null we messed up
                destinationCompetition.Rankings.Add(new TeamRanking(sourceRanking.Rank, sourceRanking.GroupName, team, sourceRanking.GroupLevel));
            });

        }
    }
}
