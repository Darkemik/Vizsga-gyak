namespace RendelesGUI
{
    // Egy sor a kinalat.txt-ben = egy termék.
    internal class Termek
    {
        public string Nev { get; set; }
        public string Kategoria { get; set; }
        public int Ar { get; set; }
        public bool Laktozmentes { get; set; }
        public bool Cukormentes { get; set; }

        public Termek(string sor)
        {
            string[] m = sor.Split(';');
            Nev = m[0];
            Kategoria = m[1];
            Ar = int.Parse(m[2]);
            Laktozmentes = m[3] == "1";    // "1" -> true, "0" -> false
            Cukormentes = m[4] == "1";
        }

        // Ez jelenik meg a ListBoxban, mert OBJEKTUMOT teszünk bele (lbKinalat.Items.Add(t)).
        public override string ToString()
        {
            return $"{Nev} ({Kategoria}) - {Ar} Ft";
        }
    }
}
