# 19 – Hány különböző? Melyikből van a legtöbb? (Distinct, Dictionary)

## Hány különböző (Distinct)

**Mikor kell?** „Hány különböző … szerepel?”, „Sorolja fel ismétlés nélkül …”

```csharp
List<string> telepulesek = ingatlanok
    .Select(i => i.Telepules)   // csak a település nevét vesszük ki
    .Distinct()                 // ismétlődések eldobása
    .OrderBy(t => t)            // ABC sorrend
    .ToList();

Console.WriteLine($"{telepulesek.Count} település: {string.Join(", ", telepulesek)}");
```

## Gyakoriság Dictionary-vel (a GroupBy „klasszikus” párja)

**Mikor kell?** „Melyikből van a legtöbb?”, „Hányszor fordul elő …?”, vagy ha a tanárod így tanította.

```csharp
Dictionary<string, int> db = new Dictionary<string, int>();   // kulcs -> darabszám
foreach (Ingatlan i in ingatlanok)
{
    if (db.ContainsKey(i.Elado.Nev))
        db[i.Elado.Nev]++;          // már szerepelt: +1
    else
        db[i.Elado.Nev] = 1;        // először látjuk: 1
}

// Kiírás
foreach (KeyValuePair<string, int> par in db)
{
    Console.WriteLine($"\t{par.Key}: {par.Value} db");
}

// A legnagyobb
var legtobb = db.OrderByDescending(p => p.Value).First();
Console.WriteLine($"Legtöbb: {legtobb.Key} ({legtobb.Value} db)");
```

## Ugyanez GroupBy-jal (rövidebb)

```csharp
var legtobb = ingatlanok.GroupBy(i => i.Elado.Nev).OrderByDescending(cs => cs.Count()).First();
Console.WriteLine($"Legtöbb: {legtobb.Key} ({legtobb.Count()} db)");
```

## Tömb mint számláló (ha a kulcs kis egész szám, pl. jegy 1–5)

```csharp
int[] db = new int[6];          // 0..5 indexek, a 0-t nem használjuk
foreach (Diak d in diakok)
    foreach (int jegy in d.Jegyek)
        db[jegy]++;

for (int j = 5; j >= 1; j--)
    Console.WriteLine($"{j}-es: {db[j]} db");
```

**Élesben:** [04_Ingatlan](../2_GYAKORLO_FELADATOK/04_Ingatlan/Megoldas/Program.cs) (6. és 8. feladat), [05_Diakok](../2_GYAKORLO_FELADATOK/05_Diakok/Megoldas/Program.cs) (10. feladat)
