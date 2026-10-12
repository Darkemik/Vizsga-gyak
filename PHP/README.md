# PHP – Backend (PHP + MySQL, XAMPP)

> ⭐ **Ha a nulláról indulsz, KEZDD ITT: [00_KEZDD_ITT.md](00_KEZDD_ITT.md)**: hogyan olvasd a végpont-táblázatot és a mintaválaszt, hány és milyen nevű fájlt kell írni, és az első PHP-fájlod 10 perc alatt.
> Utána: [0_ALAPOK_KEZDOKNEK.md](0_ALAPOK_KEZDOKNEK.md) (PHP vs. C#, státuszkódok, 10 perc).

## Mennyit ér, és hol a legolcsóbb pont?

A tanárotok Babszem-mintájában a PHP **15 pont**. Részpontok számítanak!

| Ha ennyi időd van… | Ezt csináld | Kb. pont |
|---|---|---|
| 15 perc | XAMPP indítás + SQL importálás + mappa a htdocs-ba + **config.php** + **kategoriak.php** (másolva) | 2 |
| +15 perc | **GET lista** és **GET ?id=** (404-gyel), fejléc, 405 | +6–7 |
| +15 perc | **POST** (új elem, ellenőrzések) | +3 |
| +10 perc | **PATCH** és **DELETE** | +3 |

> A config.php és egy egyszerű GET végpont szinte szó szerint kimásolható. **Ezt mindenképp csináld meg.**

## A PHP-rész lépésről lépésre

| # | Lépés | Tipikus feladatszöveg | Hol a kód |
|---|---|---|---|
| 0 | **Előkészítés** | „Indítsa el a XAMPP-ban az Apache és a MySQL szolgáltatást… importálja… másolja a htdocs mappába” | [01](1_TECHNIKAK/01_XAMPP_elokeszites.md) |
| 1 | **config.php** | „hozzon létre PDO kapcsolatot … utf8mb4 … ERRMODE_EXCEPTION … require_once” | [03](1_TECHNIKAK/03_Kapcsolat_config_PDO.md), gyorsindító **[A]** |
| 2 | **GET lista** | „GET kérésre adja vissza az összes …-t név szerint rendezve” | [04](1_TECHNIKAK/04_Lekerdezes_JSON_valasz.md), **[C]** |
| 3 | **GET ?id=** | „?id=N: egyetlen … objektumként … ha nincs: 404 … előkészített lekérdezéssel” | [05](1_TECHNIKAK/05_GET_parameter_404.md), **[D]** |
| 4 | **JOIN** | „kapcsolja össze a táblákat”, „a kategóriái egy tömbben” | [06](1_TECHNIKAK/06_JOIN_csoportositas.md) |
| 5 | **POST** | „új … felvétele a kérés törzsében érkező JSON alapján … ellenőrzések … 201” | [07](1_TECHNIKAK/07_POST_PATCH_DELETE.md), **[E]** |
| 6 | **PATCH / DELETE** | „… módosítása”, „… törlése”, „hiányzó azonosító: 400”, „nem létező: 404” | [07](1_TECHNIKAK/07_POST_PATCH_DELETE.md), **[F] [G]** |
| 7 | **405 + fejléc** | „Content-Type: application/json; charset=utf-8”, „egyéb metódusra 405” | [04](1_TECHNIKAK/04_Lekerdezes_JSON_valasz.md), **[H]** |

---

## KERESŐTÁBLA: mit kér a feladat → hol a kód

| Ha ezt kéri a feladat… | Mit használsz | Technika |
|---|---|---|
| „PDO kapcsolat”, „utf8mb4”, „kivételt dobjon” | `new PDO("mysql:...;charset=utf8mb4", ...)` + `ERRMODE_EXCEPTION` | [03](1_TECHNIKAK/03_Kapcsolat_config_PDO.md) |
| „a többi fájl ezt töltse be” | `require_once "config.php";` | [03](1_TECHNIKAK/03_Kapcsolat_config_PDO.md) |
| „JSON formátumú válasz”, „Content-Type …” | `header(...)` + `echo json_encode(...)` | [04](1_TECHNIKAK/04_Lekerdezes_JSON_valasz.md) |
| „név szerint rendezve” | `ORDER BY name` | [04](1_TECHNIKAK/04_Lekerdezes_JSON_valasz.md), [08](1_TECHNIKAK/08_SQL_puska.md) |
| „számként (ne szövegként)” | `(int)$sor["id"]` | [04](1_TECHNIKAK/04_Lekerdezes_JSON_valasz.md) |
| „más metódusra 405” | `if ($_SERVER["REQUEST_METHOD"] !== "GET")` → `http_response_code(405)` | [04](1_TECHNIKAK/04_Lekerdezes_JSON_valasz.md) |
| „?id=N”, „paraméter” | `$_GET["id"]`, `isset(...)` | [05](1_TECHNIKAK/05_GET_parameter_404.md) |
| „előkészített lekérdezés”, „prepared statement” | `$pdo->prepare("... WHERE id = :id")` + `execute([":id" => $id])` | [05](1_TECHNIKAK/05_GET_parameter_404.md) |
| „ha nincs ilyen: 404” | `fetch()` → `false` → `http_response_code(404)` | [05](1_TECHNIKAK/05_GET_parameter_404.md) |
| „elhagyható szűrő”, „keresett szöveg szerepel” | `WHERE 1 = 1` + `AND ... LIKE :keres` | [05](1_TECHNIKAK/05_GET_parameter_404.md) |
| „kapcsolja össze a táblákat”, „LEFT JOIN” | `JOIN` / `LEFT JOIN ... ON ...` | [06](1_TECHNIKAK/06_JOIN_csoportositas.md) |
| „a kategóriái egy tömbben”, „termékenként csoportosítsa” | tömb id szerinti kulccsal + `array_values` | [06](1_TECHNIKAK/06_JOIN_csoportositas.md) |
| „hány … tartozik hozzá” (pl. productCount) | `COUNT(...)` + `GROUP BY` | [06](1_TECHNIKAK/06_JOIN_csoportositas.md) |
| „a kérés törzsében érkező JSON” | `json_decode(file_get_contents("php://input"), true)` | [07](1_TECHNIKAK/07_POST_PATCH_DELETE.md) |
| „ellenőrzések … 400 … az első hibát” | `if (...) { valasz(400, [...]); }` sorban | [07](1_TECHNIKAK/07_POST_PATCH_DELETE.md) |
| „201 és az új azonosító” | `INSERT` + `$pdo->lastInsertId()` | [07](1_TECHNIKAK/07_POST_PATCH_DELETE.md) |
| „tranzakcióban” | `beginTransaction()` / `commit()` / `rollBack()` | [07](1_TECHNIKAK/07_POST_PATCH_DELETE.md) |
| „előbb a kapcsolótábla sorait kell törölni” | két `DELETE`, sorrendben | [07](1_TECHNIKAK/07_POST_PATCH_DELETE.md) |
| SQL: SELECT, WHERE, JOIN, GROUP BY, INSERT, UPDATE, DELETE | | [08](1_TECHNIKAK/08_SQL_puska.md) |
| Hiba: a kódot látod, „Access denied”, „Unknown database”, „headers already sent”… | | [09](1_TECHNIKAK/09_Teszteles_es_buktatok.md) |

---

## A mappák

| Mappa | Mi van benne | Mikor nyisd meg |
|---|---|---|
| [00_KEZDD_ITT.md](00_KEZDD_ITT.md) | **a nulláról**: végpont-táblázat és mintaválasz olvasása, első PHP-fájl | **legelőször** |
| [0_ALAPOK_KEZDOKNEK.md](0_ALAPOK_KEZDOKNEK.md) | mi a PHP, XAMPP, metódusok, státuszkódok, PHP vs. C# | utána |
| [0_GYORSINDITO](0_GYORSINDITO/) | működő mini-backend (könyvtár): `config.php`, `szerzok.php`, `konyvek.php` [A]–[H], `teszt.html` | vizsgán, ebből másolsz |
| [1_TECHNIKAK](1_TECHNIKAK/) | 9 rövid fájl, mindegyik egy dolog | ha egy konkrét dolog kell |
| [2_GYAKORLO_FELADATOK/01_Babszem](2_GYAKORLO_FELADATOK/01_Babszem/) | **a tanárotok Babszem PHP-feladatának teljes megoldása**, soronként kommentezve | gyakorláshoz |

> Minden végpontot valódi MariaDB adatbázissal és PHP 8.3-mal kipróbáltam: a válaszok egyeznek a feladatlap mintáival.
