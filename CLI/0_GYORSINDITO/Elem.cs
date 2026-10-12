using System;
using System.Globalization;

namespace Gyorsindito
{
    // =====================================================================
    // SABLON OSZTÁLY. Vizsgán:
    //   1. Nevezd át az osztályt (pl. Auto): kattints a nevére -> Ctrl+R, Ctrl+R -> új név
    //      (így MINDENHOL átíródik, a Program.cs-ben is).
    //   2. Írd át a tulajdonságokat a fájl fejléce szerint.
    //   3. A konstruktorban igazítsd az indexeket (m[0], m[1]...) a fejléc sorrendjéhez.
    // =====================================================================
    internal class Elem
    {
        public int Id { get; set; }               // egész szám     -> int.Parse
        public string Nev { get; set; }           // szöveg         -> nem kell átalakítani
        public string Kategoria { get; set; }
        public double Ertek { get; set; }         // tört szám      -> double.Parse(..., InvariantCulture)
        public DateTime Datum { get; set; }       // dátum          -> DateTime.ParseExact
        public bool Aktiv { get; set; }           // 1/0 vagy igaz/hamis -> összehasonlítás

        public Elem(string sor)
        {
            string[] m = sor.Split(';');          // elválasztó: ; (ha tabulátor: '\t', ha vessző: ',')

            Id = int.Parse(m[0]);
            Nev = m[1];
            Kategoria = m[2];
            Ertek = double.Parse(m[3], CultureInfo.InvariantCulture);   // a fájlban PONT a tizedesjel
            Datum = DateTime.ParseExact(m[4], "yyyy-MM-dd", CultureInfo.InvariantCulture);
            Aktiv = m[5] == "1";

            // Ha egy mezőcsoport külön osztály (pl. Gyarto: ID + név):
            // Gyarto = new Gyarto(int.Parse(m[2]), m[3]);
        }

        // Metódus az osztályban: ha a feladat azt kéri, hogy az osztály számoljon ki valamit.
        // Kerekítés "rendesen" (2,345 -> 2,35): MidpointRounding.AwayFromZero
        public double BruttoErtek()
        {
            return Math.Round(Ertek * 1.27, 2, MidpointRounding.AwayFromZero);
        }

        // ToString override: a Console.WriteLine(elem) ezt írja ki. A MINTÁT kövesd betűre!
        public override string ToString()
        {
            return $"{Id}\n\tNév: {Nev}\n\tKategória: {Kategoria}\n\tÉrték: {Ertek:F2}\n\tDátum: {Datum:yyyy.MM.dd.}";
        }
    }
}
