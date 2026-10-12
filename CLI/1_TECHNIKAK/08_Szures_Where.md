# 08 – Szűrés (Where)

**Mikor kell?** „Írja ki azokat a …, amelyek …”, „Gyűjtse ki …”, „Listázza …”

## Szűrés és kiírás

```csharp
foreach (Elem e in lista.Where(e => !e.Aktiv))
{
    Console.WriteLine($"\t{e.Nev} ({e.Kategoria})");
}
```

## Szűrés listába (ha többször kell, vagy meg kell nézni, üres-e)

```csharp
List<Diak> talalatok = diakok.Where(d => d.Osztaly == "11.A").ToList();
if (talalatok.Count == 0)
    Console.WriteLine("Nincs ilyen.");
```

## Benne van-e több érték közül (pl. „Aston Martin, Ferrari”)

```csharp
string[] markak = { "Aston Martin", "Ferrari" };
var f1 = autok.Where(a => markak.Contains(a.Gyarto.GyartoNev));
```

## Csak egy mező kell (Select)

```csharp
List<string> nevek = diakok.Where(d => d.Hianyzas > 40).Select(d => d.Nev).ToList();
Console.WriteLine(string.Join(", ", nevek));   // "Kiss Anna, Nagy Péter"
```

## Szöveges feltételek

```csharp
e.Nev.Contains("an")                 // tartalmazza
e.Nev.StartsWith("K")                // ezzel kezdődik
e.Nev.ToLower().Contains(resz)       // kis/nagybetű nem számít
```

**Élesben:** [01_Autok](../2_GYAKORLO_FELADATOK/01_Autok/Megoldas/Program.cs) (7. feladat), [05_Diakok](../2_GYAKORLO_FELADATOK/05_Diakok/Megoldas/Program.cs) (6. és 7. feladat)
