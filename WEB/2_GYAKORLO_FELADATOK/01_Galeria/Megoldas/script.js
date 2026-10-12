// =====================================================================
// HAMBURGER MENÜ (mindkét oldal használja)
// Kattintásra a menühöz hozzáadjuk / elvesszük a "nyitva" osztályt.
// Hogy mi történik "nyitva" állapotban (megjelenik a menü), azt a CSS mondja meg.
// =====================================================================
const hamburger = document.getElementById("hamburger");   // a ☰ gomb
const menu = document.getElementById("menu");             // a <ul> menü

hamburger.addEventListener("click", function () {
    menu.classList.toggle("nyitva");                       // toggle = ha van, elveszi; ha nincs, hozzáadja

    // A gomb jele: nyitva ✕, zárva ☰
    if (menu.classList.contains("nyitva")) {
        hamburger.textContent = "✕";
    } else {
        hamburger.textContent = "☰";
    }
});
