# 18 – Metódus / tulajdonság az osztályban

**Mikor kell?** „Készítsen az osztályban metódust, amely …”, „Az osztály számolja ki …”, vagy ha egy számítás több feladatban is kell.

## Metódus (zárójellel hívod)

```csharp
// az Auto osztályon belül:
public double AtlagFogyasztas()
{
    return Math.Round((FogyasztasVarosban + FogyasztasAutopalyan) / 2, 2, MidpointRounding.AwayFromZero);
}

// használat:
Console.WriteLine(auto.AtlagFogyasztas());
var takarekos = autok.Where(a => a.AtlagFogyasztas() < 12);
```

## Metódus paraméterrel

```csharp
public int KintNapok(DateTime maiNap)
{
    DateTime vege = Visszahozta ? VisszahozasDatum : maiNap;
    return (vege - KolcsonzesDatum).Days;
}

// használat:
int napok = k.KintNapok(new DateTime(2026, 10, 12));
```

## bool metódus (igaz/hamis kérdés)

```csharp
public bool Kituno()
{
    return Jegyek.All(j => j == 5);
}

// használat:
var kitunok = diakok.Where(d => d.Kituno());
```

## Számított tulajdonság (zárójel NÉLKÜL hívod)

```csharp
public bool NoiFuto
{
    get { return Nem == "N"; }
}

// használat:
var nok = futok.Where(f => f.NoiFuto);
```

> Ha az osztálydiagramon `Metódus()` zárójellel szerepel, metódust írj; ha zárójel nélkül, tulajdonságot.

## Statikus segédmetódus a Program osztályban

Ha nem az objektumhoz tartozik (pl. egy átváltás):

```csharp
static long Forintra(double cad)
{
    return (long)Math.Round(cad * 248.02, MidpointRounding.AwayFromZero);
}

// a Main-ben:
Console.WriteLine(Forintra(legdragabb.Ar));
```

**Élesben:** [01_Autok/Auto.cs](../2_GYAKORLO_FELADATOK/01_Autok/Megoldas/Auto.cs), [02_Konyvtar/Kolcsonzes.cs](../2_GYAKORLO_FELADATOK/02_Konyvtar/Megoldas/Kolcsonzes.cs), [03_Futoverseny/Futo.cs](../2_GYAKORLO_FELADATOK/03_Futoverseny/Megoldas/Futo.cs), [05_Diakok/Diak.cs](../2_GYAKORLO_FELADATOK/05_Diakok/Megoldas/Diak.cs)
