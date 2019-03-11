using System.Linq;
using System.Collections.Generic;

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
        public virtual int? FirstYear { get; set; }
        public virtual int? LastYear { get; set; }
        public virtual int? CompetitionStartingDay { get; set; }

        protected CompetitionConfig() { }
        protected CompetitionConfig(string name, League league, int order, int? competitionStartingDay, GameRules gameRules, List<CompetitionConfig> parents, int? firstYear, int? lastYear)
        {
            Name = name;
            League = league;
            Ordering = order;
            GameRules = gameRules;
            Parents = parents;
            FirstYear = firstYear;
            LastYear = lastYear;
            CompetitionStartingDay = competitionStartingDay;
            if (parents == null)
                Parents = new List<CompetitionConfig>();
            else
                Parents = parents;
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

        public abstract Competition CreateCompetitionDetails(int day, int year, IList<Competition> parents);       
        
                
    }
}
