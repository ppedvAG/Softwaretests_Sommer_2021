using ppedv.Blumenklavier.Data.EFCore;
using ppedv.Blumenklavier.Model;
using ppedv.Blumenklavier.Model.Contracts;
using System;
using System.Linq;

namespace ppedv.Blumenklavier.Logic
{
    public class Core
    {
        public IRepository Repository { get; }

        public Core(IRepository repository)
        {
            Repository = repository;
        }

        public int GetAllowedPlantCountForAllOfDatabase()
        {
            return Repository.GetAll<Klavier>().Sum(x => GetAllowedPlantCount(x));
        }

        public virtual int GetAllowedPlantCount(Klavier klavier)
        {
            if (klavier == null)
                throw new ArgumentNullException(nameof(klavier));

            return klavier.AnzahlTasten / 3;
        }

        public virtual int GetMagicNumer()
        {
            return 5;
        }
    }
}
