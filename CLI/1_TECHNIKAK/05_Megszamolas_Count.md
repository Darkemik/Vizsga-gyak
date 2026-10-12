# 05 – Megszámolás (Count)

**Mikor kell?** „Hány db … van?”, „Hány olyan …, amelyik …?”, „Hányan …?”

## A kód

```csharp
int osszes = autok.Count;   // az összes elem (lista esetén zárójel NÉLKÜL)

int db = autok.Count(a => a.Gyarto.GyartoNev == "Rolls-Royce"
                       && a.Karosszeria.KarosszeriaNev == "Sedan"
                       && a.HengerekSzama == 8);

Console.WriteLine($"5. feladat: {db} db");
```

## Feltételek összekötése

| Jel | Jelentés | Példa |
|---|---|---|
| `&&` | ÉS (mindkettő igaz) | `a.Ar > 100 && a.Evjarat == 2020` |
| `\|\|` | VAGY (legalább az egyik) | `a.Szin == "Red" \|\| a.Szin == "Blue"` |
| `!` | NEM | `!k.Visszahozta` |
| `==` / `!=` | egyenlő / nem egyenlő | `a.Nem == "N"` |

## Kézzel, ciklussal (ha a LINQ nem jut eszedbe)

```csharp
int db = 0;
foreach (Auto a in autok)
{
    if (a.HengerekSzama == 8)
        db++;
}
```

## Gyakori hiba

`autok.Count` (tulajdonság, összes elem) vs. `autok.Count(feltétel)` (metódus, szűrt darabszám).

**Élesben:** [01_Autok](../2_GYAKORLO_FELADATOK/01_Autok/Megoldas/Program.cs) (5. feladat), [02_Konyvtar](../2_GYAKORLO_FELADATOK/02_Konyvtar/Megoldas/Program.cs) (4. feladat)
