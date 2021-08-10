namespace ppedv.Blumenklavier.Model
{
    public class Blume : Entity
    {
        public string Art { get; set; }
        public string Farbe { get; set; }
        public int Welkigkeit { get; set; }
        public virtual Klavier Klavier { get; set; }
    }

}
