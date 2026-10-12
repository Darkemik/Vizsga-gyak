# 04 – Ingatlanhirdetések (átlag, csoportosítás, statisztika)

**Adatfájl:** `Megoldas/ingatlanok.csv` (UTF-8, `;`, az első sor a fejléc)

| Mező | Típus |
|---|---|
| Id | egész |
| Kategoria | szöveg (Lakas, Haz, Sorhaz) |
| Telepules | szöveg |
| Alapterulet, Szobak | egész |
| Ar | egész, Ft |
| Hirdetve | dátum |
| Kiemelt | `1` vagy `0` |
| Elado | **önálló osztály**: EladoId (egész), EladoNev (szöveg), EladoTelefon (szöveg) |

## Feladatok

1. Készítsen konzolos alkalmazást **IngatlanKonzol** néven!
2. Készítsen `Ingatlan` és `Elado` osztályt! Az `Ingatlan` osztályban legyen egy metódus, ami megadja a négyzetméterárat (egész Ft), és egy `ToString()`!
3. Olvassa be az adatokat, és írja ki a hirdetések számát!
4. Mennyi az átlagos alapterület (2 tizedesjegyre)?
5. Írja ki a legolcsóbb **kiemelt ház** adatait!
6. Hány különböző településen van hirdetés? Sorolja fel ABC sorrendben, vesszővel elválasztva!
7. Írja ki kategóriánként a hirdetések számát és az átlagárat (ezres tagolással)!
8. Melyik eladónak van a legtöbb hirdetése? (név, telefon, darabszám)
9. Van-e Budapesten 50 millió Ft alatti lakás? Ha igen, írja ki a legolcsóbbat!
10. Írja a `dragak.txt` fájlba az 1 millió Ft/m² feletti ingatlanokat, négyzetméterár szerint csökkenő sorrendben: `Id;Telepules;Alapterulet;NegyzetmeterAr`!

## Amit gyakorol

| Feladat | Technika |
|---|---|
| 2. | [04 Osztály az osztályban](../../1_TECHNIKAK/04_Osztaly_az_osztalyban.md), [18 Metódus](../../1_TECHNIKAK/18_Metodus_az_osztalyban.md), [17 Buktatók](../../1_TECHNIKAK/17_Buktatok.md) (egész osztás) |
| 4. | [06 Átlag](../../1_TECHNIKAK/06_Osszeg_Atlag.md) |
| 5. | [07 Legkisebb](../../1_TECHNIKAK/07_Legnagyobb_Legkisebb.md) |
| 6. | [19 Distinct](../../1_TECHNIKAK/19_Distinct_Dictionary.md) |
| 7. | [10 GroupBy](../../1_TECHNIKAK/10_Csoportositas_GroupBy.md), [14 Formázás](../../1_TECHNIKAK/14_Kerekites_Kiiras_formazas.md) |
| 8. | [19 Dictionary](../../1_TECHNIKAK/19_Distinct_Dictionary.md) |
| 9. | [11 Any](../../1_TECHNIKAK/11_Van_e_Any.md) |
| 10. | [13 Fájlba írás](../../1_TECHNIKAK/13_Fajlba_iras.md) |

**Megoldás:** [Megoldas/](Megoldas/) · **Elvárt kimenet:** [MINTA_KIMENET.txt](MINTA_KIMENET.txt)
