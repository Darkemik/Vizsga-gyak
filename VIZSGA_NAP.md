# Vizsganap – gyors átvezető

## 1. Reggel, indulás előtt

Aludj és egyél. Ha van időd: a nulláról induló [GUI/00_KEZDD_ITT.md](GUI/00_KEZDD_ITT.md), [WEB/00_KEZDD_ITT.md](WEB/00_KEZDD_ITT.md), [PHP/00_KEZDD_ITT.md](PHP/00_KEZDD_ITT.md) (kb. 25 perc / db), és a [01_AutokGUI/LEPESROL_LEPESRE.md](GUI/2_GYAKORLO_FELADATOK/01_AutokGUI/LEPESROL_LEPESRE.md).

## 2. A vizsga első 10 perce

1. **Kérdezd meg a felügyelőt:** „Megnyithatom a saját GitHub-repómat, csak olvasásra?” Ha nem engedi, ne nyisd meg (lásd a lap alján a 8 dolgot, amit fejben tarts).
2. Végezd el a kötelező beállításokat: belépés a Visual Studióba e-maillel, GitHub-fiók beállítása a VS-ben.
3. Böngészőben: github.com → belépés a **Darkemik** fiókkal (a repó privát) → **Vizsga-gyak**. Nyiss fület a kellő részekhez: [CLI/README.md](CLI/README.md), [GUI/README.md](GUI/README.md), [WEB/README.md](WEB/README.md), [PHP/README.md](PHP/README.md).
4. Olvasd át a **teljes feladatlapot** (5 perc). Nézd meg, melyik rész hány pontot ér, és számold ki: **összpontszám × 0,4 = ennyi kell a sikerhez.**
5. Nézd meg a FORRÁS mappát: milyen fájlokat kaptál.

> ⚠️ **Tilos:** AI-t kérdezni (Claude-ot sem!), a megoldást GitHubra menteni, bárkivel kommunikálni. Csak a **MEGOLDÁS** mappa tartalmát értékelik. Ments 5 percenként!

## 3. Sorrend és idő (240 perc)

| # | Rész | Idő | Miért |
|---|---|---|---|
| 1 | **CLI** | max. 50 perc | ez megy a legjobban, biztos pont |
| 2 | **API** | max. 60 perc | ezt is tudod |
| 3 | **GUI** | kb. 45 perc | már az ablak + a betöltés is részpontot ér |
| 4 | **WEB** / **PHP** | a maradék | WEB: navigáció + hero + kártyák gyorsan kimásolható; PHP: config.php + egy GET végpont szinte szó szerint kimásolható |
| – | ellenőrzés, mentés | utolsó 15 perc | |

- **5 perces szabály:** ha egy részfeladaton 5 percnél tovább állsz, lépj tovább, és a végén gyere vissza.
- Ha a lapon a WEB „weboldal” része sok pontot ér (pl. 10), csináld meg a GUI **előtt**: a gyorsindítóval kb. 20 perc.

## 4. CLI

1. Visual Studio → **Console App** → a kért név.
2. Adatfájl a projektbe → jobb klikk → Properties → **Copy to Output Directory: Copy if newer**.
3. Repóból: [CLI/0_GYORSINDITO](CLI/0_GYORSINDITO/) → az `Elem.cs` a saját osztályodba (átnevezés: Ctrl+R, Ctrl+R), a `Program.cs`-ből a kellő blokkok.
4. Nézd meg a fájl **első sorát**, és írd fel az indexeket: `0 = …, 1 = …`.
5. Minden feladatnál a [CLI keresőtábla](CLI/README.md) mondja meg, melyik blokk kell.
6. Figyelj: `5. feladat:` előtag a kiírásban; tizedes: `double.Parse(s.Replace(',', '.'), CultureInfo.InvariantCulture)`; kerekítés: `MidpointRounding.AwayFromZero`; holtverseny.
7. Ha ugyanaz az autós feladat, mint múltkor: [CLI/2_GYAKORLO_FELADATOK/01_Autok](CLI/2_GYAKORLO_FELADATOK/01_Autok/) (a valódi `carsData.csv`-vel).

## 5. API

Úgy, ahogy gyakoroltad. Ehhez nincs anyag ebben a repóban.

## 6. GUI

1. **Windows Forms App** (NEM a „.NET Framework” változat) → a kért név.
2. Osztály: jobb klikk a projekten → Add → Existing Item → a CLI-projekted osztályai → bennük a `namespace` átírása.
3. A projekt mappájában `forras` mappa, bele az adatfájl; a kódban: `"../../../forras/fajl.txt"`.
4. Designer: rajzold meg az ablakot a mintakép szerint, és minden vezérlőnek adj **(Name)**-et (`lbGyartok`, `btnKereses`…).
5. Kód: a konstruktorban `+=`-szal az események, a `Load`-ban beolvasás és feltöltés.
6. Lépésenként a [GUI/README.md](GUI/README.md) 6 lépése és keresőtáblája; a kód: [GUI/0_GYORSINDITO/Form1.cs](GUI/0_GYORSINDITO/Form1.cs) [A]–[K].
7. Ha ugyanaz az autós feladat: [01_AutokGUI/LEPESROL_LEPESRE.md](GUI/2_GYAKORLO_FELADATOK/01_AutokGUI/LEPESROL_LEPESRE.md), végig.
8. **F5 minden lépés után.**

## 7. WEB

1. VS Code → **File → Open Folder** → a web-feladat mappája.
2. **Weboldal rész:** a [WEB/0_GYORSINDITO](WEB/0_GYORSINDITO/)-ból `index.html`, `style.css`, `script.js` → írd át a szövegeket és a képeket (navigáció, hero, 3 kártya, `@media`).
3. **Frontend rész:** a JSON-ból `.js` (elé `const adatok = `, a végére `;`) → **nézd meg a képútvonalakat!** → kártyák (`forEach`) → „nem elérhető” → szűrő.
4. Ha ugyanaz a galéria: [01_Galeria/LEPESROL_LEPESRE.md](WEB/2_GYAKORLO_FELADATOK/01_Galeria/LEPESROL_LEPESRE.md).
5. Böngészőben: **F12 → Console** (hibák), **Ctrl+Shift+M** (mobilnézet).

## 7/b. PHP (ha van)

1. **XAMPP Control Panel** → Apache **Start**, MySQL **Start**.
2. **http://localhost/phpmyadmin** → **Importálás** → a kapott `.sql`. Nézd meg a táblák és oszlopok nevét.
3. A kapott projektmappát másold a **`C:\xampp\htdocs`**-ba; VS Code-ban nyisd meg.
4. **config.php**: a [gyorsindítóból](PHP/0_GYORSINDITO/konyvtar/config.php) másold, csak a `$dbname`-et írd át.
5. A kért végpontok (a fájlnevek **pontosan** a feladat szerint!): a [konyvek.php](PHP/0_GYORSINDITO/konyvtar/konyvek.php) [A]–[H] blokkjaiból, a táblák/oszlopok/JSON-kulcsok/üzenetek átírásával.
6. Próba: GET a böngészőben (`http://localhost/...`), a többi a kész frontenden vagy a `teszt.html`-lel.
7. Ha ugyanaz a Babszem: [01_Babszem/LEPESROL_LEPESRE.md](PHP/2_GYAKORLO_FELADATOK/01_Babszem/LEPESROL_LEPESRE.md).

## 8. Az utolsó 15 perc

- [ ] Minden a **MEGOLDÁS** mappában van: a CLI és a GUI **teljes** projektmappája (.sln, .csproj, .cs, adatfájl), a WEB teljes mappája (html, css, js, képek), a PHP projektmappa (a htdocs-ból kimásolva).
- [ ] Mindegyik elindul (F5 / dupla kattintás)?
- [ ] A kimeneti fájlok (pl. `forma-1.txt`) létrejönnek?
- [ ] Ne kezdj új nagy dologba, inkább javíts.

> Ami félig kész, az is pontot ér. Ami hibás, azt ne töröld, hanem kommenteld ki (Ctrl+K, Ctrl+C).

## Ha nem nyithatod meg a repót: ezt a 9 dolgot tartsd fejben

1. CLI adatfájl: **Copy if newer**, és `.Skip(1)` a fejléc miatt.
2. Tizedes: `double.Parse(s.Replace(',', '.'), CultureInfo.InvariantCulture)`.
3. Kerekítés: `Math.Round(x, 2, MidpointRounding.AwayFromZero)`.
4. GUI adatfájl: `"../../../forras/fajl.txt"`.
5. GUI: mindig `if (lista.SelectedItem == null) return;`, és objektumot tegyél a ListBoxba, nem indexet használj.
6. GUI: `MessageBox.Show(szöveg, cím, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes`, fájlba: `new StreamWriter(fajl, true)`.
7. WEB: `<meta name="viewport" ...>` és `<meta charset="UTF-8">`; a JSON-t tedd `.js`-be (`const adatok = [...]`), mert a `fetch` szerver nélkül nem megy.
8. WEB: mobile-first: alap = 1 oszlop, `@media (min-width: 768px)` = 2, `@media (min-width: 1024px)` = 3–4.
9. PHP: `<?php` → `require_once "config.php";` → `header("Content-Type: application/json; charset=utf-8");` → `$pdo->prepare("SELECT ... WHERE id = :id")` → `execute([":id" => $id])` → `echo json_encode($eredmeny, JSON_UNESCAPED_UNICODE);`

**Sok sikert!**
