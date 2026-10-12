# 02 – Könyvtári kölcsönzések (dátumok)

**Adatfájl:** `Megoldas/kolcsonzesek.csv` (UTF-8, `;`, az első sor a fejléc)

| Mező | Típus |
|---|---|
| Azonosito | egész |
| Olvaso | szöveg |
| Cim, Szerzo | szöveg |
| KiadasEve | egész |
| Kolcsonzes | dátum (`2026-03-14`) |
| Visszahozas | dátum, vagy **üres**, ha még nincs visszahozva |

A „mai nap” legyen **2026.10.12.**

## Feladatok

1. Készítsen konzolos alkalmazást **KonyvtarKonzol** néven!
2. Készítsen `Kolcsonzes` osztályt! Legyen benne egy metódus, ami megadja, hány napig volt kint a könyv (ha még nincs visszahozva, akkor a mai napig).
3. Olvassa be az adatokat, és írja ki a kölcsönzések számát!
4. Hány könyvet nem hoztak még vissza?
5. Melyik volt a leghosszabb (már visszahozott) kölcsönzés? Írja ki az olvasót, a könyvet (szerző: cím) és a napok számát!
6. Írja ki hónaponként a kölcsönzések számát (a hónap nevével, időrendben)!
7. Kérje be egy olvasó nevét, és írja ki a kölcsönzéseit (dátum `éééé.hh.nn.` formában, cím, állapot)! Ha nincs ilyen: „Nincs ilyen olvasó.”
8. Melyik a legnépszerűbb könyv (legtöbbször kölcsönözték)?
9. Írja a `kesesek.txt` fájlba a 30 napnál régebben kint lévő, vissza nem hozott könyveket, a napok szerint csökkenő sorrendben: `Olvaso;Cim;Napok`!

## Amit gyakorol

| Feladat | Technika |
|---|---|
| 2. | [15 Dátum](../../1_TECHNIKAK/15_Datum_DateTime.md) (üres mező!), [18 Metódus](../../1_TECHNIKAK/18_Metodus_az_osztalyban.md) |
| 4. | [05 Count](../../1_TECHNIKAK/05_Megszamolas_Count.md) |
| 5. | [08 Where](../../1_TECHNIKAK/08_Szures_Where.md), [07 Legnagyobb](../../1_TECHNIKAK/07_Legnagyobb_Legkisebb.md) |
| 6. | [10 GroupBy](../../1_TECHNIKAK/10_Csoportositas_GroupBy.md), [15 Dátum](../../1_TECHNIKAK/15_Datum_DateTime.md) |
| 7. | [12 Bekérés](../../1_TECHNIKAK/12_Bekeres_billentyuzetrol.md) |
| 8. | [10 GroupBy](../../1_TECHNIKAK/10_Csoportositas_GroupBy.md) |
| 9. | [13 Fájlba írás](../../1_TECHNIKAK/13_Fajlba_iras.md) |

**Megoldás:** [Megoldas/](Megoldas/) · **Elvárt kimenet:** [MINTA_KIMENET.txt](MINTA_KIMENET.txt) (bekért név: `Kiss Anna`)
