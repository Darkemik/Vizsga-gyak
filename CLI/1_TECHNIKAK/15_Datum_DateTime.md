# 15 – Dátumok (DateTime)

**Mikor kell?** Ha dátum van a fájlban: „melyik hónapban”, „legkorábbi”, „hány nap telt el”, „adott napon”

## Beolvasás

```csharp
using System.Globalization;

// Pontosan megadjuk a fájlban lévő formát:
DateTime d1 = DateTime.ParseExact("2026-03-14",  "yyyy-MM-dd",  CultureInfo.InvariantCulture);
DateTime d2 = DateTime.ParseExact("2026.03.14.", "yyyy.MM.dd.", CultureInfo.InvariantCulture);
DateTime d3 = DateTime.ParseExact("2026.03.14 08:30", "yyyy.MM.dd HH:mm", CultureInfo.InvariantCulture);
```

| Betű | Jelentés |
|---|---|
| `yyyy` | év (2026) |
| `MM` | hónap 2 jeggyel (03) — **nagy M!** |
| `dd` | nap 2 jeggyel (14) |
| `HH` | óra 24 órás (08) |
| `mm` | perc — **kis m!** |
| `ss` | másodperc |

## Részek kiolvasása

```csharp
d.Year      // 2026
d.Month     // 3
d.Day       // 14
d.DayOfWeek // DayOfWeek.Saturday
```

## Összehasonlítás, legkorábbi, szűrés

```csharp
DateTime legkorabbi = lista.Min(e => e.Datum);
int juniusi = lista.Count(e => e.Datum.Month == 6);
bool utana = d1 > new DateTime(2026, 3, 1);          // dátumokat lehet < > -vel hasonlítani
```

## Eltelt napok

```csharp
int napok = (vege - kezdet).Days;   // dátum - dátum = TimeSpan, ennek .Days része
DateTime ma = DateTime.Today;        // vagy a feladatban megadott dátum: new DateTime(2026, 10, 12)
DateTime egyHetMulva = ma.AddDays(7);
```

## Kiírás

```csharp
Console.WriteLine($"{d:yyyy.MM.dd.}");              // 2026.03.14.
Console.WriteLine(d.ToString("yyyy. MMMM d."));     // 2026. március 14. (magyar gépen)
string honapNev = new DateTime(2026, 3, 1).ToString("MMMM");   // "március"
```

## Üres dátummező

```csharp
if (m[6] == "")
    Visszahozta = false;
else
{
    Visszahozta = true;
    VisszahozasDatum = DateTime.ParseExact(m[6], "yyyy-MM-dd", CultureInfo.InvariantCulture);
}
```

**Élesben:** [02_Konyvtar](../2_GYAKORLO_FELADATOK/02_Konyvtar/Megoldas/) (az egész feladat erről szól)
