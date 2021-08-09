using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Calculator.Tests
{
    [TestClass]
    public class FluentCalcTest
    {
        [TestMethod]
        public void Fluent_Calc_Tests()
        {
            Calc calc = new Calc();

            int result = calc.Sum(4, 9);

            result.Should().BeGreaterThan(5).And.BeLessThan(20);
            result.Should().BeInRange(2, 100);
            result.Should().Be(13);
            result.Should().BePositive();
        }


        [TestMethod]
        [DataRow(0, 0, 0)]
        [DataRow(2, 3, 5)]
        [DataRow(2, 2, 4)]
        [DataRow(-2, -5, -7)]
        [DataRow(-2, 4, 2)]
        public void Sum(int a, int b, int expected)
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            int result = calc.Sum(a, b);

            //Assert
            result.Should().Be(expected);
        }

        [TestMethod]
        [TestCategory("ExceptionTest")]
        public void Sum_MAX_and_1_throws_OverflowException()
        {
            Calc calc = new Calc();

            calc.Invoking(x => x.Sum(int.MaxValue, 1)).Should().Throw<OverflowException>();
        }



    }
}
