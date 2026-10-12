# 12 – Bekérés billentyűzetről

**Mikor kell?** „Kérjen be a felhasználótól egy …”, „Kérje be egy … nevét, és írja ki …”

## Szöveg bekérése

```csharp
Console.Write("7. feladat: Kérem az olvasó nevét: ");   // Write: a kurzor a sor végén marad
string nev = Console.ReadLine();
```

## Szám bekérése

```csharp
Console.Write("8. feladat: Kérek egy rajtszámot: ");
int rajtszam = int.Parse(Console.ReadLine());
```

## Keresés + „Nincs ilyen” (EGY találat várható)

```csharp
Elem talalat = lista.FirstOrDefault(e => e.Nev == nev);   // ha nincs: null
if (talalat == null)
    Console.WriteLine("\tNincs ilyen.");
else
    Console.WriteLine($"\t{talalat.Nev}: {talalat.Ertek}");
```

## Keresés + „Nincs ilyen” (TÖBB találat lehet)

```csharp
List<Kolcsonzes> talalatok = lista.Where(k => k.Olvaso == nev).ToList();
if (talalatok.Count == 0)
{
    Console.WriteLine("\tNincs ilyen olvasó.");
}
else
{
    foreach (Kolcsonzes k in talalatok)
        Console.WriteLine($"\t{k.Cim}");
}
```

## Kis/nagybetű ne számítson

```csharp
string resz = Console.ReadLine().ToLower();
var talalt = diakok.Where(d => d.Nev.ToLower().Contains(resz));
```

## Ismételt bekérés, amíg jó értéket nem ad (ha a feladat kéri)

```csharp
int szam;
do
{
    Console.Write("Kérek egy számot 1 és 12 között: ");
} while (!int.TryParse(Console.ReadLine(), out szam) || szam < 1 || szam > 12);
```

**Élesben:** [02_Konyvtar](../2_GYAKORLO_FELADATOK/02_Konyvtar/Megoldas/Program.cs) (7.), [03_Futoverseny](../2_GYAKORLO_FELADATOK/03_Futoverseny/Megoldas/Program.cs) (8.), [05_Diakok](../2_GYAKORLO_FELADATOK/05_Diakok/Megoldas/Program.cs) (7.)
