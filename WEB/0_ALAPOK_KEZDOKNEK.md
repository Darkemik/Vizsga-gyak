# Alapok kezdőknek – hogyan épül fel egy weboldal?

5 perc olvasás. Utána a többi fájl érthető lesz.

## 1. Három fájl, három feladat

| Fájl | Mi van benne | Hasonlat |
|---|---|---|
| `index.html` | a **tartalom és a szerkezet**: menü, címek, szövegek, képek, gombok | a ház falai |
| `style.css` | a **kinézet**: színek, méretek, elrendezés, mobilnézet | a festés, a berendezés |
| `script.js` | a **működés**: mi történjen kattintásra, adatok megjelenítése | a villany, a kapcsolók |

Az `index.html` köti össze őket:

```html
<head>
    <link rel="stylesheet" href="style.css">     <!-- CSS: a <head>-be -->
</head>
<body>
    ...
    <script src="script.js"></script>             <!-- JS: a <body> VÉGÉRE -->
</body>
```

> A JS azért kerül a végére, mert addigra már az összes HTML-elem létezik, amit a JS keres.

## 2. HTML: elemek egymásba ágyazva

```html
<section class="info">                      <!-- egy doboz, "info" osztállyal -->
    <div class="info-kartya">                <!-- benne egy kártya -->
        <h2>Modern kiállítások</h2>          <!-- cím -->
        <p>Fedezd fel...</p>                 <!-- bekezdés -->
    </div>
</section>
```

- **`class="..."`**: ezzel nevezed el az elemet a CSS és a JS számára. Több elemnek is lehet ugyanaz.
- **`id="..."`**: egyedi név, egy oldalon csak egyszer. A JS-ben ezzel keresed: `document.getElementById("menu")`.

## 3. CSS: „ezeknek az elemeknek legyen ilyen a kinézetük”

```css
.info-kartya {                 /* MELYIK elemekre: a "info-kartya" osztályúakra (pont = osztály) */
    background: #fff;          /* TULAJDONSÁG: ÉRTÉK; */
    box-shadow: 0 6px 20px rgba(0, 0, 0, 0.12);
    border-radius: 10px;
}
```

| Jelölés | Mit jelöl ki |
|---|---|
| `.kartya` | a `class="kartya"` elemeket |
| `#menu` | az `id="menu"` elemet |
| `h1` | minden `<h1>`-et |
| `.hero h1` | a `.hero`-n BELÜLI `<h1>`-et |
| `.gomb:hover` | a gombot, amikor fölötte az egér |

## 4. Reszponzív = más kinézet más képernyőn

```css
.kartyak { grid-template-columns: 1fr; }          /* alapból (MOBIL): 1 oszlop */

@media (min-width: 768px) {                        /* ha a képernyő legalább 768 px: */
    .kartyak { grid-template-columns: repeat(2, 1fr); }   /* 2 oszlop */
}
```

**Mobile-first** = először a mobilt írod meg, és a `@media (min-width: ...)` blokkokba csak azt, ami nagyobb képernyőn **változik**.

## 5. JS: „ha ez történik, csináld ezt”

```js
const gomb = document.getElementById("hamburger");   // 1. megkeresem az elemet
gomb.addEventListener("click", function () {         // 2. ha rákattintanak...
    menu.classList.toggle("nyitva");                 // 3. ...ezt csinálom
});
```

Adatokból HTML-t gyártani (a frontend feladat lényege):

```js
let html = "";
artworks.forEach(function (mu) {                      // minden elemre a tömbből
    html += `<div class="kartya"><h3>${mu.title}</h3></div>`;   // ${...} = érték beillesztése
});
document.getElementById("mualkotasok").innerHTML = html;      // betesszük az oldalba
```

## 6. Kipróbálás

- **Megnyitás:** dupla kattintás az `index.html`-en, vagy VS Code-ban jobb klikk → **Open with Live Server**.
- **Frissítés mentés után:** F5.
- **Hibák keresése:** F12 → **Console** fül. Pirosan írja ki, ha a JS-ben hiba van.
- **Mobilnézet:** F12 → **Ctrl+Shift+M**.

**Tovább:** [README.md](README.md) (keresőtábla) · [Galéria lépésről lépésre](2_GYAKORLO_FELADATOK/01_Galeria/LEPESROL_LEPESRE.md)
