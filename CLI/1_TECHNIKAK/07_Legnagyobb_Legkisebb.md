# 07 – Legnagyobb / legkisebb elem

**Mikor kell?** „legdrágább”, „legolcsóbb”, „legrégebbi”, „a leggyorsabb”, „a legtöbb …”

## Ha az egész ELEM kell (pl. kiírni minden adatát)

```csharp
Auto legdragabb = autok.OrderByDescending(a => a.Ar).First();   // csökkenő -> első = legnagyobb
Auto legolcsobb = autok.OrderBy(a => a.Ar).First();             // növekvő  -> első = legkisebb

// .NET 6-tól rövidebben:
Auto legdragabb2 = autok.MaxBy(a => a.Ar);
Auto legolcsobb2 = autok.MinBy(a => a.Ar);

Console.WriteLine(legdragabb);   // ToString-gel kiírja
```

## Ha csak az ÉRTÉK kell

```csharp
double maxAr = autok.Max(a => a.Ar);
int legregebbiEv = autok.Min(a => a.Evjarat);
```

## Szűrt legnagyobb

```csharp
Ingatlan legolcsobbHaz = ingatlanok
    .Where(i => i.Kategoria == "Haz" && i.Kiemelt)
    .OrderBy(i => i.Ar)
    .First();
```

## HOLTVERSENY: ha több legnagyobb is lehet

Ha a feladat **nem** írja, hogy „feltételezheti, hogy csak egy ilyen van”:

```csharp
double legjobb = diakok.Max(d => d.Atlag());                     // 1) a legnagyobb érték
foreach (Diak d in diakok.Where(d => d.Atlag() == legjobb))      // 2) MINDEN ilyen elem
{
    Console.WriteLine($"\t{d.Nev}");
}
```

## Kézzel (klasszikus maximumkiválasztás)

```csharp
Auto max = autok[0];
foreach (Auto a in autok)
{
    if (a.Ar > max.Ar)
        max = a;
}
```

**Élesben:** [01_Autok](../2_GYAKORLO_FELADATOK/01_Autok/Megoldas/Program.cs) (6. feladat), [05_Diakok](../2_GYAKORLO_FELADATOK/05_Diakok/Megoldas/Program.cs) (4. és 8. feladat, holtverseny)
