using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competition;

namespace TeamApp.Domain
{
    public class League
    {
        private string v;

        public League(string v)
        {
            this.v = v;
        }

        public string Name { get; set; }        

        public List<ICompetitionConfig> Competitions { get; set; }
    }
}
