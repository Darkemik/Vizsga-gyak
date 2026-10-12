# 14 – Számolás: kosár, részösszeg, végösszeg

**Mikor kell?** „A Kosárba gombra kattintva…”, „részösszeg”, „szállítási díj: 8000 Ft felett ingyenes”, „végösszeg”

## Az összeg az osztály szintjén

Ha több gombnyomáson át gyűlik (kosár), a változó az **osztály szintjén** legyen, különben minden kattintásnál nulláról indul:

```csharp
public partial class Form1 : Form
{
    List<Pizza> pizzak = new List<Pizza>();
    int reszosszeg = 0;                      // ITT: megmarad a kattintások között
    const int SZALLITASI_DIJ = 690;
    const int INGYENES_HATAR = 8000;
```

## Kosárba gomb

```csharp
private void BtnKosarba_Click(object sender, EventArgs e)
{
    if (lbPizzak.SelectedItem == null)
    {
        MessageBox.Show("Válasszon pizzát!");
        return;
    }
    Pizza p = (Pizza)lbPizzak.SelectedItem;
    int db = (int)numDarab.Value;

    // 1. a kosár szövegdobozba egy új sor
    rtbKosar.AppendText($"{db} x {p.Nev} - {p.Ar * db} Ft\n");

    // 2. összeg növelése
    reszosszeg += p.Ar * db;

    // 3. címkék frissítése
    OsszegekFrissitese();
}

private void OsszegekFrissitese()
{
    int szallitas;
    if (reszosszeg >= INGYENES_HATAR)
        szallitas = 0;
    else
        szallitas = SZALLITASI_DIJ;

    lblReszosszeg.Text = $"{reszosszeg} Ft";
    lblSzallitas.Text = $"{szallitas} Ft";
    lblVegosszeg.Text = $"{reszosszeg + szallitas} Ft";
}
```

## Kosár ürítése

```csharp
reszosszeg = 0;
rtbKosar.Clear();
OsszegekFrissitese();
```

## Gyakori hibák

- Az összeget a **Label szövegéből** akarod visszaolvasni és hozzáadni: bonyolult és hibás (`"1200 Ft"` nem szám). Tárold egy `int` változóban, a Label csak megjelenít.
- `int reszosszeg = 0;` a metóduson **belül**: minden kattintásnál nulláról indul.
- Feltétel határa: „8000 Ft **felett**” → `>`, „8000 Ft-**tól**” → `>=`. Olvasd el pontosan!

**Élesben:** [03_RendelesGUI](../2_GYAKORLO_FELADATOK/03_RendelesGUI/Megoldas/Form1.cs)
