using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class OpeningHours
    {
        private Dictionary<DayOfWeek, (TimeSpan Start, TimeSpan End)> days = new Dictionary<DayOfWeek, (TimeSpan, TimeSpan)>();

        public OpeningHours()
        {
            days.Add(DayOfWeek.Monday, (new TimeSpan(10, 30, 0), new TimeSpan(19, 0, 0)));
            days.Add(DayOfWeek.Tuesday, (new TimeSpan(10, 30, 0), new TimeSpan(19, 0, 0)));
            days.Add(DayOfWeek.Wednesday, (new TimeSpan(10, 30, 0), new TimeSpan(19, 0, 0)));
            days.Add(DayOfWeek.Thursday, (new TimeSpan(10, 30, 0), new TimeSpan(19, 0, 0)));
            days.Add(DayOfWeek.Friday, (new TimeSpan(10, 30, 0), new TimeSpan(19, 0, 0)));
            days.Add(DayOfWeek.Saturday, (new TimeSpan(10, 30, 0), new TimeSpan(14, 0, 0)));
        }

        public bool IsOpen(DateTime time)
        {
            return
                   days.ContainsKey(time.DayOfWeek) &&
                   days[time.DayOfWeek].Start <= time.TimeOfDay &&
                   days[time.DayOfWeek].End > time.TimeOfDay;
        }

        public bool IsOpenNow()
        {
            return IsOpen(DateTime.Now);
        }
    }

}
