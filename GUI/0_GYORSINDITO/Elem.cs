using System;
using System.Globalization;

namespace Gyorsindito
{
    // SABLON OSZTÁLY: vizsgán nevezd át (kattints a nevére -> Ctrl+R, Ctrl+R),
    // és írd át a mezőket a fájl fejléce szerint. Ugyanaz, mint a CLI gyorsindítóban.
    internal class Elem
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        public string Kategoria { get; set; }
        public double Ar { get; set; }
        public DateTime Datum { get; set; }
        public bool Aktiv { get; set; }

        public Elem(string sor)
        {
            string[] m = sor.Split(';');            // tabulátornál: sor.Split('\t')
            Id = int.Parse(m[0]);
            Nev = m[1];
            Kategoria = m[2];
            Ar = double.Parse(m[3].Replace(',', '.'), CultureInfo.InvariantCulture);
            Datum = DateTime.ParseExact(m[4], "yyyy-MM-dd", CultureInfo.InvariantCulture);
            Aktiv = m[5] == "1";
        }

        // Ez jelenik meg a ListBoxban / ComboBoxban, ha OBJEKTUMOT teszel bele.
        public override string ToString()
        {
            return $"{Nev} ({Kategoria}) - {Ar:F2} Ft";
        }
    }
}
