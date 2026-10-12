# 01 – HTML szerkezet

**Mikor kell?** Mindig, az elején. „Készítsd el a … kezdőoldalát.”

## A váz (VS Code-ban: `!` + Enter, utána javítsd a `lang`-ot és a címet)

```html
<!DOCTYPE html>
<html lang="hu">
<head>
    <meta charset="UTF-8">                                                    <!-- ékezetek -->
    <meta name="viewport" content="width=device-width, initial-scale=1.0">   <!-- mobil! -->
    <title>ArtGallery – Kezdőlap</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
    <header> ... navigáció ... </header>
    <main>
        <section class="hero"> ... </section>
        <section class="info"> ... </section>
    </main>
    <footer> ... </footer>                                                    <!-- ha kéri -->
    <script src="script.js"></script>
</body>
</html>
```

## A leggyakoribb elemek

| Elem | Mire | Példa |
|---|---|---|
| `<header>`, `<nav>`, `<main>`, `<section>`, `<footer>` | az oldal nagy részei | |
| `<div>` | általános doboz (kártya, csoport) | `<div class="kartya">` |
| `<h1>`…`<h3>` | címek (h1 oldalanként egy) | `<h1>Fedezd fel…</h1>` |
| `<p>` | bekezdés | `<p>Kortárs alkotások…</p>` |
| `<a href="">` | link (menüpont, gomb-link) | `<a href="kiallitasok.html">` |
| `<img src="" alt="">` | kép | `<img src="images/logo.png" alt="ArtGallery">` |
| `<button>` | gomb (JS-hez) | `<button class="gomb">Érdekel</button>` |
| `<ul>` + `<li>` | lista (menü!) | `<ul class="menu"><li>…</li></ul>` |
| `<span>` | szövegrész (pl. másik színnel) | `Art<span>Gallery</span>` |

## Link vagy gomb?

- Másik oldalra visz → `<a href="kiallitasok.html" class="gomb">Kiállítások megtekintése</a>` (CSS-sel gombnak látszik)
- JS-sel csinál valamit → `<button>`

## Gyakori hibák

- Lezáratlan elem (`<div>` nyitva marad) → szétesik az elrendezés. A VS Code jelöli a párját, ha a nyitó tagre kattintasz.
- `src="Images/Logo.png"` vs. a valódi `images/logo.png`: a **kis/nagybetű számít** (a szerveren biztosan).

**Élesben:** [01_Galeria/index.html](../2_GYAKORLO_FELADATOK/01_Galeria/Megoldas/index.html)
