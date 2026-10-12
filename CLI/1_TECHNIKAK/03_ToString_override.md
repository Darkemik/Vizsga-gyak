# 03 – ToString() felülírása (override)

**Mikor kell?** „Készítsen az osztályban egy override metódust a ToString() virtuális metódus felülírására…”, vagy „a kiíráshoz használja a már elkészített virtuális metódust”.

## A kód (az osztályon belül)

```csharp
public override string ToString()
{
    return $"{Azonosito}\n" +
           $"\tGyártó: {Gyarto.GyartoNev}\n" +
           $"\tModell: {Modell} ({Evjarat})\n" +
           $"\tÁr: {Ar:F2} CAD";
}
```

Egysoros változat:

```csharp
public override string ToString()
{
    return $"{Rajtszam,4}  {Nev,-18} {Ido}";
}
```

## Használat

```csharp
Console.WriteLine(legdragabb);   // automatikusan a ToString()-et hívja
```

## Jelek

| Jel | Jelentés |
|---|---|
| `\n` | új sor |
| `\t` | tabulátor (behúzás) |
| `{Ar:F2}` | 2 tizedesjegy |
| `{Nev,-18}` | 18 karakter szélesen, balra igazítva |
| `{Rajtszam,4}` | 4 karakter szélesen, jobbra igazítva |

## Gyakori hiba

- A **mintát betűre** kell követni: szóköz, kettőspont, mértékegység. Az értékelő ezt nézi.
- Az `override` kulcsszó kimarad, ekkor nem a te metódusod fut.

**Élesben:** [01_Autok/Auto.cs](../2_GYAKORLO_FELADATOK/01_Autok/Megoldas/Auto.cs), [03_Futoverseny/Futo.cs](../2_GYAKORLO_FELADATOK/03_Futoverseny/Megoldas/Futo.cs)
