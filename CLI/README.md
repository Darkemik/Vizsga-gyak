# CLI – Konzolos alkalmazás (C#)

## Időterv a vizsgán

| Rész | Max. idő | Megjegyzés |
|---|---|---|
| **CLI** | **50 perc** | ez a legbiztosabb pont, legyen teljes |
| API | 60 perc | |
| GUI | a maradék | a könnyű pontok: projekt, ablak, beolvasás, lista feltöltése |
| Web | ha marad idő | |

> Ha egy részfeladatnál 5 percnél tovább elakadsz: lépj tovább, és a végén gyere vissza.
> Ments gyakran, és másold a **MEGOLDÁS** mappába a projektet!

## Hogyan kezdj neki a vizsgán (5 perc)

1. Visual Studio → **Create a new project** → **Console App** → a feladatban kért név (pl. `AutoKonzol`).
2. Az adatfájlt húzd be a projektbe → jobb klikk → Properties → **Copy to Output Directory: Copy if newer**.
3. Nyisd meg a [0_GYORSINDITO/Elem.cs](0_GYORSINDITO/Elem.cs) és [Program.cs](0_GYORSINDITO/Program.cs) fájlokat, és másold át, ami kell.
4. Nézd meg az adatfájl **első sorát** (fejléc), és írd fel: `0 = …, 1 = …, 2 = …`.
5. Feladatonként keresd meg lent a táblázatban, mit kér.

---

## KERESŐTÁBLA: mit kér a feladat → hol a kód

| Ha ezt kéri a feladat… | Kulcsszó | Gyorsindító blokk | Technika-fájl |
|---|---|---|---|
| „Készítsen osztályt…” | `class`, konstruktor | `Elem.cs` | [02](1_TECHNIKAK/02_Osztaly_konstruktor.md) |
| „…önálló osztály” (pl. Gyarto) | `new Gyarto(...)` | `Elem.cs` | [04](1_TECHNIKAK/04_Osztaly_az_osztalyban.md) |
| „Olvassa be… tárolja…” | `File.ReadAllLines`, `Skip(1)` | [A] | [01](1_TECHNIKAK/01_Beolvasas_fajlbol.md) |
| „override… ToString()”, „virtuális metódus” | `public override string ToString()` | `Elem.cs` | [03](1_TECHNIKAK/03_ToString_override.md) |
| „Hány db… van?”, „Hány olyan…” | `Count` | [B] | [05](1_TECHNIKAK/05_Megszamolas_Count.md) |
| „Összesen…”, „átlagos…” | `Sum`, `Average` | [C] | [06](1_TECHNIKAK/06_Osszeg_Atlag.md) |
| „Legdrágább / legolcsóbb / legrégebbi…” | `OrderByDescending().First()`, `Max` | [D] | [07](1_TECHNIKAK/07_Legnagyobb_Legkisebb.md) |
| …és **nincs** odaírva, hogy „csak egy ilyen van” | `Max` + `Where` | [E] | [07](1_TECHNIKAK/07_Legnagyobb_Legkisebb.md) |
| „Írja ki azokat, amelyek…” | `Where` + `foreach` | [F] | [08](1_TECHNIKAK/08_Szures_Where.md) |
| „…a felsorolt márkák (A, B)” | `tomb.Contains(...)` | | [08](1_TECHNIKAK/08_Szures_Where.md) |
| „Csökkenő sorrendben”, „első 3”, „helyezés” | `OrderBy`, `Take(3)`, `FindIndex` | [G] | [09](1_TECHNIKAK/09_Rendezes_Top3.md) |
| „…-nként” (gyártónként, kategóriánként) | `GroupBy` | [H] | [10](1_TECHNIKAK/10_Csoportositas_GroupBy.md) |
| „Hány különböző…?” | `Distinct` | [I] | [19](1_TECHNIKAK/19_Distinct_Dictionary.md) |
| „Melyikből van a legtöbb?” | `GroupBy` vagy `Dictionary` | [M] | [19](1_TECHNIKAK/19_Distinct_Dictionary.md) |
| „Van-e olyan…?”, „Mindegyik…?” | `Any`, `All`, `Contains` | [J] | [11](1_TECHNIKAK/11_Van_e_Any.md) |
| „Kérjen be…” | `Console.ReadLine` | [K] | [12](1_TECHNIKAK/12_Bekeres_billentyuzetrol.md) |
| „…ha nincs ilyen, írja ki: …” | `FirstOrDefault` → `null`, vagy `Count == 0` | [K] | [12](1_TECHNIKAK/12_Bekeres_billentyuzetrol.md) |
| „Írja ki a(z) xy.txt fájlba” | `File.WriteAllLines` | [L] | [13](1_TECHNIKAK/13_Fajlba_iras.md) |
| „Kerekítse…”, „2 tizedesjegy” | `Math.Round(..., AwayFromZero)`, `:F2` | [O] | [14](1_TECHNIKAK/14_Kerekites_Kiiras_formazas.md) |
| „Váltsa át forintra / dollárra” | szorzás + kerekítés | [O] | [14](1_TECHNIKAK/14_Kerekites_Kiiras_formazas.md) |
| Dátum a fájlban, „hány nap”, „melyik hónap” | `DateTime.ParseExact`, `.Month`, `(d2 - d1).Days` | [N] | [15](1_TECHNIKAK/15_Datum_DateTime.md) |
| Időtartam a fájlban (`01:23:45`) | `TimeSpan.Parse`, `TotalSeconds` | | [16](1_TECHNIKAK/16_Ido_TimeSpan.md) |
| „Készítsen metódust az osztályban…” | `public double Valami()` | [O] | [18](1_TECHNIKAK/18_Metodus_az_osztalyban.md) |
| Hiba: nem találja a fájlt, rossz tizedes, `?` az ékezet helyén | | | [17](1_TECHNIKAK/17_Buktatok.md) |

---

## A mappák

| Mappa | Mi van benne | Mikor nyisd meg |
|---|---|---|
| [0_GYORSINDITO](0_GYORSINDITO/) | Leforduló projekt; minden gyakori feladattípus egy-egy jelölt blokkban ([A]–[O]) | **Vizsga elején**, ebből másolsz |
| [1_TECHNIKAK](1_TECHNIKAK/) | 19 rövid fájl, mindegyik **egy** dolgot mutat meg, példákkal és gyakori hibákkal | Ha egy konkrét dolog nem jut eszedbe |
| [2_GYAKORLO_FELADATOK](2_GYAKORLO_FELADATOK/) | 5 teljes vizsgaszerű feladat, kommentezett megoldással és elvárt kimenettel | Gyakorláshoz, vagy ha egy egész feladatot akarsz látni |

### A gyakorlófeladatok

| Mappa | Projekt neve | Fő témák |
|---|---|---|
| [01_Autok](2_GYAKORLO_FELADATOK/01_Autok/) | AutoKonzol | **a vizsgalapod**: osztály az osztályban, ToString, Count, legdrágább, forintra váltás, fájlba írás |
| [02_Konyvtar](2_GYAKORLO_FELADATOK/02_Konyvtar/) | KonyvtarKonzol | dátumok, üres mező, eltelt napok, hónaponkénti statisztika |
| [03_Futoverseny](2_GYAKORLO_FELADATOK/03_Futoverseny/) | FutasKonzol | időtartamok, rendezés, dobogó, helyezés keresése |
| [04_Ingatlan](2_GYAKORLO_FELADATOK/04_Ingatlan/) | IngatlanKonzol | átlag, csoportosítás, Distinct, Dictionary, egész osztás |
| [05_Diakok](2_GYAKORLO_FELADATOK/05_Diakok/) | DiakKonzol | lista a mezőben, holtverseny, névrészlet-keresés, tömb mint számláló |

Minden feladatmappában: `FELADAT.md` (a feladat + melyik technika kell hozzá), `Megoldas/` (a projekt), `MINTA_KIMENET.txt` (amit ki kell írnia).

> Minden megoldás le van fordítva és futtatva (.NET 8), a minta kimenetek valódi futásból vannak.
