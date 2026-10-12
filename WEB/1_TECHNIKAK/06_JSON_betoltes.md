# 06 – Az adatok (JSON) betöltése

**Mikor kell?** „Készítsd elő feldolgozásra a projekt mappájában található artworks.json fájlt”, „jelenítsd meg … adatforrásból”

## 1. lépés mindig: nézd meg a JSON-t!

- Milyen **mezők** vannak? (`title`, `artist`, `year`, `category`, `price`, `image`, `available`)
- Jók-e a **képútvonalak**? ⚠️ A Galéria-mintában NEM voltak jók (`images/varosi-fenyek.jpg` nem létezik, a valódi: `images/card_images/city_lights.png`). VS Code-ban **Ctrl+H** a cseréhez.
- Tömb (`[ ... ]`) vagy objektum benne egy tömbbel (`{ "artworks": [ ... ] }`)?

## A) módszer – JS-változó (AJÁNLOTT: szerver nélkül is működik)

1. Másold le a `artworks.json`-t **`artworks.js`** néven.
2. Az elejére: `const artworks = ` , a végére: `;`

```js
const artworks = [
  { "id": 1, "title": "Városi fények", "image": "images/card_images/city_lights.png", "available": true },
  ...
];
```

3. A HTML-ben a te JS-ed **ELŐTT** töltsd be:

```html
<script src="artworks.js"></script>
<script src="galeria.js"></script>      <!-- itt már használhatod: artworks -->
```

✅ Dupla kattintással megnyitva is működik.

## B) módszer – fetch (CSAK webszerverrel: VS Code → jobb klikk → Open with Live Server)

```js
let artworks = [];

fetch("artworks.json")
    .then(function (valasz) {
        return valasz.json();               // a szövegből JS-tömb lesz
    })
    .then(function (adatok) {
        artworks = adatok;                  // eltesszük, hogy a szűrő is lássa
        kartyakMegjelenitese(artworks);     // CSAK itt belül vannak meg az adatok!
    })
    .catch(function (hiba) {
        console.log("Nem sikerült betölteni:", hiba);
    });
```

⚠️ Ha dupla kattintással nyitod meg (`file://...`), nem jelenik meg semmi, és a Console-ban (Chrome) ez áll:
**`Fetch API cannot load file:///…/artworks.json. URL scheme "file" is not supported.`** és **`TypeError: Failed to fetch`**
(más böngészőben: `blocked by CORS policy`). Ilyenkor Live Server kell, vagy az A) módszer. *(Kipróbálva: `file://`-ról hiba, `http://localhost`-ról mind a 12 elem betöltődik.)*

⚠️ A `fetch` **aszinkron**: a `.then` UTÁNI sorokban még nincsenek meg az adatok. Mindent, ami az adatokat használja, a `.then`-en belül indíts el.

## Ha a JSON objektum, nem tömb

```json
{ "artworks": [ ... ] }
```

```js
const tomb = adatok.artworks;     // a tömb a kulcs alatt van
```

**Élesben:** [01_Galeria/artworks.js](../2_GYAKORLO_FELADATOK/01_Galeria/Megoldas/artworks.js), és a `fetch`-es változat a [galeria.js](../2_GYAKORLO_FELADATOK/01_Galeria/Megoldas/galeria.js) végén, kommentben
