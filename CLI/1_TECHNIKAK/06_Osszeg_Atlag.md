# 06 – Összeg, átlag (Sum, Average)

**Mikor kell?** „Mennyi az összes …?”, „Határozza meg az átlagos …-t”

## A kód

```csharp
double osszeg = lista.Sum(e => e.Ar);
double atlag  = lista.Average(e => e.Alapterulet);    // az Average MINDIG double

// Szűrt átlag: előbb Where, utána Average
double gyumolcsAtlag = lista.Where(e => e.Kategoria == "Gyumolcs").Average(e => e.Ar);

Console.WriteLine($"4. feladat: Átlagos alapterület: {atlag:F2} m²");
```

## Számítás két mezőből

```csharp
// pl. a városi és az autópályás fogyasztás átlaga autónként
double atlagFogy = (a.FogyasztasVarosban + a.FogyasztasAutopalyan) / 2;
```

## Gyakori hibák

- **Üres listára** az `Average` hibát dob. Ha a szűrés üres is lehet, előtte nézd meg: `if (lista.Any(...))`.
- **Egész osztás:** `int / int` levágja a törtet! `7 / 2 = 3`. Helyesen: `(double)osszeg / db` vagy `7 / 2.0`.
- **TimeSpan** átlaga: másodpercben kell átlagolni, lásd [16_Ido_TimeSpan](16_Ido_TimeSpan.md).

**Élesben:** [04_Ingatlan](../2_GYAKORLO_FELADATOK/04_Ingatlan/Megoldas/Program.cs) (4. és 7. feladat)
