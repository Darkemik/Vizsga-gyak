# 11 – Szám bevitele és ellenőrzése (TextBox, NumericUpDown)

**Mikor kell?** Ha a felhasználó számot ír be (darab, év, ár), és „ha nem megfelelő, hibaüzenet”.

## TextBoxból: `int.TryParse` (nem száll el)

```csharp
int darab;
if (!int.TryParse(txtDarab.Text, out darab))
{
    MessageBox.Show("A darabszámhoz egész számot írjon!", "Hibás adat",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
    return;                       // kilépünk, a többi kód nem fut le
}
// innen a darab biztosan szám
```

Két mező egyszerre:

```csharp
int tol, ig;
if (!int.TryParse(txtTol.Text, out tol) || !int.TryParse(txtIg.Text, out ig))
{
    MessageBox.Show("Mindkét mezőbe egész számot írjon!");
    return;
}
```

További feltételek:

```csharp
if (darab < 1 || darab > 10)
{
    MessageBox.Show("A darabszám 1 és 10 között lehet!");
    return;
}
if (tol > ig)
{
    MessageBox.Show("A kezdőérték nem lehet nagyobb a végértéknél!");
    return;
}
```

> `int.Parse(txtDarab.Text)` is működik, de ha betűt vagy semmit írtak be, **leáll a program** (FormatException). Ezért `TryParse`.
> Tört számhoz: `double.TryParse(txt.Text, out d)`.

## Üres-e a mező?

```csharp
if (txtNev.Text.Trim() == "")       // a Trim levágja a szóközöket
{
    MessageBox.Show("Adja meg a nevet!");
    return;
}
```

## NumericUpDown (szám fel/le nyilakkal): eleve csak szám lehet

Designer: Toolbox → **NumericUpDown** → (Name): `numDarab`, **Minimum** = 1, **Maximum** = 10, **Value** = 1.

```csharp
int darab = (int)numDarab.Value;      // a Value decimal típusú -> (int)-tel alakítjuk
numDarab.Value = 1;                   // visszaállítás
```

> Ha a mintaképen fel/le nyilas mező van, NumericUpDown kell; ott nem kell TryParse.

**Élesben:** [01_AutokGUI](../2_GYAKORLO_FELADATOK/01_AutokGUI/Megoldas/Form1.cs) (TryParse), [03_RendelesGUI](../2_GYAKORLO_FELADATOK/03_RendelesGUI/Megoldas/Form1.cs) (NumericUpDown)
