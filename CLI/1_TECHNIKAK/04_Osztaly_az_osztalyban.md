# 04 – Osztály az osztályban

**Mikor kell?** Ha a mezőleírásban az áll, hogy egy mező **„önálló osztály”**, pl.:

> Gyarto – az autó gyártója, önálló osztály: GyartoID (egész szám), GyartoNev (szöveg)

Ilyenkor a fájlban ez 2 oszlop (`GyartoID;GyartoNev`), a programban viszont 1 objektum.

## 1. A kis osztály (külön fájl: Gyarto.cs)

```csharp
internal class Gyarto
{
    public int GyartoID { get; set; }
    public string GyartoNev { get; set; }

    public Gyarto(int gyartoID, string gyartoNev)
    {
        GyartoID = gyartoID;
        GyartoNev = gyartoNev;
    }
}
```

## 2. A nagy osztályban

```csharp
public Gyarto Gyarto { get; set; }   // a típus a saját osztályunk!

// a konstruktorban: két mezőből egy objektum
Gyarto = new Gyarto(int.Parse(m[2]), m[3]);
```

## 3. Használat: két pont kell!

```csharp
a.Gyarto.GyartoNev == "Ferrari"      // JÓ
a.Gyarto == "Ferrari"                 // HIBA: a Gyarto objektum, nem szöveg
```

**Élesben:** [01_Autok](../2_GYAKORLO_FELADATOK/01_Autok/Megoldas/) (Gyarto, Karosszeria, Valto), [04_Ingatlan](../2_GYAKORLO_FELADATOK/04_Ingatlan/Megoldas/) (Elado)
