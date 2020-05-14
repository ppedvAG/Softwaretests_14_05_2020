using System;

namespace Tools
{
    public class Datehelper
    {
        public bool IsWeekend()
        {
            return DateTime.Now.DayOfWeek == DayOfWeek.Sunday
                || DateTime.Now.DayOfWeek == DayOfWeek.Saturday;
        }
    }
}
