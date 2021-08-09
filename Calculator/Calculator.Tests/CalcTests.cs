using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Calculator.Tests
{
    [TestClass]
    public class CalcTests
    {

        [TestMethod]
        public void Sum_2_and_3_results_5()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            int result = calc.Sum(2, 3);

            //Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Sum_n3_and_12_results_9()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            int result = calc.Sum(-3, 12);

            //Assert
            Assert.AreEqual(9, result, "Ätsch!");
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
            Assert.AreEqual(expected, result, "Ätsch!");
        }

        [TestMethod]
        public void Sum_MAX_and_1_throws_OverflowException()
        {
            Calc calc = new Calc();

            Assert.ThrowsException<OverflowException>(() => calc.Sum(int.MaxValue, 1));
        }
    }
}
