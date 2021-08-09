using System;
using System.ComponentModel;
using Xunit;

namespace Calculator.XUnitTests
{
    public class XUnitCalcTests
    {

        [Fact]
        public void Sum_n3_and_12_results_9()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            int result = calc.Sum(-3, 12);

            //Assert
            Assert.Equal(9, result);
        }

        [Fact]
        [Category("ExceptionTest")]
        public void Sum_MAX_and_1_throws_OverflowException()
        {
            Calc calc = new Calc();

            Assert.Throws<OverflowException>(() => calc.Sum(int.MaxValue, 1));
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(2, 3, 5)]
        [InlineData(2, 2, 4)]
        [InlineData(-2, -5, -7)]
        [InlineData(-2, 4, 2)]
        public void Sum(int a, int b, int expected)
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            int result = calc.Sum(a, b);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
