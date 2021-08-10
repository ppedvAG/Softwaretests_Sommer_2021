using Microsoft.VisualStudio.TestTools.UnitTesting;
using ppedv.Blumenklavier.Model;
using System;

namespace ppedv.Blumenklavier.Data.EFCore.Tests
{
    [TestClass]
    public class EfContextTests
    {
        [TestMethod]
        public void Can_create_db()
        {
            var con = new EfContext();
            con.Database.EnsureDeleted();

            Assert.IsTrue(con.Database.EnsureCreated());
        }

        [TestMethod]
        public void Can_CRUD_Blume()
        {
            var b = new Blume() { Farbe = "rot", Art = $"Tulpe_{Guid.NewGuid()}", Welkigkeit = 4 };
            string newArt = $"Rose_{Guid.NewGuid()}";

            //CREATE
            using (var con = new EfContext())
            {
                con.Add(b);
                con.SaveChanges();
            }

            //check CREATE / READ
            using (var con = new EfContext())
            {
                var loaded = con.Blumen.Find(b.Id);
                Assert.IsNotNull(loaded);
                Assert.AreEqual(b.Art, loaded.Art);

                //UPDATE
                loaded.Art = newArt;
                con.SaveChanges();
            }

            //check UPDATE
            using (var con = new EfContext())
            {
                var loaded = con.Blumen.Find(b.Id);
                Assert.AreEqual(newArt, loaded.Art);

                //DELETE
                con.Blumen.Remove(loaded);
                con.SaveChanges();
            }

            //check DELETE
            using (var con = new EfContext())
            {
                var loaded = con.Blumen.Find(b.Id);
                Assert.IsNull(loaded);
            }
        }

    }
}
