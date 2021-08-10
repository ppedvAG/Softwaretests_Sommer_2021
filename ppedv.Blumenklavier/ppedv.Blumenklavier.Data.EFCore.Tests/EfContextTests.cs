using AutoFixture;
using AutoFixture.Kernel;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ppedv.Blumenklavier.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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


        [TestMethod]
        public void Can_Create_Read_Klavier_AutoFix_and_FluentAssertions()
        {
            var fix = new Fixture();
            fix.Customizations.Add(new PropertyNameOmitter("Id"));
            fix.Behaviors.Add(new OmitOnRecursionBehavior());

            var klavier = fix.Build<Blume>().With(x => x.Farbe, $"Farbe{Guid.NewGuid().ToString().Substring(0, 10)}")
                             .Create<Klavier>();

            using (var con = new EfContext())
            {
                con.Add(klavier);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Klaviere.Find(klavier.Id);

                loaded.Should().BeEquivalentTo(klavier, cfg => cfg.IgnoringCyclicReferences());
            }

        }
    }


    internal class PropertyNameOmitter : ISpecimenBuilder
    {
        private readonly IEnumerable<string> names;

        internal PropertyNameOmitter(params string[] names)
        {
            this.names = names;
        }

        public object Create(object request, ISpecimenContext context)
        {
            var propInfo = request as PropertyInfo;
            if (propInfo != null && names.Contains(propInfo.Name))
                return new OmitSpecimen();

            return new NoSpecimen();
        }
    }
}
