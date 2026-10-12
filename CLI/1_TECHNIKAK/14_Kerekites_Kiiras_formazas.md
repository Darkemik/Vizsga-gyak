# 14 – Kerekítés, kiírás, formázás

**Mikor kell?** „kerekítse 2 tizedesjegyre”, „egész számra kerekítve”, „a minta szerint”

## Kerekítés

```csharp
double ketTizedes = Math.Round(x, 2, MidpointRounding.AwayFromZero);   // 2,345 -> 2,35
long egeszre = (long)Math.Round(x, MidpointRounding.AwayFromZero);    // 2,5   -> 3
```

> **Fontos:** `Math.Round(2.5)` alapból **2**-t ad („banki” kerekítés, páros felé)! Ezért írd mellé mindig: `MidpointRounding.AwayFromZero`.

## Formázás kiíráskor (a szám maga nem változik)

| Kód | Eredmény (magyar gépen) | Mire jó |
|---|---|---|
| `{x:F2}` | `1234,57` | 2 tizedes |
| `{x:F0}` | `1235` | egészre kerekítve írja ki |
| `{x:N0}` | `1 235` | ezres tagolás |
| `{x:N2}` | `1 234,57` | ezres tagolás + 2 tizedes |
| `{x:P1}` | `12,3%` | százalék (0,123-ból) |
| `{nev,-15}` | `Kiss Anna      ` | 15 széles, balra igazított |
| `{db,5}` | `   42` | 5 széles, jobbra igazított |
| `{x,10:F2}` | `   1234,57` | szélesség és formátum együtt |
| `{datum:yyyy.MM.dd.}` | `2026.03.14.` | dátum, lásd 15 |

## Kiírás feladatszámmal (a vizsgán kötelező!)

```csharp
Console.WriteLine($"5. feladat: {db} db autó");
Console.WriteLine("6. feladat:");             // ha utána több sor jön
Console.WriteLine($"\t{e.Nev}");              // \t = behúzás a mintához
```

## Százalék számítása

```csharp
double szazalek = (double)reszDb / osszDb * 100;   // a (double) kell, különben egész osztás!
Console.WriteLine($"{szazalek:F2}%");
```

**Élesben:** [01_Autok/Auto.cs](../2_GYAKORLO_FELADATOK/01_Autok/Megoldas/Auto.cs) (AtlagFogyasztas), [01_Autok/Program.cs](../2_GYAKORLO_FELADATOK/01_Autok/Megoldas/Program.cs) (6. feladat)
