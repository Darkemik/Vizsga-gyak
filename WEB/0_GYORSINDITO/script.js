// =====================================================================
// WEB GYORSINDÍTÓ – script.js
// =====================================================================

// ---------------------------------------------------------------------
// [B] HAMBURGER MENÜ: kattintásra a "nyitva" osztály ki-be kapcsol
// ---------------------------------------------------------------------
const hamburger = document.getElementById("hamburger");
const menu = document.getElementById("menu");

hamburger.addEventListener("click", function () {
    menu.classList.toggle("nyitva");
    hamburger.textContent = menu.classList.contains("nyitva") ? "✕" : "☰";
});


// ---------------------------------------------------------------------
// [G] KÁRTYÁK AZ ADATOKBÓL + feltételes megjelenés ("nem elérhető")
//     Az adatok az adatok.js-ben: const termekek = [...]
// ---------------------------------------------------------------------
const racs = document.getElementById("kartyaRacs");

function kartyakMegjelenitese(lista) {
    let html = "";

    lista.forEach(function (t) {                         // t = egy termék
        // feltétel ? ha_igaz : ha_hamis
        const extraOsztaly = t.elerheto ? "" : "nem-elerheto";
        const tiltva = t.elerheto ? "" : "disabled";
        const gombSzoveg = t.elerheto ? "Érdekel" : "Nem elérhető";

        // backtick ` (AltGr+7); ${...} = érték beillesztése
        html += `
            <article class="kartya ${extraOsztaly}">
                <img class="kartya-kep" src="${t.kep}" alt="${t.nev}">
                <div class="kartya-adatok">
                    <h3>${t.nev}</h3>
                    <p>${t.kategoria}</p>
                    <p class="ar">${t.ar}</p>
                    <button class="kartya-gomb" ${tiltva}>${gombSzoveg}</button>
                </div>
            </article>`;
    });

    racs.innerHTML = html;
}


// ---------------------------------------------------------------------
// [H] SZŰRŐ: gombok data-kategoria attribútummal
// ---------------------------------------------------------------------
const szuroGombok = document.querySelectorAll(".szuro-gomb");

szuroGombok.forEach(function (gomb) {
    gomb.addEventListener("click", function () {
        // kiemelés áthelyezése
        szuroGombok.forEach(function (g) { g.classList.remove("aktiv"); });
        gomb.classList.add("aktiv");

        // szűrés
        const kategoria = gomb.dataset.kategoria;
        if (kategoria === "Összes") {
            kartyakMegjelenitese(termekek);
        } else {
            kartyakMegjelenitese(termekek.filter(function (t) {
                return t.kategoria === kategoria;
            }));
        }
    });
});


// Indításkor az összes termék
kartyakMegjelenitese(termekek);


// ---------------------------------------------------------------------
// [F] MÁSIK MÓD: fetch (CSAK Live Serverrel!). Ekkor az adatok.js helyett:
//
// let termekek = [];
// fetch("adatok.json")
//     .then(function (valasz) { return valasz.json(); })
//     .then(function (adatok) {
//         termekek = adatok;
//         kartyakMegjelenitese(termekek);
//     });
// ---------------------------------------------------------------------
