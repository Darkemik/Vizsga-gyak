using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace KonyvtarKonzol
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // A "mai nap" rögzítve, hogy a minta kimenet mindig ugyanaz legyen.
            // Vizsgán: ha a feladat ad dátumot, azt írd ide; különben DateTime.Today.
            DateTime ma = new DateTime(2026, 10, 12);

            // ------------------------------------------------------------------
            // 3. feladat: beolvasás + darabszám
            // ------------------------------------------------------------------
            List<Kolcsonzes> lista = new List<Kolcsonzes>();
            foreach (string sor in File.ReadAllLines("kolcsonzesek.csv").Skip(1))
            {
                lista.Add(new Kolcsonzes(sor));
            }
            Console.WriteLine($"3. feladat: Kölcsönzések száma: {lista.Count}");

            // ------------------------------------------------------------------
            // 4. feladat: hány könyv nincs még visszahozva?
            // ------------------------------------------------------------------
            // A "!" tagadás: !k.Visszahozta = NINCS visszahozva.
            int kintVan = lista.Count(k => !k.Visszahozta);
            Console.WriteLine($"4. feladat: Még vissza nem hozott könyvek: {kintVan} db");

            // ------------------------------------------------------------------
            // 5. feladat: a leghosszabb (már visszahozott) kölcsönzés
            // ------------------------------------------------------------------
            // Először szűrünk (Where), utána rendezünk csökkenőben a napok szerint, és az első kell.
            Kolcsonzes leghosszabb = lista
                .Where(k => k.Visszahozta)
                .OrderByDescending(k => k.KintNapok(ma))
                .First();
            Console.WriteLine("5. feladat: A leghosszabb kölcsönzés:");
            Console.WriteLine($"\tOlvasó: {leghosszabb.Olvaso}");
            Console.WriteLine($"\tKönyv: {leghosszabb.Szerzo}: {leghosszabb.Cim}");
            Console.WriteLine($"\tIdőtartam: {leghosszabb.KintNapok(ma)} nap");

            // ------------------------------------------------------------------
            // 6. feladat: kölcsönzések száma hónaponként
            // ------------------------------------------------------------------
            // GroupBy a hónap SZÁMA szerint (1..12), utána OrderBy a Key-re, hogy sorban legyenek.
            Console.WriteLine("6. feladat: Kölcsönzések hónaponként:");
            var honaponkent = lista
                .GroupBy(k => k.KolcsonzesDatum.Month)
                .OrderBy(cs => cs.Key);
            foreach (var cs in honaponkent)
            {
                // A hónap neve: csinálunk belőle egy dátumot, és "MMMM" formában kiírjuk (pl. január).
                string honapNev = new DateTime(2026, cs.Key, 1).ToString("MMMM");
                Console.WriteLine($"\t{honapNev,-12} {cs.Count()} db");
            }

            // ------------------------------------------------------------------
            // 7. feladat: olvasó bekérése, és a kölcsönzései
            // ------------------------------------------------------------------
            Console.Write("7. feladat: Kérem az olvasó nevét: ");
            string nev = Console.ReadLine();

            // Először kigyűjtjük a találatokat egy listába, és megnézzük, üres-e.
            List<Kolcsonzes> talalatok = lista.Where(k => k.Olvaso == nev).ToList();
            if (talalatok.Count == 0)
            {
                Console.WriteLine("\tNincs ilyen olvasó.");
            }
            else
            {
                foreach (Kolcsonzes k in talalatok)
                {
                    // Dátum kiírása magyar formában: "yyyy.MM.dd." -> 2026.03.14.
                    string allapot = k.Visszahozta ? "visszahozva" : "még nála van";
                    Console.WriteLine($"\t{k.KolcsonzesDatum:yyyy.MM.dd.} {k.Cim} ({allapot})");
                }
            }

            // ------------------------------------------------------------------
            // 8. feladat: a legnépszerűbb könyv (legtöbbször kölcsönözték)
            // ------------------------------------------------------------------
            // GroupBy cím szerint -> rendezés a csoport mérete szerint csökkenőben -> az első.
            var legnepszerubb = lista
                .GroupBy(k => k.Cim)
                .OrderByDescending(cs => cs.Count())
                .First();
            // A csoport első eleméből kiolvashatjuk a szerzőt is.
            Console.WriteLine($"8. feladat: A legnépszerűbb könyv: {legnepszerubb.First().Szerzo}: " +
                              $"{legnepszerubb.Key} ({legnepszerubb.Count()} alkalommal)");

            // ------------------------------------------------------------------
            // 9. feladat: késésben lévő könyvek (több mint 30 napja kint) -> kesesek.txt
            // ------------------------------------------------------------------
            List<string> kesesSorok = lista
                .Where(k => !k.Visszahozta && k.KintNapok(ma) > 30)
                .OrderByDescending(k => k.KintNapok(ma))
                .Select(k => $"{k.Olvaso};{k.Cim};{k.KintNapok(ma)}")
                .ToList();
            File.WriteAllLines("kesesek.txt", kesesSorok);
            Console.WriteLine($"9. feladat: kesesek.txt elkészült, {kesesSorok.Count} késésben lévő könyv.");
        }
    }
}
