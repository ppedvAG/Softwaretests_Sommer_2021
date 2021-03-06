using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace TDDBank.Test
{
    [TestClass]
    public class OpeningHoursTests
    {
        [TestMethod]
        [DataRow(2021, 8, 9, 10, 29, false)]//mo
        [DataRow(2021, 8, 9, 10, 30, true)]//mo
        [DataRow(2021, 8, 9, 10, 31, true)]//mo
        [DataRow(2021, 8, 9, 18, 59, true)]//mo
        [DataRow(2021, 8, 9, 19, 00, false)]//mo
        [DataRow(2021, 8, 9, 19, 01, false)]//mo

        [DataRow(2021, 8, 14, 10, 29, false)]//sa
        [DataRow(2021, 8, 14, 10, 30, true)]//sa
        [DataRow(2021, 8, 14, 10, 31, true)]//sa
        [DataRow(2021, 8, 14, 13, 59, true)]//sa
        [DataRow(2021, 8, 14, 14, 00, false)]//sa
        [DataRow(2021, 8, 14, 14, 01, false)]//sa

        [DataRow(2021, 8, 15, 12, 00, false)]//so
        public void IsOpen(int y, int M, int d, int h, int m, bool expected)
        {
            var oh = new OpeningHours();

            Assert.AreEqual(expected, oh.IsOpen(new DateTime(y, M, d, h, m, 0)));
        }

        [TestMethod]
        public void IsOpenNow()
        {
            var oh = new OpeningHours();

            using (ShimsContext.Create())
            {
                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2021, 8, 9, 11, 00, 00);
                Assert.IsTrue(oh.IsOpenNow()); //mo 11:00

                System.Fakes.ShimDateTime.NowGet = () => new DateTime(2021, 8, 15, 12, 00, 00);
                Assert.IsFalse(oh.IsOpenNow()); //so
            }
        }

        [TestMethod]
        public void IsFileExisting()
        {
            using (ShimsContext.Create())
            {
                System.IO.Fakes.ShimFile.ExistsString = (fn) => true;

                Assert.IsTrue(File.Exists(@"a:\lwejfnhewkjn.fzgt"));
            }
        }
    }
}
