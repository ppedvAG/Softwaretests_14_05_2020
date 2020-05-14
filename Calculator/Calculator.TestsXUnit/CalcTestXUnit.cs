using FluentAssertions;
using System;
using Xunit;

namespace Calculator.TestsXUnit
{
    public class CalcTestXUnit
    {
        [Fact]
        public void Calc_Sum_3_and_8_results_11()
        {

            Calc calc = new Calc();

            var result = calc.Sum(4, 7);

            Assert.Equal(11, result);

        }

        [Theory]
        [InlineData(2, 8, 10)]
        [InlineData(2, 18, 20)]
        [InlineData(33, -62, -29)]
        public void Calc_Sum(int a, int b, int x)
        {
            Calc calc = new Calc();

            var result = calc.Sum(a, b);

            Assert.Equal(x, result);

            x.Should().Be(result);
            x.Should().BeInRange(result - 10, result + 10);
        }


        [Fact]
        public void Calc_Sum_OverflowsException()
        {
            Calc calc = new Calc();

            Assert.Throws<OverflowException>(() => calc.Sum(int.MaxValue, 1));

        }
    }
}
