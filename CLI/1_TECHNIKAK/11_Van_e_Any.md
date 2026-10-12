# 11 – Van-e ilyen? Mindegyik ilyen? (Any, All, Contains)

**Mikor kell?** „Van-e olyan …?”, „Igaz-e, hogy minden …?”, „Döntse el, hogy …”

## A kód

```csharp
bool van = futok.Any(f => f.NoiFuto && f.Ido < new TimeSpan(1, 15, 0));   // legalább EGY igaz?
bool mind = diakok.All(d => d.Hianyzas < 50);                              // MINDEGYIKRE igaz?
bool benneVan = d.Jegyek.Contains(1);                                      // ez az ÉRTÉK benne van-e?

// Kiírás igen/nem szöveggel (feltételes operátor: feltétel ? ha_igaz : ha_hamis)
Console.WriteLine($"9. feladat: {(van ? "Van" : "Nincs")} ilyen futó.");
```

## Ha igen, ki is kell írni

```csharp
if (ingatlanok.Any(i => i.Telepules == "Budapest" && i.Ar < 50_000_000))
{
    Ingatlan olcso = ingatlanok.Where(i => i.Telepules == "Budapest").OrderBy(i => i.Ar).First();
    Console.WriteLine($"Van: {olcso}");
}
else
{
    Console.WriteLine("Nincs ilyen.");
}
```

## Gyakori hiba

A `?:` kifejezést interpolált szövegben **zárójelbe** kell tenni: `{(van ? "Van" : "Nincs")}`.

**Élesben:** [03_Futoverseny](../2_GYAKORLO_FELADATOK/03_Futoverseny/Megoldas/Program.cs) (9. feladat), [04_Ingatlan](../2_GYAKORLO_FELADATOK/04_Ingatlan/Megoldas/Program.cs) (9. feladat)
