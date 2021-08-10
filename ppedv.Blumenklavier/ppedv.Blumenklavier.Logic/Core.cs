using ppedv.Blumenklavier.Data.EFCore;
using ppedv.Blumenklavier.Model;
using System;
using System.Linq;

namespace ppedv.Blumenklavier.Logic
{
    public class Core
    {

        public int GetAllowedPlantCountForAllOfDatabase()
        {
            using (var con = new EfContext())
            {
                return con.Klaviere.ToList().Sum(x => GetAllowedPlantCount(x));
            }
        }

        public int GetAllowedPlantCount(Klavier klavier)
        {
            if (klavier == null)
                throw new ArgumentNullException(nameof(klavier));

            return klavier.AnzahlTasten / 3;
        }
    }
}
