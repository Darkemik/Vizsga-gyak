using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace IngatlanKonzol
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // ------------------------------------------------------------------
            // 3. feladat: beolvasás + darabszám
            // ------------------------------------------------------------------
            List<Ingatlan> ingatlanok = new List<Ingatlan>();
            foreach (string sor in File.ReadAllLines("ingatlanok.csv").Skip(1))
            {
                ingatlanok.Add(new Ingatlan(sor));
            }
            Console.WriteLine($"3. feladat: Hirdetések száma: {ingatlanok.Count}");

            // ------------------------------------------------------------------
            // 4. feladat: átlagos alapterület 2 tizedesre
            // ------------------------------------------------------------------
            // Average mindig double-t ad. Kiírásnál a :F2 két tizedesre kerekítve írja ki.
            double atlagTerulet = ingatlanok.Average(i => i.Alapterulet);
            Console.WriteLine($"4. feladat: Átlagos alapterület: {atlagTerulet:F2} m²");

            // ------------------------------------------------------------------
            // 5. feladat: a legolcsóbb kiemelt ház
            // ------------------------------------------------------------------
            // Két feltétel a szűrésben, utána növekvő rendezés ár szerint, és az első.
            Ingatlan legolcsobbHaz = ingatlanok
                .Where(i => i.Kategoria == "Haz" && i.Kiemelt)
                .OrderBy(i => i.Ar)
                .First();
            Console.WriteLine("5. feladat: A legolcsóbb kiemelt ház:");
            Console.WriteLine($"\t{legolcsobbHaz}");

            // ------------------------------------------------------------------
            // 6. feladat: hány különböző település van, és melyek ezek (ABC sorrendben)
            // ------------------------------------------------------------------
            // Select: csak a település nevét vesszük ki, Distinct: az ismétlődéseket eldobja.
            List<string> telepulesek = ingatlanok
                .Select(i => i.Telepules)
                .Distinct()
                .OrderBy(t => t)
                .ToList();
            // string.Join(", ", lista): a lista elemeit vesszővel elválasztva egy szöveggé fűzi.
            Console.WriteLine($"6. feladat: {telepulesek.Count} település: {string.Join(", ", telepulesek)}");

            // ------------------------------------------------------------------
            // 7. feladat: kategóriánként a darabszám és az átlagár
            // ------------------------------------------------------------------
            Console.WriteLine("7. feladat: Statisztika kategóriánként:");
            foreach (var cs in ingatlanok.GroupBy(i => i.Kategoria).OrderBy(cs => cs.Key))
            {
                double atlagAr = cs.Average(i => i.Ar);
                Console.WriteLine($"\t{cs.Key,-7} {cs.Count(),3} db, átlagár: {atlagAr,15:N0} Ft");
            }

            // ------------------------------------------------------------------
            // 8. feladat: melyik eladónak van a legtöbb hirdetése?
            // ------------------------------------------------------------------
            // Itt a "klasszikus" Dictionary-s számlálást mutatjuk (1_TECHNIKAK/19).
            // Kulcs = eladó neve, érték = hány hirdetése van.
            Dictionary<string, int> eladoDb = new Dictionary<string, int>();
            foreach (Ingatlan i in ingatlanok)
            {
                if (eladoDb.ContainsKey(i.Elado.Nev))
                    eladoDb[i.Elado.Nev]++;            // már van ilyen kulcs -> növeljük
                else
                    eladoDb[i.Elado.Nev] = 1;          // még nincs -> felvesszük 1-gyel
            }
            // A legnagyobb értékű pár: rendezés érték szerint csökkenőben, és az első.
            KeyValuePair<string, int> legtobb = eladoDb.OrderByDescending(p => p.Value).First();
            // Az eladó telefonszámát az első olyan ingatlanból vesszük, ahol ő az eladó.
            string telefon = ingatlanok.First(i => i.Elado.Nev == legtobb.Key).Elado.Telefon;
            Console.WriteLine($"8. feladat: Legtöbb hirdetés: {legtobb.Key} ({telefon}), {legtobb.Value} db");
            // Ugyanez GroupBy-jal:
            // var top = ingatlanok.GroupBy(i => i.Elado.Nev).OrderByDescending(cs => cs.Count()).First();

            // ------------------------------------------------------------------
            // 9. feladat: van-e Budapesten 50 millió Ft alatti lakás? Ha igen, a legolcsóbb.
            // ------------------------------------------------------------------
            bool van = ingatlanok.Any(i => i.Telepules == "Budapest" && i.Kategoria == "Lakas" && i.Ar < 50_000_000);
            if (van)
            {
                Ingatlan olcso = ingatlanok
                    .Where(i => i.Telepules == "Budapest" && i.Kategoria == "Lakas")
                    .OrderBy(i => i.Ar)
                    .First();
                Console.WriteLine($"9. feladat: Van, a legolcsóbb: {olcso}");
            }
            else
            {
                Console.WriteLine("9. feladat: Nincs ilyen lakás.");
            }

            // ------------------------------------------------------------------
            // 10. feladat: 1 millió Ft/m² feletti ingatlanok -> dragak.txt
            // ------------------------------------------------------------------
            List<string> dragaSorok = ingatlanok
                .Where(i => i.NegyzetmeterAr() > 1_000_000)
                .OrderByDescending(i => i.NegyzetmeterAr())
                .Select(i => $"{i.Id};{i.Telepules};{i.Alapterulet};{i.NegyzetmeterAr()}")
                .ToList();
            File.WriteAllLines("dragak.txt", dragaSorok);
            Console.WriteLine($"10. feladat: dragak.txt elkészült, {dragaSorok.Count} ingatlan.");
        }
    }
}
