# 09 – Rendezés, top 3

**Mikor kell?** „csökkenő sorrendben”, „ABC sorrendben”, „az első 3”, „dobogósok”, „helyezés”

## A kód

```csharp
var novekvo  = lista.OrderBy(e => e.Ar);              // kicsitől nagyig
var csokkeno = lista.OrderByDescending(e => e.Ar);    // nagytól kicsiig
var abc      = lista.OrderBy(e => e.Nev);              // szöveg: ABC sorrend

// Másodlagos rendezés (azonos értékeknél): ThenBy / ThenByDescending
var rendezett = lista.OrderByDescending(e => e.Ar).ThenBy(e => e.Nev);
```

## Top 3 helyezésszámmal

```csharp
List<Futo> dobogo = futok.OrderBy(f => f.Ido).Take(3).ToList();
for (int i = 0; i < dobogo.Count; i++)
{
    Console.WriteLine($"\t{i + 1}. hely: {dobogo[i].Nev}");
}
```

## Hányadik helyen van valaki?

```csharp
List<Futo> sorrend = futok.OrderBy(f => f.Ido).ToList();
int index = sorrend.FindIndex(f => f.Rajtszam == keresett);   // 0-tól számol, -1 = nincs
if (index == -1)
    Console.WriteLine("Nincs ilyen.");
else
    Console.WriteLine($"{index + 1}. helyezés");
```

## Gyakori hiba

Az `OrderBy` **nem módosítja** a listát, hanem újat ad vissza. Ezért kell eltárolni: `var x = lista.OrderBy(...)`.

**Élesben:** [03_Futoverseny](../2_GYAKORLO_FELADATOK/03_Futoverseny/Megoldas/Program.cs) (5., 8. és 10. feladat)
