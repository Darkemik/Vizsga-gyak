# WEB – Reszponzív weboldal + Frontend programozás (HTML, CSS, JavaScript)

> **Először:** ha a web még idegen, olvasd el a [0_ALAPOK_KEZDOKNEK.md](0_ALAPOK_KEZDOKNEK.md)-t (5 perc).

## Mennyit ér, és hol a legolcsóbb pont?

A mintafeladatban: **Weboldal 10 pont + Frontend 15 pont = 25 pont.** Részpontok számítanak!

| Ha ennyi időd van… | Ezt csináld (a [Galéria lépésről lépésre](2_GYAKORLO_FELADATOK/01_Galeria/LEPESROL_LEPESRE.md) szerint) | Kb. pont |
|---|---|---|
| 15 perc | HTML váz + navigáció + hero + 3 kártya (1–4. lépés), másolva | 5–8 |
| +10 perc | `@media` blokkok (reszponzív) + hamburger | 10 |
| +15 perc | JSON → `artworks.js`, kártyák JS-ből (6–8. lépés) | +6–8 |
| +10 perc | nem elérhető + szűrő + 4/2/1 oszlop (9–11. lépés) | +5–7 |

## A web-rész lépésről lépésre

| # | Lépés | Tipikus feladatszöveg | Hol a kód |
|---|---|---|---|
| 1 | **HTML váz** | „Készítsd el a … kezdőoldalát” | [01](1_TECHNIKAK/01_HTML_szerkezet.md), gyorsindító **[A]** |
| 2 | **Navigáció + hamburger** | „navigációs sáv… mobilnézetben hamburger ikonnal” | [02](1_TECHNIKAK/02_Navigacio_hamburger.md), **[B]** |
| 3 | **Hero** | „nagy hero szekció: háttérkép, cím, alcím, gomb” | [03](1_TECHNIKAK/03_Hero_szekcio.md), **[C]** |
| 4 | **Kártyák** | „3 információs kártya, árnyékoltak, középre igazítottak” | [04](1_TECHNIKAK/04_Kartyak_arnyekkal.md), **[D]** |
| 5 | **Reszponzív** | „mobile-first… nagy képernyőn egymás mellett, közepesen 2 oszlop…” | [05](1_TECHNIKAK/05_Reszponziv_mobile_first.md), **[E]** |
| 6 | **Adatok betöltése** | „Készítsd elő feldolgozásra a … .json fájlt” | [06](1_TECHNIKAK/06_JSON_betoltes.md), **[F]** |
| 7 | **Kártyák JS-ből** | „Jelenítsd meg az alkotásokat kártyákon: kép, cím, …” | [07](1_TECHNIKAK/07_Kartyak_JS_bol.md), **[G]** |
| 8 | **Feltételes megjelenés** | „Ha nem elérhető: szürke kép, inaktív gomb…” | [08](1_TECHNIKAK/08_Nem_elerheto.md), **[G]** |
| 9 | **Szűrő** | „Készíts kategóriaszűrőt: Összes, …” | [09](1_TECHNIKAK/09_Kategoria_szuro.md), **[H]** |

---

## KERESŐTÁBLA: mit kér a feladat → hol a kód

| Ha ezt kéri a feladat… | Mit használsz | Technika |
|---|---|---|
| „bal oldalon a logó és a név, jobbra a menü” | `display: flex; justify-content: space-between;` | [02](1_TECHNIKAK/02_Navigacio_hamburger.md) |
| „mobilnézetben hamburger ikon” | ☰ gomb + `classList.toggle("nyitva")` | [02](1_TECHNIKAK/02_Navigacio_hamburger.md) |
| „háttérkép” | `background-image: url(...)`, `background-size: cover` | [03](1_TECHNIKAK/03_Hero_szekcio.md) |
| „a szöveg olvasható legyen a képen” | sötétítő `linear-gradient` a kép fölött | [03](1_TECHNIKAK/03_Hero_szekcio.md) |
| „mobilon kisebb betűméret” | kisebb `font-size` alapból, nagyobb a `@media`-ban | [03](1_TECHNIKAK/03_Hero_szekcio.md), [05](1_TECHNIKAK/05_Reszponziv_mobile_first.md) |
| „árnyékolt kártyák” | `box-shadow` | [04](1_TECHNIKAK/04_Kartyak_arnyekkal.md) |
| „középre igazított” | `text-align: center`, `margin: 0 auto`, flex | [04](1_TECHNIKAK/04_Kartyak_arnyekkal.md) |
| „mobile-first” | alap = mobil, `@media (min-width: …)` | [05](1_TECHNIKAK/05_Reszponziv_mobile_first.md) |
| „nagy képernyőn 4 / tableten 2 / mobilon 1 oszlop” | `grid-template-columns: repeat(N, 1fr)` | [05](1_TECHNIKAK/05_Reszponziv_mobile_first.md) |
| „készítsd elő a .json fájlt”, „adatforrásból” | `const adatok = [...]` vagy `fetch` | [06](1_TECHNIKAK/06_JSON_betoltes.md) |
| „jelenítsd meg kártyákon” | `forEach` + sablonszöveg + `innerHTML` | [07](1_TECHNIKAK/07_Kartyak_JS_bol.md) |
| „egységes méretű kártyák” | fix képmagasság + `object-fit: cover`, gomb `margin-top: auto` | [07](1_TECHNIKAK/07_Kartyak_JS_bol.md) |
| „szürkeárnyalatos kép” | `filter: grayscale(100%)` | [08](1_TECHNIKAK/08_Nem_elerheto.md) |
| „inaktív gomb” | `disabled` attribútum | [08](1_TECHNIKAK/08_Nem_elerheto.md) |
| „kategóriaszűrő” | gombok `data-kategoria`-val + `filter()` | [09](1_TECHNIKAK/09_Kategoria_szuro.md) |
| Hiba: nem jelenik meg semmi, rossz kép, ékezet, mobilon nem reszponzív | | [10](1_TECHNIKAK/10_Buktatok.md) |

---

## A mappák

| Mappa | Mi van benne | Mikor nyisd meg |
|---|---|---|
| [0_ALAPOK_KEZDOKNEK.md](0_ALAPOK_KEZDOKNEK.md) | HTML / CSS / JS szerepe, class és id, @media, kipróbálás | **először** |
| [0_GYORSINDITO](0_GYORSINDITO/) | egy kész oldal minden elemmel, blokkok [A]–[H] | vizsgán, ebből másolsz |
| [1_TECHNIKAK](1_TECHNIKAK/) | 10 fájl, mindegyik egy dolog | ha egy konkrét dolog nem jut eszedbe |
| [2_GYAKORLO_FELADATOK/01_Galeria](2_GYAKORLO_FELADATOK/01_Galeria/) | **a kapott minta teljes megoldása**, lépésről lépésre, képekkel | gyakorláshoz |

> A megoldásokat fej nélküli Chrome-ban 390 / 800 / 1280 px szélességben ellenőriztem (a képek onnan vannak).
