# 06 – ComboBox (legördülő lista)

**Mikor kell?** „A legördülő listában jelenjenek meg a … (mindegyik csak egyszer)”, „Ha kiválasztunk egy fajtát…”

## Designer

- Toolbox → **ComboBox** → (Name): pl. `cbFajta`
- Ajánlott: **DropDownStyle = DropDownList** (nem lehet beleírni, csak választani)

## Feltöltés ismétlés nélkül

```csharp
cbFajta.Items.Clear();
foreach (string f in kutyak.Select(k => k.Fajta).Distinct().OrderBy(f => f))
{
    cbFajta.Items.Add(f);
}
cbFajta.SelectedIndex = -1;      // "ne legyen kiválasztva semmi"
// vagy: cbFajta.SelectedIndex = 0;   // "az első legyen kiválasztva"
```

> `Distinct()` = mindegyik csak egyszer. `OrderBy` = ABC sorrend (ha a minta nem rendezett, hagyd el).

Ha egy „mindegyik” opció is kell az elejére:

```csharp
cbFajta.Items.Add("(mindegyik)");
foreach (...) cbFajta.Items.Add(f);
```

## Kiválasztásra reagálás

```csharp
// konstruktorban:
cbFajta.SelectedIndexChanged += CbFajta_SelectedIndexChanged;

private void CbFajta_SelectedIndexChanged(object sender, EventArgs e)
{
    if (cbFajta.SelectedItem == null) return;           // semmi sincs kiválasztva
    string fajta = cbFajta.SelectedItem.ToString();

    lbKutyak.Items.Clear();
    foreach (Kutya k in kutyak.Where(k => k.Fajta == fajta))
    {
        lbKutyak.Items.Add(k);
    }
}
```

## Kiolvasás gombnyomáskor

```csharp
if (cbValto.SelectedItem == null)
{
    MessageBox.Show("Válasszon váltót!");
    return;
}
string valto = cbValto.SelectedItem.ToString();
```

## Gyakori hibák

- `cbValto.SelectedItem.ToString()` úgy, hogy nincs kiválasztva semmi: **NullReferenceException**, a program leáll. Előtte mindig: `if (... == null)`.
- **DropDown** stílusnál (ez az alapértelmezett) a felhasználó bele is írhat, akkor a `SelectedItem` null, de a `Text` nem üres. DropDownListtel ez nem fordul elő.
- `TextChanged` helyett a `SelectedIndexChanged` a helyes esemény a kiválasztáshoz.

**Élesben:** [01_AutokGUI](../2_GYAKORLO_FELADATOK/01_AutokGUI/Megoldas/Form1.cs) (karosszéria, váltó), [04_ReszletekGUI](../2_GYAKORLO_FELADATOK/04_ReszletekGUI/Megoldas/Form1.cs)
