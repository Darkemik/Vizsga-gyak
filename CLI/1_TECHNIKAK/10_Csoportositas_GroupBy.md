# 10 – Csoportosítás (GroupBy)

**Mikor kell?** Ha a feladatban **„…-nként”** szerepel: gyártónként, kategóriánként, osztályonként, hónaponként, egyesületenként. Vagy: „statisztika”.

## Alap: csoportonként darabszám

```csharp
foreach (var cs in autok.GroupBy(a => a.Gyarto.GyartoNev))
{
    Console.WriteLine($"\t{cs.Key}: {cs.Count()} db");
}
```

- `cs.Key` = a csoport „neve” (ami szerint csoportosítottunk)
- `cs` maga is egy lista: `cs.Count()`, `cs.Average(...)`, `cs.Max(...)`, `cs.Min(...)`, `cs.Sum(...)`

## Rendezve, több adattal

```csharp
foreach (var cs in ingatlanok.GroupBy(i => i.Kategoria).OrderBy(cs => cs.Key))
{
    double atlagAr = cs.Average(i => i.Ar);
    Console.WriteLine($"\t{cs.Key,-7} {cs.Count(),3} db, átlagár: {atlagAr:N0} Ft");
}
```

## A legnagyobb csoport („melyikből van a legtöbb?”)

```csharp
var legtobb = lista.GroupBy(k => k.Cim)
                   .OrderByDescending(cs => cs.Count())
                   .First();
Console.WriteLine($"{legtobb.Key}: {legtobb.Count()} db");
```

## Csoportosítás dátumrész szerint

```csharp
foreach (var cs in lista.GroupBy(k => k.Datum.Month).OrderBy(cs => cs.Key))
{
    Console.WriteLine($"{cs.Key}. hónap: {cs.Count()} db");
}
```

## Csoportokból fájl

```csharp
List<string> sorok = futok.GroupBy(f => f.Egyesulet)
                          .OrderByDescending(cs => cs.Count())
                          .Select(cs => $"{cs.Key};{cs.Count()}")
                          .ToList();
File.WriteAllLines("egyesuletek.txt", sorok);
```

**Alternatíva:** Dictionary-s számlálás, lásd [19_Distinct_Dictionary](19_Distinct_Dictionary.md).

**Élesben:** [01_Autok](../2_GYAKORLO_FELADATOK/01_Autok/Megoldas/Program.cs) (8. feladat), [02_Konyvtar](../2_GYAKORLO_FELADATOK/02_Konyvtar/Megoldas/Program.cs) (6. és 8. feladat), [03_Futoverseny](../2_GYAKORLO_FELADATOK/03_Futoverseny/Megoldas/Program.cs) (7. és 10. feladat)
