// =====================================================================
// FRONTEND PROGRAMOZÁS: a műalkotások kártyái + kategóriaszűrő
// Az adatok az artworks.js-ben vannak, az "artworks" nevű tömbben
// (a HTML-ben az artworks.js-t a galeria.js ELŐTT töltjük be, ezért itt már létezik).
// =====================================================================

const tarolo = document.getElementById("mualkotasok");          // ide kerülnek a kártyák
const szuroGombok = document.querySelectorAll(".szuro-gomb");   // az 5 szűrőgomb (lista)

// Kategória -> ikon (a kártyán a kategória neve elé)
const ikonok = {
    "Festmény": "images/icons/painting.png",
    "Szobor": "images/icons/statue.png",
    "Fotó": "images/icons/photograph.png",
    "Digitális művészet": "images/icons/digital.png"
};

// ---------------------------------------------------------------------
// 2. + 3. A kártyák megjelenítése egy listából (ezt a szűrő is újrahívja)
// ---------------------------------------------------------------------
function kartyakMegjelenitese(lista) {
    let html = "";                                  // ebbe gyűjtjük az összes kártya HTML-jét

    lista.forEach(function (mu) {                   // mu = egy műalkotás (egy objektum a tömbből)
        // 3. Ha NEM elérhető: plusz osztály (szürke kép a CSS-ben), inaktív gomb, más felirat
        const extraOsztaly = mu.available ? "" : "nem-elerheto";
        const tiltva = mu.available ? "" : "disabled";
        const gombSzoveg = mu.available ? "Érdekel" : "Nem elérhető";

        // Sablonszöveg (backtick ` jel: AltGr+7): a ${...} helyére az érték kerül
        html += `
            <article class="mu-kartya ${extraOsztaly}">
                <img class="mu-kep" src="${mu.image}" alt="${mu.title}">
                <div class="mu-adatok">
                    <h3>${mu.title}</h3>
                    <p>${mu.artist} | ${mu.year}</p>
                    <p class="mu-kategoria"><img src="${ikonok[mu.category]}" alt="">${mu.category}</p>
                    <p class="mu-ar">${mu.price}</p>
                    <button class="erdekel" ${tiltva}>${gombSzoveg}</button>
                </div>
            </article>`;
    });

    tarolo.innerHTML = html;                        // egyszerre betesszük az oldalba
}

// ---------------------------------------------------------------------
// 4. Kategóriaszűrő: minden gombra kattintás-figyelő
// ---------------------------------------------------------------------
szuroGombok.forEach(function (gomb) {
    gomb.addEventListener("click", function () {
        // a) az "aktiv" kiemelés átkerül a megnyomott gombra
        szuroGombok.forEach(function (g) {
            g.classList.remove("aktiv");
        });
        gomb.classList.add("aktiv");

        // b) melyik kategória? -> a gomb data-kategoria attribútuma
        const kategoria = gomb.dataset.kategoria;

        // c) szűrés: "Összes" -> minden; különben csak az egyező kategóriájúak
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

// Az oldal betöltésekor: az összes műalkotás
kartyakMegjelenitese(artworks);

// ---------------------------------------------------------------------
// (Extra, nem kötelező) "Érdekel" gomb: köszönő üzenet.
// Egy figyelő a tárolón -> az újrarajzolt kártyák gombjaira is működik.
// ---------------------------------------------------------------------
tarolo.addEventListener("click", function (esemeny) {
    if (esemeny.target.classList.contains("erdekel") && !esemeny.target.disabled) {
        alert("Köszönjük az érdeklődést! Hamarosan felvesszük Önnel a kapcsolatot.");
    }
});

// ---------------------------------------------------------------------
// MÁSIK MÓD: a JSON betöltése fetch-csel (CSAK webszerverrel, pl. VS Code Live Server!)
// Ilyenkor az artworks.js helyett az artworks.json kell, és a fenti
// "kartyakMegjelenitese(artworks);" sor helyett ez:
//
// let artworks = [];
// fetch("artworks.json")
//     .then(function (valasz) { return valasz.json(); })
//     .then(function (adatok) {
//         artworks = adatok;
//         kartyakMegjelenitese(artworks);
//     });
// ---------------------------------------------------------------------
