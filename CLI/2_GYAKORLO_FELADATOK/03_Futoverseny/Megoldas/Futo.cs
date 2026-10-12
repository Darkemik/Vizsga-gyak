using System;
using System.Globalization;

namespace FutasKonzol
{
    internal class Futo
    {
        public int Rajtszam { get; set; }
        public string Nev { get; set; }
        public string Egyesulet { get; set; }
        public string Kategoria { get; set; }
        public string Nem { get; set; }       // "F" = férfi, "N" = nő
        public TimeSpan Ido { get; set; }     // időtartam (óra:perc:mp) -> TimeSpan típus

        public Futo(string sor)
        {
            string[] m = sor.Split(';');
            Rajtszam = int.Parse(m[0]);
            Nev = m[1];
            Egyesulet = m[2];
            Kategoria = m[3];
            Nem = m[4];

            // IDŐTARTAM BEOLVASÁSA (1_TECHNIKAK/16): "01:23:45" -> TimeSpan
            // A TimeSpan-okat lehet összehasonlítani (<, >), rendezni és kivonni is.
            Ido = TimeSpan.Parse(m[5], CultureInfo.InvariantCulture);
        }

        // Tulajdonság számítással: igaz, ha a futó nő. Így a lekérdezésekben
        // f.NoiFuto-t írhatunk f.Nem == "N" helyett.
        public bool NoiFuto
        {
            get { return Nem == "N"; }
        }

        // ToString override: egy sorban, oszlopokba igazítva.
        // {Nev,-22} = 22 karakter szélesen balra igazítva, {Rajtszam,4} = 4 szélesen jobbra.
        // A TimeSpan alapból "01:23:45" formában íródik ki, ezért itt nem kell formátum.
        public override string ToString()
        {
            return $"{Rajtszam,4}  {Nev,-18} {Egyesulet,-20} {Ido}";
        }
    }
}
