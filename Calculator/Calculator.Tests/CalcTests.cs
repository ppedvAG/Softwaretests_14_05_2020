using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        public void Calc_Sum_5_and_3_results_8()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(5, 3);

            //Assert
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void Calc_Sum_0_and_0_results_0()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(0, 0);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Calc_Sum_N5_and_N16_results_N21()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Sum(-5, -16);

            //Assert
            Assert.AreEqual(-21, result);
        }

        [TestMethod]
        public void Calc_Sum_MAX_and_1_throws_OverflowException()
        {
            var calc = new Calc();

            Assert.ThrowsException<OverflowException>(() => calc.Sum(int.MaxValue, 1), "Doof!");
        }

        [TestMethod]
        [DataRow(0, 0, 0)]
        [DataRow(1, 2, 3)]
        [DataRow(-12, 6, -6)]
        public void Calc_Sum(int a, int b, int exp)
        {
            var calc = new Calc();

            var result = calc.Sum(a, b);

            Assert.AreEqual(exp, result);
        }

        [TestMethod]
        [DataRow(int.MaxValue, 2)]
        [DataRow(int.MinValue, -1)]
        public void Calc_Sum_overflow_throws_exception(int a, int b)
        {
            var calc = new Calc();

            Assert.ThrowsException<OverflowException>(() => calc.Sum(a, b), "Doof!");

        }
    }
}
