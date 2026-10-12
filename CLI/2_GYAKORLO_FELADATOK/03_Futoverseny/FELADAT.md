# 03 – Félmaraton eredmények (időtartamok, rendezés)

**Adatfájl:** `Megoldas/eredmenyek.txt` (UTF-8, `;`, az első sor a fejléc)

| Mező | Típus |
|---|---|
| Rajtszam | egész |
| Nev, Egyesulet | szöveg |
| Kategoria | szöveg (Junior, Felnott, Szenior) |
| Nem | `F` vagy `N` |
| Ido | időtartam (`01:23:45`) |

## Feladatok

1. Készítsen konzolos alkalmazást **FutasKonzol** néven!
2. Készítsen `Futo` osztályt! Legyen benne egy tulajdonság, ami megmondja, hogy női futó-e, és egy `ToString()`, ami egy sorban, oszlopokba igazítva írja ki a rajtszámot, a nevet, az egyesületet és az időt!
3. Olvassa be az adatokat, és írja ki a célba érkezők számát!
4. Ki nyerte a versenyt? (név, egyesület, idő)
5. Írja ki a dobogósokat (1–3. hely) a `ToString()` segítségével!
6. Mennyi volt az átlagos idő (egész másodpercre kerekítve, `óó:pp:mm` formában)?
7. Írja ki kategóriánként a létszámot és a legjobb időt (ABC sorrendben)!
8. Kérjen be egy rajtszámot, és írja ki a futó nevét, helyezését és idejét! Ha nincs ilyen: „Nincs ilyen rajtszám.”
9. Van-e olyan női futó, aki 1 óra 15 percen belül célba ért?
10. Írja az `egyesuletek.txt` fájlba egyesületenként a futók számát (csökkenő sorrend, azonos számnál ABC): `Egyesulet;Letszam`!

## Amit gyakorol

| Feladat | Technika |
|---|---|
| 2. | [16 TimeSpan](../../1_TECHNIKAK/16_Ido_TimeSpan.md), [18 Tulajdonság](../../1_TECHNIKAK/18_Metodus_az_osztalyban.md), [03 ToString](../../1_TECHNIKAK/03_ToString_override.md) |
| 4–5. | [09 Rendezés, top 3](../../1_TECHNIKAK/09_Rendezes_Top3.md) |
| 6. | [16 TimeSpan](../../1_TECHNIKAK/16_Ido_TimeSpan.md) (átlag másodpercben) |
| 7. | [10 GroupBy](../../1_TECHNIKAK/10_Csoportositas_GroupBy.md) |
| 8. | [12 Bekérés](../../1_TECHNIKAK/12_Bekeres_billentyuzetrol.md), [09 Helyezés](../../1_TECHNIKAK/09_Rendezes_Top3.md) |
| 9. | [11 Any](../../1_TECHNIKAK/11_Van_e_Any.md) |
| 10. | [10 GroupBy](../../1_TECHNIKAK/10_Csoportositas_GroupBy.md), [13 Fájlba írás](../../1_TECHNIKAK/13_Fajlba_iras.md) |

**Megoldás:** [Megoldas/](Megoldas/) · **Elvárt kimenet:** [MINTA_KIMENET.txt](MINTA_KIMENET.txt) (bekért rajtszám: `126`)
