using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Gyorsindito
{
    // =====================================================================
    // GYORSINDÍTÓ (GUI). Minden gyakori vizsgafeladat egy jelölt blokk: [A] ... [K].
    // Vizsgán: másold ki a kellő blokkot, és írd át a vezérlő- és mezőneveket.
    // A blokkok fölött: "HA A FELADAT EZT KÉRI:"
    // =====================================================================
    public partial class Form1 : Form
    {
        // Az osztály szintjén: minden eseménykezelő látja, és megmaradnak a kattintások között.
        List<Elem> elemek = new List<Elem>();           // az összes adat
        List<string> kosar = new List<string>();        // [J] a kosár sorai
        double osszeg = 0;                              // [J] a kosár értéke

        const string MIND = "(mindegyik)";

        // ---------------------------------------------------------------
        // KONSTRUKTOR: InitializeComponent + események bekötése (1_TECHNIKAK/03)
        // ---------------------------------------------------------------
        public Form1()
        {
            InitializeComponent();                                       // MINDIG az első!

            this.Load += Form1_Load;                                     // [A]
            lbElemek.SelectedIndexChanged += LbElemek_SelectedIndexChanged;   // [D]
            dgvElemek.CellClick += DgvElemek_CellClick;                  // [E]
            // [F] [C] [G]: minden szűrő ugyanazt a metódust hívja
            txtSzuro.TextChanged += Szures_Esemeny;
            cbKategoria.SelectedIndexChanged += Szures_Esemeny;
            chkCsakAktiv.CheckedChanged += Szures_Esemeny;
            rbNovekvo.CheckedChanged += Szures_Esemeny;
            rbCsokkeno.CheckedChanged += Szures_Esemeny;
            btnKosarba.Click += BtnKosarba_Click;                        // [H] [J]
            btnMentes.Click += BtnMentes_Click;                          // [I]
            btnKilepes.Click += BtnKilepes_Click;                        // [K]
        }

        // ---------------------------------------------------------------
        // [A] BETÖLTÉS
        // HA A FELADAT EZT KÉRI: "Az alkalmazás betöltésekor jelenjen meg..."
        // ---------------------------------------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {
            // Beolvasás. A program a bin\Debug\net...-windows mappából fut -> ../../../ = projekt mappa
            foreach (string sor in File.ReadAllLines("../../../forras/adatok.txt").Skip(1))
            {
                elemek.Add(new Elem(sor));
            }

            // [E] Adatrács oszlopai: ("belső név", "fejléc")
            dgvElemek.Columns.Add("Id", "Azonosító");
            dgvElemek.Columns.Add("Nev", "Név");
            dgvElemek.Columns.Add("Kategoria", "Kategória");
            dgvElemek.Columns.Add("Ar", "Ár");
            dgvElemek.Columns.Add("Datum", "Dátum");
            dgvElemek.Columns.Add("Aktiv", "Aktív");

            // [C] ComboBox: "(mindegyik)" + a kategóriák ismétlés nélkül, ABC sorrendben
            cbKategoria.Items.Add(MIND);
            foreach (string k in elemek.Select(x => x.Kategoria).Distinct().OrderBy(k => k))
            {
                cbKategoria.Items.Add(k);
            }
            cbKategoria.SelectedIndex = 0;    // ez elsüti a Szures_Esemeny-t -> megtelik a lista

            // [G] Kezdőállapot: egyik rádiógomb sincs bejelölve, a pipa nincs bent
            chkCsakAktiv.Checked = false;
            rbNovekvo.Checked = false;
            rbCsokkeno.Checked = false;
            this.ActiveControl = txtSzuro;    // különben az első rádiógomb magától bejelölődhet!

            OsszegFrissites();
        }

        // ---------------------------------------------------------------
        // [F] [C] [G] SZŰRÉS: gépelés + ComboBox + CheckBox + RadioButton EGYÜTT
        // HA A FELADAT EZT KÉRI: "Ha gépelünk / kiválasztunk / bejelölünk..., csak azok jelenjenek meg"
        // ---------------------------------------------------------------
        private void Szures_Esemeny(object sender, EventArgs e)
        {
            Szures();
        }

        private void Szures()
        {
            string minta = txtSzuro.Text.ToLower();                         // [F]
            string kategoria = cbKategoria.SelectedItem == null ? MIND : cbKategoria.SelectedItem.ToString();   // [C]

            IEnumerable<Elem> lista = elemek.Where(x =>
                   x.Nev.ToLower().StartsWith(minta)                        // [F] "kezdődik"  (Contains = "tartalmazza")
                && (kategoria == MIND || x.Kategoria == kategoria)          // [C]
                && (!chkCsakAktiv.Checked || x.Aktiv));                     // [G] ha nincs pipa, mindegy

            if (rbNovekvo.Checked) lista = lista.OrderBy(x => x.Ar);        // [G] RadioButton
            else if (rbCsokkeno.Checked) lista = lista.OrderByDescending(x => x.Ar);

            List<Elem> talalatok = lista.ToList();

            // [B] ListBox feltöltése OBJEKTUMOKKAL (a ToString() látszik)
            lbElemek.Items.Clear();
            foreach (Elem x in talalatok)
            {
                lbElemek.Items.Add(x);
            }
            if (lbElemek.Items.Count > 0)
                lbElemek.SelectedIndex = 0;          // "az első legyen kiválasztva"
            else
                ReszletekTorlese();

            // [E] DataGridView feltöltése
            dgvElemek.Rows.Clear();
            foreach (Elem x in talalatok)
            {
                dgvElemek.Rows.Add(x.Id, x.Nev, x.Kategoria, x.Ar.ToString("F2"),
                                   x.Datum.ToString("yyyy.MM.dd."), x.Aktiv ? "igen" : "nem");
            }
        }

        // ---------------------------------------------------------------
        // [D] KIVÁLASZTÁS -> RÉSZLETEK
        // HA A FELADAT EZT KÉRI: "Ha kiválasztunk egy elemet, jelenjenek meg az adatai..."
        // ---------------------------------------------------------------
        private void LbElemek_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbElemek.SelectedItem == null) return;      // Items.Clear() után null!
            Elem x = (Elem)lbElemek.SelectedItem;           // OBJEKTUM, nem index -> szűrve is jó
            ReszletekKiirasa(x);
        }

        private void ReszletekKiirasa(Elem x)
        {
            lblNev.Text = x.Nev;
            rtbReszletek.Text = $"Azonosító:\t{x.Id}\n" +
                                $"Kategória:\t{x.Kategoria}\n" +
                                $"Ár:\t\t{x.Ar:F2} Ft\n" +
                                $"Dátum:\t\t{x.Datum:yyyy.MM.dd.}\n" +
                                $"Állapot:\t\t{(x.Aktiv ? "aktív" : "inaktív")}";
        }

        private void ReszletekTorlese()
        {
            lblNev.Text = "-";
            rtbReszletek.Clear();
        }

        // ---------------------------------------------------------------
        // [E] ADATRÁCS: sor kijelölése
        // HA A FELADAT EZT KÉRI: "Ha kijelöljük az adatrácsban valamelyik sort..."
        // ---------------------------------------------------------------
        private void DgvElemek_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;                                        // fejlécre kattintás
            int id = int.Parse(dgvElemek.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            Elem x = elemek.First(el => el.Id == id);                         // az Id alapján megkeressük
            ReszletekKiirasa(x);
        }

        // ---------------------------------------------------------------
        // [H] GOMB + ELLENŐRZÉS  és  [J] ÖSSZEG SZÁMOLÁSA
        // HA A FELADAT EZT KÉRI: "A gombra kattintva...", "ha nem megfelelő az érték, hibaüzenet",
        //                        "kosár", "részösszeg", "végösszeg"
        // ---------------------------------------------------------------
        private void BtnKosarba_Click(object sender, EventArgs e)
        {
            // 1. van-e kiválasztva?
            if (lbElemek.SelectedItem == null)
            {
                MessageBox.Show("Válasszon egy elemet!", "Hiányzó adat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. szám a TextBoxból: TryParse (betűre nem száll el)
            int kedvezmeny;
            if (!int.TryParse(txtKedvezmeny.Text, out kedvezmeny) || kedvezmeny < 0 || kedvezmeny > 50)
            {
                MessageBox.Show("A kedvezmény 0 és 50 közötti egész szám lehet!", "Hibás adat",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. szám a NumericUpDownból: eleve csak szám lehet
            int db = (int)numDarab.Value;

            // [J] számolás és összeg frissítése
            Elem x = (Elem)lbElemek.SelectedItem;
            double ertek = x.Ar * db * (100 - kedvezmeny) / 100.0;
            osszeg += ertek;
            kosar.Add($"{db} x {x.Nev} - {ertek:F2} Ft");
            OsszegFrissites();
        }

        private void OsszegFrissites()
        {
            lblOsszeg.Text = $"Összesen: {osszeg:F2} Ft ({kosar.Count} tétel)";
        }

        // ---------------------------------------------------------------
        // [I] MEGERŐSÍTÉS + FÁJLBA ÍRÁS (hozzáfűzés, rendszeridővel)
        // HA A FELADAT EZT KÉRI: "megerősítő üzenetablak", "írja ki a ... fájlba",
        //                        "a sor elejére a rendszeridőt", "a további ... is ebbe a fájlba"
        // ---------------------------------------------------------------
        private void BtnMentes_Click(object sender, EventArgs e)
        {
            if (kosar.Count == 0)
            {
                MessageBox.Show("Nincs mit menteni, a kosár üres!", "Mentés", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult valasz = MessageBox.Show(
                $"Menti a kosarat?\nÖsszesen: {osszeg:F2} Ft",
                "Megerősítés",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (valasz == DialogResult.Yes)
            {
                // true = HOZZÁFŰZÉS (a régi sorok megmaradnak)
                using (StreamWriter sw = new StreamWriter("../../../forras/mentes.txt", true))
                {
                    sw.WriteLine($"{DateTime.Now};{string.Join(" | ", kosar)};{osszeg:F2} Ft");
                }
                kosar.Clear();
                osszeg = 0;
                OsszegFrissites();
            }
        }

        // ---------------------------------------------------------------
        // [K] KILÉPÉS
        // HA A FELADAT EZT KÉRI: "...majd az alkalmazás záródjon be"
        // ---------------------------------------------------------------
        private void BtnKilepes_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Biztosan kilép?", "Kilépés", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
