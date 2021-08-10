using ppedv.Blumenklavier.Model;
using ppedv.Blumenklavier.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ppedv.Blumenklavier.Logic.Tests
{
    class TestRepository : IRepository
    {
        public void Add<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            if (typeof(T) == typeof(Klavier))
            {
                var k1 = new Klavier() { AnzahlTasten = 12, Hersteller = "K1" };
                var k2 = new Klavier() { AnzahlTasten = 14, Hersteller = "K2" };
                var k3 = new Klavier() { AnzahlTasten = 13, Hersteller = "K3" };
                return new[] { k1, k2, k3 }.Cast<T>();
            }

            throw new NotImplementedException();
        }

        public T GetById<T>(int id) where T : Entity
        {
            throw new NotImplementedException();
        }

        public int SaveAll()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }
    }
}
