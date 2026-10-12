namespace AutoGUI
{
    // A vizsgalap szerint a Gyarto "önálló osztály", két mezővel.
    // Minden önálló osztály külön .cs fájlba kerül:
    // Visual Studióban: jobb klikk a projekten -> Add -> Class... -> név: Gyarto.cs
    internal class Gyarto
    {
        // Tulajdonságok (property-k): a nevük PONTOSAN az osztálydiagram szerint legyen.
        public int GyartoID { get; set; }
        public string GyartoNev { get; set; }

        // Konstruktor: amikor "new Gyarto(...)"-t írunk, ez fut le, és beállítja a mezőket.
        public Gyarto(int gyartoID, string gyartoNev)
        {
            GyartoID = gyartoID;
            GyartoNev = gyartoNev;
        }
    }
}
