# Galéria – lépésről lépésre

A sorrend a **pontok olcsósága** szerint halad: az első lépések már pontot érnek, akkor is, ha a végére nem jutsz el.
Minden lépés után **mentsd** (Ctrl+S), és **frissítsd** a böngészőt (F5).

**Mobilnézet kipróbálása:** a böngészőben **F12** → **Ctrl+Shift+M** (eszköz-eszköztár), felül választható pl. „iPhone” vagy beírható szélesség.

---

## 0. Előkészítés (2 perc)

1. VS Code → **File → Open Folder** → a kapott feladat mappája (benne: `images/`, `artworks.json`).
2. Hozd létre ugyanide: `index.html`, `style.css`, `script.js`.
3. Megnyitás: dupla kattintás az `index.html`-en (vagy VS Code-ban jobb klikk → **Open with Live Server**, ha telepítve van).

---

# A) RÉSZ – Weboldal (10 pont)

## 1. A HTML váz (2 perc)

Írd be az `index.html`-be (vagy VS Code-ban: `!` + Enter, és utána javítsd):

```html
<!DOCTYPE html>
<html lang="hu">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>ArtGallery – Kezdőlap</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
    <!-- ide jön minden -->
    <script src="script.js"></script>
</body>
</html>
```

> ⚠️ A `viewport` sor nélkül a mobil nem reszponzív! A `charset` nélkül az ékezetek elromlanak.

## 2. Navigáció + hamburger (8 perc) → 1. pont

1. HTML: másold ki a [Megoldas/index.html](Megoldas/index.html) `<header>` részét.
2. CSS: másold ki a [Megoldas/style.css](Megoldas/style.css) **0. és 1. részét** (alapok + navigáció), és a tablet `@media` blokkból a navigációs részt.
3. JS: a [Megoldas/script.js](Megoldas/script.js) teljes tartalma (10 sor).

**Ellenőrzés:** széles ablakban a menü vízszintes, a logó balra. Mobilnézetben ☰ látszik, kattintásra lenyílik a menü, a ✕-re bezárul.

## 3. Hero szekció (5 perc) → 2. pont

HTML: a `<section class="hero">` rész. CSS: a **2. rész** (`.hero`, `.hero h1`, `.gomb`) + a két `@media` blokkból a `.hero` sorok.

A lényeg egy sorban: háttérkép sötétítéssel:

```css
background-image: linear-gradient(rgba(5,10,20,0.75), rgba(5,10,20,0.35)), url("images/hero.png");
background-size: cover;
```

**Ellenőrzés:** mobilon a cím kisebb, mint asztali nézetben (ezt a feladat kéri).

## 4. Három kártya (5 perc) → 3. pont

HTML: a `<section class="info">` rész (3 db `.info-kartya`). CSS: a **3. rész** + a `@media` blokkokból az `.info` sorok.

Árnyék: `box-shadow: 0 6px 20px rgba(0, 0, 0, 0.12);`

## 5. Reszponzív ellenőrzés → 4. pont

| Szélesség | Kártyák |
|---|---|
| mobil (< 768 px) | egymás alatt |
| tablet (768–1023 px) | 2 oszlop |
| asztali (≥ 1024 px) | 3 egymás mellett |

A mechanizmus (mobile-first):

```css
.info { display: grid; grid-template-columns: 1fr; }                          /* alap = MOBIL */
@media (min-width: 768px)  { .info { grid-template-columns: repeat(2, 1fr); } }   /* tablet */
@media (min-width: 1024px) { .info { grid-template-columns: repeat(3, 1fr); } }   /* asztali */
```

✅ **Az A) rész kész.**

---

# B) RÉSZ – Frontend programozás (15 pont)

## 6. A második oldal (3 perc)

Hozd létre a `kiallitasok.html`-t: másold át az `index.html`-t, töröld a `<main>` tartalmát, és tedd bele a [Megoldas/kiallitasok.html](Megoldas/kiallitasok.html) `<main>` részét (cím, szűrőgombok, üres `<div id="mualkotasok">`). A menüben itt a „Kiállítások” kapja az `aktiv` osztályt.

Az oldal alján a scriptek **ebben a sorrendben**:

```html
<script src="script.js"></script>
<script src="artworks.js"></script>
<script src="galeria.js"></script>
```

## 7. A JSON előkészítése (5 perc) → B/1. pont

1. Másold le az `artworks.json`-t **`artworks.js`** néven.
2. Az elejére írd: `const artworks = ` és a legvégére: `;`
3. Javítsd a képútvonalakat (a tábla a [FELADAT.md](FELADAT.md)-ben van). VS Code-ban: **Ctrl+H** (keresés-csere).

```js
const artworks = [
  {
    "id": 1,
    "title": "Városi fények",
    ...
    "image": "images/card_images/city_lights.png",
    "available": true
  },
  ...
];
```

> Így szerver nélkül is működik. A `fetch`-es változat: [1_TECHNIKAK/06](../../1_TECHNIKAK/06_JSON_betoltes.md).

## 8. Kártyák (10 perc) → B/2. pont

Másold ki a [Megoldas/galeria.js](Megoldas/galeria.js) elejét és a `kartyakMegjelenitese` függvényt, a végére pedig:

```js
kartyakMegjelenitese(artworks);
```

CSS: a **4. rész** (`.mualkotasok`, `.mu-kartya`, `.mu-kep`, `.mu-adatok`, `.erdekel`).

**Ellenőrzés:** 12 kártya, mindegyiken kép, cím, művész | év, kategória, ár, gomb.

## 9. Nem elérhető alkotások (3 perc) → B/3. pont

A `kartyakMegjelenitese`-ben már benne van (3 sor a `forEach` elején). CSS:

```css
.nem-elerheto .mu-kep { filter: grayscale(100%); }
.erdekel:disabled { background: #d1d5db; cursor: not-allowed; }
```

**Ellenőrzés:** a „Csendes forma” és a „Városi csend” szürke, a gombja „Nem elérhető”, és nem kattintható.

## 10. Kategóriaszűrő (8 perc) → B/4. pont

HTML: az 5 gomb `data-kategoria` attribútummal (6. lépés). JS: a `galeria.js` „4. Kategóriaszűrő” része.

**Ellenőrzés:** Szobor → 3 kártya, Fotó → 3, Összes → 12; a megnyomott gomb ki van emelve.

## 11. Oszlopok: 4 / 2 / 1 → B/5–6. pont

```css
.mualkotasok { display: grid; grid-template-columns: 1fr; gap: 20px; }
@media (min-width: 768px)  { .mualkotasok { grid-template-columns: repeat(2, 1fr); } }
@media (min-width: 1024px) { .mualkotasok { grid-template-columns: repeat(4, 1fr); } }
```

Egyforma kártyák: fix képmagasság (`height: 160px; object-fit: cover;`), és a gomb mindig alul (`margin-top: auto;`).

✅ **Kész.** A teljes mappát (html, css, js, images) másold a **MEGOLDÁS** mappába.
