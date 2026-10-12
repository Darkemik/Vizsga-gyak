# RendelesGUI – lépésről lépésre

## 1. Projekt, osztály, adatfájl (5 perc)

1. **Windows Forms App** → név: `RendelesGUI`.
2. Add → Class… → `Termek.cs` → tartalma: [Megoldas/Termek.cs](Megoldas/Termek.cs). Figyeld meg a `ToString()`-et: ez fog látszani a listában.
3. `forras` mappa → bele a `kinalat.txt`.

## 2. Az ablak (10 perc)

| # | Toolboxból | (Name) | Text / beállítás |
|---|---|---|---|
| 0 | *(az ablak)* | – | Text: `Kávézó – rendelés`, kb. 680×480 |
| 1 | Label | – | `Kínálatunk` |
| 2 | **CheckBox** | **`chkLaktozmentes`** | `Laktózmentes` |
| 3 | **CheckBox** | **`chkCukormentes`** | `Cukormentes` |
| 4 | **ListBox** | **`lbKinalat`** | – |
| 5 | Label | – | `Kiválasztott:` |
| 6 | **Label** | **`lblValasztott`** | `-` |
| 7 | Label | – | `Darab:` |
| 8 | **NumericUpDown** | **`numDarab`** | Minimum `1`, Maximum `10`, Value `1` |
| 9 | **Button** | **`btnKosarba`** | `Kosárba` |
| 10 | Label | – | `Kosár` |
| 11 | **RichTextBox** | **`rtbKosar`** | ReadOnly `True` |
| 12 | Label ×3 | – | `Részösszeg:`, `Kiszállítás:`, `Végösszeg:` |
| 13 | **Label** ×3 | **`lblReszosszeg`, `lblSzallitas`, `lblVegosszeg`** | `0 Ft` |
| 14 | Label | – | `5000 Ft-tól ingyenes kiszállítás!` |
| 15 | **Button** | **`btnRendeles`** | `Rendelés leadása` |

## 3. A kód (15 perc)

Teljes kód: [Megoldas/Form1.cs](Megoldas/Form1.cs).

### 3/a – az osztály szintjén: listák, összeg, állandók

```csharp
List<Termek> termekek = new List<Termek>();
List<string> kosarTetelek = new List<string>();
int reszosszeg = 0;                 // ITT, nem metóduson belül -> megmarad a kattintások között
const int SZALLITASI_DIJ = 690;
const int INGYENES_HATAR = 5000;
```

### 3/b – események

```csharp
this.Load += Form1_Load;
lbKinalat.SelectedIndexChanged += LbKinalat_SelectedIndexChanged;
chkLaktozmentes.CheckedChanged += Szures_Esemeny;     // mindkettő ugyanazt hívja!
chkCukormentes.CheckedChanged += Szures_Esemeny;
btnKosarba.Click += BtnKosarba_Click;
btnRendeles.Click += BtnRendeles_Click;
```

### 3/c – szűrés (14.), ezt a betöltés is használja (12.)

```csharp
private void Szures()
{
    lbKinalat.Items.Clear();
    foreach (Termek t in termekek.Where(t => (!chkLaktozmentes.Checked || t.Laktozmentes)
                                          && (!chkCukormentes.Checked || t.Cukormentes)))
        lbKinalat.Items.Add(t);                 // OBJEKTUM a listába
    if (lbKinalat.Items.Count > 0) lbKinalat.SelectedIndex = 0;
}
```

**F5** → pipáld be a Laktózmentest → 6 termék marad?

### 3/d – kiválasztás (13.)

```csharp
private void LbKinalat_SelectedIndexChanged(object sender, EventArgs e)
{
    if (lbKinalat.SelectedItem == null) return;       // Items.Clear() után null!
    Termek t = (Termek)lbKinalat.SelectedItem;
    lblValasztott.Text = $"{t.Nev}, {t.Ar} Ft";
}
```

### 3/e – Kosárba (15.)

Másold ki a `BtnKosarba_Click` és az `OsszegekFrissitese` metódust. A lényeg:

```csharp
int db = (int)numDarab.Value;          // a NumericUpDown értéke decimal -> (int)
reszosszeg += t.Ar * db;
// szállítás: 0, ha a részösszeg >= 5000, különben 690
```

### 3/f – Rendelés (16.)

Másold ki a `BtnRendeles_Click` metódust: üres kosár → hiba; YesNo; Igen → `StreamWriter(..., true)` → kosár ürítése.

## 4. Kipróbálás

| Mit csinálsz | Mit kell látnod |
|---|---|
| Indítás | 14 termék, az Espresso kiválasztva, mindenhol 0 Ft |
| Rendelés üres kosárral | hibaüzenet |
| Laktózmentes + Cukormentes | 4 termék |
| Zabtejes latte, 2 db, Kosárba | 2380 / 690 / 3070 Ft |
| + Almás pite, 4 db | 5540 / **0** / 5540 Ft |
| Rendelés → Igen | `forras/rendelesek.txt`-ben 1 sor, a kosár kiürül |
