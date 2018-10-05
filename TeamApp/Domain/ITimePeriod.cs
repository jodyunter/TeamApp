using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain
{
    public interface ITimePeriod
    {
        int? FirstYear { get; set; }
        int? LastYear { get; set; }
    }
}
