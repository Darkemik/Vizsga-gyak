# 13 – Fájlba írás GUI-ból (hozzáfűzés, dátummal)

**Mikor kell?** „…írja ki a javaslat.txt fájlba a minta alapján. A sor elejére a rendszeridőt írja. Gondoskodjon róla, hogy a további javaslatok ugyanebbe a fájlba kiírhatók legyenek.”

## A kód

```csharp
using System.IO;

// a második paraméter: true = HOZZÁFŰZÉS (a régi tartalom megmarad)
using (StreamWriter sw = new StreamWriter("../../../forras/javaslat.txt", true))
{
    sw.WriteLine($"{DateTime.Now}\t{lblEv.Text}\t{txtArany.Text}\t{txtEzust.Text}\t{txtBronz.Text}");
}
```

| Rész | Jelentés |
|---|---|
| `new StreamWriter(fájl, true)` | **true** = hozzáfűz a végéhez; **false** vagy elhagyva = felülírja |
| `using (...) { }` | a végén a fájl bezáródik és mentődik. Nélküle üres maradhat! |
| `DateTime.Now` | „rendszeridő”, pl. `2026. 10. 12. 9:15:30` |
| `\t` | tabulátor elválasztó; ha a minta `;`-t mutat, akkor `;` |

Egysoros változat (ugyanaz):

```csharp
File.AppendAllText("../../../forras/javaslat.txt",
                   $"{DateTime.Now};{lblNev.Text}" + Environment.NewLine);
```

## A dátum formázása a minta szerint

```csharp
DateTime.Now                                  // 2026. 10. 12. 9:15:30 (magyar gépen)
DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss")  // 2026.10.12 09:15:30
DateTime.Now.ToString("yyyy.MM.dd.")          // 2026.10.12.
```

## Hova kerül a fájl?

- `"../../../forras/javaslat.txt"` → a projekt `forras` mappájába (a tanárotok módszere)
- `"javaslat.txt"` → a program mellé: `bin\Debug\net…-windows\javaslat.txt`

> Nézd meg, a feladat hova kéri! Ha nem mondja, a `forras`-ba írd, ott könnyű megtalálni.

## Megerősítéssel együtt (a teljes tipikus gomb)

```csharp
private void BtnJavaslat_Click(object sender, EventArgs e)
{
    DialogResult valasz = MessageBox.Show(
        $"Valóban javaslatot tesz a(z) {lblEv.Text}. évi éremszámokra?",
        "Megerősítés", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

    if (valasz == DialogResult.Yes)
    {
        using (StreamWriter sw = new StreamWriter("../../../forras/javaslat.txt", true))
        {
            sw.WriteLine($"{DateTime.Now}\t{lblEv.Text}\t{txtArany.Text}\t{txtEzust.Text}\t{txtBronz.Text}");
        }
    }
}
```

**Élesben:** [02_ErmekGUI](../2_GYAKORLO_FELADATOK/02_ErmekGUI/Megoldas/Form1.cs), [04_ReszletekGUI](../2_GYAKORLO_FELADATOK/04_ReszletekGUI/Megoldas/Form1.cs)
