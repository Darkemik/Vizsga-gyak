# ErmekGUI – lépésről lépésre

## 1. Projekt, osztály, adatfájl (5 perc)

1. **Windows Forms App** → név: `ErmekGUI` (lásd [01_AutokGUI 1. lépés](../01_AutokGUI/LEPESROL_LEPESRE.md)).
2. Add → Class… → `Eredmeny.cs` → tartalma: [Megoldas/Eredmeny.cs](Megoldas/Eredmeny.cs).
   ⚠️ Itt **tabulátor** az elválasztó: `sor.Split('\t')`.
3. A projekt mappájában `forras` mappa → bele az `ermek.txt`.

## 2. Az ablak (10 perc)

| # | Toolboxból | (Name) | Text / beállítás |
|---|---|---|---|
| 0 | *(az ablak)* | – | Text: `Diákolimpia – éremtábla`, méret kb. 780×500 |
| 1 | Label | – | `Iskola vagy város kezdete:` |
| 2 | **TextBox** | **`txtSzuro`** | – |
| 3 | **Label** | **`lblDb`** | `Találatok:` |
| 4 | **DataGridView** | **`dgvErmek`** | lásd lent |
| 5 | Label | – | `Iskola:` |
| 6 | **Label** | **`lblIskola`** | `-` |
| 7 | Label | – | `Év:` |
| 8 | **Label** | **`lblEv`** | `-` |
| 9 | Label ×3 | – | `Arany:`, `Ezüst:`, `Bronz:` |
| 10 | **TextBox** ×3 | **`txtArany`, `txtEzust`, `txtBronz`** | keskenyre |
| 11 | **Button** | **`btnJavaslat`** | `Módosítási javaslat` |

**A DataGridView beállításai** (Properties):
- **AllowUserToAddRows** → `False` ← ⚠️ ez a legfontosabb!
- **ReadOnly** → `True`
- **SelectionMode** → `FullRowSelect`
- **RowHeadersVisible** → `False`
- **AutoSizeColumnsMode** → `Fill`

Az oszlopokat **nem** a Designerben vesszük fel, hanem kódból (2/b), az gyorsabb.

## 3. A kód (15 perc)

Teljes kód: [Megoldas/Form1.cs](Megoldas/Form1.cs). Részenként:

### 3/a – lista + események

```csharp
List<Eredmeny> eredmenyek = new List<Eredmeny>();

public Form1()
{
    InitializeComponent();
    this.Load += Form1_Load;
    txtSzuro.TextChanged += TxtSzuro_TextChanged;
    dgvErmek.CellClick += DgvErmek_CellClick;
    btnJavaslat.Click += BtnJavaslat_Click;
}
```

### 3/b – betöltés: beolvasás, oszlopok, sorok (12.)

```csharp
private void Form1_Load(object sender, EventArgs e)
{
    Beolvasas();
    dgvErmek.Columns.Add("Id", "Sorszám");        // ("belső név", "fejléc")
    dgvErmek.Columns.Add("Iskola", "Iskola");
    // ... Varos, Ev, Arany, Ezust, Bronz
    TablaFeltoltes(eredmenyek);
}

private void TablaFeltoltes(List<Eredmeny> lista)
{
    dgvErmek.Rows.Clear();
    foreach (Eredmeny r in lista)
        dgvErmek.Rows.Add(r.Id, r.Iskola, r.Varos, r.Ev, r.Arany, r.Ezust, r.Bronz);
    lblDb.Text = $"Találatok: {lista.Count} db";
}
```

**F5** → látszik a táblázat 24 sorral? Tovább.

### 3/c – szűrés gépelésre (13.)

```csharp
private void TxtSzuro_TextChanged(object sender, EventArgs e)
{
    string minta = txtSzuro.Text.ToLower();
    TablaFeltoltes(eredmenyek.Where(r => r.Iskola.ToLower().StartsWith(minta)
                                      || r.Varos.ToLower().StartsWith(minta)).ToList());
}
```

**F5** → írj be egy `b` betűt → 13 sor marad? Töröld → 24 újra?

### 3/d – sor kijelölése (14.)

```csharp
private void DgvErmek_CellClick(object sender, DataGridViewCellEventArgs e)
{
    if (e.RowIndex < 0) return;                 // fejlécre kattintás
    DataGridViewRow sor = dgvErmek.Rows[e.RowIndex];
    lblIskola.Text = sor.Cells["Iskola"].Value.ToString();
    lblEv.Text = sor.Cells["Ev"].Value.ToString();
    txtArany.Text = sor.Cells["Arany"].Value.ToString();
    // ... Ezust, Bronz
}
```

### 3/e – javaslat gomb (15.)

Másold ki a `BtnJavaslat_Click` metódust. Sorrend:
1. ha `lblEv.Text == ""` → hibaüzenet, `return`
2. `MessageBox.Show(..., MessageBoxButtons.YesNo, MessageBoxIcon.Question)` → `DialogResult`
3. ha `Yes`: `using (StreamWriter sw = new StreamWriter("../../../forras/javaslat.txt", true))` → `sw.WriteLine($"{DateTime.Now}\t...")`

## 4. Kipróbálás

| Mit csinálsz | Mit kell látnod |
|---|---|
| Indítás | 24 sor, „Találatok: 24 db”, lent üres mezők |
| Javaslat gomb kijelölés nélkül | hibaüzenet |
| `b` beírása | 13 sor |
| Kattintás a fejlécre | NEM száll el |
| Kattintás egy sorra | lent megjelenik az iskola, az év és az érmek |
| Javaslat → Nem | nem ír a fájlba |
| Javaslat → Igen (kétszer) | a `forras/javaslat.txt`-ben 2 sor dátummal |
