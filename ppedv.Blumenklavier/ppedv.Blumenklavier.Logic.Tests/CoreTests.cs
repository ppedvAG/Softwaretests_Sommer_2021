using Microsoft.VisualStudio.TestTools.UnitTesting;
using ppedv.Blumenklavier.Model;
using System;

namespace ppedv.Blumenklavier.Logic.Tests
{
    [TestClass]
    public class CoreTests
    {
        [TestMethod]
        public void GetAllowedPlantCount_Klavier_null_throws_ArgumentNullException()
        {
            var core = new Core();

            Assert.ThrowsException<ArgumentNullException>(() => core.GetAllowedPlantCount(null));
        }

        [TestMethod]
        public void GetAllowedPlantCount_Klavier_Tasten_ist_0_results_0()
        {
            var core = new Core();

            int result = core.GetAllowedPlantCount(new Klavier() { AnzahlTasten = 0 });

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [DataRow(0, 0)]
        [DataRow(1, 0)]
        [DataRow(2, 0)]
        [DataRow(3, 1)]
        [DataRow(4, 1)]
        [DataRow(5, 1)]
        [DataRow(6, 2)]
        [DataRow(30, 10)]
        [DataRow(600, 200)]
        public void GetAllowedPlantCount(int tasten, int expectedResult)
        {
            var core = new Core();

            int result = core.GetAllowedPlantCount(new Klavier() { AnzahlTasten = tasten });

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GetAllowedPlantCountForAllOfDatabase()
        {
            var core = new Core();

            var result = core.GetAllowedPlantCountForAllOfDatabase();

            Assert.AreEqual(12, result);
        }
    }
}
