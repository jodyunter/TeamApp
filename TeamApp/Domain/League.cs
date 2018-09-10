using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
