# 16 – Időtartam (TimeSpan)

**Mikor kell?** Ha **időtartam** van a fájlban: versenyidő, hívás hossza, menetidő (`01:23:45`).

## Beolvasás

```csharp
using System.Globalization;

TimeSpan ido = TimeSpan.Parse("01:23:45", CultureInfo.InvariantCulture);   // óra:perc:mp
TimeSpan hatar = new TimeSpan(1, 15, 0);                                    // 1 óra 15 perc 0 mp
```

## Összehasonlítás, rendezés, legkisebb

```csharp
bool gyorsabb = ido < hatar;
var sorrend = futok.OrderBy(f => f.Ido);       // a leggyorsabb az első
TimeSpan legjobb = futok.Min(f => f.Ido);
```

## Részek, átváltás

```csharp
ido.Hours          // 1   (csak az óra RÉSZ)
ido.Minutes        // 23
ido.Seconds        // 45
ido.TotalMinutes   // 83,75  (az EGÉSZ idő percben)
ido.TotalSeconds   // 5025
```

## Átlag (nincs közvetlen Average TimeSpan-ra!)

```csharp
double atlagMp = futok.Average(f => f.Ido.TotalSeconds);       // másodpercben átlagolunk
TimeSpan atlag = TimeSpan.FromSeconds(Math.Round(atlagMp));     // egész mp-re kerekítve vissza
Console.WriteLine(atlag);                                        // 01:53:14
```

## Összeg

```csharp
TimeSpan osszes = TimeSpan.FromSeconds(futok.Sum(f => f.Ido.TotalSeconds));
```

## Kiírás

```csharp
Console.WriteLine($"{ido}");                        // 01:23:45 (alapból jó)
Console.WriteLine(ido.ToString(@"hh\:mm\:ss"));     // ugyanez, kényszerítve
Console.WriteLine(ido.ToString(@"mm\:ss"));         // 23:45
```

> A `:` elé `\` kell a formátumban, és `@"..."` szöveg, hogy a `\` ne legyen speciális.

## Ha két dátum különbsége kell (nem a fájlban van az időtartam)

```csharp
TimeSpan kulonbseg = vege - kezdet;   // DateTime - DateTime
int napok = kulonbseg.Days;
```

**Élesben:** [03_Futoverseny](../2_GYAKORLO_FELADATOK/03_Futoverseny/Megoldas/)
