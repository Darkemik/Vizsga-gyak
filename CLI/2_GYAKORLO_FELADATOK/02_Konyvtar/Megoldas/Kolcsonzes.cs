using System;
using System.Globalization;

namespace KonyvtarKonzol
{
    // Egy sor a fájlban = egy kölcsönzés.
    internal class Kolcsonzes
    {
        public int Azonosito { get; set; }
        public string Olvaso { get; set; }
        public string Cim { get; set; }
        public string Szerzo { get; set; }
        public int KiadasEve { get; set; }
        public DateTime KolcsonzesDatum { get; set; }

        // A visszahozás mező lehet ÜRES (még nincs visszahozva).
        // Ezt egy bool jelzi, a dátum csak akkor számít, ha Visszahozta == true.
        public bool Visszahozta { get; set; }
        public DateTime VisszahozasDatum { get; set; }

        public Kolcsonzes(string sor)
        {
            string[] m = sor.Split(';');
            Azonosito = int.Parse(m[0]);
            Olvaso = m[1];
            Cim = m[2];
            Szerzo = m[3];
            KiadasEve = int.Parse(m[4]);

            // DÁTUM BEOLVASÁSA (1_TECHNIKAK/15):
            // ParseExact: pontosan megadjuk, milyen formában van a dátum a fájlban.
            // "yyyy-MM-dd" = 2026-01-17. Ha a fájlban 2026.01.17. van, akkor "yyyy.MM.dd." kell.
            KolcsonzesDatum = DateTime.ParseExact(m[5], "yyyy-MM-dd", CultureInfo.InvariantCulture);

            // Üres mező kezelése: ha a szöveg üres, nincs visszahozva.
            if (m[6] == "")
            {
                Visszahozta = false;
            }
            else
            {
                Visszahozta = true;
                VisszahozasDatum = DateTime.ParseExact(m[6], "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
        }

        // Metódus az osztályban (1_TECHNIKAK/18): hány napig volt kint a könyv.
        // Ha még nincs visszahozva, akkor a megadott "mai napig" számolunk.
        public int KintNapok(DateTime maiNap)
        {
            DateTime vege;
            if (Visszahozta)
                vege = VisszahozasDatum;
            else
                vege = maiNap;

            // Két dátum különbsége TimeSpan, ennek a .Days része a napok száma.
            return (vege - KolcsonzesDatum).Days;
        }
    }
}
