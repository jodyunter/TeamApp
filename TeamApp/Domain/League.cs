using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
