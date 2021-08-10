using System.Collections.Generic;

namespace ppedv.Blumenklavier.Model
{
    public class Klavier : Entity
    {
        public string Hersteller { get; set; }
        public string Model { get; set; }
        public string Farbe { get; set; }
        public int AnzahlTasten { get; set; }
        public int Gewicht { get; set; }
        public virtual ICollection<Blume> Blumen { get; set; } = new HashSet<Blume>();
    }

}
