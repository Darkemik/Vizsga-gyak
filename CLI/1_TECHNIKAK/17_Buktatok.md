# 17 – Buktatók (ezeken szokott elcsúszni)

## 1. „Could not find file …” – nem találja az adatfájlt

A program a `bin\Debug\net8.0\` mappából fut, ott keresi a fájlt. Két megoldás:

- **A)** Húzd be a fájlt a projektbe (Solution Explorer), jobb klikk rajta → **Properties** → **Copy to Output Directory: Copy if newer**.
- **B)** Másold be kézzel a `bin\Debug\net8.0\` mappába.

> A vizsgán a FORRÁS mappából másold, és a MEGOLDÁS mappába a **projektet** add le.

## 2. Tizedespont vs. tizedesvessző

A magyar Windows **vesszőt** vár (`13,5`). A vizsga `carsData.csv`-jében vessző van, ez magától működik, de más fájlokban **pont** is lehet (`13.5`), és az elszáll.

**Ezt használd mindig, mindkettőre jó, bármilyen gépen:**

```csharp
double.Parse(m[15].Replace(',', '.'), CultureInfo.InvariantCulture)
```

```csharp
double.Parse("13.5")                                   // magyar gépen: HIBA (FormatException)
double.Parse("13,5")                                   // magyar gépen: jó, angol gépen: 135 (!)
double.Parse("13.5", CultureInfo.InvariantCulture)    // jó, de "13,5"-re 135 (!)
double.Parse(s.Replace(',', '.'), CultureInfo.InvariantCulture)   // MINDIG jó
```

Kell hozzá: `using System.Globalization;`

## 3. Egész osztás

```csharp
int a = 7, b = 2;
double rossz = a / b;           // 3   (!!)
double jo = (double)a / b;      // 3,5
```

## 4. Math.Round „banki” kerekítése

```csharp
Math.Round(2.5)                                     // 2 (!!)
Math.Round(2.5, MidpointRounding.AwayFromZero)     // 3
```

## 5. Ékezetek a konzolon

Ha `?` jelenik meg az ékezetes betűk helyén, a `Main` elejére:

```csharp
Console.OutputEncoding = System.Text.Encoding.UTF8;
```

## 6. A fejléc sor

A `.Skip(1)` kihagyja. Ha elfelejted: `FormatException` az első `int.Parse`-nál.

## 7. Üres sor a fájl végén

Ha az utolsó sor üres, a `Split` után kevés mező lesz (`IndexOutOfRangeException`). Megoldás:

```csharp
foreach (string sor in File.ReadAllLines("adat.csv").Skip(1))
{
    if (sor.Trim() == "") continue;   // üres sort kihagyja
    lista.Add(new Elem(sor));
}
```

## 8. Szöveg összehasonlítás

- `==` kis/nagybetű érzékeny: `"Ferrari" != "ferrari"`.
- Ha nem számít: `a.ToLower() == b.ToLower()`.
- Felesleges szóköz a fájlban: `m[1].Trim()`.

## 9. A kiírás formája

A vizsgán az értékelő a **mintát** nézi: `5. feladat:` előtag, szóközök, mértékegység. Másold a minta szövegét!

## 10. Mentés

Ments gyakran, és a végén ellenőrizd, hogy a **MEGOLDÁS** mappában ott van-e a teljes projekt (a .sln, a .csproj és a .cs fájlok).
