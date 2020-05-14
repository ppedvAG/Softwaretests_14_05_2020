using System;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tools.Tests
{
    [TestClass]
    public class DatehelperTests
    {
        [TestMethod]
        public void Datehelper_IsWeekend()
        {
            var dh = new Datehelper();

            using (ShimsContext.Create())
            {
                
                Assert.IsFalse(dh.IsWeekend());//Mo
                Assert.IsFalse(dh.IsWeekend());//Di
                Assert.IsFalse(dh.IsWeekend());//Mi
                Assert.IsFalse(dh.IsWeekend());//Do
                Assert.IsFalse(dh.IsWeekend());//Fr
                Assert.IsTrue(dh.IsWeekend());//Sa
                Assert.IsTrue(dh.IsWeekend());//So
            }
        }
    }
}
