# 12 – MessageBox (üzenetablak)

**Mikor kell?** „…jelenjen meg egy üzenetablak”, „A felhasználói szándék megerősítésére szolgáló, minta szerinti üzenetablak…”, hibaüzenet

## A 4 rész

```csharp
MessageBox.Show(
    "Valóban leadja a rendelést?",      // 1. szöveg
    "Megerősítés",                      // 2. ablak címe (caption)
    MessageBoxButtons.YesNo,            // 3. gombok
    MessageBoxIcon.Question);           // 4. ikon
```

Nevesített paraméterekkel (a tanárotok így írja, ugyanaz):

```csharp
MessageBox.Show(text: "Valóban leadja a rendelést?",
                caption: "Megerősítés",
                buttons: MessageBoxButtons.YesNo,
                icon: MessageBoxIcon.Question);
```

## Választások a mintakép alapján

| A mintán ez látszik | Gombok | Ikon |
|---|---|---|
| csak OK | `MessageBoxButtons.OK` | |
| Igen / Nem | `MessageBoxButtons.YesNo` | |
| OK / Mégse | `MessageBoxButtons.OKCancel` | |
| Igen / Nem / Mégse | `MessageBoxButtons.YesNoCancel` | |
| kék kérdőjel | | `MessageBoxIcon.Question` |
| sárga felkiáltójel | | `MessageBoxIcon.Warning` |
| piros X | | `MessageBoxIcon.Error` |
| kék „i” | | `MessageBoxIcon.Information` |

## Megerősítés: mit választott?

```csharp
DialogResult valasz = MessageBox.Show(
    $"Valóban javaslatot tesz a(z) {lblEv.Text}. évi paralimpia éremszámaira?",
    "Megerősítés", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

if (valasz == DialogResult.Yes)
{
    // csak IGEN esetén: mentés fájlba, stb.
}
```

| Gomb | Visszatérési érték |
|---|---|
| Igen | `DialogResult.Yes` |
| Nem | `DialogResult.No` |
| OK | `DialogResult.OK` |
| Mégse | `DialogResult.Cancel` |

## Többsoros szöveg

```csharp
MessageBox.Show($"Leadja a rendelést?\nVégösszeg: {vegosszeg} Ft", "Rendelés",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
```

## Kilépés a programból az üzenet után

„…majd az alkalmazás záródjon be”:

```csharp
Application.Exit();      // az egész program bezárul
// vagy: this.Close();   // ez az ablak bezárul (egyablakos programnál ugyanaz)
```

## Gyakori hibák

- Rossz **sorrend**: a 2. paraméter a CÍM, nem a szöveg. Az `MessageBox.Show("Hiba", "Rossz szám!")` fordítva jelenik meg.
- Az Igen/Nem eredményét nem vizsgálod: akkor a „Nem”-re is ment.

**Élesben:** [02_ErmekGUI](../2_GYAKORLO_FELADATOK/02_ErmekGUI/Megoldas/Form1.cs), [03_RendelesGUI](../2_GYAKORLO_FELADATOK/03_RendelesGUI/Megoldas/Form1.cs), [04_ReszletekGUI](../2_GYAKORLO_FELADATOK/04_ReszletekGUI/Megoldas/Form1.cs)
