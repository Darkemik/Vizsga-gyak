# 01 – Használt autók (a vizsgalap alapján)

> Az 1–7. feladat a vizsgalapod szövege szerint. A 8–9. extra gyakorlás.
> Az adatfájl a vizsga eredeti `carsData.csv`-je (198 autó). **Vizsgán mindig nézd meg a fájl első sorát!**

**Adatfájl:** `Megoldas/carsData.csv` (UTF-8, pontosvesszővel elválasztva, az első sor a fejléc)

| Mező | Típus |
|---|---|
| Azonosito | egész |
| Evjarat | egész |
| Gyarto | **önálló osztály**: GyartoID (egész), GyartoNev (szöveg) |
| Modell | szöveg |
| KilometeroraAllas | egész |
| Karosszeria | **önálló osztály**: KarosszeriaID (egész), KarosszeriaNev (szöveg) |
| HengerekSzama | egész |
| Valto | **önálló osztály**: ValtoID (egész), ValtoNev (szöveg) |
| KulsoSzin, BelsoSzin | szöveg |
| SzemelyekSzama, Ajtok | egész |
| FogyasztasVarosban, FogyasztasAutopalyan | tört (a fájlban vesszővel: 13,59) |
| Ar | tört, kanadai dollár (pl. 499000) |

## Feladatok

1. Készítsen konzolos alkalmazást **AutoKonzol** néven!
2. Készítsen saját osztályokat `Auto`, `Karosszeria`, `Valto` és `Gyarto` azonosítóval!
3. Írja felül az `Auto` osztályban a `ToString()` metódust: az első sorban az azonosító, utána az autó főbb adatai. A fogyasztás a városi és az autópályás fogyasztás átlaga, 2 tizedesjegyre kerekítve.
4. Olvassa be az adatokat egy összetett adatszerkezetbe!
5. Írja ki, hány **Rolls-Royce** márkájú, **Sedan** karosszériájú, **8 hengeres** autót adtak el!
6. Írja ki a legdrágább autót (a `ToString()`-gel), és az árát **forintban**, egészre kerekítve! Árfolyam: 1 CAD = 248,02 Ft. Feltételezheti, hogy csak egy legdrágább autó van.
7. Gyűjtse ki a `forma-1.txt` fájlba az **Aston Martin** és **Ferrari** autók adatait: `Azonosito;GyartoNev;Modell;Evjarat;KilometeroraAllas`!
8. *(extra)* Írja ki gyártónként az autók számát és az átlagárat, átlagár szerint csökkenő sorrendben!
9. *(extra)* Kérjen be egy gyártót, és írja ki, hány autója van! Ha nincs ilyen: „Nincs ilyen gyártó az adatok között.”

## Amit gyakorol (technika-fájlok)

| Feladat | Technika |
|---|---|
| 2. | [02 Osztály](../../1_TECHNIKAK/02_Osztaly_konstruktor.md), [04 Osztály az osztályban](../../1_TECHNIKAK/04_Osztaly_az_osztalyban.md) |
| 3. | [03 ToString](../../1_TECHNIKAK/03_ToString_override.md), [18 Metódus](../../1_TECHNIKAK/18_Metodus_az_osztalyban.md), [14 Kerekítés](../../1_TECHNIKAK/14_Kerekites_Kiiras_formazas.md) |
| 4. | [01 Beolvasás](../../1_TECHNIKAK/01_Beolvasas_fajlbol.md), [17 Buktatók](../../1_TECHNIKAK/17_Buktatok.md) (tizedespont) |
| 5. | [05 Count](../../1_TECHNIKAK/05_Megszamolas_Count.md) |
| 6. | [07 Legnagyobb](../../1_TECHNIKAK/07_Legnagyobb_Legkisebb.md), [14 Kerekítés](../../1_TECHNIKAK/14_Kerekites_Kiiras_formazas.md) |
| 7. | [08 Where](../../1_TECHNIKAK/08_Szures_Where.md), [13 Fájlba írás](../../1_TECHNIKAK/13_Fajlba_iras.md) |
| 8. | [10 GroupBy](../../1_TECHNIKAK/10_Csoportositas_GroupBy.md) |
| 9. | [12 Bekérés](../../1_TECHNIKAK/12_Bekeres_billentyuzetrol.md), [11 Any](../../1_TECHNIKAK/11_Van_e_Any.md) |

**Megoldás:** [Megoldas/](Megoldas/) · **Elvárt kimenet:** [MINTA_KIMENET.txt](MINTA_KIMENET.txt)
