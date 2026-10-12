namespace KonyvtarGUI
{
    // Egy sor a konyvek.txt-ben = egy könyv.
    internal class Konyv
    {
        public int Id { get; set; }
        public string Cim { get; set; }
        public string Szerzo { get; set; }
        public string Mufaj { get; set; }
        public int Kiadas { get; set; }
        public int Oldalszam { get; set; }
        public bool Kikolcsonozve { get; set; }   // a fájlban 1 / 0; a program futás közben módosítja

        public Konyv(string sor)
        {
            string[] m = sor.Split(';');
            Id = int.Parse(m[0]);
            Cim = m[1];
            Szerzo = m[2];
            Mufaj = m[3];
            Kiadas = int.Parse(m[4]);
            Oldalszam = int.Parse(m[5]);
            Kikolcsonozve = m[6] == "1";
        }

        // Feltételes szöveg az állapothoz (1_TECHNIKAK/08)
        public string AllapotSzoveg()
        {
            return Kikolcsonozve ? "Kikölcsönözve" : "Kölcsönözhető";
        }

        // Ez látszik a ListBoxban
        public override string ToString()
        {
            return $"{Cim} ({Szerzo})";
        }
    }
}
