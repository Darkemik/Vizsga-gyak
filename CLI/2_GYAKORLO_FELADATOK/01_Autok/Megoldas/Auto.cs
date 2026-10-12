using System;
using System.Globalization;

namespace AutoKonzol
{
    // 2. feladat: az Auto osztály. A Gyarto, Karosszeria és Valto mezők NEM szövegek,
    // hanem a saját osztályaink példányai ("osztály az osztályban", lásd 1_TECHNIKAK/04).
    internal class Auto
    {
        public int Azonosito { get; set; }
        public int Evjarat { get; set; }
        public Gyarto Gyarto { get; set; }
        public string Modell { get; set; }
        public int KilometeroraAllas { get; set; }
        public Karosszeria Karosszeria { get; set; }
        public int HengerekSzama { get; set; }
        public Valto Valto { get; set; }
        public string KulsoSzin { get; set; }
        public string BelsoSzin { get; set; }
        public int SzemelyekSzama { get; set; }
        public int Ajtok { get; set; }
        public double FogyasztasVarosban { get; set; }
        public double FogyasztasAutopalyan { get; set; }
        public double Ar { get; set; }

        // Konstruktor, ami EGY sort kap a fájlból, és szétszedi.
        // Így a beolvasásnál elég ennyi: autok.Add(new Auto(sor));
        public Auto(string sor)
        {
            // Split(';') -> a sorból tömb lesz, minden mező egy elem.
            string[] m = sor.Split(';');

            // Az indexek a FEJLÉC sorrendjét követik! Vizsgán nézd meg a fájl első sorát,
            // és írd fel magadnak: 0 = Azonosito, 1 = Evjarat, 2 = GyartoID, 3 = GyartoNev ...
            Azonosito = int.Parse(m[0]);
            Evjarat = int.Parse(m[1]);
            Gyarto = new Gyarto(int.Parse(m[2]), m[3]);              // két mezőből egy objektum
            Modell = m[4];
            KilometeroraAllas = int.Parse(m[5]);
            Karosszeria = new Karosszeria(int.Parse(m[6]), m[7]);
            HengerekSzama = int.Parse(m[8]);
            Valto = new Valto(int.Parse(m[9]), m[10]);
            KulsoSzin = m[11];
            BelsoSzin = m[12];
            SzemelyekSzama = int.Parse(m[13]);
            Ajtok = int.Parse(m[14]);

            // TÖRT SZÁMOK: a vizsga carsData.csv-jében VESSZŐ a tizedesjel (13,59487179),
            // más fájlokban PONT (13.5). Ez a sor MINDKETTŐT jól olvassa, bármilyen gépen:
            // a vesszőt pontra cseréljük, és "nemzetközi" (pontos) formátumként olvassuk.
            // (lásd 1_TECHNIKAK/17)
            FogyasztasVarosban = double.Parse(m[15].Replace(',', '.'), CultureInfo.InvariantCulture);
            FogyasztasAutopalyan = double.Parse(m[16].Replace(',', '.'), CultureInfo.InvariantCulture);
            Ar = double.Parse(m[17].Replace(',', '.'), CultureInfo.InvariantCulture);
        }

        // Metódus az osztályban (1_TECHNIKAK/18): a 3. feladat szerinti átlagfogyasztás.
        // Azért metódus, mert több helyen is kellhet, és így csak egyszer írjuk meg.
        public double AtlagFogyasztas()
        {
            // MidpointRounding.AwayFromZero = "normál" kerekítés (2,345 -> 2,35).
            // Nélküle a Math.Round "páros felé" kerekít, ami néha eltér a mintától!
            return Math.Round((FogyasztasVarosban + FogyasztasAutopalyan) / 2, 2, MidpointRounding.AwayFromZero);
        }

        // 3. feladat: a ToString() felülírása (override).
        // Ezt hívja meg a Console.WriteLine(auto) automatikusan, ezért lesz rövid a kiírás.
        // FONTOS: a valódi vizsgán a MINTÁT kövesd betűre (szóközök, kettőspontok, tabulátorok)!
        public override string ToString()
        {
            // \n = új sor, \t = tabulátor (behúzás). Az első sorban csak az azonosító van.
            return $"{Azonosito}\n" +
                   $"\tGyártó: {Gyarto.GyartoNev}\n" +
                   $"\tModell: {Modell} ({Evjarat})\n" +
                   $"\tKarosszéria: {Karosszeria.KarosszeriaNev}, váltó: {Valto.ValtoNev}\n" +
                   $"\tÁtlagfogyasztás: {AtlagFogyasztas():F2} l/100 km\n" +
                   $"\tÁr: {Ar:F2} CAD";
        }
    }
}
