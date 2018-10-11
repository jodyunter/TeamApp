using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Competition
{
    public interface CompetitionConfig:ITimePeriod
    {
        string Name { get; set; }
        League League { get; set; }
        int Order { get; set; }
        GameRules GameRules { get; set; }
        //how do we setup generic rules?
        Dictionary<string, CompetitionConfig> Parents { get; set; } //this would be the list of competitions where they could get thier teams from
    }
}
