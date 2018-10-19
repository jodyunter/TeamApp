using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competition;

namespace TeamApp.Domain
{
    public class League:BaseDataObject
    {
        private string v;
        public League() { }
        public League(string v)
        {
            this.v = v;
            Competitions = new List<CompetitionConfig>();
        }

        public virtual string Name { get; set; }

        public virtual IList<CompetitionConfig> Competitions { get; set; }
    }
}
