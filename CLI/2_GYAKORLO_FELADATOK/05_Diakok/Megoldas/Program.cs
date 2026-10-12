using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DiakKonzol
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // ------------------------------------------------------------------
            // 3. feladat: beolvasás + létszám
            // ------------------------------------------------------------------
            List<Diak> diakok = new List<Diak>();
            foreach (string sor in File.ReadAllLines("diakok.txt").Skip(1))
            {
                diakok.Add(new Diak(sor));
            }
            Console.WriteLine($"3. feladat: Diákok száma: {diakok.Count}");

            // ------------------------------------------------------------------
            // 4. feladat: a legjobb átlagú diák(ok) -- HOLTVERSENY lehetséges!
            // ------------------------------------------------------------------
            // Ha a feladat NEM mondja, hogy "feltételezheti, hogy csak egy ilyen van",
            // akkor két lépés: 1) megkeressük a legnagyobb értéket, 2) kiírjuk az ÖSSZES ilyet.
            double legjobbAtlag = diakok.Max(d => d.Atlag());
            Console.WriteLine($"4. feladat: Legjobb átlag: {legjobbAtlag:F2}");
            foreach (Diak d in diakok.Where(d => d.Atlag() == legjobbAtlag))
            {
                Console.WriteLine($"\t{d.Nev} ({d.Osztaly})");
            }

            // ------------------------------------------------------------------
            // 5. feladat: osztályonként a létszám és az osztályátlag
            // ------------------------------------------------------------------
            // Osztályátlag itt = a diákok átlagainak átlaga.
            Console.WriteLine("5. feladat: Osztályok:");
            foreach (var cs in diakok.GroupBy(d => d.Osztaly).OrderBy(cs => cs.Key))
            {
                double osztalyAtlag = cs.Average(d => d.Atlag());
                Console.WriteLine($"\t{cs.Key}: {cs.Count()} fő, átlag: {osztalyAtlag:F2}");
            }

            // ------------------------------------------------------------------
            // 6. feladat: akiknek van elégtelen (1-es) jegye
            // ------------------------------------------------------------------
            List<Diak> bukasVeszely = diakok.Where(d => d.VanEgyese()).ToList();
            Console.WriteLine($"6. feladat: Elégtelent kapott diákok ({bukasVeszely.Count} fő):");
            foreach (Diak d in bukasVeszely)
            {
                // string.Join: a jegyek listáját "4, 1, 3" formában írja ki
                Console.WriteLine($"\t{d.Nev}: {string.Join(", ", d.Jegyek)}");
            }

            // ------------------------------------------------------------------
            // 7. feladat: névrészlet bekérése, kis/nagybetű NEM számít
            // ------------------------------------------------------------------
            Console.Write("7. feladat: Kérek egy névrészletet: ");
            string resz = Console.ReadLine().ToLower();
            // Mindkét oldalt kisbetűsre alakítjuk, és Contains-szal keresünk benne.
            List<Diak> talalatok = diakok.Where(d => d.Nev.ToLower().Contains(resz)).ToList();
            if (talalatok.Count == 0)
            {
                Console.WriteLine("\tNincs találat.");
            }
            else
            {
                foreach (Diak d in talalatok)
                {
                    Console.WriteLine($"\t{d.Nev} ({d.Osztaly}), átlag: {d.Atlag():F2}");
                }
            }

            // ------------------------------------------------------------------
            // 8. feladat: a legtöbbet hiányzó diák(ok) -- megint holtverseny-kezelés
            // ------------------------------------------------------------------
            int maxHianyzas = diakok.Max(d => d.Hianyzas);
            // Select-tel csak a neveket vesszük ki, string.Join-nal egy sorba fűzzük őket.
            List<string> nevek = diakok.Where(d => d.Hianyzas == maxHianyzas).Select(d => d.Nev).ToList();
            Console.WriteLine($"8. feladat: Legtöbb hiányzás ({maxHianyzas} óra): {string.Join(", ", nevek)}");

            // ------------------------------------------------------------------
            // 9. feladat: kitűnő tanulók -> kitunok.txt
            // ------------------------------------------------------------------
            List<string> kitunoSorok = diakok
                .Where(d => d.Kituno())
                .Select(d => $"{d.Nev};{d.Osztaly}")
                .ToList();
            File.WriteAllLines("kitunok.txt", kitunoSorok);
            Console.WriteLine($"9. feladat: kitunok.txt elkészült, {kitunoSorok.Count} kitűnő tanuló.");

            // ------------------------------------------------------------------
            // 10. feladat: jegyek eloszlása (hány 5-ös, 4-es, ... volt összesen)
            // ------------------------------------------------------------------
            // TÖMB MINT SZÁMLÁLÓ: db[5] = ötösök száma, db[4] = négyesek száma...
            // 6 elemű tömb, hogy az 5-ös index is létezzen (0..5); a 0. elemet nem használjuk.
            int[] db = new int[6];
            foreach (Diak d in diakok)
            {
                foreach (int jegy in d.Jegyek)
                {
                    db[jegy]++;   // a jegy maga az index
                }
            }
            Console.WriteLine("10. feladat: Jegyek eloszlása:");
            for (int jegy = 5; jegy >= 1; jegy--)
            {
                Console.WriteLine($"\t{jegy}-es: {db[jegy]} db");
            }
        }
    }
}
