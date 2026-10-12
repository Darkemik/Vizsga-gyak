# 05 – Reszponzív, mobile-first

**Mikor kell?** „mobile-first approach”, „nagy képernyőn egymás mellett, közepes képernyőn két oszlopban, mobilnézetben egymás alatt”, „nagy képernyőn 4 oszlop, tableten 2, mobilon 1”

## A szabály

1. **Alap CSS = MOBIL.** Ide írsz mindent.
2. Utána **`@media (min-width: 768px)`** = tablettől: csak ami VÁLTOZIK.
3. Utána **`@media (min-width: 1024px)`** = asztalitól: csak ami VÁLTOZIK.

> `min-width` = „legalább ennyi”. Mobile-first-nél mindig `min-width`, növekvő sorrendben!

## Oszlopok gridrel (ez a leggyakoribb feladat)

```css
.kartyak {
    display: grid;
    grid-template-columns: 1fr;                  /* MOBIL: 1 oszlop */
    gap: 20px;
}

@media (min-width: 768px) {
    .kartyak { grid-template-columns: repeat(2, 1fr); }   /* TABLET: 2 oszlop */
}

@media (min-width: 1024px) {
    .kartyak { grid-template-columns: repeat(4, 1fr); }   /* ASZTALI: 4 oszlop (vagy 3) */
}
```

> `repeat(3, 1fr)` = 3 egyforma széles oszlop. `1fr` = „egy egység a maradék helyből”.

## Mi szokott még változni képernyőméret szerint?

| Mi | Mobil (alap) | Tablettől / asztalitól |
|---|---|---|
| menü | `display: none` + hamburger | `display: flex`, hamburger `display: none` |
| betűméret | `font-size: 2.2rem` | `3.2rem` / `4.2rem` |
| kártya belseje | `flex-direction: row` (ikon balra) | `flex-direction: column` (ikon fölül) |
| két hasáb (kép + szöveg) | `grid-template-columns: 1fr` | `1fr 1fr` |

## A viewport sor nélkül NEM működik

```html
<meta name="viewport" content="width=device-width, initial-scale=1.0">
```

## Kipróbálás

Böngészőben **F12 → Ctrl+Shift+M**, felül állítsd a szélességet: 390 (mobil), 800 (tablet), 1280 (asztali). Vagy egyszerűen húzd keskenyebbre az ablakot.

## Ha a feladat max-width-et használ (desktop-first)

Ugyanaz fordítva: alap = asztali, `@media (max-width: 1023px)` = tablet, `@media (max-width: 767px)` = mobil. De ha a feladat **mobile-first**-öt kér, a `min-width` a helyes.

**Élesben:** [01_Galeria/style.css](../2_GYAKORLO_FELADATOK/01_Galeria/Megoldas/style.css) (a fájl vége: a két `@media` blokk)
