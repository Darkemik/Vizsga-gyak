# Alapok kezdőknek – hogyan működik egy Windows Forms program?

Olvasd el egyszer, 5 perc. Utána minden más érthetőbb lesz.

## 1. Két fájl, két feladat

Egy ablakhoz (Form1) **két fájl** tartozik:

| Fájl | Mi van benne | Ki írja |
|---|---|---|
| `Form1.cs [Design]` / `Form1.Designer.cs` | az ablak **KINÉZETE**: milyen vezérlők vannak, hol, mekkora, mi a feliratuk | **a Designer**, amikor egérrel rajzolsz. Kézzel ne írd! |
| `Form1.cs` (jobb klikk → View Code, F7) | a **KÓD**: mi történjen, ha megnyílik az ablak, ha kattintanak, ha kiválasztanak valamit | **te** |

```
  Designer (rajzolás)                    Form1.cs (kód)
  ┌──────────────────────┐               public Form1()
  │ [lbGyartok ▓▓▓▓▓]    │                {
  │                      │   (Name)        InitializeComponent();
  │      [ Keresés ]─────┼──────────────►  btnKereses.Click += BtnKereses_Click;
  │     btnKereses       │                }
  └──────────────────────┘                private void BtnKereses_Click(...) { ... }
```

## 2. A (Name) a legfontosabb

Minden vezérlőnek van egy **neve**: Properties ablak (F4) → **(Name)**. A kódban **ezzel a névvel** éred el:

```csharp
lbGyartok.Items.Add("Ferrari");     // lbGyartok = egy ListBox neve
btnKereses.Text = "Keresés";        // btnKereses = egy Button neve
```

Ha nem nevezed át, `listBox1`, `button1`, `textBox3` lesz a neve. Ez is működik, de 10 vezérlőnél már nem tudod, melyik melyik. Ezért ezt az előtagos névadást használjuk:

| Vezérlő | Előtag | Példa |
|---|---|---|
| ListBox | `lb` | `lbGyartok` |
| ComboBox | `cb` | `cbValto` |
| TextBox | `txt` | `txtNev` |
| Button | `btn` | `btnKereses` |
| Label (ha a kód írja) | `lbl` | `lblAr` |
| RadioButton | `rb` | `rb2` |
| CheckBox | `chk` | `chkVega` |
| DataGridView | `dgv` | `dgvErmek` |
| GroupBox | `grp` | `grpAjtok` |
| NumericUpDown | `num` | `numDarab` |

> A sima feliratoknak („Autó gyártók:”) nem kell nevet adni, azokhoz a kód nem nyúl.

## 3. A Text a felirat

A **Text** tulajdonság az, ami látszik: gombon a felirat, Labelen a szöveg, TextBoxban a beírt szöveg, az ablaknál a címsor.

```csharp
lblAr.Text = "12 500 Ft";            // kiírunk egy címkébe
string nev = txtNev.Text;            // kiolvassuk, mit írt be a felhasználó
```

## 4. Esemény = „ha ez történik, fusson le ez”

A Windows Forms program **nem fentről lefelé** fut, mint a konzolos. Elindul, megjeleníti az ablakot, és **vár**. Ha a felhasználó csinál valamit, lefut a hozzá **bekötött metódus**.

| Esemény | Mikor történik | Tipikus feladatszöveg |
|---|---|---|
| `Load` (az ablaké) | az ablak megnyílásakor, egyszer | „Az alkalmazás betöltésekor…” |
| `Click` | gombra kattintáskor | „A … gombra kattintva…” |
| `SelectedIndexChanged` | ListBoxban / ComboBoxban mást választanak ki | „Ha kiválasztunk egy…” |
| `TextChanged` | TextBoxba gépelnek (minden betűnél!) | „Ha a beviteli mezőbe gépelünk…” |
| `CheckedChanged` | CheckBox / RadioButton bejelölése változik | „Ha bejelöljük…” |
| `CellClick` | DataGridView-ban egy cellára kattintanak | „Ha kijelöljük az adatrácsban egy sort…” |

**Bekötés** a konstruktorban (a tanárotok is így csinálja):

```csharp
public Form1()
{
    InitializeComponent();                     // 1. MINDIG ez az első: felrakja a vezérlőket
    this.Load += Form1_Load;                   // 2. események bekötése
    btnKereses.Click += BtnKereses_Click;
}

private void Form1_Load(object sender, EventArgs e)       // 3. a metódus, ami lefut
{
    // ide jön, ami megnyitáskor kell
}
```

> **Tipp:** írd be: `btnKereses.Click += BtnKereses_Click;`. Ha a VS aláhúzza (még nincs ilyen metódus),
> kattints rá → **Ctrl + .** → **Generate method**. A VS megírja a metódus vázát.

**Másik mód:** a Designerben **dupla klikk** a gombon. A VS létrehozza a `button1_Click` metódust, és magától beköti.
⚠️ Ilyenkor NE írd be a `+=`-t is, mert akkor kétszer fut le!

## 5. Az adatok tárolása

Az osztályt (pl. `Auto`) és a beolvasást **ugyanúgy** csinálod, mint a konzolos részben. A lista az osztály **szintjén** legyen (nem metóduson belül), hogy minden eseménykezelő lássa:

```csharp
public partial class Form1 : Form
{
    List<Auto> autok = new List<Auto>();     // ITT: minden metódus látja

    private void Form1_Load(object sender, EventArgs e)
    {
        // List<Auto> autok = ...   <- NE itt! Akkor a többi metódus nem látná.
    }
}
```

## 6. Egy tipikus vizsga-GUI menete

```
 Program indul
     │
     ▼
 Form1()  konstruktor:  InitializeComponent() + események bekötése (+=)
     │
     ▼
 Form1_Load:  beolvasás → listák / adatrács feltöltése → kezdőállapot beállítása
     │
     ▼
 VÁR a felhasználóra ◄──────────────────────────────────────────────┐
     │                                                              │
     ├─ kiválaszt valamit  → SelectedIndexChanged → részletek kiírása ─┤
     ├─ gépel              → TextChanged         → lista szűrése     ─┤
     ├─ bejelöl            → CheckedChanged      → lista szűrése     ─┤
     └─ gombra kattint     → Click → ellenőrzés → MessageBox → fájlba ─┘
```

Ennyi. Minden vizsgafeladat ennek a sémának egy változata.

**Tovább:** [README.md](README.md) (keresőtábla) · [01_AutokGUI lépésről lépésre](2_GYAKORLO_FELADATOK/01_AutokGUI/LEPESROL_LEPESRE.md)
