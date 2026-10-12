# 05 – ListBox (lista)

**Mikor kell?** „…jelenjenek meg a listában”, „Ha kiválasztunk egy elemet a listából…”

## Feltöltés

```csharp
lbAdatok.Items.Clear();                 // először mindig ürítsd!
foreach (Kutya k in kutyak)
{
    lbAdatok.Items.Add(k);              // OBJEKTUMOT teszünk bele -> a ToString() jelenik meg
}
lbAdatok.SelectedIndex = 0;             // az első legyen kiválasztva
```

Csak szöveg kell (pl. ismétlés nélküli nevek):

```csharp
foreach (string gy in autok.Select(a => a.Gyarto.GyartoNev).Distinct().OrderBy(n => n))
{
    lbGyartok.Items.Add(gy);
}
```

## Melyik van kiválasztva?

```csharp
lbAdatok.SelectedIndex     // hányadik (0-tól), -1 ha semmi
lbAdatok.SelectedItem      // MAGA az elem (object), null ha semmi
```

### ✅ A biztos módszer: objektum a listában + SelectedItem

```csharp
private void LbAdatok_SelectedIndexChanged(object sender, EventArgs e)
{
    if (lbAdatok.SelectedItem == null) return;       // nincs kiválasztva (pl. ürítés után)
    Kutya k = (Kutya)lbAdatok.SelectedItem;          // visszaalakítjuk Kutya-vá
    lblNev.Text = k.Nev;
    lblFajta.Text = k.Fajta;
}
```

### ⚠️ A veszélyes módszer: index a teljes listába

```csharp
int i = lbAdatok.SelectedIndex;
lblNev.Text = kutyak[i].Nev;     // CSAK akkor jó, ha a ListBox UGYANAZT tartalmazza, mint a lista!
```

Ha a ListBoxban **szűrt** elemek vannak (pl. csak a beaglek), a 0. sor nem a `kutyak[0]`, és **rossz kutya adatai** jelennek meg. Ezért tegyél objektumot a ListBoxba, és a `SelectedItem`-et használd.

## Ha a ToString() nem a kívánt szöveget adja

Ha a ToString már foglalt (pl. a konzolos kiíráshoz), de a listában más formátum kell:

```csharp
lbTalalatok.Items.Add(a.TalalatSor());     // csak szöveget teszünk bele (saját metódus)
```

Ekkor a `SelectedItem` szöveg lesz, nem objektum.

## Egyéb

```csharp
lbAdatok.Items.Count          // hány elem van benne
lbAdatok.Items.Remove(elem);  // egy elem törlése
```

**Élesben:** [01_AutokGUI](../2_GYAKORLO_FELADATOK/01_AutokGUI/Megoldas/Form1.cs), [04_ReszletekGUI](../2_GYAKORLO_FELADATOK/04_ReszletekGUI/Megoldas/Form1.cs)
