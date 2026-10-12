using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FutasKonzol
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // ------------------------------------------------------------------
            // 3. feladat: beolvasás + létszám
            // ------------------------------------------------------------------
            List<Futo> futok = new List<Futo>();
            foreach (string sor in File.ReadAllLines("eredmenyek.txt").Skip(1))
            {
                futok.Add(new Futo(sor));
            }
            Console.WriteLine($"3. feladat: Célba érkezett futók száma: {futok.Count}");

            // Egyszer rendezzük idő szerint növekvőbe, és ezt a listát használjuk
            // a helyezésekhez (győztes, dobogó, rajtszám szerinti keresés).
            List<Futo> sorrend = futok.OrderBy(f => f.Ido).ToList();

            // ------------------------------------------------------------------
            // 4. feladat: a győztes = a legrövidebb idő
            // ------------------------------------------------------------------
            Futo gyoztes = sorrend[0];   // a rendezett lista első eleme (ugyanaz, mint sorrend.First())
            Console.WriteLine($"4. feladat: A győztes: {gyoztes.Nev} ({gyoztes.Egyesulet}), ideje: {gyoztes.Ido}");

            // ------------------------------------------------------------------
            // 5. feladat: a dobogósok (első 3)
            // ------------------------------------------------------------------
            // Take(3) = az első 3 elem. Sima for ciklus, mert a helyezés számát (i + 1) is ki kell írni.
            Console.WriteLine("5. feladat: Dobogósok:");
            List<Futo> dobogo = sorrend.Take(3).ToList();
            for (int i = 0; i < dobogo.Count; i++)
            {
                Console.WriteLine($"\t{i + 1}. hely: {dobogo[i]}");   // itt a ToString() fut le
            }

            // ------------------------------------------------------------------
            // 6. feladat: átlagidő
            // ------------------------------------------------------------------
            // TimeSpan-ra nincs közvetlen Average, ezért MÁSODPERCBEN átlagolunk (TotalSeconds),
            // kerekítjük egész másodpercre, és visszaalakítjuk TimeSpan-ná.
            double atlagMp = futok.Average(f => f.Ido.TotalSeconds);
            TimeSpan atlagIdo = TimeSpan.FromSeconds(Math.Round(atlagMp));
            Console.WriteLine($"6. feladat: Átlagos idő: {atlagIdo}");

            // ------------------------------------------------------------------
            // 7. feladat: kategóriánként a létszám és a legjobb idő
            // ------------------------------------------------------------------
            Console.WriteLine("7. feladat: Kategóriák:");
            var kategoriak = futok
                .GroupBy(f => f.Kategoria)
                .OrderBy(cs => cs.Key);              // ABC sorrend a kategória neve szerint
            foreach (var cs in kategoriak)
            {
                TimeSpan legjobb = cs.Min(f => f.Ido);   // a csoporton belüli legkisebb idő
                Console.WriteLine($"\t{cs.Key,-8} {cs.Count(),2} fő, legjobb idő: {legjobb}");
            }

            // ------------------------------------------------------------------
            // 8. feladat: rajtszám bekérése -> helyezés és idő
            // ------------------------------------------------------------------
            Console.Write("8. feladat: Kérek egy rajtszámot: ");
            int rajtszam = int.Parse(Console.ReadLine());

            // FindIndex: a rendezett listában hányadik helyen van (0-tól számol!), -1 ha nincs.
            int index = sorrend.FindIndex(f => f.Rajtszam == rajtszam);
            if (index == -1)
            {
                Console.WriteLine("\tNincs ilyen rajtszám.");
            }
            else
            {
                Futo f = sorrend[index];
                Console.WriteLine($"\t{f.Nev}: {index + 1}. helyezés, idő: {f.Ido}");
            }

            // ------------------------------------------------------------------
            // 9. feladat: van-e 1 óra 15 percen belül célba ért női futó?
            // ------------------------------------------------------------------
            // TimeSpan létrehozása: new TimeSpan(óra, perc, másodperc)
            TimeSpan hatar = new TimeSpan(1, 15, 0);
            bool vanIlyen = futok.Any(f => f.NoiFuto && f.Ido < hatar);
            Console.WriteLine($"9. feladat: {(vanIlyen ? "Van" : "Nincs")} 1:15:00-nál gyorsabb női futó.");

            // ------------------------------------------------------------------
            // 10. feladat: egyesületenként a futók száma -> egyesuletek.txt
            // ------------------------------------------------------------------
            // Csökkenő létszám; azonos létszámnál ABC sorrend (ThenBy = másodlagos rendezés).
            List<string> egyesuletSorok = futok
                .GroupBy(f => f.Egyesulet)
                .OrderByDescending(cs => cs.Count())
                .ThenBy(cs => cs.Key)
                .Select(cs => $"{cs.Key};{cs.Count()}")
                .ToList();
            File.WriteAllLines("egyesuletek.txt", egyesuletSorok);
            Console.WriteLine("10. feladat: egyesuletek.txt elkészült.");
        }
    }
}
