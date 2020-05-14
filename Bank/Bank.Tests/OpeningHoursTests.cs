using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Bank.Tests
{
    public class OpeningHoursTests
    {
        [Theory]
        [InlineData(2020, 1, 1, 10, 29, false)] //Mi
        [InlineData(2020, 1, 1, 10, 30, true)] //Mi
        [InlineData(2020, 1, 1, 10, 31, true)] //Mi
        [InlineData(2020, 1, 1, 18, 59, true)] //Mi
        [InlineData(2020, 1, 1, 19, 0, false)] //Mi
        [InlineData(2020, 1, 1, 19, 1, false)] //Mi
        [InlineData(2020, 1, 4, 10, 29, !true)] //Sa
        [InlineData(2020, 1, 4, 10, 30, true)] //Sa
        [InlineData(2020, 1, 4, 10, 31, true)] //Sa
        [InlineData(2020, 1, 4, 13, 59, true)] //Sa
        [InlineData(2020, 1, 4, 14, 00, !true)] //Sa
        [InlineData(2020, 1, 5, 12, 00, !true)] //So
        public void OpeningHours_IsOpen(int year, int month, int day, int hour, int minute, bool exp)
        {
            var oh = new OpeningHours();
            var dt = new DateTime(year, month, day, hour, minute, 0);

            Assert.Equal(exp, oh.IsOpen(dt));
        }
    }
}
