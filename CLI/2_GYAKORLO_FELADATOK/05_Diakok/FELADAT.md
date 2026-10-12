# 05 – Diákok jegyei (lista az osztályban, holtverseny)

**Adatfájl:** `Megoldas/diakok.txt` (UTF-8, `;`, az első sor a fejléc)

| Mező | Típus |
|---|---|
| Nev | szöveg |
| Osztaly | szöveg (pl. 11.A) |
| Jegyek | **vesszővel elválasztott** egész számok (pl. `3,4,5,5`) |
| Hianyzas | egész (óra) |

## Feladatok

1. Készítsen konzolos alkalmazást **DiakKonzol** néven!
2. Készítsen `Diak` osztályt! A jegyeket `List<int>`-ben tárolja! Legyen benne metódus az átlagra, arra, hogy kitűnő-e (minden jegye 5-ös), és arra, hogy van-e 1-ese!
3. Olvassa be az adatokat, és írja ki a diákok számát!
4. Írja ki a legjobb átlagot és az ÖSSZES ilyen átlagú diákot! (Holtverseny lehet!)
5. Írja ki osztályonként a létszámot és az osztályátlagot (a diákok átlagainak átlaga)!
6. Írja ki azokat, akiknek van elégtelen jegye, a jegyeikkel együtt!
7. Kérjen be egy névrészletet, és írja ki azokat, akiknek a nevében szerepel (kis/nagybetű nem számít)! Ha nincs: „Nincs találat.”
8. Ki(k) hiányzott a legtöbbet? (Holtverseny lehet!)
9. Írja a `kitunok.txt` fájlba a kitűnő tanulókat: `Nev;Osztaly`!
10. Írja ki, hány 5-ös, 4-es, 3-as, 2-es és 1-es jegy született összesen!

## Amit gyakorol

| Feladat | Technika |
|---|---|
| 2. | [02 Lista a mezőben](../../1_TECHNIKAK/02_Osztaly_konstruktor.md), [18 Metódus](../../1_TECHNIKAK/18_Metodus_az_osztalyban.md), [11 All/Contains](../../1_TECHNIKAK/11_Van_e_Any.md) |
| 4., 8. | [07 Holtverseny](../../1_TECHNIKAK/07_Legnagyobb_Legkisebb.md) |
| 5. | [10 GroupBy](../../1_TECHNIKAK/10_Csoportositas_GroupBy.md) |
| 6. | [08 Where](../../1_TECHNIKAK/08_Szures_Where.md) |
| 7. | [12 Bekérés](../../1_TECHNIKAK/12_Bekeres_billentyuzetrol.md) (névrészlet) |
| 9. | [13 Fájlba írás](../../1_TECHNIKAK/13_Fajlba_iras.md) |
| 10. | [19 Tömb mint számláló](../../1_TECHNIKAK/19_Distinct_Dictionary.md) |

**Megoldás:** [Megoldas/](Megoldas/) · **Elvárt kimenet:** [MINTA_KIMENET.txt](MINTA_KIMENET.txt) (bekért névrészlet: `kiss`)
