using System.Collections.Generic;

namespace TeamApp.Domain.Competitions.Seasons
{
    public class SeasonDivision:BaseDataObject
    {
        public virtual Season Season { get; set; }
        public virtual SeasonDivision ParentDivision { get; set; }
        public virtual int Year { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<SeasonTeam> Teams { get; set; }
        public virtual int Level { get; set; }
        public virtual int Ordering { get; set; }
        //need to add the ranking rules

        public SeasonDivision() { }
        public SeasonDivision(Season season, SeasonDivision parentDivision, int year, string name, int level, int order, List<SeasonTeam> teams)
        {
            Season = season;
            ParentDivision = parentDivision;
            Year = year;
            Name = name;
            Teams = teams;
            Ordering = order;
            Level = level;
        }

        protected internal virtual void AddTeam(SeasonTeam newTeam)
        {
            if (Teams == null) Teams = new List<SeasonTeam>();
            if (!Teams.Contains(newTeam)) Teams.Add(newTeam);
        }        
    }
}
