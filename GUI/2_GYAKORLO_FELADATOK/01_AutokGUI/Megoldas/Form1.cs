using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AutoGUI
{
    // =====================================================================
    // Form1.cs = AZ ABLAK KÓDJA. Ide írod, hogy mi történjen, amikor
    // megnyílik az ablak, rákattintanak egy gombra, kiválasztanak valamit...
    // (Az ablak KINÉZETE a Form1.Designer.cs-ben van, azt a Designer írja.)
    // =====================================================================
    public partial class Form1 : Form
    {
        // Az összes beolvasott autó. Itt, az osztály szintjén hozzuk létre,
        // hogy MINDEN metódus (Load, gombnyomás...) lássa és használhassa.
        List<Auto> autok = new List<Auto>();

        // ---------------------------------------------------------------
        // KONSTRUKTOR: az ablak létrehozásakor fut le, MÉG a megjelenés előtt.
        // ---------------------------------------------------------------
        public Form1()
        {
            // Ez rakja fel az ablakra a Designerben megrajzolt vezérlőket.
            // MINDIG ez legyen az első sor! Előtte a vezérlők még nem léteznek.
            InitializeComponent();

            // ESEMÉNYEK BEKÖTÉSE (1_TECHNIKAK/03):
            // "ha EZ történik  +=  akkor EZ a metódus fusson le"
            this.Load += Form1_Load;                // amikor az ablak megnyílik
            btnKereses.Click += BtnKereses_Click;   // amikor a Keresés gombra kattintanak
        }

        // ---------------------------------------------------------------
        // 10. feladat: beolvasás (ugyanúgy, mint a konzolos részben)
        // ---------------------------------------------------------------
        private void Beolvasas()
        {
            // A program a bin\Debug\net10.0-windows\ mappából fut.
            // "../../../" = három mappát fellépünk -> a projekt mappájába, ott van a "forras".
            foreach (string sor in File.ReadAllLines("../../../forras/carsData.csv").Skip(1))
            {
                autok.Add(new Auto(sor));
            }
        }

        // ---------------------------------------------------------------
        // 11-15. feladat: AZ ABLAK BETÖLTÉSEKOR fut le, egyszer.
        // Ide jön minden, aminek a megnyitáskor már látszania kell.
        // ---------------------------------------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {
            Beolvasas();

            // 11. A gyártók a bal oldali listába, ISMÉTLÉS NÉLKÜL, és az első legyen kiválasztva.
            //     Select = csak a gyártó nevét vesszük ki, Distinct = minden név csak egyszer,
            //     OrderBy = ABC sorrend (ha a feladat nem kéri, elhagyható).
            lbGyartok.Items.Clear();
            foreach (string gyarto in autok.Select(a => a.Gyarto.GyartoNev).Distinct().OrderBy(n => n))
            {
                lbGyartok.Items.Add(gyarto);
            }
            lbGyartok.SelectedIndex = 0;   // 0 = az első elem kiválasztva

            // 12. Karosszériák a legördülő listába; NE legyen kiválasztva semmi.
            cbKarosszeria.Items.Clear();
            foreach (string k in autok.Select(a => a.Karosszeria.KarosszeriaNev).Distinct().OrderBy(n => n))
            {
                cbKarosszeria.Items.Add(k);
            }
            cbKarosszeria.SelectedIndex = -1;   // -1 = nincs kiválasztva semmi

            // 13. Váltók ugyanígy.
            cbValto.Items.Clear();
            foreach (string v in autok.Select(a => a.Valto.ValtoNev).Distinct().OrderBy(n => n))
            {
                cbValto.Items.Add(v);
            }
            cbValto.SelectedIndex = -1;

            // 14. Az ajtók száma: egyik rádiógomb se legyen bejelölve.
            rb2.Checked = false;
            rb3.Checked = false;
            rb4.Checked = false;
            rb5.Checked = false;
            // BUKTATÓ: ha induláskor egy rádiógomb kapja a fókuszt, a Windows AUTOMATIKUSAN
            // bejelöli. Ezért a fókuszt a gyártók listájára tesszük.
            this.ActiveControl = lbGyartok;

            // 15. Az évek mezői üresek.
            txtKorTol.Text = "";
            txtKorIg.Text = "";
        }

        // ---------------------------------------------------------------
        // 16-17. feladat: a KERESÉS gomb megnyomásakor fut le.
        // ---------------------------------------------------------------
        private void BtnKereses_Click(object sender, EventArgs e)
        {
            // 17. Az előző keresés találatait töröljük, különben a régiek is ott maradnának.
            lbTalalatok.Items.Clear();

            // --- ELLENŐRZÉS: mindent kiválasztottak / kitöltöttek? (1_TECHNIKAK/11) ---
            // Ha valamelyik ComboBoxban nincs kiválasztva semmi, a SelectedItem == null.
            // Ellenőrzés nélkül a .ToString() hibát dobna, és a program leállna!
            if (lbGyartok.SelectedItem == null || cbKarosszeria.SelectedItem == null || cbValto.SelectedItem == null)
            {
                MessageBox.Show("Válasszon gyártót, karosszériát és váltót!", "Hiányzó adat",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;   // a return KILÉP a metódusból, a keresés nem fut tovább
            }

            // Melyik rádiógomb van bejelölve? (1_TECHNIKAK/10)
            int ajtok = 0;
            if (rb2.Checked) ajtok = 2;
            else if (rb3.Checked) ajtok = 3;
            else if (rb4.Checked) ajtok = 4;
            else if (rb5.Checked) ajtok = 5;

            if (ajtok == 0)
            {
                MessageBox.Show("Válassza ki az ajtók számát!", "Hiányzó adat",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Számok a szövegmezőkből. TryParse: ha nem szám van benne, false-t ad (nem száll el).
            int korTol, korIg;
            if (!int.TryParse(txtKorTol.Text, out korTol) || !int.TryParse(txtKorIg.Text, out korIg))
            {
                MessageBox.Show("Az évek számához egész számokat írjon!", "Hibás adat",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // A kiválasztott értékek szövegként.
            string gyarto = lbGyartok.SelectedItem.ToString();
            string karosszeria = cbKarosszeria.SelectedItem.ToString();
            string valto = cbValto.SelectedItem.ToString();
            int aktualisEv = DateTime.Now.Year;

            // 16. Szűrés MINDEN feltételre egyszerre (&& = ÉS), és a találatok a jobb oldali listába.
            foreach (Auto a in autok.Where(a => a.Gyarto.GyartoNev == gyarto
                                             && a.Karosszeria.KarosszeriaNev == karosszeria
                                             && a.Valto.ValtoNev == valto
                                             && a.Ajtok == ajtok
                                             && a.Kor(aktualisEv) >= korTol
                                             && a.Kor(aktualisEv) <= korIg))
            {
                lbTalalatok.Items.Add(a.TalalatSor());
            }

            // (Extra, ha a feladat nem kéri, elhagyható:) jelezzük, ha nincs találat.
            if (lbTalalatok.Items.Count == 0)
            {
                MessageBox.Show("Nincs a feltételeknek megfelelő autó.", "Keresés",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
