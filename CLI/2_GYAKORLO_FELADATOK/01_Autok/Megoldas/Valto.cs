namespace AutoKonzol
{
    // Ugyanaz a felépítés, mint a Gyarto osztálynál: ID + név, konstruktorral.
    internal class Valto
    {
        public int ValtoID { get; set; }
        public string ValtoNev { get; set; }

        public Valto(int valtoID, string valtoNev)
        {
            ValtoID = valtoID;
            ValtoNev = valtoNev;
        }
    }
}
