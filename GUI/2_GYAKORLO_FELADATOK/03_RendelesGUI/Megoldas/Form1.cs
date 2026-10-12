using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RendelesGUI
{
    public partial class Form1 : Form
    {
        // ---- Az osztály szintjén: ezek MEGMARADNAK a kattintások között ----
        List<Termek> termekek = new List<Termek>();     // a teljes kínálat
        List<string> kosarTetelek = new List<string>(); // a kosár sorai (a fájlba íráshoz)
        int reszosszeg = 0;                              // a kosár értéke (1_TECHNIKAK/14)

        const int SZALLITASI_DIJ = 690;      // const = állandó, nem változik
        const int INGYENES_HATAR = 5000;     // 5000 Ft-TÓL ingyenes -> >=

        public Form1()
        {
            InitializeComponent();

            this.Load += Form1_Load;
            lbKinalat.SelectedIndexChanged += LbKinalat_SelectedIndexChanged;
            // Mindkét jelölőnégyzet UGYANAZT a metódust hívja (1_TECHNIKAK/10)
            chkLaktozmentes.CheckedChanged += Szures_Esemeny;
            chkCukormentes.CheckedChanged += Szures_Esemeny;
            btnKosarba.Click += BtnKosarba_Click;
            btnRendeles.Click += BtnRendeles_Click;
        }

        // ---------------------------------------------------------------
        // 12. Betöltéskor: beolvasás, a teljes kínálat a listába, összegek nullázása.
        // ---------------------------------------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (string sor in File.ReadAllLines("../../../forras/kinalat.txt").Skip(1))
            {
                termekek.Add(new Termek(sor));
            }
            Szures();              // a lista feltöltése (most még nincs pipa -> minden termék)
            OsszegekFrissitese();  // 0 Ft mindenhol
        }

        // ---------------------------------------------------------------
        // 14. Szűrés a jelölőnégyzetek szerint. Ezt hívja a betöltés ÉS a pipálás is.
        // ---------------------------------------------------------------
        private void Szures_Esemeny(object sender, EventArgs e)
        {
            Szures();
        }

        private void Szures()
        {
            lbKinalat.Items.Clear();

            // (!pipa || feltétel) = "ha nincs bepipálva, mindegy; ha be van, teljesüljön"
            foreach (Termek t in termekek.Where(t => (!chkLaktozmentes.Checked || t.Laktozmentes)
                                                  && (!chkCukormentes.Checked || t.Cukormentes)))
            {
                lbKinalat.Items.Add(t);    // OBJEKTUMOT teszünk bele -> a ToString() látszik
            }

            if (lbKinalat.Items.Count > 0)
                lbKinalat.SelectedIndex = 0;   // az első legyen kiválasztva
            else
                lblValasztott.Text = "-";      // nincs ilyen termék
        }

        // ---------------------------------------------------------------
        // 13. Kiválasztáskor: a termék neve és ára a címkébe.
        // ---------------------------------------------------------------
        private void LbKinalat_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Az Items.Clear() is elsüti ezt az eseményt, null kiválasztással -> ellenőrizni kell!
            if (lbKinalat.SelectedItem == null) return;

            Termek t = (Termek)lbKinalat.SelectedItem;   // a kiválasztott OBJEKTUM, nem index!
            lblValasztott.Text = $"{t.Nev}, {t.Ar} Ft";
        }

        // ---------------------------------------------------------------
        // 15. Kosárba: a kiválasztott termék × darab a kosárba, összegek frissítése.
        // ---------------------------------------------------------------
        private void BtnKosarba_Click(object sender, EventArgs e)
        {
            if (lbKinalat.SelectedItem == null)
            {
                MessageBox.Show("Válasszon terméket!", "Kosár", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Termek t = (Termek)lbKinalat.SelectedItem;
            int db = (int)numDarab.Value;          // NumericUpDown.Value decimal -> (int)
            int ertek = t.Ar * db;

            string tetel = $"{db} x {t.Nev} - {ertek} Ft";
            kosarTetelek.Add(tetel);
            rtbKosar.AppendText(tetel + "\n");     // új sor a kosár szövegdobozba

            reszosszeg += ertek;
            OsszegekFrissitese();

            numDarab.Value = 1;                    // a darabszám visszaáll 1-re
        }

        // A részösszeg, kiszállítás és végösszeg címkék frissítése.
        private void OsszegekFrissitese()
        {
            int szallitas;
            if (reszosszeg == 0 || reszosszeg >= INGYENES_HATAR)
                szallitas = 0;                     // üres kosár, vagy elérte a határt
            else
                szallitas = SZALLITASI_DIJ;

            lblReszosszeg.Text = $"{reszosszeg} Ft";
            lblSzallitas.Text = $"{szallitas} Ft";
            lblVegosszeg.Text = $"{reszosszeg + szallitas} Ft";
        }

        // ---------------------------------------------------------------
        // 16. Rendelés: megerősítés (Igen/Nem) -> rendelesek.txt-be hozzáfűzés -> kosár ürítése.
        // ---------------------------------------------------------------
        private void BtnRendeles_Click(object sender, EventArgs e)
        {
            if (kosarTetelek.Count == 0)
            {
                MessageBox.Show("A kosár üres!", "Rendelés", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult valasz = MessageBox.Show(
                $"Leadja a rendelést?\nVégösszeg: {lblVegosszeg.Text}",
                "Rendelés",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (valasz == DialogResult.Yes)
            {
                // Egy rendelés = egy sor: dátum; tételek | jellel elválasztva; végösszeg
                using (StreamWriter sw = new StreamWriter("../../../forras/rendelesek.txt", true))
                {
                    sw.WriteLine($"{DateTime.Now};{string.Join(" | ", kosarTetelek)};{lblVegosszeg.Text}");
                }

                MessageBox.Show("Köszönjük a rendelést!", "Rendelés", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Kosár ürítése. (Ha a feladat azt kéri, hogy záródjon be a program:
                // Application.Exit(); )
                kosarTetelek.Clear();
                rtbKosar.Clear();
                reszosszeg = 0;
                OsszegekFrissitese();
            }
        }
    }
}
