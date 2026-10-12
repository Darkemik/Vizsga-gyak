# 03 – Események bekötése

**Mikor kell?** Minden interakcióhoz: „Az alkalmazás betöltésekor…”, „A gombra kattintva…”, „Ha kiválasztunk…”

## A tanárotok módja: `+=` a konstruktorban

```csharp
public Form1()
{
    InitializeComponent();                                  // 1. MINDIG ez az első!

    // 2. "ha EZ történik  +=  EZ a metódus fusson le"
    this.Load += Form1_Load;                                // ablak megnyílásakor
    btnKereses.Click += BtnKereses_Click;                   // gombnyomáskor
    lbAdatok.SelectedIndexChanged += LbAdatok_SelectedIndexChanged;   // kiválasztáskor
    txtSzuro.TextChanged += TxtSzuro_TextChanged;           // gépeléskor
    chkVega.CheckedChanged += ChkVega_CheckedChanged;       // pipáláskor
    dgvAdatok.CellClick += DgvAdatok_CellClick;             // adatrács cellájára kattintáskor
}

// 3. a metódusok (eseménykezelők)
private void Form1_Load(object sender, EventArgs e) { ... }
private void BtnKereses_Click(object sender, EventArgs e) { ... }
private void DgvAdatok_CellClick(object sender, DataGridViewCellEventArgs e) { ... }   // ⚠️ más a 2. paraméter!
```

### A vázat megírja a VS

Írd be a `+=` sort a metódus nevével. A VS aláhúzza (mert még nincs ilyen metódus) → kattints rá → **Ctrl + .** → **Generate method**.

## Melyik eseményt kell?

| Feladatszöveg | Vezérlő | Esemény |
|---|---|---|
| „Az alkalmazás betöltésekor / indításakor…” | az ablak (`this`) | `Load` |
| „A … gombra kattintva…” | Button | `Click` |
| „Ha kiválasztunk egy elemet a listából…” | ListBox, ComboBox | `SelectedIndexChanged` |
| „Ha a beviteli mezőbe gépelünk…” | TextBox | `TextChanged` |
| „Ha bejelöljük / kivesszük a jelölést…” | CheckBox, RadioButton | `CheckedChanged` |
| „Ha kijelölünk egy sort az adatrácsban…” | DataGridView | `CellClick` |
| „Ha megváltoztatjuk a darabszámot…” | NumericUpDown | `ValueChanged` |

## Több vezérlő → ugyanaz a metódus

Ha pl. két jelölőnégyzet ugyanazt a szűrést indítja:

```csharp
chkVega.CheckedChanged += Szures_Esemeny;
chkCsipos.CheckedChanged += Szures_Esemeny;

private void Szures_Esemeny(object sender, EventArgs e)
{
    Szures();   // egy közös metódus végzi a munkát
}
```

## A másik mód: dupla klikk a Designerben

Dupla klikk a gombon → a VS létrehozza a `btnKereses_Click` metódust, és **magától beköti** (a `Form1.Designer.cs`-be írja). Más eseményhez: Properties ablak → **villám ikon** ⚡ → az esemény mellett dupla klikk.

⚠️ **Csak az egyiket használd!** Ha duplán kattintottál ÉS a konstruktorba is beírtad a `+=`-t, a metódus **kétszer fut le** (pl. kétszer írja a fájlba).

**Élesben:** mindegyik gyakorlófeladat `Form1()` konstruktora
