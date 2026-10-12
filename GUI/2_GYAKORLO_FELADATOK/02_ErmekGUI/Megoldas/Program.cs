namespace ErmekGUI
{
    // Ezt a fájlt a Visual Studio hozza létre, NEM kell hozzányúlni.
    // Annyit csinál, hogy elindítja a programot a Form1 ablakkal.
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
