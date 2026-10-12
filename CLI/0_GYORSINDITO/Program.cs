using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Gyorsindito
{
    // =====================================================================
    // GYORSINDÍTÓ. Minden blokk MŰKÖDIK (le lehet futtatni).
    // Vizsgán: másold át a projektet, a nem kellő blokkokat töröld,
    // a kellőket írd át a saját mezőnevekre és a feladat szövegére.
    // A blokkok fölött "Ha a feladat ezt kéri:" mondja meg, mikor kell.
    // =====================================================================
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;   // ékezetek a konzolon

            // ---------------------------------------------------------------
            // [A] BEOLVASÁS
            // Ha a feladat ezt kéri: "Olvassa be az állomány adatait, tárolja egy összetett adatszerkezetben"
            // ---------------------------------------------------------------
            List<Elem> lista = new List<Elem>();
            foreach (string sor in File.ReadAllLines("adatok.csv").Skip(1))   // Skip(1) = fejléc kihagyása
            {
                lista.Add(new Elem(sor));
            }
            Console.WriteLine($"[A] Beolvasott sorok: {lista.Count}");

            // ---------------------------------------------------------------
            // [B] MEGSZÁMOLÁS
            // Ha a feladat ezt kéri: "Hány db ... van?", "Hány olyan ..., amelyik ..."
            // ---------------------------------------------------------------
            int db = lista.Count(e => e.Kategoria == "Gyumolcs" && e.Aktiv);   // && = ÉS, || = VAGY
            Console.WriteLine($"[B] Aktív gyümölcsök: {db} db");

            // ---------------------------------------------------------------
            // [C] ÖSSZEG, ÁTLAG
            // Ha a feladat ezt kéri: "Mennyi az összes ...", "Mennyi az átlagos ..."
            // ---------------------------------------------------------------
            double osszeg = lista.Sum(e => e.Ertek);
            double atlag = lista.Average(e => e.Ertek);
            // Szűrt átlag: előbb Where, utána Average
            double gyumolcsAtlag = lista.Where(e => e.Kategoria == "Gyumolcs").Average(e => e.Ertek);
            Console.WriteLine($"[C] Összeg: {osszeg:F2}, átlag: {atlag:F2}, gyümölcsátlag: {gyumolcsAtlag:F2}");

            // ---------------------------------------------------------------
            // [D] LEGNAGYOBB / LEGKISEBB ELEM (feltételezheted, hogy csak egy van)
            // Ha a feladat ezt kéri: "legdrágább", "legrégebbi", "legkisebb", "a legtöbb ..."
            // ---------------------------------------------------------------
            Elem legnagyobb = lista.OrderByDescending(e => e.Ertek).First();   // csökkenő -> első = legnagyobb
            Elem legkisebb = lista.OrderBy(e => e.Ertek).First();              // növekvő  -> első = legkisebb
            double maxErtek = lista.Max(e => e.Ertek);                          // ha csak az ÉRTÉK kell
            Console.WriteLine($"[D] Legnagyobb: {legnagyobb.Nev}, legkisebb: {legkisebb.Nev}, max érték: {maxErtek:F2}");
            Console.WriteLine("[D] A legnagyobb elem ToString-gel:");
            Console.WriteLine(legnagyobb);   // automatikusan a ToString() fut

            // ---------------------------------------------------------------
            // [E] HOLTVERSENY (több legnagyobb is lehet)
            // Ha a feladat NEM írja, hogy "feltételezheti, hogy csak egy ilyen van"
            // ---------------------------------------------------------------
            List<Elem> mindenMax = lista.Where(e => e.Ertek == maxErtek).ToList();
            Console.WriteLine($"[E] Legnagyobb értékűek: {string.Join(", ", mindenMax.Select(e => e.Nev))}");

            // ---------------------------------------------------------------
            // [F] SZŰRÉS ÉS KIÍRÁS
            // Ha a feladat ezt kéri: "Írja ki azokat a ..., amelyek ..."
            // ---------------------------------------------------------------
            Console.WriteLine("[F] Inaktív elemek:");
            foreach (Elem e in lista.Where(e => !e.Aktiv))   // ! = tagadás
            {
                Console.WriteLine($"\t{e.Nev} ({e.Kategoria})");
            }

            // ---------------------------------------------------------------
            // [G] RENDEZÉS, TOP 3
            // Ha a feladat ezt kéri: "az első 3", "csökkenő sorrendben", "rangsor"
            // ---------------------------------------------------------------
            Console.WriteLine("[G] A 3 legdrágább:");
            List<Elem> top3 = lista.OrderByDescending(e => e.Ertek).ThenBy(e => e.Nev).Take(3).ToList();
            for (int i = 0; i < top3.Count; i++)
            {
                Console.WriteLine($"\t{i + 1}. {top3[i].Nev,-10} {top3[i].Ertek,10:F2}");   // ,-10 / ,10 = oszlopszélesség
            }

            // ---------------------------------------------------------------
            // [H] CSOPORTOSÍTÁS, STATISZTIKA
            // Ha a feladat ezt kéri: "...-nként" (kategóriánként, gyártónként, hónaponként)
            // ---------------------------------------------------------------
            Console.WriteLine("[H] Kategóriánként:");
            foreach (var cs in lista.GroupBy(e => e.Kategoria).OrderBy(cs => cs.Key))
            {
                // cs.Key = a csoport neve, cs.Count() / cs.Average(...) / cs.Max(...) a csoporton belül
                Console.WriteLine($"\t{cs.Key,-10} {cs.Count()} db, átlag: {cs.Average(e => e.Ertek):F2}");
            }

            // ---------------------------------------------------------------
            // [I] HÁNY KÜLÖNBÖZŐ
            // Ha a feladat ezt kéri: "Hány különböző ... szerepel?", "Sorolja fel a ... (ismétlés nélkül)"
            // ---------------------------------------------------------------
            List<string> kategoriak = lista.Select(e => e.Kategoria).Distinct().OrderBy(k => k).ToList();
            Console.WriteLine($"[I] {kategoriak.Count} különböző kategória: {string.Join(", ", kategoriak)}");

            // ---------------------------------------------------------------
            // [J] VAN-E ILYEN / MINDEGYIK ILYEN-E
            // Ha a feladat ezt kéri: "Van-e olyan ...?", "Igaz-e, hogy minden ...?"
            // ---------------------------------------------------------------
            bool vanDraga = lista.Any(e => e.Ertek > 1500);
            bool mindAktiv = lista.All(e => e.Aktiv);
            Console.WriteLine($"[J] Van 1500 feletti: {(vanDraga ? "Igen" : "Nem")}, mind aktív: {(mindAktiv ? "Igen" : "Nem")}");

            // ---------------------------------------------------------------
            // [K] BEKÉRÉS + KERESÉS + "NINCS ILYEN"
            // Ha a feladat ezt kéri: "Kérjen be egy ... és írja ki ..."
            // ---------------------------------------------------------------
            Console.Write("[K] Kérek egy nevet: ");
            string keresett = Console.ReadLine();
            // Szám bekérése: int szam = int.Parse(Console.ReadLine());
            Elem talalat = lista.FirstOrDefault(e => e.Nev.ToLower() == keresett.ToLower());   // nincs -> null
            if (talalat == null)
                Console.WriteLine("\tNincs ilyen elem.");
            else
                Console.WriteLine($"\t{talalat.Nev}: {talalat.Ertek:F2}");

            // ---------------------------------------------------------------
            // [L] FÁJLBA ÍRÁS
            // Ha a feladat ezt kéri: "Írja ki a(z) xy.txt állományba ..., pontosvesszővel elválasztva"
            // ---------------------------------------------------------------
            List<string> sorok = lista
                .Where(e => e.Aktiv)
                .Select(e => $"{e.Id};{e.Nev};{e.Ertek}")
                .ToList();
            File.WriteAllLines("kimenet.txt", sorok);
            Console.WriteLine($"[L] kimenet.txt: {sorok.Count} sor");

            // ---------------------------------------------------------------
            // [M] DICTIONARY SZÁMLÁLÁS (GroupBy helyett, "klasszikusan")
            // Ha a feladat ezt kéri: "Melyikből van a legtöbb?", gyakoriság
            // ---------------------------------------------------------------
            Dictionary<string, int> szamlalo = new Dictionary<string, int>();
            foreach (Elem e in lista)
            {
                if (szamlalo.ContainsKey(e.Kategoria))
                    szamlalo[e.Kategoria]++;
                else
                    szamlalo[e.Kategoria] = 1;
            }
            var leggyakoribb = szamlalo.OrderByDescending(p => p.Value).First();
            Console.WriteLine($"[M] Leggyakoribb kategória: {leggyakoribb.Key} ({leggyakoribb.Value} db)");

            // ---------------------------------------------------------------
            // [N] DÁTUMOK
            // Ha a feladat ezt kéri: "legkorábbi", "adott hónapban", "hány nap telt el"
            // ---------------------------------------------------------------
            DateTime legkorabbi = lista.Min(e => e.Datum);
            int juniusiDb = lista.Count(e => e.Datum.Month == 6);
            int eltelt = (new DateTime(2026, 10, 12) - legkorabbi).Days;   // dátum - dátum = TimeSpan
            Console.WriteLine($"[N] Legkorábbi: {legkorabbi:yyyy.MM.dd.}, júniusi: {juniusiDb} db, azóta eltelt: {eltelt} nap");

            // ---------------------------------------------------------------
            // [O] KEREKÍTÉS ÉS METÓDUS AZ OSZTÁLYBAN
            // Ha a feladat ezt kéri: "kerekítse egészre / 2 tizedesre", "készítsen metódust"
            // ---------------------------------------------------------------
            long egeszre = (long)Math.Round(osszeg, MidpointRounding.AwayFromZero);
            Console.WriteLine($"[O] Összeg egészre: {egeszre}, az első elem bruttó értéke: {lista[0].BruttoErtek():F2}");
        }
    }
}
