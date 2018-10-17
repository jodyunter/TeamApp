using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competition;

namespace TeamApp.Domain
{
    public interface ISingleYearTeam : ITeam
    {
        ICompetition Competition { get; set; }
        Team Parent { get; set; }        
    }
}
