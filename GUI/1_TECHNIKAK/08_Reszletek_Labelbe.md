# 08 – Részletek kiírása (Label, TextBox, RichTextBox)

**Mikor kell?** „Ha kiválasztunk egy elemet, jelenjenek meg az adatai a megfelelő címkékben / beviteli mezőkben / a szövegdobozban”

## Címkékbe (Label)

```csharp
private void LbKutyak_SelectedIndexChanged(object sender, EventArgs e)
{
    if (lbKutyak.SelectedItem == null) return;
    Kutya k = (Kutya)lbKutyak.SelectedItem;

    lblNev.Text = k.Nev;
    lblKor.Text = $"{k.Kor} év";                       // mértékegységgel, a minta szerint
    lblSuly.Text = $"{k.Suly} kg";
    lblAllapot.Text = k.Orokbefogadva ? "Gazdára talált" : "Örökbefogadható";   // feltételes szöveg
}
```

> `feltétel ? "ha igaz" : "ha hamis"`: egy sorban választ a két szöveg közül.

## Beviteli mezőkbe (TextBox), amit a felhasználó módosíthat

```csharp
txtArany.Text = p.Arany.ToString();       // számot szöveggé kell alakítani!
```

## Többsoros szövegdobozba (RichTextBox)

```csharp
rtbReszletek.Text = $"Kategória\n\t{l.Kategoria}\n" +
                    $"Processzor\n\t{l.Processzor}\n" +
                    $"RAM\n\t{l.Ram} GB\n" +
                    $"Ár\n\t{l.Ar:N0} Ft";
```

Hozzáfűzés (pl. kosárhoz új sor):

```csharp
rtbKosar.AppendText($"{db} x {p.Nev} - {p.Ar} Ft\n");
```

> Designer: RichTextBox → **ReadOnly = True**, ha a felhasználó nem írhat bele.

## Üresre állítás

```csharp
lblNev.Text = "";
rtbReszletek.Clear();
```

## Gyakori hibák

- `lblKor.Text = k.Kor;` → fordítási hiba: a `Text` szöveget vár. Helyesen: `k.Kor.ToString()` vagy `$"{k.Kor}"`.
- A Label **AutoSize = True** mellett hosszú szövegnél kilóg. Ha fix méret kell: AutoSize = False, és húzd nagyobbra.

**Élesben:** [04_ReszletekGUI](../2_GYAKORLO_FELADATOK/04_ReszletekGUI/Megoldas/Form1.cs), [02_ErmekGUI](../2_GYAKORLO_FELADATOK/02_ErmekGUI/Megoldas/Form1.cs)
