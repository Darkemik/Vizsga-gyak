# 03 – Hero szekció

**Mikor kell?** „A kezdőoldalon legyen egy nagy hero szekció: háttérkép, cím, alcím, gomb”, „a hero szöveg mobilon kisebb betűméretű legyen”

## HTML

```html
<section class="hero">
    <div class="hero-tartalom">
        <h1>Fedezd fel a művészet világát!</h1>
        <p>Kortárs alkotások, különleges kiállítások, inspiráló terek.</p>
        <a href="kiallitasok.html" class="gomb">Kiállítások megtekintése</a>
    </div>
</section>
```

## CSS

```css
.hero {
    /* sötétítő réteg + kép: a gradient a kép FÖLÉ kerül, így a fehér szöveg olvasható */
    background-image: linear-gradient(rgba(0, 0, 0, 0.6), rgba(0, 0, 0, 0.3)),
                      url("images/hero.png");
    background-size: cover;          /* kitölti a dobozt, torzítás nélkül */
    background-position: center;
    min-height: 70vh;                /* a képernyő 70%-a magas */
    display: flex;
    align-items: center;             /* tartalom függőlegesen középen */
    padding: 40px 20px;
    color: #fff;
}

.hero h1 { font-size: 2.2rem; }      /* MOBIL: kisebb */

.gomb {
    display: inline-block;
    background: #c8963e;
    color: #fff;
    padding: 14px 26px;
    border-radius: 6px;
    text-decoration: none;
}

@media (min-width: 768px)  { .hero h1 { font-size: 3.2rem; } }
@media (min-width: 1024px) { .hero h1 { font-size: 4.2rem; } }
```

> **„Mobilon kisebb betűméret”** mobile-first módon: az ALAP (mobil) kisebb, a `@media`-ban nagyobb.

## Ha középre kell a szöveg

```css
.hero { justify-content: center; text-align: center; }
```

## Gyakori hibák

- Rossz útvonal a CSS-ben: az `url()` a **CSS fájlhoz képest** értendő. Ha a CSS a `css/` mappában van: `url("../images/hero.png")`.
- `background-size: 100%` → torzít vagy nem tölt ki. A helyes: `cover`.

**Élesben:** [01_Galeria/style.css](../2_GYAKORLO_FELADATOK/01_Galeria/Megoldas/style.css) (2. rész)
