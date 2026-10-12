namespace AutoKonzol
{
    // Ugyanaz a felépítés, mint a Gyarto osztálynál: ID + név, konstruktorral.
    internal class Karosszeria
    {
        public int KarosszeriaID { get; set; }
        public string KarosszeriaNev { get; set; }

        public Karosszeria(int karosszeriaID, string karosszeriaNev)
        {
            KarosszeriaID = karosszeriaID;
            KarosszeriaNev = karosszeriaNev;
        }
    }
}
