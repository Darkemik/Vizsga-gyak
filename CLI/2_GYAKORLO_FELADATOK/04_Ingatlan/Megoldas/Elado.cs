namespace IngatlanKonzol
{
    // Az eladó adatai 3 mezőből jönnek a fájlban -> saját osztály (osztály az osztályban).
    internal class Elado
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        public string Telefon { get; set; }

        public Elado(int id, string nev, string telefon)
        {
            Id = id;
            Nev = nev;
            Telefon = telefon;
        }
    }
}
