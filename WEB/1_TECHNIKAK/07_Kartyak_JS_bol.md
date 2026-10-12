# 07 – Kártyák generálása JavaScriptből

**Mikor kell?** „Jelenítsd meg az alkotásokat kártyákon: kép, cím, művész neve, évszám, kategória, ár, gomb”

## HTML: egy üres tároló

```html
<div class="mualkotasok" id="mualkotasok"></div>
```

## JS

```js
const tarolo = document.getElementById("mualkotasok");

function kartyakMegjelenitese(lista) {
    let html = "";

    lista.forEach(function (mu) {               // mu = egy elem a tömbből
        html += `
            <article class="mu-kartya">
                <img class="mu-kep" src="${mu.image}" alt="${mu.title}">
                <div class="mu-adatok">
                    <h3>${mu.title}</h3>
                    <p>${mu.artist} | ${mu.year}</p>
                    <p>${mu.category}</p>
                    <p class="mu-ar">${mu.price}</p>
                    <button class="erdekel">Érdekel</button>
                </div>
            </article>`;
    });

    tarolo.innerHTML = html;                    // a régi tartalom helyére
}

kartyakMegjelenitese(artworks);                 // induláskor mindet
```

| Rész | Jelentés |
|---|---|
| `` `...` `` (backtick, **AltGr+7**) | sablonszöveg: több soros lehet, és beilleszthetők értékek |
| `${mu.title}` | ide a `mu` objektum `title` mezője kerül |
| `forEach(function (mu) { ... })` | a tömb minden elemére lefut egyszer |
| `innerHTML = html` | a tároló tartalmát lecseréli az elkészült HTML-re |

> A mezőnevek **pontosan** egyezzenek a JSON-nal (kis/nagybetű is!): `mu.title`, nem `mu.Title`.

## CSS: egységes kártyák

```css
.mu-kartya {
    display: flex;
    flex-direction: column;          /* egymás alatt: kép, adatok */
    border-radius: 8px;
    overflow: hidden;
    box-shadow: 0 4px 14px rgba(0, 0, 0, 0.12);
}
.mu-kep {
    width: 100%;
    height: 160px;                   /* MINDEN kép ugyanakkora */
    object-fit: cover;               /* kitölti, torzítás nélkül */
}
.mu-adatok {
    flex: 1;                         /* kitölti a kártya maradék magasságát */
    display: flex;
    flex-direction: column;
    padding: 12px;
}
.erdekel {
    margin-top: auto;                /* a gomb mindig a kártya ALJÁN */
}
```

> **Egységes méret:** a grid sorai egyforma magasra húzzák a kártyákat, a fix képmagasság és a `margin-top: auto` gomb pedig gondoskodik róla, hogy a belsejük is egy vonalban legyen.

## Másik mód: createElement (hosszabb, de ezt is tanítják)

```js
lista.forEach(function (mu) {
    const kartya = document.createElement("article");
    kartya.className = "mu-kartya";
    kartya.innerHTML = `<h3>${mu.title}</h3> ...`;
    tarolo.appendChild(kartya);
});
```

**Élesben:** [01_Galeria/galeria.js](../2_GYAKORLO_FELADATOK/01_Galeria/Megoldas/galeria.js)
