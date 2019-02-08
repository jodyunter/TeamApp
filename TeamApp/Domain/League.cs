using System;
using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain.Competitions;

namespace TeamApp.Domain
{
    public class League:BaseDataObject,ITimePeriod
    {        
        public virtual int? FirstYear { get; set; }
        public virtual int? LastYear { get; set; }
        public League() { }
        public League(string name, int? firstYear, int? lastYear)
        {
            Name = name;
            FirstYear = firstYear;
            LastYear = lastYear;
            CompetitionConfigs = new List<CompetitionConfig>();
        }

        public virtual string Name { get; set; }

        public virtual IList<CompetitionConfig> CompetitionConfigs { get; set; }
        
        public CompetitionConfig GetNextCompetitionConfig(CompetitionConfig current, int currentYear)
        {
            if (CompetitionConfigs == null || CompetitionConfigs.Count() == 0) throw new Exception("Competition Configs are null");

            if (current == null)
            {
                return CompetitionConfigs.OrderBy(c => c.Ordering).ToList().Where(c => c.IsActive(currentYear)).First();
            }
            else
            {
                return CompetitionConfigs.OrderBy(c => c.Ordering).ToList().Where(c => c.IsActive(currentYear) && (c.Ordering > current.Ordering)).FirstOrDefault();
            }
        }        
    }
}
