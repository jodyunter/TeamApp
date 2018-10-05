using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain
{
    public static class TimePeriodExtensions
    {
        public static bool IsActive(this ITimePeriod timePeriod, int currentYear)
        {
            if (timePeriod.FirstYear == null) return false;
            else if (timePeriod.FirstYear <= currentYear)
            {
                if (timePeriod.LastYear == null) return true;
                else
                    return timePeriod.LastYear >= currentYear;
            }
            else
                return false;
        }
    }
}
