using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ppedv.Blumenklavier.Model;
using ppedv.Blumenklavier.Model.Contracts;
using System;
using System.Linq;

namespace ppedv.Blumenklavier.Logic.Tests
{
    [TestClass]
    public class CoreTests
    {
        [TestMethod]
        public void GetAllowedPlantCount_Klavier_null_throws_ArgumentNullException()
        {
            var core = new Core(null);

            Assert.ThrowsException<ArgumentNullException>(() => core.GetAllowedPlantCount(null));
        }

        [TestMethod]
        public void GetAllowedPlantCount_Klavier_Tasten_ist_0_results_0()
        {
            var core = new Core(null);

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
            var core = new Core(null);

            int result = core.GetAllowedPlantCount(new Klavier() { AnzahlTasten = tasten });

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void GetAllowedPlantCountForAllOfDatabase()
        {
            var core = new Core(new TestRepository());

            var result = core.GetAllowedPlantCountForAllOfDatabase();

            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void GetAllowedPlantCountForAllOfDatabase_Moq()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.GetAll<Klavier>()).Returns(() =>
            {
                var k1 = new Klavier() { AnzahlTasten = 12, Hersteller = "K1" };
                var k2 = new Klavier() { AnzahlTasten = 14, Hersteller = "K2" };
                var k3 = new Klavier() { AnzahlTasten = 13, Hersteller = "K3" };
                return new[] { k1, k2, k3 };
            });
            var core = new Core(mock.Object);

            var result = core.GetAllowedPlantCountForAllOfDatabase();

            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void GetAllowedPlantCountForAllOfDatabase_will_GetAllowedPlantCount_be_called()
        {

            var repoMock = new Mock<IRepository>();
            repoMock.Setup(x => x.GetAll<Klavier>()).Returns(() =>
            {
                var k1 = new Klavier() { AnzahlTasten = 12, Hersteller = "K1" };
                var k2 = new Klavier() { AnzahlTasten = 12, Hersteller = "K2" };
                return new[] { k1, k2 };
            });

            var coreMock = new Mock<Core>(repoMock.Object);
            coreMock.Setup(x => x.GetMagicNumer()).Returns(8);
            coreMock.CallBase = true;

            var result = coreMock.Object.GetAllowedPlantCountForAllOfDatabase();
            Assert.AreEqual(8, result);

            Assert.AreEqual(coreMock.Object.GetMagicNumer(), result);

            coreMock.Verify(x => x.GetAllowedPlantCount(It.IsAny<Klavier>()), Times.Exactly(2));
        }
    }
}
