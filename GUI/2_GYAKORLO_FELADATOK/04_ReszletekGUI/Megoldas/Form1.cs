using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace KonyvtarGUI
{
    public partial class Form1 : Form
    {
        List<Konyv> konyvek = new List<Konyv>();          // az összes könyv
        List<int> megtekintettek = new List<int>();       // a megnézett könyvek azonosítói (ismétlés nélkül)

        const string MIND = "(mindegyik)";                // a ComboBox első eleme

        public Form1()
        {
            InitializeComponent();

            this.Load += Form1_Load;
            cbMufaj.SelectedIndexChanged += CbMufaj_SelectedIndexChanged;
            lbKonyvek.SelectedIndexChanged += LbKonyvek_SelectedIndexChanged;
            btnKolcsonzes.Click += BtnKolcsonzes_Click;
            btnKilepes.Click += BtnKilepes_Click;
        }

        // ---------------------------------------------------------------
        // 12. Betöltéskor: beolvasás, kínálat felirat, műfajok a ComboBoxba.
        // ---------------------------------------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (string sor in File.ReadAllLines("../../../forras/konyvek.txt").Skip(1))
            {
                konyvek.Add(new Konyv(sor));
            }

            // Felirat kiszámolt értékekkel (1_TECHNIKAK/04)
            int mufajDb = konyvek.Select(k => k.Mufaj).Distinct().Count();
            lblValasztek.Text = $"VÁLASSZON {mufajDb} MŰFAJ {konyvek.Count} KÖNYVE KÖZÜL!";

            // Műfajok ismétlés nélkül, ABC sorrendben, az elején egy "(mindegyik)" opcióval.
            cbMufaj.Items.Clear();
            cbMufaj.Items.Add(MIND);
            foreach (string m in konyvek.Select(k => k.Mufaj).Distinct().OrderBy(m => m))
            {
                cbMufaj.Items.Add(m);
            }

            // Ez ELSÜTI a CbMufaj_SelectedIndexChanged eseményt -> feltölti a könyvlistát.
            cbMufaj.SelectedIndex = 0;
        }

        // ---------------------------------------------------------------
        // 13. Műfaj kiválasztásakor: csak az ilyen műfajú könyvek a listában.
        // ---------------------------------------------------------------
        private void CbMufaj_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMufaj.SelectedItem == null) return;
            string mufaj = cbMufaj.SelectedItem.ToString();

            lbKonyvek.Items.Clear();
            foreach (Konyv k in konyvek.Where(k => mufaj == MIND || k.Mufaj == mufaj))
            {
                lbKonyvek.Items.Add(k);   // OBJEKTUM a listában -> szűrés után is a jó könyvet kapjuk
            }

            if (lbKonyvek.Items.Count > 0)
                lbKonyvek.SelectedIndex = 0;
        }

        // ---------------------------------------------------------------
        // 14. Könyv kiválasztásakor: az adatai a címkékbe.
        // ---------------------------------------------------------------
        private void LbKonyvek_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbKonyvek.SelectedItem == null) return;   // pl. Items.Clear() után

            // NEM konyvek[lbKonyvek.SelectedIndex]! A lista szűrt, az index nem egyezik
            // a teljes lista indexével. A kiválasztott OBJEKTUMOT vesszük ki (1_TECHNIKAK/05).
            Konyv k = (Konyv)lbKonyvek.SelectedItem;
            ReszletekKiirasa(k);

            if (!megtekintettek.Contains(k.Id))      // minden könyvet csak egyszer számolunk
                megtekintettek.Add(k.Id);
        }

        private void ReszletekKiirasa(Konyv k)
        {
            lblCim.Text = k.Cim;
            lblSzerzo.Text = k.Szerzo;
            lblMufaj.Text = k.Mufaj;
            lblKiadas.Text = k.Kiadas.ToString();
            lblOldal.Text = $"{k.Oldalszam} oldal";
            lblAllapot.Text = k.AllapotSzoveg();
        }

        // ---------------------------------------------------------------
        // 15. Kölcsönzés: ha már ki van kölcsönözve -> üzenet; különben Igen/Nem,
        //     majd kolcsonzesek.txt-be hozzáfűzés és az állapot frissítése.
        // ---------------------------------------------------------------
        private void BtnKolcsonzes_Click(object sender, EventArgs e)
        {
            if (lbKonyvek.SelectedItem == null)
            {
                MessageBox.Show("Válasszon könyvet!", "Kölcsönzés", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Konyv k = (Konyv)lbKonyvek.SelectedItem;

            if (k.Kikolcsonozve)
            {
                MessageBox.Show("Ez a könyv már ki van kölcsönözve!", "Kölcsönzés",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult valasz = MessageBox.Show(
                $"Biztosan kikölcsönzi a(z) „{k.Cim}” című könyvet?",
                "Kölcsönzés",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (valasz == DialogResult.Yes)
            {
                using (StreamWriter sw = new StreamWriter("../../../forras/kolcsonzesek.txt", true))
                {
                    sw.WriteLine($"{DateTime.Now};{k.Id};{k.Cim}");
                }
                k.Kikolcsonozve = true;     // a memóriában is átállítjuk
                ReszletekKiirasa(k);        // a címke frissüljön: "Kikölcsönözve"
            }
        }

        // ---------------------------------------------------------------
        // 16. Kilépés: üzenet a megtekintett könyvek számával, Igen esetén bezárás.
        // ---------------------------------------------------------------
        private void BtnKilepes_Click(object sender, EventArgs e)
        {
            DialogResult valasz = MessageBox.Show(
                $"Ön {megtekintettek.Count} könyvet tekintett meg. Biztosan kilép?",
                "Kilépés",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (valasz == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
