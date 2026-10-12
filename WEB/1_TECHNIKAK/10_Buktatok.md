# 10 – Buktatók (WEB)

**Első lépés MINDEN hibánál:** böngészőben **F12 → Console**. A piros sor megmondja, mi a baj, és melyik sorban.

## 1. Nem jelenik meg semmi a JSON-ból

| Console üzenet | Ok | Megoldás |
|---|---|---|
| `URL scheme "file" is not supported` / `Failed to fetch` / `blocked by CORS policy` | `fetch` dupla kattintással megnyitott oldalon | Live Server, vagy JS-változó ([06](06_JSON_betoltes.md) A) módszer |
| `artworks is not defined` | az `artworks.js` nincs betöltve, vagy a te JS-ed UTÁN jön | `<script src="artworks.js">` a te scripted ELÉ |
| `Unexpected token` | elrontott JSON/JS (hiányzó vessző, `;`) | nézd meg a jelzett sort |
| `Cannot read properties of null` | a JS nem találja az elemet (`getElementById`) | egyezik-e az `id`? a `<script>` a `</body>` előtt van? |

## 2. Hiányzó képek (törött kép ikon)

- Rossz útvonal → F12 → **Network** fül, vagy Console: `404 (Not Found)`.
- A Galéria JSON-jában az útvonalak **szándékosan rosszak** voltak → javítani kell.
- Kis/nagybetű: `images/Hero.png` ≠ `images/hero.png`.
- A CSS-ben az `url()` a **CSS fájlhoz képest** értendő (`css/style.css` → `url("../images/hero.png")`).

## 3. Mobilon nem reszponzív (kicsinyített asztali oldal)

Hiányzik a `<head>`-ből:

```html
<meta name="viewport" content="width=device-width, initial-scale=1.0">
```

## 4. Ékezetek helyett furcsa jelek (Ã©)

Hiányzik: `<meta charset="UTF-8">`, vagy a fájl nem UTF-8-ként van mentve (VS Code jobb alsó sarok → UTF-8).

## 5. A @media nem hat

- Mobile-first-nél `min-width`, **növekvő** sorrendben (768, utána 1024). Ha fordítva írod, a későbbi felülírja a korábbit.
- A `@media` blokk a fájl **végén** legyen, az alap szabályok után.
- Elgépelt osztálynév a `@media`-n belül.

## 6. A hamburger nem nyit

- A `.menu.nyitva { display: block; }` szabály hiányzik, vagy egy későbbi szabály felülírja.
- A gomb `id`-ja nem egyezik a JS-ben keresettel.

## 7. A szűrő nem talál semmit

A gomb `data-kategoria` értéke nem egyezik **betűre** a JSON `category` értékével (`"Foto"` ≠ `"Fotó"`).

## 8. A kártyák nem egyforma magasak

Fix képmagasság (`height` + `object-fit: cover`), a kártya `display: flex; flex-direction: column;`, a gomb `margin-top: auto;`.

## 9. A változtatás nem látszik

Mentetted (Ctrl+S)? Frissítettél (F5)? Ha a CSS makacs: **Ctrl+F5** (kemény frissítés).

## 10. Leadás

A **teljes mappát** add le (html, css, js, images), ne csak az index.html-t!
