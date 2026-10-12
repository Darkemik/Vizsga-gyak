using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AutoKonzol   // 1. feladat: a projekt neve AutoKonzol
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Hogy az ékezetes betűk (á, é, ő...) jól jelenjenek meg a konzolon.
            Console.OutputEncoding = Encoding.UTF8;

            // ------------------------------------------------------------------
            // 4. feladat: beolvasás egy listába
            // ------------------------------------------------------------------
            // File.ReadAllLines: a fájl összes sora egy string-tömbbe.
            // .Skip(1): az első sort (fejléc, mezőnevek) kihagyjuk.
            // A fájlnak a program mellett kell lennie (bin\Debug\net8.0\), lásd 1_TECHNIKAK/17.
            List<Auto> autok = new List<Auto>();
            foreach (string sor in File.ReadAllLines("carsData.csv").Skip(1))
            {
                autok.Add(new Auto(sor));   // a konstruktor szedi szét a sort
            }

            // ------------------------------------------------------------------
            // 5. feladat: hány db Rolls-Royce, Sedan, 8 hengeres autó van?
            // ------------------------------------------------------------------
            // Count(feltétel): megszámolja, hány elemre igaz a feltétel.
            // Több feltétel: && (ÉS). Az "a" egy autót jelent a listából.
            int rrDb = autok.Count(a => a.Gyarto.GyartoNev == "Rolls-Royce"
                                     && a.Karosszeria.KarosszeriaNev == "Sedan"
                                     && a.HengerekSzama == 8);
            Console.WriteLine($"5. feladat: {rrDb} db Rolls-Royce, Sedan karosszériájú, 8 hengeres autót adtak el.");

            // ------------------------------------------------------------------
            // 6. feladat: a legdrágább autó, és az ára forintban
            // ------------------------------------------------------------------
            // OrderByDescending(ár) = csökkenő sorrend, .First() = az első, vagyis a legdrágább.
            // (Ugyanez rövidebben .NET 6-tól: autok.MaxBy(a => a.Ar))
            Auto legdragabb = autok.OrderByDescending(a => a.Ar).First();

            const double ARFOLYAM = 248.02;   // 1 kanadai dollár = 248,02 Ft
            // Egészre kerekítés: Math.Round(..., MidpointRounding.AwayFromZero), majd (long)-ra alakítás.
            // long, mert egy milliós ár szorozva 248-cal már nem fér el biztosan az int-ben.
            long arForintban = (long)Math.Round(legdragabb.Ar * ARFOLYAM, MidpointRounding.AwayFromZero);

            Console.WriteLine("6. feladat: A legdrágább autó:");
            // "A kiírás első részéhez használja a már elkészített virtuális metódust":
            // a Console.WriteLine(objektum) automatikusan a ToString()-et hívja.
            Console.WriteLine(legdragabb);
            Console.WriteLine($"\tÁra forintban: {arForintban} Ft");

            // ------------------------------------------------------------------
            // 7. feladat: F1-es márkák kiírása a forma-1.txt fájlba
            // ------------------------------------------------------------------
            // A keresett márkákat egy tömbbe tesszük, így a .Contains() megmondja, benne van-e.
            string[] f1Markak = { "Aston Martin", "Ferrari" };

            // Where = szűrés, Select = minden autóból egy szöveges sort készítünk.
            List<string> f1Sorok = autok
                .Where(a => f1Markak.Contains(a.Gyarto.GyartoNev))
                .Select(a => $"{a.Azonosito};{a.Gyarto.GyartoNev};{a.Modell};{a.Evjarat};{a.KilometeroraAllas}")
                .ToList();

            // File.WriteAllLines: minden lista-elem egy sor a fájlban.
            // A fájl a program mellé kerül (bin\Debug\net8.0\forma-1.txt).
            File.WriteAllLines("forma-1.txt", f1Sorok);
            // (A vizsgalapon ehhez nem volt képernyő-kiírás, ez csak ellenőrzés.)
            Console.WriteLine($"7. feladat: forma-1.txt kiírva, {f1Sorok.Count} sor.");

            // ==================================================================
            // EXTRA feladatok gyakorlásra (NEM voltak a vizsgalapon)
            // ==================================================================

            // 8. EXTRA: átlagár gyártónként, ár szerint csökkenő sorrendben (GroupBy, 1_TECHNIKAK/10)
            Console.WriteLine("8. feladat (extra): Átlagár gyártónként:");
            var gyartonkent = autok
                .GroupBy(a => a.Gyarto.GyartoNev)          // csoportok gyártó szerint
                .Select(cs => new
                {
                    Nev = cs.Key,                           // a csoport "kulcsa" = a gyártó neve
                    Db = cs.Count(),                        // hány autó van a csoportban
                    Atlag = cs.Average(a => a.Ar)           // a csoport átlagára
                })
                .OrderByDescending(x => x.Atlag);

            foreach (var g in gyartonkent)
            {
                // {g.Nev,-15}: 15 karakter szélesen, balra igazítva -> szép oszlopok
                Console.WriteLine($"\t{g.Nev,-15} {g.Db,2} db  {g.Atlag:F2} CAD");
            }

            // 9. EXTRA: gyártó bekérése, és van-e tőle autó (Console.ReadLine + Any, 1_TECHNIKAK/11, 12)
            Console.Write("9. feladat (extra): Kérek egy gyártót: ");
            string keresett = Console.ReadLine();
            // Any = van-e legalább egy olyan elem, amire igaz a feltétel (true/false)
            if (autok.Any(a => a.Gyarto.GyartoNev == keresett))
            {
                int db = autok.Count(a => a.Gyarto.GyartoNev == keresett);
                Console.WriteLine($"\t{keresett}: {db} db autó található.");
            }
            else
            {
                Console.WriteLine("\tNincs ilyen gyártó az adatok között.");
            }
        }
    }
}
