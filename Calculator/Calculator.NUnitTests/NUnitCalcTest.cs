using NUnit.Framework;
using System;

namespace Calculator.NUnitTests
{
    [TestFixture]
    public class NUnitCalcTest
    {
        [Test]
        public void NUnit_Calc_Sum_5_and_9_results_14()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            int result = calc.Sum(5, 9);

            //Assert
            Assert.AreEqual(14, result);
        }


        [Test]
        [Category("ExceptionTest")]
        public void Sum_MAX_and_1_throws_OverflowException()
        {
            Calc calc = new Calc();

            Assert.Throws<OverflowException>(() => calc.Sum(int.MaxValue, 1));
        }

        [Test]
        [TestCase(0, 0, 0)]
        [TestCase(2, 3, 5)]
        [TestCase(2, 2, 4)]
        [TestCase(-2, -5, -7)]
        [TestCase(-2, 4, 2)]
        public void Sum(int a, int b, int expected)
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            int result = calc.Sum(a, b);

            //Assert
            Assert.AreEqual(expected, result, "Ätsch!");
        }

    }
}
