# 09 – Kategóriaszűrő gombokkal

**Mikor kell?** „Készíts kategóriaszűrőt: Összes, Festmény, Szobor, Fotó, Digitális művészet”

## HTML: minden gomb „tudja” a saját kategóriáját (data-kategoria)

```html
<div class="szuro">
    <button class="szuro-gomb aktiv" data-kategoria="Összes">Összes</button>
    <button class="szuro-gomb" data-kategoria="Festmény">Festmény</button>
    <button class="szuro-gomb" data-kategoria="Szobor">Szobor</button>
    <button class="szuro-gomb" data-kategoria="Fotó">Fotó</button>
    <button class="szuro-gomb" data-kategoria="Digitális művészet">Digitális művészet</button>
</div>
```

> A `data-kategoria` értéke **betűre** egyezzen a JSON `category` értékével (ékezet, kis/nagybetű, szóköz)!

## JS

```js
const szuroGombok = document.querySelectorAll(".szuro-gomb");   // MINDEN szűrőgomb

szuroGombok.forEach(function (gomb) {
    gomb.addEventListener("click", function () {

        // 1. kiemelés: mindről le, a megnyomottra fel
        szuroGombok.forEach(function (g) { g.classList.remove("aktiv"); });
        gomb.classList.add("aktiv");

        // 2. melyik kategória? (data-kategoria -> dataset.kategoria)
        const kategoria = gomb.dataset.kategoria;

        // 3. szűrés és újrarajzolás
        if (kategoria === "Összes") {
            kartyakMegjelenitese(artworks);
        } else {
            const szurt = artworks.filter(function (mu) {
                return mu.category === kategoria;
            });
            kartyakMegjelenitese(szurt);
        }
    });
});
```

| Rész | Jelentés |
|---|---|
| `querySelectorAll(".szuro-gomb")` | az összes ilyen osztályú elem (lista) |
| `gomb.dataset.kategoria` | a `data-kategoria="..."` értéke |
| `artworks.filter(function (mu) { return feltétel; })` | új tömb csak azokkal, amelyekre a feltétel igaz |

## CSS: az aktív gomb kiemelése

```css
.szuro { display: flex; flex-wrap: wrap; gap: 10px; }
.szuro-gomb { padding: 8px 14px; border: 1px solid #ddd; background: #fff; border-radius: 6px; cursor: pointer; }
.szuro-gomb.aktiv, .szuro-gomb:hover { border-color: #c4661f; color: #c4661f; }
```

## Legördülő listával (ha select-et kér a feladat)

```html
<select id="kategoriaValaszto">
    <option value="Összes">Összes</option>
    <option value="Festmény">Festmény</option>
</select>
```

```js
document.getElementById("kategoriaValaszto").addEventListener("change", function () {
    const kategoria = this.value;
    // ... ugyanaz a szűrés, mint fent
});
```

## Keresés gépelésre (ha kéri)

```js
document.getElementById("kereso").addEventListener("input", function () {
    const minta = this.value.toLowerCase();
    kartyakMegjelenitese(artworks.filter(mu => mu.title.toLowerCase().includes(minta)));
});
```

**Élesben:** [01_Galeria/galeria.js](../2_GYAKORLO_FELADATOK/01_Galeria/Megoldas/galeria.js) (4. rész)
