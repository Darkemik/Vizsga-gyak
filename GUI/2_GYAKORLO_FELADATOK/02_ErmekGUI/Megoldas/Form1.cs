using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ErmekGUI
{
    public partial class Form1 : Form
    {
        // Az összes beolvasott eredmény. Az osztály szintjén, hogy minden metódus lássa.
        List<Eredmeny> eredmenyek = new List<Eredmeny>();

        public Form1()
        {
            InitializeComponent();   // MINDIG az első: felrakja a vezérlőket

            // Események bekötése (1_TECHNIKAK/03)
            this.Load += Form1_Load;                          // 12. ablak megnyitásakor
            txtSzuro.TextChanged += TxtSzuro_TextChanged;     // 13. gépeléskor
            dgvErmek.CellClick += DgvErmek_CellClick;         // 14. sor kijelölésekor
            btnJavaslat.Click += BtnJavaslat_Click;           // 15. gombnyomáskor
        }

        // ---------------------------------------------------------------
        // 10. Beolvasás. A fájlnak VAN fejléce -> Skip(1).
        // ---------------------------------------------------------------
        private void Beolvasas()
        {
            foreach (string sor in File.ReadAllLines("../../../forras/ermek.txt").Skip(1))
            {
                eredmenyek.Add(new Eredmeny(sor));
            }
        }

        // ---------------------------------------------------------------
        // 12. Betöltéskor: oszlopok + az összes rekord az adatrácsba.
        // ---------------------------------------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {
            Beolvasas();

            // Az adatrács oszlopai: Columns.Add("belső név", "fejléc felirata").
            // A belső névvel később a cellát is el tudjuk érni: sor.Cells["Ev"].
            dgvErmek.Columns.Add("Id", "Sorszám");
            dgvErmek.Columns.Add("Iskola", "Iskola");
            dgvErmek.Columns.Add("Varos", "Város");
            dgvErmek.Columns.Add("Ev", "Év");
            dgvErmek.Columns.Add("Arany", "Arany");
            dgvErmek.Columns.Add("Ezust", "Ezüst");
            dgvErmek.Columns.Add("Bronz", "Bronz");

            TablaFeltoltes(eredmenyek);

            // Kezdőállapot: semmi sincs kijelölve, a lenti mezők üresek.
            lblIskola.Text = "";
            lblEv.Text = "";
            txtArany.Text = "";
            txtEzust.Text = "";
            txtBronz.Text = "";
        }

        // Külön metódus, mert a betöltés ÉS a szűrés is ezt használja.
        private void TablaFeltoltes(List<Eredmeny> lista)
        {
            dgvErmek.Rows.Clear();   // a régi sorok törlése, különben duplázódna
            foreach (Eredmeny r in lista)
            {
                // Az értékek sorrendje = az oszlopok sorrendje!
                dgvErmek.Rows.Add(r.Id, r.Iskola, r.Varos, r.Ev, r.Arany, r.Ezust, r.Bronz);
            }
            dgvErmek.ClearSelection();   // ne legyen automatikusan kijelölve az első sor
            lblDb.Text = $"Találatok: {lista.Count} db";
        }

        // ---------------------------------------------------------------
        // 13. Gépelésre szűrés: az iskola VAGY a város a beírt szöveggel KEZDŐDIK.
        //     Minden leütésnél lefut. Üres mezőnél minden sor megjelenik.
        // ---------------------------------------------------------------
        private void TxtSzuro_TextChanged(object sender, EventArgs e)
        {
            string minta = txtSzuro.Text.ToLower();   // kis/nagybetű ne számítson

            List<Eredmeny> talalatok = eredmenyek
                .Where(r => r.Iskola.ToLower().StartsWith(minta)
                         || r.Varos.ToLower().StartsWith(minta))
                .ToList();

            TablaFeltoltes(talalatok);
        }

        // ---------------------------------------------------------------
        // 14. Sor kijelölésekor: az év és az iskola a címkékbe,
        //     az érmek a szövegmezőkbe (ott a felhasználó módosíthatja őket).
        // ---------------------------------------------------------------
        private void DgvErmek_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;   // a FEJLÉCRE kattintottak -> nincs teendő

            DataGridViewRow sor = dgvErmek.Rows[e.RowIndex];
            lblIskola.Text = sor.Cells["Iskola"].Value.ToString();
            lblEv.Text = sor.Cells["Ev"].Value.ToString();
            txtArany.Text = sor.Cells["Arany"].Value.ToString();
            txtEzust.Text = sor.Cells["Ezust"].Value.ToString();
            txtBronz.Text = sor.Cells["Bronz"].Value.ToString();
        }

        // ---------------------------------------------------------------
        // 15. Javaslat gomb: megerősítés (Igen/Nem), majd hozzáfűzés a javaslat.txt-hez.
        // ---------------------------------------------------------------
        private void BtnJavaslat_Click(object sender, EventArgs e)
        {
            // Ha még nem jelöltek ki sort, nincs mire javaslatot tenni.
            if (lblEv.Text == "")
            {
                MessageBox.Show("Előbb jelöljön ki egy sort az adatrácsban!", "Hiányzó kijelölés",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Megerősítő üzenetablak: a válasz Yes vagy No (1_TECHNIKAK/12)
            DialogResult valasz = MessageBox.Show(
                $"Valóban javaslatot tesz a(z) {lblIskola.Text} {lblEv.Text}. évi éremszámaira?",
                "Megerősítés",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (valasz == DialogResult.Yes)
            {
                // true = HOZZÁFŰZÉS: a korábbi javaslatok megmaradnak (1_TECHNIKAK/13).
                // A sor elejére a rendszeridő kerül (DateTime.Now).
                using (StreamWriter sw = new StreamWriter("../../../forras/javaslat.txt", true))
                {
                    sw.WriteLine($"{DateTime.Now}\t{lblIskola.Text}\t{lblEv.Text}\t" +
                                 $"Érmek: {txtArany.Text}\t{txtEzust.Text}\t{txtBronz.Text}");
                }
                MessageBox.Show("A javaslatot rögzítettük.", "Javaslat",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
