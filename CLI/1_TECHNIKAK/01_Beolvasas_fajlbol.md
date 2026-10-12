# 01 – Beolvasás fájlból

**Mikor kell?** Mindig. „Olvassa be az adatforrás adatait, és tárolja egy összetett adatszerkezetben.”

## A kód

```csharp
using System.IO;
using System.Linq;

List<Auto> autok = new List<Auto>();
foreach (string sor in File.ReadAllLines("carsData.csv").Skip(1))
{
    autok.Add(new Auto(sor));   // a konstruktor szedi szét a sort (lásd 02)
}
```

## Mit csinál?

| Rész | Jelentés |
|---|---|
| `File.ReadAllLines("fájl")` | a fájl összes sora egy `string[]` tömbbe |
| `.Skip(1)` | az első sort (fejléc, mezőnevek) kihagyja |
| `new Auto(sor)` | egy sorból egy Auto objektum |
| `List<Auto>` | ebben tároljuk; ez az „összetett adatszerkezet” |

## Ha NINCS fejléc a fájlban

Hagyd el a `.Skip(1)`-et.

## Ha az elválasztó nem pontosvessző

A konstruktorban a `Split` paraméterét kell átírni:

```csharp
sor.Split(';')    // pontosvessző
sor.Split('\t')   // tabulátor
sor.Split(',')    // vessző
sor.Split(' ')    // szóköz
```

## Gyakori hiba

- **„Could not find file”**: a fájl nincs a program mellett. Lásd [17_Buktatok](17_Buktatok.md).
- Elfelejtett `.Skip(1)`: a fejlécből próbál számot csinálni, és `FormatException`-t dob.

**Élesben:** [01_Autok/Program.cs](../2_GYAKORLO_FELADATOK/01_Autok/Megoldas/Program.cs) (4. feladat)
