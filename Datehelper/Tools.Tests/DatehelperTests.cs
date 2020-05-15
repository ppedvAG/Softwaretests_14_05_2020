using System;
using System.IO;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pose;

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
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2020, 5, 11);
                Assert.IsFalse(dh.IsWeekend());//Mo
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2020, 5, 12);
                Assert.IsFalse(dh.IsWeekend());//Di
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2020, 5, 13);
                Assert.IsFalse(dh.IsWeekend());//Mi
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2020, 5, 14);
                Assert.IsFalse(dh.IsWeekend());//Do
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2020, 5, 15);
                Assert.IsFalse(dh.IsWeekend());//Fr
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2020, 5, 16);
                Assert.IsTrue(dh.IsWeekend());//Sa
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2020, 5, 17);
                Assert.IsTrue(dh.IsWeekend());//So
            }
        }

        [TestMethod]
        public void DateHelper_Dummes_Tests()
        {
            var dh = new Datehelper();
            using (ShimsContext.Create())
            {
                System.IO.Fakes.ShimFile.ReadAllTextString = x => "RESULT";
                dh.DummesZeug();
            }
        }


        [TestMethod]
        public void DateHelper_Dummes_Tests_POSE()
        {
    //        var dh = new Datehelper();
    //        PoseContext.Isolate(() =>
    //        {
    //            Shim consoleShim = Shim.Replace(() => File.ReadAllText(Is.A<string>())).With(
    //delegate (string s) { return "LALALAA"; });


    //            dh.DummesZeug();
    //        });

        }
    }
}
