# 08 – Feltételes megjelenés: „ha nem elérhető…”

**Mikor kell?** „Ha az alkotás nem elérhető: a kép legyen szürkeárnyalatos, a gomb legyen inaktív, a gomb szövege: »Nem elérhető«”

## JS: a forEach-en belül 3 változó a feltétel alapján

```js
lista.forEach(function (mu) {
    // feltétel ? ha_igaz : ha_hamis
    const extraOsztaly = mu.available ? "" : "nem-elerheto";
    const tiltva       = mu.available ? "" : "disabled";
    const gombSzoveg   = mu.available ? "Érdekel" : "Nem elérhető";

    html += `
        <article class="mu-kartya ${extraOsztaly}">
            <img class="mu-kep" src="${mu.image}" alt="${mu.title}">
            ...
            <button class="erdekel" ${tiltva}>${gombSzoveg}</button>
        </article>`;
});
```

Ugyanez `if`-fel, ha az olvashatóbb:

```js
let gombSzoveg = "Érdekel";
if (mu.available === false) {
    gombSzoveg = "Nem elérhető";
}
```

## CSS

```css
.nem-elerheto .mu-kep {
    filter: grayscale(100%);          /* SZÜRKEÁRNYALATOS kép */
}

.erdekel:disabled {                   /* az inaktív gomb kinézete */
    background: #d1d5db;
    color: #374151;
    cursor: not-allowed;
}
```

> A `disabled` attribútumú gombra a böngésző **nem** enged kattintani: ez maga az „inaktív”.

## Más hasonló feladatok ugyanígy

| Feladat | Feltétel | Mit változtatsz |
|---|---|---|
| „ha nincs raktáron” | `t.keszlet === 0` | szürke, „Elfogyott” |
| „ha akciós, piros áthúzott régi ár” | `t.akcios` | plusz `<del>` elem, piros osztály |
| „ha új, »ÚJ« címke” | `t.ev === 2024` | plusz `<span class="cimke">ÚJ</span>` |

**Élesben:** [01_Galeria/galeria.js](../2_GYAKORLO_FELADATOK/01_Galeria/Megoldas/galeria.js), [style.css](../2_GYAKORLO_FELADATOK/01_Galeria/Megoldas/style.css) (4. rész vége)
