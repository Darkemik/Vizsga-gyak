# 02 – Osztály konstruktorral

**Mikor kell?** Mindig. „Készítsen saját osztályt … azonosítóval, az osztálydiagram alapján.”

## Új osztály Visual Studióban

Jobb klikk a projekten → **Add** → **Class…** → név (pl. `Auto.cs`) → Add.

## A kód

```csharp
using System;
using System.Globalization;

internal class Auto
{
    // Tulajdonságok: a nevük és típusuk PONTOSAN az osztálydiagram szerint
    public int Azonosito { get; set; }
    public string Modell { get; set; }
    public double Ar { get; set; }
    public bool Kiemelt { get; set; }

    // Konstruktor: egy fájlsort kap, és szétszedi
    public Auto(string sor)
    {
        string[] m = sor.Split(';');

        Azonosito = int.Parse(m[0]);                                // egész szám
        Modell = m[1];                                              // szöveg
        Ar = double.Parse(m[2].Replace(',', '.'), CultureInfo.InvariantCulture);   // tört szám (vessző vagy pont)
        Kiemelt = m[3] == "1";                                     // 1/0 -> true/false
    }
}
```

## Típusok átalakítása

| A fájlban | Típus | Átalakítás |
|---|---|---|
| `42` | `int` | `int.Parse(m[i])` |
| `13,5` vagy `13.5` | `double` | `double.Parse(m[i].Replace(',', '.'), CultureInfo.InvariantCulture)` (mindkettőre jó) |
| `szöveg` | `string` | `m[i]` |
| `1` / `0` | `bool` | `m[i] == "1"` |
| `igaz` / `hamis` | `bool` | `m[i] == "igaz"` |
| `2026-03-14` | `DateTime` | lásd [15_Datum_DateTime](15_Datum_DateTime.md) |
| `01:23:45` | `TimeSpan` | lásd [16_Ido_TimeSpan](16_Ido_TimeSpan.md) |
| `3,4,5` (lista) | `List<int>` | lásd lent |

## Lista egy mezőben (kétszintű Split)

```csharp
// a sor: "Kiss Anna;11.A;3,4,5,5"
Jegyek = new List<int>();
foreach (string j in m[2].Split(','))
{
    Jegyek.Add(int.Parse(j));
}
```

## Tipp

Írd fel magadnak a fejléc alapján: `0 = Azonosito, 1 = Evjarat, 2 = GyartoID …`. Így nem csúszol el az indexekkel.

**Élesben:** [01_Autok/Auto.cs](../2_GYAKORLO_FELADATOK/01_Autok/Megoldas/Auto.cs), [05_Diakok/Diak.cs](../2_GYAKORLO_FELADATOK/05_Diakok/Megoldas/Diak.cs) (lista a mezőben)
