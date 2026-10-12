# 13 – Fájlba írás

**Mikor kell?** „Gyűjtse ki egy szöveges fájlba …”, „Írja ki a(z) xy.txt állományba …”

## A kód (a legegyszerűbb, és szinte mindig elég)

```csharp
List<string> sorok = autok
    .Where(a => markak.Contains(a.Gyarto.GyartoNev))                                   // MELYIK sorok
    .Select(a => $"{a.Azonosito};{a.Gyarto.GyartoNev};{a.Modell};{a.Evjarat}")         // MILYEN formában
    .ToList();

File.WriteAllLines("forma-1.txt", sorok);   // minden lista-elem egy sor
```

## Fejléccel

```csharp
sorok.Insert(0, "Azonosito;GyartoNev;Modell;Evjarat");   // a lista elejére
File.WriteAllLines("ki.txt", sorok);
```

## Klasszikus módon (StreamWriter)

```csharp
using (StreamWriter sw = new StreamWriter("ki.txt"))
{
    foreach (Auto a in autok)
    {
        if (a.Ar > 300000)
            sw.WriteLine($"{a.Azonosito};{a.Modell}");
    }
}   // a using végén a fájl automatikusan bezáródik és mentődik
```

## Hova kerül a fájl?

A program mellé: `bin\Debug\net8.0\forma-1.txt`. Ha a feladat a projekt mappáját kéri, onnan másold át a MEGOLDÁS mappába.

## Gyakori hibák

- **Tizedesjel a fájlban:** magyar gépen `{a.Ar}` vesszővel ír (`12,5`). Ha a minta pontot vár: `a.Ar.ToString(CultureInfo.InvariantCulture)`.
- StreamWriternél `using` nélkül a fájl üres maradhat (nem zárod be).

**Élesben:** mind az 5 gyakorlófeladat utolsó feladata
