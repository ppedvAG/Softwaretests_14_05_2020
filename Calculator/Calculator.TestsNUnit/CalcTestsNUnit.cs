using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.TestsNUnit
{
    [TestFixture]
    public class CalcTestsNUnit
    {
        [Test]
        public void Calc_Sum_3_and_9_results_12_NUnit()
        {
            var calc = new Calc();

            var r = calc.Sum(3, 9);

            Assert.AreEqual(12, r);

        }

        [Test]
        [TestCase(2, 8, 10)]
        [TestCase(2, 8, 10)]
        [TestCase(33, -62, -29)]
        public void Calc_Sum(int a, int b, int x)
        {
            Calc calc = new Calc();

            var result = calc.Sum(a, b);

            Assert.AreEqual(x, result);

            Assert.Inconclusive();

            Assert.That(x, Is.EqualTo(result));
        }

        [Test]
        public void Calc_Sum_OverflowsException()
        {
            Calc calc = new Calc();

            Assert.Throws<OverflowException>(() => calc.Sum(int.MaxValue, 1));

        }
    }
}
