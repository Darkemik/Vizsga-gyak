namespace ErmekGUI
{
    // Egy sor a fájlban = egy iskola eredménye egy adott évben.
    internal class Eredmeny
    {
        public int Id { get; set; }
        public string Iskola { get; set; }
        public string Varos { get; set; }
        public int Ev { get; set; }
        public int Arany { get; set; }
        public int Ezust { get; set; }
        public int Bronz { get; set; }

        public Eredmeny(string sor)
        {
            // FIGYELEM: ebben a fájlban TABULÁTOR az elválasztó -> '\t'
            string[] m = sor.Split('\t');
            Id = int.Parse(m[0]);
            Iskola = m[1];
            Varos = m[2];
            Ev = int.Parse(m[3]);
            Arany = int.Parse(m[4]);
            Ezust = int.Parse(m[5]);
            Bronz = int.Parse(m[6]);
        }

        // Összes érem (ha a feladat kérné)
        public int Osszes()
        {
            return Arany + Ezust + Bronz;
        }
    }
}
