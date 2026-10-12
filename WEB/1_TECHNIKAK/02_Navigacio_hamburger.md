# 02 – Navigációs sáv + hamburger menü

**Mikor kell?** „Alakíts ki navigációs sávot: bal oldalon a logó és a név, menüpontok: …, mobilnézetben a menü hamburger ikonnal jelenjen meg.”

## HTML

```html
<header class="fejlec">
    <nav class="navbar">
        <a href="index.html" class="logo"><img src="images/logo.png" alt="ArtGallery"></a>
        <button class="hamburger" id="hamburger">☰</button>
        <ul class="menu" id="menu">
            <li><a href="index.html" class="aktiv">Kezdőlap</a></li>
            <li><a href="kiallitasok.html">Kiállítások</a></li>
            <li><a href="#">Művészek</a></li>
            <li><a href="#">Kapcsolat</a></li>
        </ul>
    </nav>
</header>
```

> Ha a név szövegként kell: `<a href="index.html" class="logo"><img src="images/logo.png" alt="">Art<span>Gallery</span></a>`

## CSS (mobile-first)

```css
/* MOBIL (alap): logó balra, hamburger jobbra, a menü REJTVE, alatta teljes szélességben */
.navbar {
    display: flex;
    flex-wrap: wrap;
    justify-content: space-between;   /* logó balra, többi jobbra */
    align-items: center;
    padding: 10px 20px;
    background: #0b1220;
}
.hamburger { background: none; border: none; color: #fff; font-size: 30px; cursor: pointer; }
.menu { list-style: none; width: 100%; display: none; }    /* rejtve */
.menu.nyitva { display: block; }                            /* JS kapcsolja */
.menu a { display: block; padding: 14px 4px; color: #fff; text-decoration: none; }
.menu a.aktiv { color: #c8963e; }

/* TABLETTŐL: hamburger el, menü vízszintesen */
@media (min-width: 768px) {
    .hamburger { display: none; }
    .menu { display: flex; width: auto; gap: 32px; }
}
```

## JS (script.js)

```js
const hamburger = document.getElementById("hamburger");
const menu = document.getElementById("menu");

hamburger.addEventListener("click", function () {
    menu.classList.toggle("nyitva");                               // ki-be kapcsol
    hamburger.textContent = menu.classList.contains("nyitva") ? "✕" : "☰";
});
```

## Ha a logóképen nagy üres szél van (mint a Galéria logo.png-jén)

- **Egyszerű:** Paintben nyisd meg → Kijelölés → jelöld ki a logót → **Kivágás** → Mentés másként (pl. `logo_kicsi.png`).
- **Kód:** háttérképként, kicsinyítve és pozícionálva, lásd [Galéria style.css → `.logo`](../2_GYAKORLO_FELADATOK/01_Galeria/Megoldas/style.css).

## Gyakori hibák

- A `.menu`-nek nincs `display: none` alapból → mobilon is látszik a teljes menü.
- A JS az `id`-t keresi (`getElementById("menu")`), de a HTML-ben nincs `id="menu"` → `Cannot read properties of null` hiba a Console-ban.
- A `<script>` a `<head>`-ben van → a JS még nem találja a gombot. Tedd a `</body>` elé.

**Élesben:** [01_Galeria](../2_GYAKORLO_FELADATOK/01_Galeria/Megoldas/index.html), [script.js](../2_GYAKORLO_FELADATOK/01_Galeria/Megoldas/script.js)
