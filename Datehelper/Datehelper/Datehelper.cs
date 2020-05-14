using System;
using System.IO;

namespace Tools
{
    public class Datehelper
    {
        public bool IsWeekend()
        {
            return DateTime.Now.DayOfWeek == DayOfWeek.Sunday
                || DateTime.Now.DayOfWeek == DayOfWeek.Saturday;
        }

        public void DummesZeug()
        {
            var data = File.ReadAllText(@"ab:\alledatein\lala.txt");
        }
    }
}
