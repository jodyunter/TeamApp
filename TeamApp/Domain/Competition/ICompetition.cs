using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Competition
{
    public interface ICompetition
    {
        string Name { get; set; }
        League League { get; set; }
        int? FirstYear { get; set; }
        int? LastYear { get; set; }
        int Order { get; set; }
        //how do we setup generic rules?
    }
}
