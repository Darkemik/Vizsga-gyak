# 04 – Betöltéskor (Load)

**Mikor kell?** „Az alkalmazás betöltésekor jelenjen meg…”, „Induláskor … legyen kiválasztva / üres”

## A váz

```csharp
public Form1()
{
    InitializeComponent();
    this.Load += Form1_Load;
}

private void Form1_Load(object sender, EventArgs e)
{
    Beolvasas();          // 1. adatok beolvasása (lásd 01)
    ListaFeltoltes();     // 2. lista / adatrács / ComboBox feltöltése
    // 3. kezdőállapot: mi legyen kiválasztva, mi legyen üres
}
```

## Tipikus kezdőállapotok

```csharp
lbAdatok.SelectedIndex = 0;          // "az első elem legyen kiválasztva"
cbTipus.SelectedIndex = -1;          // "ne legyen kiválasztva semmi"
txtTol.Text = "";                    // "a mező legyen üres"
rb2.Checked = false;                 // "egyik rádiógomb se legyen bejelölve"
chkVega.Checked = false;             // "a jelölőnégyzet ne legyen bejelölve"
lblAr.Text = "";                     // "a címke legyen üres"
this.ActiveControl = lbAdatok;       // a fókusz ide kerül (rádiógombnál fontos, lásd 15)
```

## Feliratok kiszámolt értékkel

Ha a feladat például ezt kéri: „VÁLASSZON 5 GYÁRTÓ 40 LAPTOPJA KÖZÜL!”

```csharp
int gyartoDb = laptopok.Select(l => l.Gyarto).Distinct().Count();
lblValasztek.Text = $"VÁLASSZON {gyartoDb} GYÁRTÓ {laptopok.Count} LAPTOPJA KÖZÜL!";
```

## Az ablak címe kódból

```csharp
this.Text = "Paralimpia – magyar eredmények";
```

## Gyakori hibák

- A beolvasást a **konstruktorba** írod `InitializeComponent()` **elé**: a vezérlők még nem léteznek, hibát dob. Tedd a `Load`-ba.
- A `SelectedIndex = 0` **előtt** üres a lista (rossz sorrend): `ArgumentOutOfRangeException`. Először tölts, utána válassz.
- A `SelectedIndex = 0` beállítása **elsüti** a `SelectedIndexChanged` eseményt. Ez általában jó (megjelennek a részletek), de az eseménykezelő legyen felkészülve rá.

**Élesben:** [01_AutokGUI/Form1.cs](../2_GYAKORLO_FELADATOK/01_AutokGUI/Megoldas/Form1.cs) (`Form1_Load`)
