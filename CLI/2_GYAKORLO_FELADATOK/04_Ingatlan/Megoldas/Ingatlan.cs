using System;
using System.Globalization;

namespace IngatlanKonzol
{
    internal class Ingatlan
    {
        public int Id { get; set; }
        public string Kategoria { get; set; }    // Lakas, Haz, Sorhaz
        public string Telepules { get; set; }
        public int Alapterulet { get; set; }      // m²
        public int Szobak { get; set; }
        public int Ar { get; set; }               // Ft (egész szám; 2 milliárdig elfér az int-ben)
        public DateTime Hirdetve { get; set; }
        public bool Kiemelt { get; set; }         // a fájlban 1 vagy 0
        public Elado Elado { get; set; }

        public Ingatlan(string sor)
        {
            string[] m = sor.Split(';');
            Id = int.Parse(m[0]);
            Kategoria = m[1];
            Telepules = m[2];
            Alapterulet = int.Parse(m[3]);
            Szobak = int.Parse(m[4]);
            Ar = int.Parse(m[5]);
            Hirdetve = DateTime.ParseExact(m[6], "yyyy-MM-dd", CultureInfo.InvariantCulture);

            // LOGIKAI ÉRTÉK "1"/"0"-ból: az összehasonlítás eredménye maga a bool.
            // (Ha a fájlban "true"/"false" vagy "igaz"/"hamis" van, akkor azt hasonlítsd!)
            Kiemelt = m[7] == "1";

            Elado = new Elado(int.Parse(m[8]), m[9], m[10]);
        }

        // Metódus az osztályban (1_TECHNIKAK/18): négyzetméterár.
        // VIGYÁZAT: int / int = EGÉSZ osztás (a tört rész elveszik)!
        // Ha tört eredmény kell, az egyiket alakítsd double-lé: (double)Ar / Alapterulet
        public int NegyzetmeterAr()
        {
            return Ar / Alapterulet;   // itt szándékosan egész Ft/m² kell
        }

        public override string ToString()
        {
            // {Ar:N0} = ezres tagolás (magyar gépen szóközzel: 53 900 000)
            return $"#{Id} {Kategoria}, {Telepules}, {Alapterulet} m², {Szobak} szoba, " +
                   $"{Ar:N0} Ft (eladó: {Elado.Nev}, {Elado.Telefon})";
        }
    }
}
