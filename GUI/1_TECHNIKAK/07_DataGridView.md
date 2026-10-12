# 07 – DataGridView (adatrács, táblázat)

**Mikor kell?** „…jelenjen meg az adattábla összes rekordja az alkalmazásablak **adatrácsában**”, „Ha kijelöljük az adatrácsban valamelyik sort…”

## Designer

Toolbox → **DataGridView** → (Name): pl. `dgvErmek`. Properties:

| Beállítás | Érték | Miért |
|---|---|---|
| **AllowUserToAddRows** | **False** | különben van egy üres „új sor” alul, és ha rákattintanak → hiba |
| **ReadOnly** | True | ne lehessen átírni a cellákat |
| **SelectionMode** | FullRowSelect | kattintásra az egész sor kijelölődik |
| **RowHeadersVisible** | False | a bal oldali üres oszlop eltűnik (ha a minta ilyen) |
| **AutoSizeColumnsMode** | Fill | az oszlopok kitöltik a szélességet |

> Ezeket kódból is beállíthatod a `Load`-ban: `dgvErmek.AllowUserToAddRows = false;` stb.

## Oszlopok + sorok (a tanárotok módja)

```csharp
private void Form1_Load(object sender, EventArgs e)
{
    Beolvasas();

    // 1. oszlopok: Columns.Add("belső név", "fejléc felirata")
    dgvErmek.Columns.Add("Id", "Sorszám");
    dgvErmek.Columns.Add("Orszag", "Ország");
    dgvErmek.Columns.Add("Varos", "Város");
    dgvErmek.Columns.Add("Ev", "Év");
    dgvErmek.Columns.Add("Arany", "Arany");

    // 2. sorok
    TablaFeltoltes(adatok);
}

// Külön metódus, mert a szűrés is ezt hívja
private void TablaFeltoltes(List<Paralimpia> lista)
{
    dgvErmek.Rows.Clear();
    foreach (Paralimpia p in lista)
    {
        // az értékek SORRENDJE = az oszlopok sorrendje
        dgvErmek.Rows.Add(p.Id, p.Orszag, p.Varos, p.Ev, p.Arany);
    }
}
```

> Az oszlopokat a Designerben is felveheted: kattints az adatrácsra → jobb felső kis nyíl ▸ → **Edit Columns… → Add**.

## Kijelölt sor → adatok kiírása (CellClick)

```csharp
// konstruktorban:
dgvErmek.CellClick += DgvErmek_CellClick;

private void DgvErmek_CellClick(object sender, DataGridViewCellEventArgs e)
{
    if (e.RowIndex < 0) return;                        // a FEJLÉCRE kattintottak -> nincs sor

    DataGridViewRow sor = dgvErmek.Rows[e.RowIndex];
    lblEv.Text = sor.Cells["Ev"].Value.ToString();      // oszlop belső neve szerint
    txtArany.Text = sor.Cells[4].Value.ToString();      // vagy oszlop SORSZÁMA szerint (0-tól)
}
```

## Másik mód: DataSource (oszlopok automatikusan)

```csharp
dgvErmek.DataSource = adatok.ToList();     // az osztály tulajdonságai lesznek az oszlopok
// szűrés:
dgvErmek.DataSource = adatok.Where(p => p.Ev > 2000).ToList();
// kijelölt sor objektumként:
Paralimpia p = (Paralimpia)dgvErmek.Rows[e.RowIndex].DataBoundItem;
```

> Gyorsabb, de az oszlopfejlécek a tulajdonságnevek lesznek (`Orszag`, nem `Ország`), és DataSource mellett a `Rows.Add`/`Rows.Clear` nem használható.

## Gyakori hibák

- `Rows.Add` oszlopok nélkül: „No row can be added to a DataGridView control that does not have columns” → előbb `Columns.Add`.
- Kattintás a fejlécre: `e.RowIndex == -1` → `Rows[-1]` hiba. Ezért kell az `if (e.RowIndex < 0) return;`.
- Az üres „új sor” (AllowUserToAddRows = True): ha rákattintanak, a `Value` null → `NullReferenceException`.

**Élesben:** [02_ErmekGUI](../2_GYAKORLO_FELADATOK/02_ErmekGUI/Megoldas/Form1.cs)
