namespace Gyorsindito
{
    // Ezt a fájlt a Visual Studio hozza létre, NEM kell hozzányúlni.
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
